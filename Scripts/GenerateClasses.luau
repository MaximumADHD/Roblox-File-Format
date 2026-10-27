--!nolint DeprecatedApi

local ReflectionService = game:GetService("ReflectionService")
local HttpService = game:GetService("HttpService")

local ALL_PERMS = SecurityCapabilities.new(
	table.unpack(Enum.SecurityCapability:GetEnumItems())
)

local BrickColors = {
	ById = {} :: { [number]: string },
	ByName = {} :: { [string]: string },
}

local MappedColors = {}

for id = 1, 1032 do
	local color = BrickColor.new(id)

	if color.Number ~= id then
		continue
	end

	local name = color.Name
	local enumName = name
		:gsub("[^A-z ]+", "")
		:gsub(" ", "_")
		:gsub("^_%l", string.upper)

	if MappedColors[enumName] then
		MappedColors[enumName] += 1
	else
		MappedColors[enumName] = 1
	end

	if MappedColors[enumName] > 1 then
		enumName = `{enumName}_{MappedColors[enumName]}`
	end

	MappedColors[enumName] = 1
	BrickColors.ById[id] = enumName
	BrickColors.ByName[name] = enumName
end

const LegacyFonts = {}

for _, font in Enum.Font:GetEnumItems() do
	if font ~= Enum.Font.Unknown then
		LegacyFonts[tostring(Font.fromEnum(font))] = font
	end
end

local Formatting = {}

const Vector2Constants = table.freeze({
	[Vector2.one] = "Vector2.one",
	[Vector2.zero] = "Vector2.zero",
	[Vector2.xAxis] = "Vector2.xAxis",
	[Vector2.yAxis] = "Vector2.yAxis",
})

const Vector3Constants = table.freeze({
	[Vector3.one] = "Vector3.one",
	[Vector3.zero] = "Vector3.zero",
	[Vector3.xAxis] = "Vector3.xAxis",
	[Vector3.yAxis] = "Vector3.yAxis",
	[Vector3.zAxis] = "Vector3.zAxis",
})

local function formatFlags(flagType: any, enum: Enum, dataType: string): string
	local items = {}

	for _, item in enum:GetEnumItems() do
		if flagType[item.Name] then
			table.insert(items, `{dataType}.{item.Name}`)
		end
	end

	return table.concat(items, " | ")
end

function Formatting.Null(value: any): string
	return ""
end

function Formatting.Bytes(value: string): string
	if #value > 0 then
		return string.format("Convert.FromBase64String(%q)", value)
	end

	return "Array.Empty<byte>()"
end

function Formatting.Bool(value: boolean?): string
	return if value then "true" else ""
end

function Formatting.String(value: string): string
	return string.format("%q", value)
end

function Formatting.Int(value: number): string
	if value == 2 ^ 31 - 1 then
		return "int.MaxValue"
	elseif value == -(2 ^ 31) then
		return "int.MinValue"
	end

	return string.format("%i", value)
end

function Formatting.Number(value: number): string
	local integer = math.floor(value)

	if math.abs(value - integer) < 0.001 then
		return Formatting.Int(integer)
	end

	return string.format("%.5f", value):gsub("%.?0+$", "")
end

function Formatting.Double(value: number): string
	local result = Formatting.Number(value)

	if result == "inf" then
		return "double.MaxValue"
	elseif result == "-inf" then
		return "double.MinValue"
	end

	return result
end

function Formatting.Float(value: number): string
	local result = Formatting.Number(value)

	if result == "inf" then
		return "float.MaxValue"
	elseif result == "-inf" then
		return "float.MinValue"
	elseif result:find("%.") then
		return result .. "f"
	end

	return result
end

function Formatting.Axes(value: Axes): string
	return formatFlags(value, Enum.Axis, "Axes")
end

function Formatting.Faces(value: Faces): string
	return formatFlags(value, Enum.NormalId, "Faces")
end

function Formatting.EnumItem(value: EnumItem): string
	return tostring(value.EnumType) .. "." .. value.Name
end

function Formatting.BrickColor(value: BrickColor): string
	local name = BrickColors.ById[value.Number]
	return name and ("BrickColorId." .. name) or "BrickColorId.White"
end

function Formatting.Color3(value: Color3): string
	if value == Color3.new() then
		return "new Color3()"
	end

	local r = Formatting.Float(value.R)
	local g = Formatting.Float(value.G)
	local b = Formatting.Float(value.B)
	local constructor = "new Color3"

	if string.find(r .. g .. b, "f") then
		r = Formatting.Int(value.R * 255)
		g = Formatting.Int(value.G * 255)
		b = Formatting.Int(value.B * 255)
		constructor = "Color3.FromRGB"
	end

	return string.format("%s(%s, %s, %s)", constructor, r, g, b)
end

function Formatting.UDim(value: UDim): string
	if value == UDim.new() then
		return "new UDim()"
	end

	return string.format("new UDim(%s, %s)", Formatting.Float(value.Scale), Formatting.Int(value.Offset))
end

function Formatting.Content(value: Content): string
	if value.SourceType == Enum.ContentSourceType.Uri then
		return string.format("new Content(%q)", assert(value.Uri))
	end

	return "Content.None"
end

function Formatting.UDim2(value: UDim2): string
	if value == UDim2.new() then
		return "new UDim2()"
	end
	
	return string.format("new UDim2(%s, %s, %s, %s)", Formatting.Float(value.X.Scale), Formatting.Int(value.X.Offset), Formatting.Float(value.Y.Scale), Formatting.Int(value.Y.Offset))
end

function Formatting.Vector2(value: Vector2): string
	for constant, name in pairs(Vector2Constants) do
		if value:FuzzyEq(constant) then
			return name
		end
	end

	if value.X == value.Y then
		return string.format("Vector2.one * %s", Formatting.Float(value.X))
	end

	return string.format("new Vector2(%s, %s)", Formatting.Float(value.X), Formatting.Float(value.Y))
end

function Formatting.Vector3(value: Vector3): string
	for constant, name in pairs(Vector3Constants) do
		if value:FuzzyEq(constant) then
			return name
		end
	end

	if value.X == value.Y and value.Y == value.Z then
		return string.format("Vector3.one * %s", Formatting.Float(value.X))
	end

	return string.format("new Vector3(%s, %s, %s)", Formatting.Float(value.X), Formatting.Float(value.Y), Formatting.Float(value.Z))
end

function Formatting.CFrame(value: CFrame): string
	if value == CFrame.identity then
		return "CFrame.identity"
	elseif value.Rotation == CFrame.identity then
		return string.format("new CFrame(%s, %s, %s)", Formatting.Float(value.X), Formatting.Float(value.Y), Formatting.Float(value.Z))
	end

	local components = { value:GetComponents() }
	local formatted = {}

	for index = 1, 12 do
		formatted[index] = Formatting.Float(components[index])
	end

	return "new CFrame(" .. table.concat(formatted, ", ") .. ")"
end

function Formatting.NumberRange(value: NumberRange): string
	local minimum = Formatting.Float(value.Min)
	local maximum = Formatting.Float(value.Max)

	if minimum == maximum then
		return string.format("new NumberRange(%s)", minimum)
	end

	return string.format("new NumberRange(%s, %s)", minimum, maximum)
end

function Formatting.Ray(value: Ray): string
	if value.Origin == Vector3.zero and value.Direction == Vector3.zero then
		return "new Ray()"
	end

	return string.format("new Ray(%s, %s)", Formatting.Vector3(value.Origin), Formatting.Vector3(value.Direction))
end

function Formatting.Rect(value: Rect): string
	if value.Min == Vector2.zero and value.Max == Vector2.zero then
		return "new Rect()"
	end

	return string.format("new Rect(%s, %s)", Formatting.Vector2(value.Min), Formatting.Vector2(value.Max))
end

function Formatting.ColorSequence(value: ColorSequence): string
	return "new ColorSequence(" .. tostring(value.Keypoints[1].Value) .. ")"
end

function Formatting.NumberSequence(value: NumberSequence): string
	return string.format("new NumberSequence(%s)", Formatting.Float(value.Keypoints[1].Value))
end

function Formatting.Vector3int16(value: Vector3int16): string
	if value == Vector3int16.new() then
		return "new Vector3int16()"
	end

	return string.format("new Vector3int16(%s, %s, %s)", Formatting.Int(value.X), Formatting.Int(value.Y), Formatting.Int(value.Z))
end

function Formatting.SharedString(value: string): string
	if value ~= "" then
		return string.format("SharedString.FromBase64(%q)", value)
	end

	return "SharedString.None"
end

function Formatting.PhysicalProperties(value: PhysicalProperties): string
	if value == nil then
		return "new PhysicalProperties()"
	end

	return string.format(
		"new PhysicalProperties(%s, %s, %s, %s, %s, %s)",
		Formatting.Float(value.Density),
		Formatting.Float(value.Friction),
		Formatting.Float(value.Elasticity),
		Formatting.Float(value.FrictionWeight),
		Formatting.Float(value.ElasticityWeight),
		Formatting.Float(value.AcousticAbsorption)
	)
end

function Formatting.FontFace(value: Font): string
	local legacyFont = LegacyFonts[tostring(value)]

	if legacyFont then
		return string.format("FontFace.FromEnum(Enums.Font.%s)", legacyFont.Name)
	end

	local args = { string.format("%q", value.Family) }

	if value.Style ~= Enum.FontStyle.Normal then
		table.insert(args, "FontStyle." .. value.Style.Name)
	end

	if #args > 1 or value.Weight ~= Enum.FontWeight.Regular then
		table.insert(args, "FontWeight." .. value.Weight.Name)
	end

	return "new FontFace(" .. table.concat(args, ", ") .. ")"
end

type GetSet = string | { Get: string, Set: string?, Flags: string? }
type Patch = { Redirect: { [string]: GetSet }?, Defaults: { [string]: any }? }

local function UseColor3(propName: string): GetSet
	return {
		Get = string.format("BrickColor.FromColor3(%s)", propName),
		Set = propName .. " = value?.Color",
	}
end

local function TryGetEnumItem(enumName: string, itemName: string): EnumItem?
	local success, item = pcall(function()
		return (Enum :: any)[enumName]:FromName(itemName)
	end)
	return if success then item else nil
end

local function GetBodyPart(bodyPart: Enum.BodyPart): GetSet
	return {
		Get = `Specials.GetBodyPart(this, BodyPart.{bodyPart.Name}).AssetId`,
		Set = `Specials.GetBodyPart(this, BodyPart.{bodyPart.Name}).AssetId = value`,
	}
end

local function GetBodyColor(bodyPart: Enum.BodyPart): GetSet
	return {
		Get = `Specials.GetBodyPart(this, BodyPart.{bodyPart.Name}).Color`,
		Set = `Specials.GetBodyPart(this, BodyPart.{bodyPart.Name}).Color = value`,
	}
end

local function ContentAssetId(propName: string): GetSet
	return {
		Get = propName .. ".AssetId",
		Set = propName .. " = new Content(value)",
	}
end

const GuiTextMixIn: Patch = {
	Redirect = {
		Font = { Get = "FontUtility.GetLegacyFont(FontFace)", Set = "FontUtility.TryGetFontFace(value, out FontFace)" },
		FontSize = { Get = "FontUtility.GetFontSize(TextSize)", Set = "TextSize = FontUtility.GetFontSize(value)" },
		TextColor = UseColor3("TextColor3"),
		TextWrap = "TextWrapped",
		Transparency = { Get = "base.Transparency", Set = "base.Transparency = value;\nTextTransparency  = value;", Flags = "new" },
	},
}

const PropertyPatches: { [string]: Patch } = {
	AnimationRigData = {
		Defaults = {
			name = "AQAAAAEAAAAAAAAA",
			label = "AQAAAAEAAAAAAAAA",
			parent = "AQAAAAEAAAAAAA==",

			transform = "AQAAAAEAAAAAAIA/AAAAAAAAAAAAAAAAAACAPwAAAAAAAAAAAAAAAAAAgD8AAAAAAAAAAAAAAAA=",
			preTransform = "AQAAAAEAAAAAAIA/AAAAAAAAAAAAAAAAAACAPwAAAAAAAAAAAAAAAAAAgD8AAAAAAAAAAAAAAAA=",
			postTransform = "AQAAAAEAAAAAAIA/AAAAAAAAAAAAAAAAAACAPwAAAAAAAAAAAAAAAAAAgD8AAAAAAAAAAAAAAAA=",

			weight = "AQAAAAAAAAA=",
		},
	},

	AudioSearchParams = {
		Redirect = {
			AudioSubtype = "AudioSubType",
		},
	},

	AudioPlayer = {
		Redirect = {
			Asset = "AudioContent",
			AssetId = "Asset",
		}
	},

	BallSocketConstraint = {
		-- Why does this even exist?
		Redirect = {
			MaxFrictionTorque = "MaxFrictionTorqueXml",
		},
	},

	BasePart = {
		Redirect = {
			Position = {
				Get = "CFrame.Position",
				Set = "CFrame = new CFrame(value) * CFrame.Rotation",
			},

			MaterialVariant = "MaterialVariantSerialized",
			BrickColor = UseColor3("Color"),
			Color = "Color3uint8",
			Size = "size",
		},

		Defaults = {
			Color3uint8 = Color3.fromRGB(163, 162, 165),
			MaterialVariantSerialized = "",
			size = Vector3.new(4, 1.2, 2),
		},
	},

	BodyColors = {
		Redirect = {
			HeadColor = UseColor3("HeadColor3"),
			LeftArmColor = UseColor3("LeftArmColor3"),
			RightArmColor = UseColor3("RightArmColor3"),
			LeftLegColor = UseColor3("LeftLegColor3"),
			RightLegColor = UseColor3("RightLegColor3"),
			TorsoColor = UseColor3("TorsoColor3"),
		},
	},

	BodyAngularVelocity = {
		Redirect = {
			angularvelocity = "AngularVelocity"
		},
	},

	BodyForce = {
		Redirect = {
			force = "Force",
		},
	},

	BodyGyro = {
		Redirect = {
			cframe = "CFrame",
			maxTorque = "MaxTorque",
		},
	},

	BodyPosition = {
		Redirect = {
			cframe = "CFrame",
			maxTorque = "MaxTorque",
		},
	},

	Camera = {
		Redirect = {
			CoordinateFrame = "CFrame"
		},
	},

	CharacterMesh = {
		Redirect = {
			MeshId = ContentAssetId("MeshContent"),
			BaseTextureId = ContentAssetId("BaseTextureContent"),
			OverlayTextureId = ContentAssetId("OverlayTextureContent"),
		},
	},
	
	DataStoreService = {
		Defaults = {
			AutomaticRetry = true,
			LegacyNamingScheme = false,
		},
	},

	DoubleConstrainedValue = {
		Redirect = {
			Value = "value",
			ConstrainedValue = "value",
		},
	},

	Fire = {
		Defaults = {
			heat_xml = 9,
			size_xml = 5,
		},

		Redirect = {
			Heat = "heat_xml",
			Size = "size_xml",
		},
	},

	FloatCurve = {
		Defaults = {
			ValuesAndTimes = "AAAAAAEAAAAKAAAAAAAAFkUAAAAA"
		},
	},

	FormFactorPart = {
		Defaults = {
			formFactorRaw = TryGetEnumItem("FormFactor", "Brick"),
		},

		Redirect = {
			FormFactor = "formFactorRaw",
		},
	},

	FunctionalTest = {
		Defaults = {
			HasMigratedSettingsToTestService = false
		},
	},

	GuiBase2d = {
		Redirect = {
			Localize = "AutoLocalize"
		},
	},

	GuiBase3d = {
		Redirect = {
			Color = UseColor3("Color3")
		},
	},

	GuiObject = {
		Redirect = {
			Transparency = "BackgroundTransparency",
			BackgroundColor = UseColor3("BackgroundColor3"),
			BorderColor = UseColor3("BorderColor3"),
		},
	},

	HttpService = {
		Defaults = {
			HttpEnabled = false
		},
	},

	Humanoid = {
		Defaults = {
			Health_XML = 100,
			InternalHeadScale = 1,
			InternalBodyScale = Vector3.one,
		},

		Redirect = {
			Health = "Health_XML",
		},
	},

	HumanoidDescription = {
		Defaults = {
			AccessoryBlob = "[]",
			EmotesDataInternal = "[]",
			EquippedEmotesDataInternal = "[]",
		},

		Redirect = {
			Head = GetBodyPart(Enum.BodyPart.Head),
			Torso = GetBodyPart(Enum.BodyPart.Torso),
			LeftArm = GetBodyPart(Enum.BodyPart.LeftArm),
			LeftLeg = GetBodyPart(Enum.BodyPart.LeftLeg),
			RightArm = GetBodyPart(Enum.BodyPart.RightArm),
			RightLeg = GetBodyPart(Enum.BodyPart.RightLeg),

			HeadColor = GetBodyColor(Enum.BodyPart.Head),
			TorsoColor = GetBodyColor(Enum.BodyPart.Torso),
			LeftArmColor = GetBodyColor(Enum.BodyPart.LeftArm),
			LeftLegColor = GetBodyColor(Enum.BodyPart.LeftLeg),
			RightArmColor = GetBodyColor(Enum.BodyPart.RightArm),
			RightLegColor = GetBodyColor(Enum.BodyPart.RightLeg),
		}
	},

	InsertService = {
		Defaults = {
			AllowClientInsertModels = false
		},
	},

	IntConstrainedValue = {
		Redirect = {
			Value = "value",
			ConstrainedValue = "value",
		},
	},

	JointInstance = {
		Redirect = {
			part1 = "Part1"
		}
	},

	Lighting = {
		Defaults = {
			Technology = TryGetEnumItem("Technology", "Compatibility"),
		},
	},

	LocalizationTable = {
		Defaults = {
			Contents = "[]"
		},

		Redirect = {
			DevelopmentLanguage = "SourceLocaleId",
		},
	},

	MarkerCurve = {
		Defaults = {
			ValuesAndTimes = "AAAAAAEAAAAKAAAAAAAAFkUAAAAA"
		},
	},

	MaterialService = {
		Redirect = {
			Use2022Materials = "Use2022MaterialsXml"
		},
	},

	Model = {
		Defaults = {
			ScaleFactor = 1
		},
	},

	PackageLink = {
		Defaults = {
			AutoUpdate = false
		},

		Redirect = {
			PackageIdSerialize = "PackageContentSerialize",
		}
	},

	Part = {
		Redirect = {
			Shape = "shape"
		},
	},

	ParticleEmitter = {
		Redirect = {
			VelocitySpread = {
				Get = "SpreadAngle.X",
				Set = "SpreadAngle = new Vector2(value, value)",
			},
		},
	},

	PartOperation = {
		Defaults = {
			FormFactor = Enum.FormFactor.Custom
		},
	},

	Players = {
		Defaults = {
			MaxPlayersInternal = 16
		},
	},

	PolicyService = {
		Defaults = {
			IsLuobuServer = TryGetEnumItem("TriStateBoolean", "Unknown"),
			LuobuWhitelisted = TryGetEnumItem("TriStateBoolean", "Unknown"),
		},
	},

	RotationCurve = {
		Defaults = {
			ValuesAndTimes = "AAAAAAEAAAAKAAAAAAAAFkUAAAAA"
		},
	},

	SelectionBox = {
		Redirect = {
			SurfaceColor = UseColor3("SurfaceColor3")
		},
	},

	SelectionSphere = {
		Redirect = {
			SurfaceColor = UseColor3("SurfaceColor3")
		},
	},

	ServerScriptService = {
		Defaults = {
			LoadStringEnabled = false
		},
	},

	ShirtGraphic = {
		Redirect = {
			Graphic = "TextureContent",
		},
	},

	Sky = {
		Redirect = {
			SkyboxBk = "SkyboxBackContent",
			SkyboxDn = "SkyboxDownContent",
			SkyboxFt = "SkyboxFrontContent",
			SkyboxLf = "SkyboxLeftContent",
			SkyboxRt = "SkyboxRightContent",
			SkyboxUp = "SkyboxUpContent",
		}
	},

	Smoke = {
		Defaults = {
			size_xml = 1,
			opacity_xml = 0.5,
			riseVelocity_xml = 1,
		},

		Redirect = {
			Size = "size_xml",
			Opacity = "opacity_xml",
			RiseVelocity = "riseVelocity_xml",
		},
	},

	Sound = {
		Redirect = {
			Pitch = "PlaybackSpeed",
			SoundId = "AudioContent",
			MinDistance = "RollOffMinDistance",
			MaxDistance = "RollOffMaxDistance",
			xmlRead_MinDistance_3 = "RollOffMinDistance",
			xmlRead_MaxDistance_3 = "RollOffMaxDistance",
		},
	},

	Sparkles = {
		Redirect = {
			Color = "SparkleColor"
		},
	},

	StarterPlayer = {
		Defaults = {
			GameSettingsAvatar = Enum.GameAvatarType.R15,
			GameSettingsR15Collision = Enum.R15CollisionType.OuterBox,
			LoadCharacterLayeredClothing = Enum.LoadCharacterLayeredClothing.Default,

			GameSettingsScaleRangeHead = NumberRange.new(0.95, 1.00),
			GameSettingsScaleRangeWidth = NumberRange.new(0.70, 1.00),
			GameSettingsScaleRangeHeight = NumberRange.new(0.90, 1.05),
			GameSettingsScaleRangeBodyType = NumberRange.new(0.00, 1.00),
			GameSettingsScaleRangeProportion = NumberRange.new(0.00, 1.00),
		},
	},

	SurfaceAppearance = {
		Defaults = {
			AlphaMode = Enum.AlphaMode.Overlay
		},
	},

	Terrain = {
		Defaults = {
			Decoration = false,
			SmoothGrid = "AQU=",
			PhysicsGrid = "AgMAAAAAAAAAAAAAAAA=",
			AcquisitionMethod = TryGetEnumItem("TerrainAcquisitionMethod", "None"),
			MaterialColors = "AAAAAAAAan8/P39rf2Y/ilY+j35fi21PZmxvZbDqw8faiVpHOi4kHh4lZlw76JxKc3trhHtagcLgc4RKxr21zq2UlJSM",
		},
	},

	TerrainRegion = {
		Defaults = {
			ExtentsMax = Vector3int16.new(),
			ExtentsMin = Vector3int16.new(),

			GridV3 = "",
			SmoothGrid = "AQU=",
		},
	},

	TextBox = GuiTextMixIn,
	TextLabel = GuiTextMixIn,
	TextButton = GuiTextMixIn,

	TextChatService = {
		Defaults = {
			CreateDefaultCommands = true,
			CreateDefaultTextChannels = true,
		},
	},

	TriangleMeshPart = {
		Defaults = {
			InitialSize = Vector3.new(1, 1, 1),
			PhysicalConfigData = "1B2M2Y8AsgTpgAmY7PhCfg==",
		},
	},

	TrussPart = {
		Redirect = {
			Style = "style"
		},
	},

	UnvalidatedAssetService = {
		Defaults = {
			CachedData = HttpService:JSONEncode({
				users = {},
				lastSaveTime = 0,
				lastKnownPublishRequest = 0,
			}),
		},
	},

	UserInputService = {
		Defaults = {
			LegacyInputEventsEnabled = true,
		}
	},

	ViewportFrame = {
		Defaults = {
			CameraCFrame = CFrame.identity,
			CameraFieldOfView = 70,
		},
	},

	WeldConstraint = {
		Defaults = {
			CFrame0 = CFrame.identity,
			State = 3,

			Part0 = Instance.new("Part"),
			Part1 = Instance.new("Part"),
		},

		Redirect = {
			Part0 = "Part0Internal",
			Part1 = "Part1Internal",
		},
	},

	Workspace = {
		Defaults = {
			CollisionGroupData = "AQEABP////8HRGVmYXVsdA==",

			TouchesUseCollisionGroups = false,
			ExplicitAutoJoints = true,
			TerrainWeldsFixed = true,

			StreamingMinRadius = 64,
			StreamingTargetRadius = 1024,
		},
	},

	WrapLayer = {
		Redirect = {
			TemporaryReferenceId = "TemporaryReferenceMeshContent",
		}
	}
}

const NON_ROOTED_SERVICES = {
	Lighting = true,
	SoundService = true,
	Teams = true,
}

const FORCE_REGISTER = {
	ChatInputBarConfiguration = true,
	ChatWindowConfiguration = true,
	ChannelSelectorSoundEffect = true,
	CustomSoundEffect = true,
	MetaBreakpoint = true,
	MetaBreakpointContext = true,
	PackageLink = true,
	RobloxSerializableInstance = true,
	ScriptDebugger = true,
}

const ENGINE_TYPE_MAP = {
	bool = "bool",
	int = "int",
	int64 = "long",
	float = "float",
	Font = "FontFace",
	double = "double",
	string = "string",
	ContentId = "ContentId",
	UniqueId = "UniqueId",
	Content = "Content",
	BinaryString = "byte[]",
	Color3uint8 = "Color3uint8",
	SharedString = "SharedString",
	ProtectedString = "ProtectedString",
	OptionalCoordinateFrame = "CFrame",
	PhysicalProperties = "PhysicalProperties",
}

const VALUE_TYPES = {
	SecurityCapabilities = true,
	Color3uint8 = true,
	ContentId = true,
	UniqueId = true,
}

const FORMAT_TYPE_MAP = {
	bool = "Bool",
	int = "Int",
	long = "Int",
	float = "Float",
	double = "Double",
	string = "String",
	ContentId = "String",
	["byte[]"] = "Bytes",
	EnumItem = "EnumItem",
	ProtectedString = "String",
}

const CSHARP_VALUE_TYPES = {
	bool = true,
	int = true,
	long = true,
	float = true,
	double = true,
}

local function getCSharpType(reflectedType: any, includedClasses: { [string]: boolean }): (string?, string?)
	local engineType = reflectedType.EngineType
	local scriptType = reflectedType.ScriptType

	if reflectedType.EnumType then
		return reflectedType.EnumType, "Enum"
	end

	if reflectedType.InstanceType then
		local instanceType = reflectedType.InstanceType

		if instanceType == "Object" then
			return "RbxObject", "RefType"
		elseif includedClasses[instanceType] then
			return instanceType, "RefType"
		end

		return "Instance", "RefType"
	end

	if ENGINE_TYPE_MAP[engineType] then
		return ENGINE_TYPE_MAP[engineType], engineType
	end

	if scriptType == "number" then
		return "double", engineType
	elseif scriptType == "boolean" then
		return "bool", engineType
	elseif scriptType == "string" then
		return "string", engineType
	elseif scriptType == "EnumItem" then
		return nil, engineType
	end

	if type(scriptType) == "string" and Formatting[scriptType] then
		return scriptType, engineType
	end

	if type(scriptType) == "string" and VALUE_TYPES[scriptType] then
		return scriptType, engineType
	end

	return nil, engineType
end

local function formatDefault(value: any, csharpType: string, engineType: string?): string?
	if value == nil then
		return nil
	end

	local formatName: string = 
		if engineType == "Enum" 
			then "EnumItem"
		elseif csharpType == "Color3uint8"
			then "Color3"
		else FORMAT_TYPE_MAP[engineType ] or FORMAT_TYPE_MAP[csharpType] or csharpType
    
	local formatFunction = Formatting[formatName]

	if not formatFunction then
		return nil
	end

	local success, result = pcall(formatFunction, value)

	if success and type(result) == "string" and result ~= "" then
		return result
	end

	return nil
end

local function getDefaultInstance(class: any, engineInstancesByClass: { [string]: Instance }): (Instance?, boolean)
	local permissions = class.Permits or {}

	if permissions.GetService then
		local success, service = pcall(function()
			return game:GetService(class.Name)
		end)

		if success then
			return service, false
		end
	elseif permissions.New then
		local success, instance = pcall(function()
			return Instance.new(class.Name)
		end)

		if success then
			-- ! This helps avoid some crashes when saving
			instance.Archivable = false
			return instance, true
		end
	end

	return engineInstancesByClass[class.Name], false
end

local function getCSharpName(name: string, className: string): string
	local result = name:gsub("[^%w_]", "_")

	if result == className then
		result ..= "_"
	end

	return result
end

local function generateClasses()
	local classes = ReflectionService:GetClasses({ Security = ALL_PERMS })
	classes = table.clone(classes)

	table.sort(classes, function(a, b)
		return a.Name < b.Name
	end)

	local classByName = {}

	for _, class in ipairs(classes) do
		classByName[class.Name] = class
	end

	local engineInstancesByClass: { [string]: Instance } = {
		Terrain = workspace.Terrain,
		StarterPlayerScripts = game.StarterPlayer.StarterPlayerScripts,
		StarterCharacterScripts = game.StarterPlayer.StarterCharacterScripts,
		ChatWindowConfiguration = game.TextChatService.ChatWindowConfiguration,
		ChatInputBarConfiguration = game.TextChatService.ChatInputBarConfiguration,
		ChannelTabsConfiguration = game.TextChatService.ChannelTabsConfiguration,
		BubbleChatConfiguration = game.TextChatService.BubbleChatConfiguration,
	}

	for _, class in ipairs(classes) do
		local permissions = class.Permits or {}

		if permissions.GetService then
			local success, service = pcall(function()
				return game:GetService(class.Name)
			end)

			if success and service then
				engineInstancesByClass[service.ClassName] = service
			end
		end
	end

	local includedClasses = {}

	for _, class in ipairs(classes) do
		local permissions = class.Permits or {}

		if permissions.New or permissions.GetService or FORCE_REGISTER[class.Name] or engineInstancesByClass[class.Name] then
			local parentName = class.Name

			while parentName and parentName ~= "Object" and parentName ~= "Instance" do
				local parent = classByName[parentName]
				includedClasses[parentName] = true

				parentName = parent and parent.Superclass or nil
			end
		end
	end

	local defaultInstancesByClass: { [string]: Instance } = {}
	local temporaryInstances: { Instance } = {}

	for _, candidate in ipairs(classes) do
		local permissions = candidate.Permits or {}

		if permissions.New or permissions.GetService or engineInstancesByClass[candidate.Name] then
			local instance, shouldDestroy = getDefaultInstance(candidate, engineInstancesByClass)
			
			if instance then
				if shouldDestroy then
					table.insert(temporaryInstances, instance)
				end

				local ancestorName: string? = candidate.Name

				while ancestorName and ancestorName ~= "Object" do
					if includedClasses[ancestorName]
						and (ancestorName == candidate.Name or defaultInstancesByClass[ancestorName] == nil)
					then
						defaultInstancesByClass[ancestorName] = instance
					end

					local ancestor = classByName[ancestorName]
					ancestorName = ancestor and ancestor.Superclass or nil
				end
			end
		end
	end

	local output = ""
	local stackLevel = 0

	local function writeLine(formatString: string?, ...: any)
		if formatString then
			output ..= string.rep(" ", stackLevel * 4) .. formatString:format(...) .. "\n"
		else
			output ..= "\n"
		end
	end

	local function openStack()
		writeLine("{")
		stackLevel += 1
	end

	local function closeStack()
		stackLevel -= 1
		writeLine("}")
	end

	writeLine("// Auto-generated list of creatable Roblox classes.")
	writeLine("// Updated as of %s", version())
	writeLine()
	writeLine("using System;")
	writeLine()
	writeLine("using RobloxFiles.DataTypes;")
	writeLine("using RobloxFiles.Enums;")
	writeLine("using RobloxFiles.Utility;")
	writeLine()
	writeLine("#pragma warning disable IDE1006 // Naming Styles")
	writeLine("#pragma warning disable CS0612 // Type or member is obsolete")
	writeLine()
	writeLine("namespace RobloxFiles")
	openStack()

	local generatedNames = {}
	local childrenByParent: { [string]: { string } } = {}

	for className in pairs(includedClasses) do
		local class = classByName[className]
		local parentName = class and class.Superclass or "Object"
		
		if parentName ~= "Object" and parentName ~= "Instance" and not includedClasses[parentName] then
			parentName = "Instance"
		end

		local siblings = childrenByParent[parentName]

		if not siblings then
			siblings = {}
			childrenByParent[parentName] = siblings
		end

		table.insert(siblings, className)
	end

	for _, siblings in pairs(childrenByParent) do
		table.sort(siblings)
	end

	local ordered: { [string]: boolean } = {}

	local function visitChildren(parentName: string)
		local class = classByName[parentName]
		local subClasses = class and class.Subclasses

		if not subClasses then
			return
		end

		for _, childName in ipairs(subClasses) do
			if not ordered[childName] then
				ordered[childName] = true
				table.insert(generatedNames, childName)
				visitChildren(childName)
			end
		end
	end

	local remainingNames = {}
	visitChildren("Object")

	for className in pairs(includedClasses) do
		if not ordered[className] then
			table.insert(remainingNames, className)
		end
	end

	table.sort(remainingNames)

	for _, className in ipairs(remainingNames) do
		if not ordered[className] then
			ordered[className] = true
			table.insert(generatedNames, className)
			visitChildren(className)
		end
	end

	local generatedClasses = {}

	for _, generatedClassName in ipairs(generatedNames) do
		generatedClasses[generatedClassName] = true
	end

	local function getCSharpSuperclass(className: string): string
		local class = classByName[className]
		local parentName = class and class.Superclass

		while parentName and parentName ~= "Object" and parentName ~= "Instance" do
			if generatedClasses[parentName] then
				return parentName
			end

			local parent = classByName[parentName]
			parentName = parent and parent.Superclass
		end

		return if parentName == "Object" then "RbxObject" else "Instance"
	end

	for index, className in ipairs(generatedNames) do
		if className == "Object" or className == "Instance" then
			continue
		end

		local class = classByName[className]

		if not class then
			continue
		end

		local permissions = class.Permits or {}
		local isService = permissions.GetService ~= nil

		local isCreatable = permissions.New ~= nil or isService
			or FORCE_REGISTER[className] or engineInstancesByClass[className] ~= nil
		local superclass = getCSharpSuperclass(className)

		if not isCreatable and not class.Subclasses then
			-- Do we derive from Instance somewhere in the hierarchy?
			local ancestor = class and class.Superclass

			while ancestor and ancestor ~= "Instance" do
				local parent = classByName[ancestor]
				ancestor = parent and parent.Superclass
			end
			
			if ancestor == "Instance" then
				continue
			end
		end

		local classDisplay = class.Display

		if classDisplay and classDisplay.DeprecationMessage then
			if classDisplay.DeprecationMessage ~= "" then
				writeLine("[Obsolete(\"%s\")]", class.Display.DeprecationMessage)
			else
				writeLine("[Obsolete]")
			end
		end
	
		if isService then
			if NON_ROOTED_SERVICES[className] then
				writeLine("[RbxService(IsRooted = false)]")
			else
				writeLine("[RbxService]")
			end
		end
		
		local topClass = getCSharpSuperclass(className)
		
		while topClass and (topClass ~= "RbxObject" and topClass ~= "Instance") do
			local parent = classByName[topClass]
			
			if parent and parent.Superclass then
				topClass = getCSharpSuperclass(topClass)
			else
				break
			end
		end

		if topClass == "RbxObject" then
			isCreatable = true
		end

		writeLine("public %sclass %s : %s", if isCreatable then "" else "abstract ", className, superclass)
		openStack()

		local classPatch = PropertyPatches[className] or {}
		local redirects = classPatch.Redirect or {}
	
		local patchDefaults = classPatch.Defaults or {}
		local defaultInstance = defaultInstancesByClass[className]

		local reflectedProperties: {ReflectedProperty} = ReflectionService:GetPropertiesOfClass(className, {
			Security = ALL_PERMS,
			ExcludeInherited = true,
		}) or {}

		local properties = {}
		
		for _, property in ipairs(reflectedProperties) do
			table.insert(properties, property)
		end
		
		table.sort(properties, function(a, b)
			return a.Name < b.Name
		end)

		local propertiesByName = {}
		
		for _, property in ipairs(properties) do
			propertiesByName[property.Name] = property
		end

		local contentRedirects: { [string]: GetSet } = {}
		local legacyRedirects: { [string]: GetSet } = {}

		for _, property in ipairs(properties) do
			local deprecated = property.Display and property.Display.DeprecationMessage

			if deprecated ~= nil and not property.Serialized and redirects[property.Name] == nil then
				for _, target in ipairs(properties) do
					if target.Name ~= property.Name
						and target.Name:lower() == property.Name:lower()
						and (target.Serialized or redirects[target.Name] ~= nil)
					then
						local sourceType = getCSharpType(property.Type or {}, includedClasses)
						local targetType = getCSharpType(target.Type or {}, includedClasses)

						if sourceType ~= nil and sourceType == targetType then
							legacyRedirects[property.Name] = getCSharpName(target.Name, className)
							break
						end
					end
				end
			end
		end

		for _, contentProperty in ipairs(properties) do
			local contentName = contentProperty.Name
			local contentType = contentProperty.Type or {}
			local contentDisplay = contentProperty.Display

			local contentIsEmitted = contentProperty.Serialized
				or contentProperty.ContentType ~= nil
				or redirects[contentName] ~= nil
				or (contentDisplay and contentDisplay.DeprecationMessage ~= nil)
			
			if contentType.EngineType == "Content" and contentName:match("Content$") and contentIsEmitted then
				local prefix = contentName:sub(1, #contentName - 7)

				for _, legacyProperty in ipairs(properties) do
					if legacyProperty.Name ~= contentName
						and legacyProperty.Type
						and legacyProperty.Type.EngineType == "ContentId"
						and legacyProperty.Name:sub(1, #prefix) == prefix
						and redirects[legacyProperty.Name] == nil
						and contentRedirects[legacyProperty.Name] == nil
					then
						contentRedirects[legacyProperty.Name] = {
							Get = contentName,
							Set = contentName .. " = value",
						}
					end
				end
			end
		end

		local emittedProperty = false
		local lastDeprecationRedirect = false
		
		for _, property in ipairs(properties) do
			local redirect = redirects[property.Name] or contentRedirects[property.Name] or legacyRedirects[property.Name]
			local deprecated = property.Display and property.Display.DeprecationMessage
			
			if not (property.Serialized or property.ContentType or redirect or deprecated) then
				continue
			end

			local reflectedType = property.Type or {}
			local csharpType, engineType = getCSharpType(reflectedType, includedClasses)
	
			if not csharpType then
				warn("Skipping unsupported reflected property type:", className, property.Name, engineType)
				continue
			end

			local propertyName = getCSharpName(property.Name, className)
			local newDeprecationRedirect = deprecated or redirect
			local permits = property.Permits
			local canWrite = permits ~= nil and permits.Write ~= nil
			local getter
			local setter
			local modifiers = ""

			if redirect then
				if type(redirect) == "string" then
					getter = redirect
					setter = redirect .. " = value"

					if redirect == "value" then
						setter = "this." .. setter
					end
				else
					getter = redirect.Get
					setter = redirect.Set
					modifiers = redirect.Flags or ""
				end

				if not canWrite then
					setter = nil
				end

				if setter then
					local assignedProperties = {}

					for name in setter:gmatch("([%a_][%w_]*)%s*=") do
						assignedProperties[name] = true
					end

					for name in setter:gmatch("out%s+([%a_][%w_]*)") do
						assignedProperties[name] = true
					end

					for name in pairs(assignedProperties) do
						local targetProperty = propertiesByName[name]

						if targetProperty
							and targetProperty.Permits ~= nil
							and targetProperty.Permits.Write == nil
							and not targetProperty.Serialized
						then
							setter = nil
							break
						end
					end
				end

				if not (getter and setter) then
					continue
				end
			elseif not canWrite and not (property.Serialized or property.ContentType) then
				continue
			elseif deprecated ~= nil and not (property.Serialized or property.ContentType)
				and patchDefaults[property.Name] == nil
			then
				continue
			end

			if emittedProperty and (lastDeprecationRedirect ~= newDeprecationRedirect or newDeprecationRedirect) then
				writeLine()
			end

			if deprecated then
				if deprecated ~= "" then
					writeLine("[Obsolete(\"%s\")]", deprecated)
				else
					writeLine("[Obsolete]")
				end
			end

			if redirect then
				if getter and setter then
					writeLine("public %s%s %s", if modifiers ~= "" 
						then modifiers .. " " 
						else "", csharpType, propertyName)
					
					openStack()
					writeLine("get => %s;", getter)

					if setter:find("\n") then
						writeLine("set")
						openStack()
					
						for line in setter:gmatch("[^\r\n]+") do
							writeLine(line)
						end
					
						closeStack()
					else
						writeLine("set => %s;", setter)
					end
					
					closeStack()
				elseif getter then
					writeLine("public %s %s => %s;", csharpType, propertyName, getter)
				elseif setter then
					writeLine("public %s%s %s", if modifiers ~= "" then modifiers .. " " else "", csharpType, propertyName)
					openStack()
					writeLine("set => %s;", setter)
					closeStack()
				end
			else
				local value = patchDefaults[property.Name]
				local gotValue = value ~= nil

				local isReferenceType = engineType ~= "Enum" and not CSHARP_VALUE_TYPES[csharpType]
				local defaultToNull = not property.Serialized and not gotValue and not redirect and isReferenceType

				if not gotValue and not defaultToNull and defaultInstance then
					local success, instanceValue = pcall(function()
						return (defaultInstance :: any)[property.Name]
					end)

					gotValue = success
					value = instanceValue
				end

				local initializer = if defaultToNull and csharpType == "Content" then " = Content.None"
					elseif defaultToNull then " = null"
					else ""
				
				if gotValue then
					local formatted = formatDefault(value, csharpType, engineType)
				
					if formatted then
						initializer = ` = {formatted}`
					end
				end
				
				writeLine("public %s %s%s;", csharpType, propertyName, initializer)
			end

			emittedProperty = true
			lastDeprecationRedirect = newDeprecationRedirect
		end

		local constructorAssignments = {}
		local directSuperclass = class.Superclass
		local superclassDefault = directSuperclass and defaultInstancesByClass[directSuperclass]

		if permissions.New and not isService and directSuperclass and directSuperclass ~= "Instance" and superclassDefault and defaultInstance then
			local seenProperties = {}
			local ancestorName: string? = directSuperclass

			while ancestorName and ancestorName ~= "Object" and ancestorName ~= "Instance" do
				local ancestor = classByName[ancestorName]
				if not ancestor then
					break
				end

				local ancestorPatch = PropertyPatches[ancestorName] or {}
				local ancestorRedirects = ancestorPatch.Redirect or {}
				local ancestorDefaults = ancestorPatch.Defaults or {}

				local ancestorProperties = ReflectionService:GetPropertiesOfClass(ancestorName, {
					Security = ALL_PERMS,
					ExcludeInherited = true,
				}) or {}

				local ancestorContentProperties = {}

				for _, ancestorProperty in ipairs(ancestorProperties) do
					if ancestorProperty.Type and ancestorProperty.Type.EngineType == "Content"
						and ancestorProperty.Name:match("Content$")
					then
						table.insert(ancestorContentProperties, ancestorProperty.Name)
					end
				end

				for _, property in ipairs(ancestorProperties) do
					local propertyName = property.Name
					local propertyType = property.Type or {}
					local deprecated = property.Display and property.Display.DeprecationMessage ~= nil
					local isRedirect = ancestorRedirects[propertyName] ~= nil

					if propertyType.EngineType == "ContentId" then
						for _, contentName in ipairs(ancestorContentProperties) do
							local prefix = contentName:sub(1, #contentName - 7)

							if propertyName ~= contentName and propertyName:sub(1, #prefix) == prefix then
								isRedirect = true
								break
							end
						end
					end

					if not seenProperties[propertyName]
						and not isRedirect
						and not deprecated
						and (property.Serialized or property.ContentType)
					then
						local csharpType, engineType = getCSharpType(propertyType, includedClasses)
						seenProperties[propertyName] = true

						if csharpType then
							local isReferenceType = engineType ~= "Enum" and not CSHARP_VALUE_TYPES[csharpType]

							local function formatInstanceDefault(instance: Instance, patchValue: any): string?
								local value = patchValue
								
								if value == nil then
									local success, instanceValue = pcall(function()
										return (instance :: any)[propertyName]
									end)

									if not success then
										return nil
									end
									
									value = instanceValue
								end

								if value == nil then
									return if isReferenceType then "null" else nil
								end

								return formatDefault(value, csharpType, engineType)
							end

							local childFormatted = formatInstanceDefault(defaultInstance, patchDefaults[propertyName])
							local parentFormatted = formatInstanceDefault(superclassDefault, ancestorDefaults[propertyName])

							if childFormatted and parentFormatted and childFormatted ~= parentFormatted then
								table.insert(constructorAssignments, string.format(
									"%s = %s;",
									getCSharpName(propertyName, ancestorName),
									childFormatted
								))
							end
						end
					end
				end

				ancestorName = ancestor.Superclass
			end
		end

		if #constructorAssignments > 0 then
			writeLine()
			writeLine("public %s()", className)
			openStack()

			for _, assignment in ipairs(constructorAssignments) do
				writeLine(assignment)
			end

			closeStack()
		end

		closeStack()
		
		if index ~= #generatedNames then
			writeLine()
		end
	end

	for _, instance in ipairs(temporaryInstances) do
		pcall(function()
			instance:Destroy()
		end)
	end

	closeStack()
	return output
end

return generateClasses()