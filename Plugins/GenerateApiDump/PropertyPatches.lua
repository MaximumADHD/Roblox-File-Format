local function UseColor3(propName)
	return
	{
		Get = string.format("BrickColor.FromColor3(%s)", propName);
		Set = propName .. " = value?.Color";
	}
end

local GuiTextMixIn = 
{
	Add = { Transparency = "float" };
	
	Redirect =
	{
		FontSize = 
		{
			Get = "FontUtility.GetFontSize(TextSize)";
			Set = "TextSize = FontUtility.GetFontSize(value)";
		};
		
		TextColor = UseColor3("TextColor3");
		TextWrap = "TextWrapped";

		Transparency = 
		{
			Get = "base.Transparency";

			Set = "base.Transparency = value;\n" ..
				  "TextTransparency  = value;";
			
			Flag = "new";
		}
	};
}

return
{
	BallSocketConstraint =
	{
		-- Why does this even exist?
		Add = { MaxFrictionTorqueXml = "float" };
	};
	
	BasePart =
	{
		Add = 
		{
			Color3uint8 = "Color3uint8";
			size = "Vector3";
		};
		
		Redirect =
		{
			Position = "CFrame.Position";
			BrickColor = UseColor3("Color");
			Color = "Color3uint8";
			Size = "size";
		};
		
		Defaults =
		{
			Color3uint8 = Color3.fromRGB(163, 162, 165);
			size = Vector3.new(4, 1.2, 2);
		};
	};

	BaseScript =
	{
		Remove = {"LinkedSource"};
	};
	
	BevelMesh = 
	{
		Add = 
		{
			Bevel = "float";
			Bevel_Roundness = "float";
			Bulge = "float";
		}
	};
	
	BinaryStringValue =
	{
		Add = { Value = "BinaryString" };
	};
	
	BodyColors =
	{
		Redirect =
		{
			HeadColor     = UseColor3("HeadColor3");
			LeftArmColor  = UseColor3("LeftArmColor3");
			RightArmColor = UseColor3("RightArmColor3");
			LeftLegColor  = UseColor3("LeftLegColor3");
			RightLegColor = UseColor3("RightLegColor3");
			TorsoColor    = UseColor3("TorsoColor3");
		}
	};
	
	BodyAngularVelocity =
	{
		Redirect = { angularvelocity = "AngularVelocity" };
	};
	
	BodyGyro =
	{
		Redirect = { cframe = "CFrame" };
	};
	
	Camera = 
	{
		Redirect = { CoordinateFrame = "CFrame" }
	};

	CustomEvent =
	{
		Add = { PersistedCurrentValue = "float" };
	};
	
	DataModelMesh = 
	{
		Add = 
		{
			LODX = "Enum:LevelOfDetailSetting";
			LODY = "Enum:LevelOfDetailSetting";
		};
		
		Defaults = 
		{
			LODX = Enum.LevelOfDetailSetting.High;
			LODY = Enum.LevelOfDetailSetting.High;
		};
	};
	
	DataStoreService = 
	{
		Defaults = 
		{
			AutomaticRetry = true;
			LegacyNamingScheme = false;
		}
	};
	
	DoubleConstrainedValue = 
	{
		Add = { value = "double" };
		
		Redirect = 
		{
			Value = "value";
			ConstrainedValue = "value"; 
		}
	};
	
	Fire =
	{
		Add =
		{
			heat_xml = "float";
			size_xml = "float";
		};
		
		Defaults =
		{
			heat_xml = 9;
			size_xml = 5;
		};
		
		Redirect = 
		{
			Heat = "heat_xml";
			Size = "size_xml";
		};
	};
	
	FormFactorPart =
	{
		Add = 
		{
			formFactorRaw = "Enum:FormFactor";
		};
		
		Defaults = 
		{
			formFactorRaw = Enum.FormFactor.Brick;
		};
		
		Redirect = 
		{
			FormFactor = "formFactorRaw";
		};
	};

	FunctionalTest =
	{
		Add      = { HasMigratedSettingsToTestService = "bool"; };
		Defaults = { HasMigratedSettingsToTestService = false;  };
	};
	
	GuiBase2d = 
	{
		Redirect = { Localize = "AutoLocalize" }
	};
	
	GuiBase3d = 
	{
		Redirect = { Color = UseColor3("Color3") }
	};
	
	GuiObject = 
	{
		Redirect = 
		{
			BackgroundColor = UseColor3("BackgroundColor3");
			BorderColor = UseColor3("BorderColor3");
			Transparency = "BackgroundTransparency";
		}
	};
	
	HttpService =
	{
		Defaults = { HttpEnabled = false }
	};
	
	Humanoid = 
	{
		Add =
		{
			Health_XML = "float";
			InternalHeadScale = "float";
			InternalBodyScale = "Vector3";
		};
		
		Defaults = 
		{
			Health_XML = 100;
			InternalHeadScale = 1;
			InternalBodyScale = Vector3.new(1, 1, 1);
		};
		
		Redirect = 
		{
			Health = "Health_XML";
		};
		
		Remove = 
		{
			"Jump";
			"Torso";
			"LeftLeg";
			"RightLeg";
		};
	};
	
	HumanoidDescription =
	{
		Add =
		{
			EmotesDataInternal = "string";
			EquippedEmotesDataInternal = "string";
		};
	};
	
	InsertService = 
	{
		Add      = { AllowClientInsertModels = "bool" };
		Defaults = { AllowClientInsertModels = false  };
	};
	
	IntConstrainedValue = 
	{
		Add      = { value = "int64" };
		
		Redirect = 
		{
			Value = "value";
			ConstrainedValue = "value";
		}
	};
	
	Lighting =
	{
		Add = 
		{
			Technology = "Enum:Technology";
		};
		
		Defaults = 
		{
			Technology = Enum.Technology.Compatibility;
		};
	};
	
	LocalizationTable = 
	{
		Add      = { Contents = "string" };
		Defaults = { Contents = "[]"     };
		
		Redirect =
		{
			DevelopmentLanguage = "SourceLocaleId";
		}
	};

	LocalScript =
	{
		Remove = 
		{
			"LinkedSource",
			"Source"
		}
	};
	
	LuaSourceContainer = 
	{
		Add = 
		{ 
			LinkedSource = "Content";
			ScriptGuid = "string";
			Source = "ProtectedString";
		};
	};
	
	ManualSurfaceJointInstance = 
	{
		Add = 
		{
			Surface0 = "int";
			Surface1 = "int";
		};
		
		Defaults = 
		{
			Surface0 = -1;
			Surface1 = -1;			
		}
	};
	
	MeshPart =
	{
		Redirect = { MeshID = "MeshId" }
	};
	
	Model = 
	{
		Add =
		{
			ModelInPrimary = "CFrame";
			ModelMeshCFrame = "CFrame";
			ModelMeshData = "SharedString";
			ModelMeshSize = "Vector3";
		};
	};

	ModuleScript = 
	{
		Remove =
		{
			"LinkedSource",
			"Source"
		}
	};
	
	PackageLink = 
	{
		Add = 
		{
			VersionIdSerialize = "int64";
			PackageIdSerialize = "Content";
		};
		
		Defaults = { AutoUpdate = false };
	};
	
	Part = 
	{
		Add = { shape = "Enum:PartType" };
		Redirect = { Shape = "shape" };
	};
	
	ParticleEmitter = 
	{
		Redirect = 
		{
			VelocitySpread = 
			{
				Get = "SpreadAngle.X";
				Set = "SpreadAngle = new Vector2(value, value)";
			}
		}
	};
	
	PartOperation = 
	{
		Add =
		{
			AssetId = "Content";
			ChildData = "BinaryString";
			MeshData = "BinaryString";
			FormFactor = "Enum:FormFactor";
		};
		
		Defaults = { FormFactor = Enum.FormFactor.Custom };
	};
	
	PartOperationAsset = 
	{
		Add = 
		{
			ChildData = "BinaryString";
			MeshData = "BinaryString";
		};
	};
	
	Players =
	{
		Defaults = { MaxPlayersInternal = 16 }
	};
	
	SelectionBox =
	{
		Redirect = { SurfaceColor = UseColor3("SurfaceColor3") }
	};
	
	SelectionSphere =
	{
		Redirect = { SurfaceColor = UseColor3("SurfaceColor3") }
	};
	
	ServerScriptService = 
	{
		Defaults = { LoadStringEnabled = false }
	};

	Script = 
	{
		Remove = 
		{
			"LinkedSource",
			"Source"
		}
	};
	
	Smoke =
	{
		Add =
		{
			size_xml = "float";
			opacity_xml = "float";
			riseVelocity_xml = "float";
		};
		
		Defaults = 
		{
			size_xml = 1;
			opacity_xml = 0.5;
			riseVelocity_xml = 1;
		};
		
		Redirect = 
		{
			Size = "size_xml";
			Opacity = "opacity_xml";
			RiseVelocity = "riseVelocity_xml";
		};
	};
	
	Sound = 
	{
		Add = 
		{
			MaxDistance = "float"; -- ?!
			
			xmlRead_MaxDistance_3 = "float";
			xmlRead_MinDistance_3 = "float";
		};
		
		Defaults = 
		{
			xmlRead_MinDistance_3 = 10;
			xmlRead_MaxDistance_3 = 10000;
		};
		
		Redirect =
		{
			MaxDistance = "xmlRead_MaxDistance_3";
			xmlRead_MinDistance_3 = "EmitterSize";
			
			MinDistance = "EmitterSize";
			Pitch = "PlaybackSpeed";
		};
	};
	
	Sparkles = 
	{
		Redirect = { Color = "SparkleColor" };
	};

	StarterPlayer =
	{
		Defaults =
		{
			GameSettingsAvatar = Enum.GameAvatarType.R15;
			GameSettingsR15Collision = Enum.R15CollisionType.OuterBox;
			
			GameSettingsScaleRangeHead       = NumberRange.new(0.95, 1.00);
			GameSettingsScaleRangeWidth      = NumberRange.new(0.70, 1.00);
			GameSettingsScaleRangeHeight     = NumberRange.new(0.90, 1.05);
			GameSettingsScaleRangeBodyType   = NumberRange.new(0.00, 1.00);
			GameSettingsScaleRangeProportion = NumberRange.new(0.00, 1.00);
		};
	};
	
	StudioData = 
	{
		Add =
		{
			CommitInflightGuid = "string";
			CommitInflightAuthorId = "int64";
			CommitInflightPlaceVersion = "int";
		};
	};
	
	SurfaceAppearance =
	{
		Defaults = { AlphaMode = Enum.AlphaMode.Overlay }
	};
	
	TextBox = GuiTextMixIn;
	TextLabel = GuiTextMixIn;
	TextButton = GuiTextMixIn;
	
	Terrain = 
	{
		Add = 
		{
			ClusterGridV3 = "BinaryString";
			PhysicsGrid = "BinaryString";
			SmoothGrid = "BinaryString";
		};
		
		Defaults = 
		{
			SmoothGrid = "AQU=";
			PhysicsGrid = "AgMAAAAAAAAAAAAAAAA=";
			MaterialColors = "AAAAAAAAan8/P39rf2Y/ilY+j35fi21PZmxvZbDqw8faiVpHOi4kHh4lZlw76JxKc3trhHtagcLgc4RKxr21zq2UlJSM";
		};
	};
	
	TerrainRegion = 
	{
		Add =
		{
			ExtentsMax = "Vector3int16";
			ExtentsMin = "Vector3int16";
			
			GridV3 = "BinaryString";
			SmoothGrid = "BinaryString";
		};
		
		Defaults = 
		{
			ExtentsMax = Vector3int16.new();
			ExtentsMin = Vector3int16.new();
			
			GridV3 = "";
			SmoothGrid = "AQU=";
		};
	};
	
	TriangleMeshPart =
	{
		Add =
		{
			InitialSize = "Vector3";
			LODData = "BinaryString";
			PhysicsData = "BinaryString";
			PhysicalConfigData = "SharedString";
		};
		
		Defaults =
		{
			InitialSize = Vector3.new(1, 1, 1);
			PhysicalConfigData = "1B2M2Y8AsgTpgAmY7PhCfg==";
		};
	};
	
	TrussPart =
	{
		Add = { style = "Enum:Style" };
		Redirect = { Style = "style" };
	};
	
	ViewportFrame = 
	{
		Add = 
		{
			CameraCFrame = "CFrame";
			CameraFieldOfView = "float";
		};
		
		Defaults = 
		{
			CameraCFrame = CFrame.new();
			CameraFieldOfView = 70;
		};
	};
	
	WeldConstraint =
	{
		Add =
		{
			Part0Internal = "Class:BasePart";
			Part1Internal = "Class:BasePart";

			EnabledInternal = "bool";
			State = "int";

			CFrame0 = "CFrame";
			CFrame1 = "CFrame";
		};
		
		Defaults =
		{
			CFrame0 = CFrame.new();
			CFrame1 = CFrame.new();

			EnabledInternal = true;
			State = 3;
			
			Part0 = Instance.new("Part");
			Part1 = Instance.new("Part");
		};
		
		Redirect =
		{
			Part0 = "Part0Internal";
			Part1 = "Part1Internal";
			Enabled = "EnabledInternal";
		};
	};
	
	Workspace =
	{
		Add =
		{
			CollisionGroups = "string";
			ExplicitAutoJoints = "bool";
			
			StreamingMinRadius = "int";
			StreamingTargetRadius = "int";
			StreamingPauseMode = "Enum:StreamingPauseMode";
			
			TerrainWeldsFixed = "bool";
		};
		
		Defaults =
		{
			CollisionGroups = "Default^0^1";
			ExplicitAutoJoints = true;
			
			StreamingMinRadius = 64;
			StreamingTargetRadius = 1024;
			StreamingPauseMode = Enum.StreamingPauseMode.Default;
			
			TerrainWeldsFixed = true;
			MeshPartHeads = Enum.MeshPartHeads.Default;
		}
	}
}