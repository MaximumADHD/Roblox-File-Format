--!strict
local HttpService = game:GetService("HttpService")

export type GetSet = string | {
	Get: string,
	Set: string,
	Flags: string?,
}

export type Patch = {
	Redirect: { [string]: GetSet }?,
	Defaults: { [string]: any }?,
}

-- strict type reaffirmation?
-- this is some bug with Luau.

local function GetSet(getSet: GetSet): GetSet
	return getSet
end

local function UseColor3(propName: string): GetSet
	return {
		Get = string.format("BrickColor.FromColor3(%s)", propName),
		Set = propName .. " = value?.Color",
	}
end

local function TryGetEnumItem(enumName, itemName): EnumItem?
	local gotEnum, enum = pcall(function()
		return (Enum :: any)[enumName] :: Enum
	end)

	if gotEnum then
		local gotEnumItem, item = pcall(function()
			return (enum :: any)[itemName] :: EnumItem
		end)

		if gotEnumItem then
			return item
		end
	end

	return nil
end

local GuiTextMixIn: Patch = {
	Redirect = {
		Font = GetSet({
			Get = "FontUtility.GetLegacyFont(FontFace)",
			Set = "FontUtility.TryGetFontFace(value, out FontFace)",
		}),

		FontSize = GetSet({
			Get = "FontUtility.GetFontSize(TextSize)",
			Set = "TextSize = FontUtility.GetFontSize(value)",
		}),

		TextColor = UseColor3("TextColor3"),
		TextWrap = GetSet("TextWrapped"),

		Transparency = GetSet({
			Get = "base.Transparency",
			Set = "base.Transparency = value;\nTextTransparency  = value;",
			Flag = "new",
		}),
	},
}

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

local PropertyPatches: { [string]: Patch } = {
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
			AudioSubtype = GetSet("AudioSubType"),
		},
	},

	BallSocketConstraint = {
		-- Why does this even exist?
		Redirect = {
			MaxFrictionTorque = GetSet("MaxFrictionTorqueXml"),
		},
	},

	BasePart = {
		Redirect = {
			Position = GetSet({
				Get = "CFrame.Position",
				Set = "CFrame = new CFrame(value) * CFrame.Rotation",
			}),

			MaterialVariant = GetSet("MaterialVariantSerialized"),
			BrickColor = UseColor3("Color"),
			Color = GetSet("Color3uint8"),
			Size = GetSet("size"),
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
		Redirect = { angularvelocity = GetSet("AngularVelocity") },
	},

	BodyGyro = {
		Redirect = { cframe = GetSet("CFrame") },
	},

	Camera = {
		Redirect = { CoordinateFrame = GetSet("CFrame") },
	},

	DataStoreService = {
		Defaults = {
			AutomaticRetry = true,
			LegacyNamingScheme = false,
		},
	},

	DoubleConstrainedValue = {
		Redirect = {
			Value = GetSet("value"),
			ConstrainedValue = GetSet("value"),
		},
	},

	Fire = {
		Defaults = {
			heat_xml = 9,
			size_xml = 5,
		},

		Redirect = {
			Heat = GetSet("heat_xml"),
			Size = GetSet("size_xml"),
		},
	},

	FloatCurve = {
		Defaults = { ValuesAndTimes = "AAAAAAEAAAAKAAAAAAAAFkUAAAAA" },
	},

	FormFactorPart = {
		Defaults = {
			formFactorRaw = TryGetEnumItem("FormFactor", "Brick"),
		},

		Redirect = {
			FormFactor = GetSet("formFactorRaw"),
		},
	},

	FunctionalTest = {
		Defaults = { HasMigratedSettingsToTestService = false },
	},

	GuiBase2d = {
		Redirect = { Localize = GetSet("AutoLocalize") },
	},

	GuiBase3d = {
		Redirect = { Color = UseColor3("Color3") },
	},

	GuiObject = {
		Redirect = {
			Transparency = GetSet("BackgroundTransparency"),
			BackgroundColor = UseColor3("BackgroundColor3"),
			BorderColor = UseColor3("BorderColor3"),
		},
	},

	HttpService = {
		Defaults = { HttpEnabled = false },
	},

	Humanoid = {
		Defaults = {
			Health_XML = 100,
			InternalHeadScale = 1,
			InternalBodyScale = Vector3.new(1, 1, 1),
		},

		Redirect = {
			Health = GetSet("Health_XML"),
		},
	},

	HumanoidDescription = {
		Defaults = {
			AccessoryBlob = "[]",
			EmotesDataInternal = "[]",
			EquippedEmotesDataInternal = "[]",
		},
	},

	InsertService = {
		Defaults = { AllowClientInsertModels = false },
	},

	IntConstrainedValue = {
		Redirect = {
			Value = GetSet("value"),
			ConstrainedValue = GetSet("value"),
		},
	},

	Lighting = {
		Defaults = {
			Technology = TryGetEnumItem("Technology", "Compatibility"),
		},
	},

	LocalizationTable = {
		Defaults = { Contents = "[]" },

		Redirect = {
			DevelopmentLanguage = GetSet("SourceLocaleId"),
		},
	},

	MarkerCurve = {
		Defaults = { ValuesAndTimes = "AAAAAAEAAAAKAAAAAAAAFkUAAAAA" },
	},

	MaterialService = {
		Redirect = { Use2022Materials = GetSet("Use2022MaterialsXml") },

		Defaults = {
			AsphaltName = "Asphalt",
			BasaltName = "Basalt",
			BrickName = "Brick",
			CobblestoneName = "Cobblestone",
			ConcreteName = "Concrete",
			CorrodedMetalName = "CorrodedMetal",
			CrackedLavaName = "CrackedLava",
			DiamondPlateName = "DiamondPlate",
			FabricName = "Fabric",
			FoilName = "Foil",
			GlacierName = "Glacier",
			GraniteName = "Granite",
			GrassName = "Grass",
			GroundName = "Ground",
			IceName = "Ice",
			LeafyGrassName = "LeafyGrass",
			LimestoneName = "Limestone",
			MarbleName = "Marble",
			MetalName = "Metal",
			MudName = "Mud",
			PavementName = "Pavement",
			PebbleName = "Pebble",
			PlasticName = "Plastic",
			RockName = "Rock",
			SaltName = "Salt",
			SandName = "Sand",
			SandstoneName = "Sandstone",
			SlateName = "Slate",
			SmoothPlasticName = "SmoothPlastic",
			SnowName = "Snow",
			WoodName = "Wood",
			WoodPlanksName = "WoodPlanks",
		},
	},

	MeshPart = {
		Defaults = { VertexCount = 0 },
		Redirect = { MeshID = GetSet("MeshId") },
	},

	Model = {
		Defaults = { ScaleFactor = 1 },
	},

	PackageLink = {
		Defaults = { AutoUpdate = false },
	},

	Part = {
		Redirect = { Shape = GetSet("shape") },
	},

	ParticleEmitter = {
		Redirect = {
			VelocitySpread = GetSet({
				Get = "SpreadAngle.X",
				Set = "SpreadAngle = new Vector2(value, value)",
			}),
		},
	},

	PartOperation = {
		Defaults = { FormFactor = Enum.FormFactor.Custom },
	},

	Players = {
		Defaults = { MaxPlayersInternal = 16 },
	},

	PolicyService = {
		Defaults = {
			IsLuobuServer = TryGetEnumItem("TriStateBoolean", "Unknown"),
			LuobuWhitelisted = TryGetEnumItem("TriStateBoolean", "Unknown"),
		},
	},

	RotationCurve = {
		Defaults = { ValuesAndTimes = "AAAAAAEAAAAKAAAAAAAAFkUAAAAA" },
	},

	SelectionBox = {
		Redirect = { SurfaceColor = UseColor3("SurfaceColor3") },
	},

	SelectionSphere = {
		Redirect = { SurfaceColor = UseColor3("SurfaceColor3") },
	},

	ServerScriptService = {
		Defaults = { LoadStringEnabled = false },
	},

	Smoke = {
		Defaults = {
			size_xml = 1,
			opacity_xml = 0.5,
			riseVelocity_xml = 1,
		},

		Redirect = {
			Size = GetSet("size_xml"),
			Opacity = GetSet("opacity_xml"),
			RiseVelocity = GetSet("riseVelocity_xml"),
		},
	},

	Sound = {
		Defaults = {
			xmlRead_MinDistance_3 = 10,
			xmlRead_MaxDistance_3 = 10000,
		},

		Redirect = {
			MaxDistance = GetSet("xmlRead_MaxDistance_3"),
			xmlRead_MinDistance_3 = GetSet("EmitterSize"),
			RollOffMinDistance = GetSet("EmitterSize"),
			MinDistance = GetSet("EmitterSize"),
			Pitch = GetSet("PlaybackSpeed"),
		},
	},

	Sparkles = {
		Redirect = { Color = GetSet("SparkleColor") },
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
		Defaults = { AlphaMode = Enum.AlphaMode.Overlay },
	},

	TextBox = GuiTextMixIn,
	TextLabel = GuiTextMixIn,
	TextButton = GuiTextMixIn,

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
		Redirect = { Style = GetSet("style") },
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
		Defaults = { LegacyInputEventsEnabled = true },
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
			Part0 = GetSet("Part0Internal"),
			Part1 = GetSet("Part1Internal"),
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

			MeshPartHeads = TryGetEnumItem("MeshPartHeads", "Default"),
			SignalBehavior = TryGetEnumItem("SignalBehavior", "Default"),
			StreamingPauseMode = TryGetEnumItem("StreamingPauseMode", "Default"),
			PhysicsSteppingMethod = TryGetEnumItem("PhysicsSteppingMethod", "Default"),
			MeshPartHeadsAndAccessories = TryGetEnumItem("MeshPartHeadsAndAccessories", "Default"),
		},
	},
}

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

return PropertyPatches

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
