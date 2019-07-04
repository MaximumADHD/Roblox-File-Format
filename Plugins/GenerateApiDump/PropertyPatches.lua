local function UseColor3(propName)
	return
	{
		Get = "BrickColor.FromColor3(" .. propName .. ')';
		Set = propName .. " = value.Color";
	}
end

local GuiTextMixIn = 
{
	Redirect = 
	{
		FontSize = 
		{
			Get = "FontUtility.GetFontSize(TextSize)";
			Set = "TextSize = FontUtility.GetFontSize(value)";
		};
		
		TextColor = UseColor3("TextColor3");
		TextWrap = "TextWrapped";
	};
}

return
{
	Accoutrement = 
	{
		Remove =
		{
			"AttachmentUp";
			"AttachmentPos";
			"AttachmentRight";
			"AttachmentForward";
		};
	};
	
	AnalyticsService = 
	{
		Defaults = { ApiKey = "" }
	};
	
	Attachment = 
	{
		Remove = 
		{
			"Axis";
			"Orientation";
			"Position";
			"SecondaryAxis";
			"WorldAxis";
			"WorldCFrame";
			"WorldOrientation";
			"WorldPosition";
			"WorldSecondaryAxis";
		};
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
		
		Remove = 
		{
			"Orientation";
			"Rotation";
		}
	};
	
	BevelMesh = 
	{
		Add = 
		{
			Bevel = "float";
			Bevel_Roundness = "float";
			Bulge = "float";
		};
		
		Defaults = 
		{
			Bevel = 0;
			Bevel_Roundness = 0;
			Bulge = 0;
		}
	};
	
	BinaryStringValue =
	{
		Add = 
		{
			Value = "BinaryString"; 
		};
		
		Defaults = 
		{
			Value = ""; 
		};
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
	
	DebuggerWatch =
	{
		Defaults = { Expression = "" };
	};
	
	DoubleConstrainedValue = 
	{
		Redirect = { ConstrainedValue = "Value" }
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
		
		Defaults = 
		{
			EmotesDataInternal = "";
			EquippedEmotesDataInternal = "";
		};
	};
	
	InsertService = 
	{
		Add      = { AllowClientInsertModels = "bool" };
		Defaults = { AllowClientInsertModels = false  };
	};
	
	IntConstrainedValue = 
	{
		Redirect = { ConstrainedValue = "Value" }
	};
	
	JointInstance = 
	{
		Add      = { IsAutoJoint = "bool" };
		Defaults = { IsAutoJoint = true   };
	};
	
	Lighting =
	{
		Add = 
		{
			Technology = "Enum:Technology";
		};
		
		Defaults = 
		{ 
			LegacyOutlines = false;
			Technology = Enum.Technology.Compatibility;
		};
		
		Redirect = 
		{
			Outlines = "LegacyOutlines";
		};
		
		Remove = 
		{ 
			"ClockTime";
		};
	};
	
	LocalizationService = 
	{
		Remove =
		{
			"ForcePlayModeGameLocaleId";
			"ForcePlayModeRobloxLocaleId";
			"RobloxForcePlayModeGameLocaleId";
			"RobloxForcePlayModeRobloxLocaleId";
		} 
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
	
	LuaSourceContainer = 
	{
		Add      = { ScriptGuid = "string" };
		Defaults = { ScriptGuid = ""       };
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
		Add      = { ModelInPrimary = "CFrame"     };
		Defaults = { ModelInPrimary = CFrame.new() };
	};
	
	NotificationService = 
	{
		Remove = {"SelectedTheme"}
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
		
		Defaults = 
		{
			AssetId = "";
			ChildData = "";
			MeshData = "";
			FormFactor = Enum.FormFactor.Custom;
		};
	};
	
	PartOperationAsset = 
	{
		Add = 
		{
			ChildData = "BinaryString";
			MeshData = "BinaryString";
		};
		
		Defaults = 
		{
			ChildData = "";
			MeshData = "";
		};
	};
	
	Players =
	{
		Defaults =
		{
			MaxPlayersInternal = 16;
			PreferredPlayersInternal = 0;
		}
	};
	
	RenderingTest = 
	{
		Remove =
		{
			"Position";
			"Orientation";
		};
	};
	
	ScriptContext = 
	{
		Remove = { "ScriptsDisabled" }
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
			EmitterSize = "xmlRead_MinDistance_3";
			MaxDistance = "xmlRead_MaxDistance_3";
			
			MinDistance = "EmitterSize";
			Pitch = "PlaybackSpeed";
		};
	};
	
	Sparkles = 
	{
		Redirect = { Color = "SparkleColor" };
	};
	
	StudioData = 
	{
		Defaults = 
		{
			SrcPlaceId = 0;
			SrcUniverseId = 0;
		};
	};
	
	TextBox = GuiTextMixIn;
	TextLabel = GuiTextMixIn;
	TextButton = GuiTextMixIn;
	
	Terrain = 
	{
		Add = 
		{
			ClusterGrid = "string";
			ClusterGridV2 = "string";
			ClusterGridV3 = "BinaryString";
			
			SmoothGrid = "BinaryString";
			PhysicsGrid = "BinaryString";
		};
		
		Defaults = 
		{
			ClusterGrid = "";
			ClusterGridV2 = "";
			ClusterGridV3 = "";
			
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
	
	Tool =
	{
		Remove =
		{
			"GripForward";
			"GripPos";
			"GripRight";
			"GripUp";
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
			LODData = "";
			PhysicsData = "";
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
		
		Remove = {"CurrentCamera"};
	};
	
	WeldConstraint =
	{
		Add = 
		{
			Part0Internal = "Class:BasePart";
			Part1Internal = "Class:BasePart";
			
			CFrame0 = "CFrame";
			CFrame1 = "CFrame";
		};
		
		Defaults =
		{
			CFrame0 = CFrame.new();
			CFrame1 = CFrame.new();
			
			Part0 = Instance.new("Part");
			Part1 = Instance.new("Part");
		};
		
		Redirect =
		{
			Part0 = "Part0Internal";
			Part1 = "Part1Internal";
		};
	};
	
	Workspace =
	{
		Add =
		{
			AutoJointsMode = "Enum:AutoJointsMode";
			CollisionGroups = "string";
			ExplicitAutoJoints = "bool";
			
			StreamingMinRadius = "int";
			StreamingTargetRadius = "int";
			StreamingPauseMode = "Enum:StreamingPauseMode";
			
			TerrainWeldsFixed = "bool";
		};
		
		Defaults =
		{
			AutoJointsMode = Enum.AutoJointsMode.Default;
			CollisionGroups = "Default^0^1";
			ExplicitAutoJoints = true;
			
			StreamingMinRadius = 64;
			StreamingTargetRadius = 1024;
			StreamingPauseMode = Enum.StreamingPauseMode.Default;
			
			TerrainWeldsFixed = true;
		}
	}
}