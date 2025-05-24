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

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

local GuiTextMixIn: Patch = {
	Redirect = {
		Font = {
			Get = "FontUtility.GetLegacyFont(FontFace)",
			Set = "FontUtility.TryGetFontFace(value, out FontFace)",
		},

		FontSize = {
			Get = "FontUtility.GetFontSize(TextSize)",
			Set = "TextSize = FontUtility.GetFontSize(value)",
		},

		TextColor = UseColor3("TextColor3"),
		TextWrap = "TextWrapped",

		Transparency = {
			Get = "base.Transparency",
			Set = "base.Transparency = value;\nTextTransparency  = value;",
			Flags = "new",
		},
	},
}

local GuiImageMixIn: Patch = {
	Redirect = {
		Image = "ImageContent",
		HoverImage = "HoverImageContent",
		PressedImage = "PressedImageContent",
	}
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
			AudioSubtype = "AudioSubType",
		},
	},

	AudioPlayer = {
		Redirect = {
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

	BaseWrap = {
		Redirect = {
			CageMeshId = "CageMeshContent",
		}
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

	BodyGyro = {
		Redirect = {
			cframe = "CFrame"
		},
	},

	Camera = {
		Redirect = {
			CoordinateFrame = "CFrame"
		},
	},

	DataStoreService = {
		Defaults = {
			AutomaticRetry = true,
			LegacyNamingScheme = false,
		},
	},

	Decal = {
		Redirect = {
			Texture = "TextureContent",
		}
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

	ImageButton = GuiImageMixIn,
	ImageLabel = GuiImageMixIn,

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

	MaterialVariant = {
		Redirect = {
			ColorMap = "ColorMapContent",
			NormalMap = "NormalMapContent",
			MetalnessMap = "MetalnessMapContent",
			RoughnessMap = "RoughnessMapContent",
		}
	},

	MeshPart = {
		Redirect = {
			MeshId = "MeshContent",
			MeshID = "MeshContent",
			TextureID = "TextureContent",
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

		Redirect = {
			ColorMap = "ColorMapContent",
			NormalMap = "NormalMapContent",
			MetalnessMap = "MetalnessMapContent",
			RoughnessMap = "RoughnessMapContent",
		}
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

	TerrainDetail = {
		Redirect = {
			ColorMap = "ColorMapContent",
			NormalMap = "NormalMapContent",
			MetalnessMap = "MetalnessMapContent",
			RoughnessMap = "RoughnessMapContent",
		}
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
			LegacyInputEventsEnabled = true
		},
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

			MeshPartHeads = TryGetEnumItem("MeshPartHeads", "Default"),
			SignalBehavior = TryGetEnumItem("SignalBehavior", "Default"),
			StreamingPauseMode = TryGetEnumItem("StreamingPauseMode", "Default"),
			PhysicsSteppingMethod = TryGetEnumItem("PhysicsSteppingMethod", "Default"),
			MeshPartHeadsAndAccessories = TryGetEnumItem("MeshPartHeadsAndAccessories", "Default"),
		},
	},

	WrapLayer = {
		Redirect = {
			ReferenceMeshId = "ReferenceMeshContent",
		}
	}
}

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

return PropertyPatches

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
