// Auto-generated list of creatable Roblox classes.
// Updated as of 0.458.1.415373

using System;

using RobloxFiles.DataTypes;
using RobloxFiles.Enums;
using RobloxFiles.Utility;

#pragma warning disable CA1041  // Provide ObsoleteAttribute message
#pragma warning disable CA1051  // Do not declare visible instance fields
#pragma warning disable CA1707  // Identifiers should not contain underscores
#pragma warning disable CA1716  // Identifiers should not match keywords
#pragma warning disable IDE1006 // Naming Styles

namespace RobloxFiles
{
    public class ABTestService : Instance
    {
        public ABTestService()
        {
            IsService = true;
        }
    }

    public class Accoutrement : Instance
    {
        public CFrame AttachmentPoint = new CFrame();
    }

    public class Accessory : Accoutrement
    {
    }

    public class Hat : Accoutrement
    {
    }

    public class AdService : Instance
    {
        public AdService()
        {
            IsService = true;
        }
    }

    public class AdvancedDragger : Instance
    {
    }

    public class AnalyticsService : Instance
    {
        public AnalyticsService()
        {
            IsService = true;
        }

        [Obsolete]
        public string ApiKey = "";
    }

    public class Animation : Instance
    {
        public Content AnimationId = "";
    }

    public class AnimationController : Instance
    {
    }

    public class Animator : Instance
    {
    }

    public class AppUpdateService : Instance
    {
        public AppUpdateService()
        {
            IsService = true;
        }
    }

    public class AssetCounterService : Instance
    {
        public AssetCounterService()
        {
            IsService = true;
        }
    }

    public class AssetManagerService : Instance
    {
        public AssetManagerService()
        {
            IsService = true;
        }
    }

    public class AssetService : Instance
    {
        public AssetService()
        {
            IsService = true;
        }
    }

    public class Atmosphere : Instance
    {
        public Color3 Color = Color3.FromRGB(199, 170, 107);
        public Color3 Decay = Color3.FromRGB(92, 60, 13);
        public float Density = 0.395f;
        public float Glare;
        public float Haze;
        public float Offset;
    }

    public class Attachment : Instance
    {
        public CFrame CFrame = new CFrame();
        public bool Visible;
    }

    public class Bone : Attachment
    {
    }

    public class AvatarEditorService : Instance
    {
        public AvatarEditorService()
        {
            IsService = true;
        }
    }

    public class Backpack : Instance
    {
    }

    public abstract class BackpackItem : Instance
    {
        public Content TextureId = "";
    }

    public class HopperBin : BackpackItem
    {
        public bool Active;
        public BinType BinType = BinType.Script;
    }

    public class Tool : BackpackItem
    {
        public bool CanBeDropped = true;
        public bool Enabled = true;
        public CFrame Grip = new CFrame();
        public bool ManualActivationOnly;
        public bool RequiresHandle = true;
        public string ToolTip = "";
    }

    public class Flag : Tool
    {
        public BrickColor TeamColor = BrickColor.FromNumber(194);
    }

    public class BadgeService : Instance
    {
        public BadgeService()
        {
            IsService = true;
        }
    }

    public abstract class BasePlayerGui : Instance
    {
    }

    public class CoreGui : BasePlayerGui
    {
        public CoreGui()
        {
            IsService = true;
        }

        public GuiObject SelectionImageObject;
    }

    public class StarterGui : BasePlayerGui
    {
        public StarterGui()
        {
            IsService = true;
        }

        [Obsolete]
        public bool ResetPlayerGuiOnSpawn = true;

        public ScreenOrientation ScreenOrientation = ScreenOrientation.LandscapeSensor;
        public bool ShowDevelopmentGui = true;
    }

    public abstract class BaseWrap : Instance
    {
        public Content CageMeshId = "";
        public CFrame CageOrigin = new CFrame();
        public CFrame ImportOrigin = new CFrame();
    }

    public class WrapLayer : BaseWrap
    {
        public CFrame BindOffset = new CFrame();
        public bool Enabled = true;
        public int Order = 1;
        public float Puffiness = 1;
        public Content ReferenceMeshId = "";
        public CFrame ReferenceOrigin = new CFrame();
        public float ShrinkFactor;
    }

    public class WrapTarget : BaseWrap
    {
        public float Stiffness = 0.9f;
    }

    public class Beam : Instance
    {
        public Attachment Attachment0;
        public Attachment Attachment1;
        public ColorSequence Color = new ColorSequence(1, 1, 1);
        public float CurveSize0;
        public float CurveSize1;
        public bool Enabled = true;
        public bool FaceCamera;
        public float LightEmission;
        public float LightInfluence;
        public int Segments = 10;
        public Content Texture = "";
        public float TextureLength = 1;
        public TextureMode TextureMode = TextureMode.Stretch;
        public float TextureSpeed = 1;
        public NumberSequence Transparency = new NumberSequence(0.5f);
        public float Width0 = 1;
        public float Width1 = 1;
        public float ZOffset;
    }

    public class BindableEvent : Instance
    {
    }

    public class BindableFunction : Instance
    {
    }

    public abstract class BodyMover : Instance
    {
    }

    public class BodyAngularVelocity : BodyMover
    {
        public Vector3 AngularVelocity = new Vector3(0, 2, 0);
        public Vector3 MaxTorque = new Vector3(4000, 4000, 4000);
        public float P = 1250;

        [Obsolete]
        public Vector3 angularvelocity
        {
            get => AngularVelocity;
            set => AngularVelocity = value;
        }

        [Obsolete]
        public Vector3 maxTorque
        {
            get => MaxTorque;
            set => MaxTorque = value;
        }
    }

    public class BodyForce : BodyMover
    {
        public Vector3 Force = new Vector3(0, 1, 0);

        [Obsolete]
        public Vector3 force
        {
            get => Force;
            set => Force = value;
        }
    }

    public class BodyGyro : BodyMover
    {
        public CFrame CFrame = new CFrame();
        public float D = 500;
        public Vector3 MaxTorque = new Vector3(400000, 0, 400000);
        public float P = 3000;

        [Obsolete]
        public CFrame cframe
        {
            get => CFrame;
            set => CFrame = value;
        }

        [Obsolete]
        public Vector3 maxTorque
        {
            get => MaxTorque;
            set => MaxTorque = value;
        }
    }

    public class BodyPosition : BodyMover
    {
        public float D = 1250;
        public Vector3 MaxForce = new Vector3(4000, 4000, 4000);
        public float P = 10000;
        public Vector3 Position = new Vector3(0, 50, 0);

        [Obsolete]
        public Vector3 maxForce
        {
            get => MaxForce;
            set => MaxForce = value;
        }

        [Obsolete]
        public Vector3 position
        {
            get => Position;
            set => Position = value;
        }
    }

    public class BodyThrust : BodyMover
    {
        public Vector3 Force = new Vector3(0, 1, 0);
        public Vector3 Location = new Vector3();

        [Obsolete]
        public Vector3 force
        {
            get => Force;
            set => Force = value;
        }

        [Obsolete]
        public Vector3 location
        {
            get => Location;
            set => Location = value;
        }
    }

    public class BodyVelocity : BodyMover
    {
        public Vector3 MaxForce = new Vector3(4000, 4000, 4000);
        public float P = 1250;
        public Vector3 Velocity = new Vector3(0, 2, 0);

        [Obsolete]
        public Vector3 maxForce
        {
            get => MaxForce;
            set => MaxForce = value;
        }

        [Obsolete]
        public Vector3 velocity
        {
            get => Velocity;
            set => Velocity = value;
        }
    }

    public class RocketPropulsion : BodyMover
    {
        public float CartoonFactor = 0.7f;
        public float MaxSpeed = 30;
        public float MaxThrust = 4000;
        public Vector3 MaxTorque = new Vector3(400000, 400000, 0);
        public BasePart Target;
        public Vector3 TargetOffset = new Vector3();
        public float TargetRadius = 4;
        public float ThrustD = 0.001f;
        public float ThrustP = 5;
        public float TurnD = 500;
        public float TurnP = 3000;
    }

    public class BrowserService : Instance
    {
        public BrowserService()
        {
            IsService = true;
        }
    }

    public class BulkImportService : Instance
    {
        public BulkImportService()
        {
            IsService = true;
        }
    }

    public abstract class CacheableContentProvider : Instance
    {
        public CacheableContentProvider()
        {
            IsService = true;
        }
    }

    public class MeshContentProvider : CacheableContentProvider
    {
        public MeshContentProvider()
        {
            IsService = true;
        }
    }

    public class SolidModelContentProvider : CacheableContentProvider
    {
        public SolidModelContentProvider()
        {
            IsService = true;
        }
    }

    public class Camera : Instance
    {
        public CFrame CFrame = new CFrame(0, 20, 20, 1, 0, 0, 0, 0.70711f, 0.70711f, 0, -0.70711f, 0.70711f);
        public Instance CameraSubject;
        public CameraType CameraType = CameraType.Fixed;

        [Obsolete]
        public CFrame CoordinateFrame
        {
            get => CFrame;
            set => CFrame = value;
        }

        public float FieldOfView = 70;
        public FieldOfViewMode FieldOfViewMode = FieldOfViewMode.Vertical;
        public CFrame Focus = new CFrame(0, 0, -5);
        public bool HeadLocked = true;
        public float HeadScale = 1;

        [Obsolete]
        public CFrame focus
        {
            get => Focus;
            set => Focus = value;
        }
    }

    public class ChangeHistoryService : Instance
    {
        public ChangeHistoryService()
        {
            IsService = true;
        }
    }

    public abstract class CharacterAppearance : Instance
    {
    }

    public class BodyColors : CharacterAppearance
    {
        public BrickColor HeadColor
        {
            get => BrickColor.FromColor3(HeadColor3);
            set => HeadColor3 = value?.Color;
        }

        public Color3 HeadColor3 = Color3.FromRGB(253, 234, 141);

        public BrickColor LeftArmColor
        {
            get => BrickColor.FromColor3(LeftArmColor3);
            set => LeftArmColor3 = value?.Color;
        }

        public Color3 LeftArmColor3 = Color3.FromRGB(253, 234, 141);

        public BrickColor LeftLegColor
        {
            get => BrickColor.FromColor3(LeftLegColor3);
            set => LeftLegColor3 = value?.Color;
        }

        public Color3 LeftLegColor3 = Color3.FromRGB(13, 105, 172);

        public BrickColor RightArmColor
        {
            get => BrickColor.FromColor3(RightArmColor3);
            set => RightArmColor3 = value?.Color;
        }

        public Color3 RightArmColor3 = Color3.FromRGB(253, 234, 141);

        public BrickColor RightLegColor
        {
            get => BrickColor.FromColor3(RightLegColor3);
            set => RightLegColor3 = value?.Color;
        }

        public Color3 RightLegColor3 = Color3.FromRGB(13, 105, 172);

        public BrickColor TorsoColor
        {
            get => BrickColor.FromColor3(TorsoColor3);
            set => TorsoColor3 = value?.Color;
        }

        public Color3 TorsoColor3 = Color3.FromRGB(40, 127, 71);
    }

    public class CharacterMesh : CharacterAppearance
    {
        public long BaseTextureId;
        public BodyPart BodyPart = BodyPart.Head;
        public long MeshId;
        public long OverlayTextureId;
    }

    public abstract class Clothing : CharacterAppearance
    {
        public Color3 Color3 = new Color3(1, 1, 1);
    }

    public class Pants : Clothing
    {
        public Content PantsTemplate = "";
    }

    public class Shirt : Clothing
    {
        public Content ShirtTemplate = "";
    }

    public class ShirtGraphic : CharacterAppearance
    {
        public Color3 Color3 = new Color3(1, 1, 1);
        public Content Graphic = "";
    }

    public class Skin : CharacterAppearance
    {
        public BrickColor SkinColor = BrickColor.FromNumber(226);
    }

    public class Chat : Instance
    {
        public Chat()
        {
            IsService = true;
        }

        public bool BubbleChatEnabled;
        public bool LoadDefaultChat = true;
    }

    public class ClickDetector : Instance
    {
        public Content CursorIcon = "";
        public float MaxActivationDistance = 32;
    }

    public class Clouds : Instance
    {
        public float Cover = 0.5f;
        public float Density = 0.7f;
    }

    public class CollectionService : Instance
    {
        public CollectionService()
        {
            IsService = true;
        }
    }

    public class Configuration : Instance
    {
    }

    public abstract class Constraint : Instance
    {
        public Attachment Attachment0;
        public Attachment Attachment1;
        public BrickColor Color = BrickColor.FromNumber(23);
        public bool Enabled = true;
        public bool Visible;
    }

    public class AlignOrientation : Constraint
    {
        public AlignType AlignType = AlignType.Parallel;
        public float MaxAngularVelocity = float.MaxValue;
        public float MaxTorque = 10000;
        public bool PrimaryAxisOnly;
        public bool ReactionTorqueEnabled;
        public float Responsiveness = 10;
        public bool RigidityEnabled;
    }

    public class AlignPosition : Constraint
    {
        public bool ApplyAtCenterOfMass;
        public float MaxForce = 10000;
        public float MaxVelocity = float.MaxValue;
        public bool ReactionForceEnabled;
        public float Responsiveness = 10;
        public bool RigidityEnabled;
    }

    public class AngularVelocity : Constraint
    {
        public Vector3 AngularVelocity_ = new Vector3();
        public float MaxTorque;
        public bool ReactionTorqueEnabled;
        public ActuatorRelativeTo RelativeTo = ActuatorRelativeTo.World;
    }

    public class BallSocketConstraint : Constraint
    {
        public bool LimitsEnabled;
        public float MaxFrictionTorqueXml;
        public float Radius = 0.15f;
        public float Restitution;
        public bool TwistLimitsEnabled;
        public float TwistLowerAngle = -45;
        public float TwistUpperAngle = 45;
        public float UpperAngle = 45;
    }

    public class HingeConstraint : Constraint
    {
        public ActuatorType ActuatorType = ActuatorType.None;
        public float AngularSpeed;
        public float AngularVelocity;
        public bool LimitsEnabled;
        public float LowerAngle = -45;
        public float MotorMaxAcceleration = float.MaxValue;
        public float MotorMaxTorque;
        public float Radius = 0.15f;
        public float Restitution;
        public float ServoMaxTorque;
        public float TargetAngle;
        public float UpperAngle = 45;
    }

    public class LineForce : Constraint
    {
        public bool ApplyAtCenterOfMass;
        public bool InverseSquareLaw;
        public float Magnitude = 1000;
        public float MaxForce = float.MaxValue;
        public bool ReactionForceEnabled;
    }

    public class RodConstraint : Constraint
    {
        public float Length = 5;
        public float Thickness = 0.1f;
    }

    public class RopeConstraint : Constraint
    {
        public float Length = 5;
        public float Restitution;
        public float Thickness = 0.1f;
    }

    public abstract class SlidingBallConstraint : Constraint
    {
        public ActuatorType ActuatorType = ActuatorType.None;
        public bool LimitsEnabled;
        public float LowerLimit;
        public float MotorMaxAcceleration = float.MaxValue;
        public float MotorMaxForce;
        public float Restitution;
        public float ServoMaxForce;
        public float Size = 0.15f;
        public float Speed;
        public float TargetPosition;
        public float UpperLimit = 5;
        public float Velocity;
    }

    public class CylindricalConstraint : SlidingBallConstraint
    {
        public ActuatorType AngularActuatorType = ActuatorType.None;
        public bool AngularLimitsEnabled;
        public float AngularRestitution;
        public float AngularSpeed;
        public float AngularVelocity;
        public float InclinationAngle;
        public float LowerAngle = -45;
        public float MotorMaxAngularAcceleration = float.MaxValue;
        public float MotorMaxTorque;
        public bool RotationAxisVisible;
        public float ServoMaxTorque;
        public float TargetAngle;
        public float UpperAngle = 45;
    }

    public class PrismaticConstraint : SlidingBallConstraint
    {
    }

    public class SpringConstraint : Constraint
    {
        public float Coils = 3;
        public float Damping;
        public float FreeLength = 1;
        public bool LimitsEnabled;
        public float MaxForce = float.MaxValue;
        public float MaxLength = 5;
        public float MinLength;
        public float Radius = 0.4f;
        public float Stiffness;
        public float Thickness = 0.1f;
    }

    public class Torque : Constraint
    {
        public ActuatorRelativeTo RelativeTo = ActuatorRelativeTo.Attachment0;
        public Vector3 Torque_ = new Vector3();
    }

    public class VectorForce : Constraint
    {
        public bool ApplyAtCenterOfMass;
        public Vector3 Force = new Vector3(1000, 0, 0);
        public ActuatorRelativeTo RelativeTo = ActuatorRelativeTo.Attachment0;
    }

    public class ContentProvider : Instance
    {
        public ContentProvider()
        {
            IsService = true;
        }
    }

    public class ContextActionService : Instance
    {
        public ContextActionService()
        {
            IsService = true;
        }
    }

    public abstract class Controller : Instance
    {
    }

    public class HumanoidController : Controller
    {
    }

    public class SkateboardController : Controller
    {
    }

    public class VehicleController : Controller
    {
    }

    public class ControllerService : Instance
    {
        public ControllerService()
        {
            IsService = true;
        }
    }

    public class CookiesService : Instance
    {
        public CookiesService()
        {
            IsService = true;
        }
    }

    public class CorePackages : Instance
    {
        public CorePackages()
        {
            IsService = true;
        }
    }

    public class CoreScriptSyncService : Instance
    {
        public CoreScriptSyncService()
        {
            IsService = true;
        }
    }

    public class CustomEvent : Instance
    {
        public float PersistedCurrentValue;
    }

    public class CustomEventReceiver : Instance
    {
        public Instance Source;
    }

    public abstract class DataModelMesh : Instance
    {
        public LevelOfDetailSetting LODX = LevelOfDetailSetting.High;
        public LevelOfDetailSetting LODY = LevelOfDetailSetting.High;
        public Vector3 Offset = new Vector3();
        public Vector3 Scale = new Vector3(1, 1, 1);
        public Vector3 VertexColor = new Vector3(1, 1, 1);
    }

    public abstract class BevelMesh : DataModelMesh
    {
        public float Bevel;
        public float Bevel_Roundness;
        public float Bulge;
    }

    public class BlockMesh : BevelMesh
    {
    }

    public class CylinderMesh : BevelMesh
    {
    }

    public class FileMesh : DataModelMesh
    {
        public Content MeshId = "";
        public Content TextureId = "";
    }

    public class SpecialMesh : FileMesh
    {
        public MeshType MeshType = MeshType.Head;
    }

    public class DataStoreService : Instance
    {
        public DataStoreService()
        {
            IsService = true;
        }

        public bool AutomaticRetry = true;

        [Obsolete]
        public bool LegacyNamingScheme;
    }

    public class Debris : Instance
    {
        public Debris()
        {
            IsService = true;
        }

        [Obsolete]
        public int MaxItems = 1000;
    }

    public class DebuggerWatch : Instance
    {
        public string Expression = "";
    }

    public class Dialog : Instance
    {
        public DialogBehaviorType BehaviorType = DialogBehaviorType.SinglePlayer;
        public float ConversationDistance = 25;
        public bool GoodbyeChoiceActive = true;
        public string GoodbyeDialog = "";
        public string InitialPrompt = "";
        public DialogPurpose Purpose = DialogPurpose.Help;
        public DialogTone Tone = DialogTone.Neutral;
        public float TriggerDistance;
        public Vector3 TriggerOffset = new Vector3();
    }

    public class DialogChoice : Instance
    {
        public bool GoodbyeChoiceActive = true;
        public string GoodbyeDialog = "";
        public string ResponseDialog = "";
        public string UserDialog = "";
    }

    public class DraftsService : Instance
    {
        public DraftsService()
        {
            IsService = true;
        }
    }

    public class Dragger : Instance
    {
    }

    public class EventIngestService : Instance
    {
        public EventIngestService()
        {
            IsService = true;
        }
    }

    public class Explosion : Instance
    {
        public float BlastPressure = 500000;
        public float BlastRadius = 4;
        public float DestroyJointRadiusPercent = 1;
        public ExplosionType ExplosionType = ExplosionType.Craters;
        public Vector3 Position = new Vector3();
        public bool Visible = true;
    }

    public abstract class FaceInstance : Instance
    {
        public NormalId Face = NormalId.Front;
    }

    public class Decal : FaceInstance
    {
        public Color3 Color3 = new Color3(1, 1, 1);

        [Obsolete]
        public float Shiny = 20;

        [Obsolete]
        public float Specular;

        public Content Texture = "";
        public float Transparency;
    }

    public class Texture : Decal
    {
        public float OffsetStudsU;
        public float OffsetStudsV;
        public float StudsPerTileU = 2;
        public float StudsPerTileV = 2;
    }

    public abstract class Feature : Instance
    {
        public NormalId FaceId = NormalId.Right;
        public InOut InOut = InOut.Center;
        public LeftRight LeftRight = LeftRight.Center;
        public TopBottom TopBottom = TopBottom.Center;
    }

    public class Hole : Feature
    {
    }

    public class MotorFeature : Feature
    {
    }

    public class Fire : Instance
    {
        public Color3 Color = Color3.FromRGB(236, 139, 70);
        public bool Enabled = true;

        public float Heat
        {
            get => heat_xml;
            set => heat_xml = value;
        }

        public Color3 SecondaryColor = Color3.FromRGB(139, 80, 55);

        public float Size
        {
            get => size_xml;
            set => size_xml = value;
        }

        public float heat_xml = 9;

        [Obsolete]
        public float size
        {
            get => Size;
            set => Size = value;
        }

        public float size_xml = 5;
    }

    public class FlyweightService : Instance
    {
        public FlyweightService()
        {
            IsService = true;
        }
    }

    public class CSGDictionaryService : FlyweightService
    {
        public CSGDictionaryService()
        {
            IsService = true;
        }
    }

    public class NonReplicatedCSGDictionaryService : FlyweightService
    {
        public NonReplicatedCSGDictionaryService()
        {
            IsService = true;
        }
    }

    public class Folder : Instance
    {
    }

    public class ForceField : Instance
    {
        public bool Visible = true;
    }

    public class FriendService : Instance
    {
        public FriendService()
        {
            IsService = true;
        }
    }

    public class FunctionalTest : Instance
    {
        public string Description = "?";
        public bool HasMigratedSettingsToTestService;
    }

    public class GamePassService : Instance
    {
        public GamePassService()
        {
            IsService = true;
        }
    }

    public class GamepadService : Instance
    {
        public GamepadService()
        {
            IsService = true;
        }
    }

    public class Geometry : Instance
    {
        public Geometry()
        {
            IsService = true;
        }
    }

    public class GroupService : Instance
    {
        public GroupService()
        {
            IsService = true;
        }
    }

    public abstract class GuiBase : Instance
    {
    }

    public abstract class GuiBase2d : GuiBase
    {
        public bool AutoLocalize = true;

        [Obsolete]
        public bool Localize
        {
            get => AutoLocalize;
            set => AutoLocalize = value;
        }

        public LocalizationTable RootLocalizationTable;
    }

    public abstract class GuiObject : GuiBase2d
    {
        public bool Active;
        public Vector2 AnchorPoint = new Vector2();
        public AutomaticSize AutomaticSize = AutomaticSize.None;

        [Obsolete]
        public BrickColor BackgroundColor
        {
            get => BrickColor.FromColor3(BackgroundColor3);
            set => BackgroundColor3 = value?.Color;
        }

        public Color3 BackgroundColor3 = Color3.FromRGB(163, 162, 165);
        public float BackgroundTransparency;

        [Obsolete]
        public BrickColor BorderColor
        {
            get => BrickColor.FromColor3(BorderColor3);
            set => BorderColor3 = value?.Color;
        }

        public Color3 BorderColor3 = Color3.FromRGB(27, 42, 53);
        public BorderMode BorderMode = BorderMode.Outline;
        public int BorderSizePixel = 1;
        public bool ClipsDescendants;

        [Obsolete]
        public bool Draggable;

        public int LayoutOrder;
        public GuiObject NextSelectionDown;
        public GuiObject NextSelectionLeft;
        public GuiObject NextSelectionRight;
        public GuiObject NextSelectionUp;
        public UDim2 Position = new UDim2();
        public float Rotation;
        public bool Selectable;
        public GuiObject SelectionImageObject;
        public UDim2 Size = new UDim2();
        public SizeConstraint SizeConstraint = SizeConstraint.RelativeXY;

        public float Transparency
        {
            get => BackgroundTransparency;
            set => BackgroundTransparency = value;
        }

        public bool Visible = true;
        public int ZIndex = 1;
    }

    public class Frame : GuiObject
    {
        public FrameStyle Style = FrameStyle.Custom;
    }

    public abstract class GuiButton : GuiObject
    {
        public bool AutoButtonColor = true;
        public bool Modal;
        public bool Selected;
        public ButtonStyle Style = ButtonStyle.Custom;
    }

    public class ImageButton : GuiButton
    {
        public Content HoverImage = "";
        public Content Image = "";
        public Color3 ImageColor3 = new Color3(1, 1, 1);
        public Vector2 ImageRectOffset = new Vector2();
        public Vector2 ImageRectSize = new Vector2();
        public float ImageTransparency;
        public Content PressedImage = "";
        public ScaleType ScaleType = ScaleType.Stretch;
        public Rect SliceCenter = new Rect(new Vector2(), new Vector2());
        public float SliceScale = 1;
        public UDim2 TileSize = new UDim2(1, 0, 1, 0);
    }

    public class TextButton : GuiButton
    {
        public Font Font = Font.Legacy;

        [Obsolete]
        public FontSize FontSize
        {
            get => FontUtility.GetFontSize(TextSize);
            set => TextSize = FontUtility.GetFontSize(value);
        }

        public float LineHeight = 1;
        public bool RichText;
        public string Text = "Button";

        [Obsolete]
        public BrickColor TextColor
        {
            get => BrickColor.FromColor3(TextColor3);
            set => TextColor3 = value?.Color;
        }

        public Color3 TextColor3 = Color3.FromRGB(27, 42, 53);
        public bool TextScaled;
        public float TextSize = 8;
        public Color3 TextStrokeColor3 = new Color3();
        public float TextStrokeTransparency = 1;
        public float TextTransparency;
        public TextTruncate TextTruncate = TextTruncate.None;

        [Obsolete]
        public bool TextWrap
        {
            get => TextWrapped;
            set => TextWrapped = value;
        }

        public bool TextWrapped;
        public TextXAlignment TextXAlignment = TextXAlignment.Center;
        public TextYAlignment TextYAlignment = TextYAlignment.Center;

        public new float Transparency
        {
            get => base.Transparency;

            set
            {
                base.Transparency = value;
                TextTransparency = value;
            }
        }
    }

    public abstract class GuiLabel : GuiObject
    {
    }

    public class ImageLabel : GuiLabel
    {
        public Content Image = "";
        public Color3 ImageColor3 = new Color3(1, 1, 1);
        public Vector2 ImageRectOffset = new Vector2();
        public Vector2 ImageRectSize = new Vector2();
        public float ImageTransparency;
        public ScaleType ScaleType = ScaleType.Stretch;
        public Rect SliceCenter = new Rect(new Vector2(), new Vector2());
        public float SliceScale = 1;
        public UDim2 TileSize = new UDim2(1, 0, 1, 0);
    }

    public class TextLabel : GuiLabel
    {
        public Font Font = Font.Legacy;

        [Obsolete]
        public FontSize FontSize
        {
            get => FontUtility.GetFontSize(TextSize);
            set => TextSize = FontUtility.GetFontSize(value);
        }

        public float LineHeight = 1;
        public bool RichText;
        public string Text = "Label";

        [Obsolete]
        public BrickColor TextColor
        {
            get => BrickColor.FromColor3(TextColor3);
            set => TextColor3 = value?.Color;
        }

        public Color3 TextColor3 = Color3.FromRGB(27, 42, 53);
        public bool TextScaled;
        public float TextSize = 8;
        public Color3 TextStrokeColor3 = new Color3();
        public float TextStrokeTransparency = 1;
        public float TextTransparency;
        public TextTruncate TextTruncate = TextTruncate.None;

        [Obsolete]
        public bool TextWrap
        {
            get => TextWrapped;
            set => TextWrapped = value;
        }

        public bool TextWrapped;
        public TextXAlignment TextXAlignment = TextXAlignment.Center;
        public TextYAlignment TextYAlignment = TextYAlignment.Center;

        public new float Transparency
        {
            get => base.Transparency;

            set
            {
                base.Transparency = value;
                TextTransparency = value;
            }
        }
    }

    public class ScrollingFrame : GuiObject
    {
        public AutomaticSize AutomaticCanvasSize = AutomaticSize.None;
        public Content BottomImage = "rbxasset://textures/ui/Scroll/scroll-bottom.png";
        public Vector2 CanvasPosition = new Vector2();
        public UDim2 CanvasSize = new UDim2(0, 0, 2, 0);
        public ElasticBehavior ElasticBehavior = ElasticBehavior.WhenScrollable;
        public ScrollBarInset HorizontalScrollBarInset = ScrollBarInset.None;
        public Content MidImage = "rbxasset://textures/ui/Scroll/scroll-middle.png";
        public Color3 ScrollBarImageColor3 = new Color3(1, 1, 1);
        public float ScrollBarImageTransparency;
        public int ScrollBarThickness = 12;
        public ScrollingDirection ScrollingDirection = ScrollingDirection.XY;
        public bool ScrollingEnabled = true;
        public Content TopImage = "rbxasset://textures/ui/Scroll/scroll-top.png";
        public ScrollBarInset VerticalScrollBarInset = ScrollBarInset.None;
        public VerticalScrollBarPosition VerticalScrollBarPosition = VerticalScrollBarPosition.Right;
    }

    public class TextBox : GuiObject
    {
        public bool ClearTextOnFocus = true;
        public Font Font = Font.Legacy;

        [Obsolete]
        public FontSize FontSize
        {
            get => FontUtility.GetFontSize(TextSize);
            set => TextSize = FontUtility.GetFontSize(value);
        }

        public float LineHeight = 1;
        public bool MultiLine;
        public Color3 PlaceholderColor3 = Color3.FromRGB(178, 178, 178);
        public string PlaceholderText = "";
        public bool RichText;
        public bool ShowNativeInput = true;
        public string Text = "TextBox";

        [Obsolete]
        public BrickColor TextColor
        {
            get => BrickColor.FromColor3(TextColor3);
            set => TextColor3 = value?.Color;
        }

        public Color3 TextColor3 = Color3.FromRGB(27, 42, 53);
        public bool TextEditable = true;
        public bool TextScaled;
        public float TextSize = 8;
        public Color3 TextStrokeColor3 = new Color3();
        public float TextStrokeTransparency = 1;
        public float TextTransparency;
        public TextTruncate TextTruncate = TextTruncate.None;

        [Obsolete]
        public bool TextWrap
        {
            get => TextWrapped;
            set => TextWrapped = value;
        }

        public bool TextWrapped;
        public TextXAlignment TextXAlignment = TextXAlignment.Center;
        public TextYAlignment TextYAlignment = TextYAlignment.Center;

        public new float Transparency
        {
            get => base.Transparency;

            set
            {
                base.Transparency = value;
                TextTransparency = value;
            }
        }
    }

    public class VideoFrame : GuiObject
    {
        public bool Looped;
        public bool Playing;
        public double TimePosition;
        public Content Video = "";
        public float Volume = 1;
    }

    public class ViewportFrame : GuiObject
    {
        public Color3 Ambient = Color3.FromRGB(200, 200, 200);
        public CFrame CameraCFrame = new CFrame();
        public float CameraFieldOfView = 70;
        public Color3 ImageColor3 = new Color3(1, 1, 1);
        public float ImageTransparency;
        public Color3 LightColor = Color3.FromRGB(140, 140, 140);
        public Vector3 LightDirection = new Vector3(-1, -1, -1);
    }

    public abstract class LayerCollector : GuiBase2d
    {
        public bool Enabled = true;
        public bool ResetOnSpawn = true;
        public ZIndexBehavior ZIndexBehavior = ZIndexBehavior.Global;
    }

    public class BillboardGui : LayerCollector
    {
        public bool Active;
        public Instance Adornee;
        public bool AlwaysOnTop;
        public bool ClipsDescendants;
        public float DistanceLowerLimit;
        public float DistanceStep;
        public float DistanceUpperLimit = -1;
        public Vector3 ExtentsOffset = new Vector3();
        public Vector3 ExtentsOffsetWorldSpace = new Vector3();
        public float LightInfluence;
        public float MaxDistance = float.MaxValue;
        public Instance PlayerToHideFrom;
        public UDim2 Size = new UDim2();
        public Vector2 SizeOffset = new Vector2();
        public Vector3 StudsOffset = new Vector3();
        public Vector3 StudsOffsetWorldSpace = new Vector3();
    }

    public class ScreenGui : LayerCollector
    {
        public int DisplayOrder;
        public bool IgnoreGuiInset;
    }

    public class GuiMain : ScreenGui
    {
    }

    public class SurfaceGui : LayerCollector
    {
        public bool Active = true;
        public Instance Adornee;
        public bool AlwaysOnTop;
        public Vector2 CanvasSize = new Vector2(800, 600);
        public bool ClipsDescendants;
        public NormalId Face = NormalId.Front;
        public float LightInfluence;
        public float PixelsPerStud = 50;
        public SurfaceGuiSizingMode SizingMode = SurfaceGuiSizingMode.FixedSize;
        public float ToolPunchThroughDistance;
        public float ZOffset;
    }

    public abstract class GuiBase3d : GuiBase
    {
        [Obsolete]
        public BrickColor Color
        {
            get => BrickColor.FromColor3(Color3);
            set => Color3 = value?.Color;
        }

        public Color3 Color3 = Color3.FromRGB(13, 105, 172);
        public float Transparency;
        public bool Visible = true;
    }

    public class FloorWire : GuiBase3d
    {
        public float CycleOffset;
        public BasePart From;
        public float StudsBetweenTextures = 4;
        public Content Texture = "";
        public Vector2 TextureSize = new Vector2(1, 1);
        public BasePart To;
        public float Velocity = 2;
        public float WireRadius = 0.0625f;
    }

    public abstract class InstanceAdornment : GuiBase3d
    {
        public Instance Adornee;
    }

    public class SelectionBox : InstanceAdornment
    {
        public float LineThickness = 0.15f;

        [Obsolete]
        public BrickColor SurfaceColor
        {
            get => BrickColor.FromColor3(SurfaceColor3);
            set => SurfaceColor3 = value?.Color;
        }

        public Color3 SurfaceColor3 = Color3.FromRGB(13, 105, 172);
        public float SurfaceTransparency = 1;
    }

    public abstract class PVAdornment : GuiBase3d
    {
        public PVInstance Adornee;
    }

    public abstract class HandleAdornment : PVAdornment
    {
        public AdornCullingMode AdornCullingMode = AdornCullingMode.Automatic;
        public bool AlwaysOnTop;
        public CFrame CFrame = new CFrame();
        public Vector3 SizeRelativeOffset = new Vector3();
        public int ZIndex = -1;
    }

    public class BoxHandleAdornment : HandleAdornment
    {
        public Vector3 Size = new Vector3(1, 1, 1);
    }

    public class ConeHandleAdornment : HandleAdornment
    {
        public float Height = 2;
        public float Radius = 0.5f;
    }

    public class CylinderHandleAdornment : HandleAdornment
    {
        public float Angle = 360;
        public float Height = 1;
        public float InnerRadius;
        public float Radius = 1;
    }

    public class ImageHandleAdornment : HandleAdornment
    {
        public Content Image = "rbxasset://textures/SurfacesDefault.png";
        public Vector2 Size = new Vector2(1, 1);
    }

    public class LineHandleAdornment : HandleAdornment
    {
        public float Length = 5;
        public float Thickness = 1;
    }

    public class SphereHandleAdornment : HandleAdornment
    {
        public float Radius = 1;
    }

    public class ParabolaAdornment : PVAdornment
    {
    }

    public class SelectionSphere : PVAdornment
    {
        [Obsolete]
        public BrickColor SurfaceColor
        {
            get => BrickColor.FromColor3(SurfaceColor3);
            set => SurfaceColor3 = value?.Color;
        }

        public Color3 SurfaceColor3 = Color3.FromRGB(13, 105, 172);
        public float SurfaceTransparency = 1;
    }

    public abstract class PartAdornment : GuiBase3d
    {
        public BasePart Adornee;
    }

    public abstract class HandlesBase : PartAdornment
    {
    }

    public class ArcHandles : HandlesBase
    {
        public Axes Axes = (Axes)7;
    }

    public class Handles : HandlesBase
    {
        public Faces Faces = (Faces)63;
        public HandlesStyle Style = HandlesStyle.Resize;
    }

    public class SurfaceSelection : PartAdornment
    {
        public NormalId TargetSurface = NormalId.Right;
    }

    public abstract class SelectionLasso : GuiBase3d
    {
        public Humanoid Humanoid;
    }

    public class SelectionPartLasso : SelectionLasso
    {
        public BasePart Part;
    }

    public class SelectionPointLasso : SelectionLasso
    {
        public Vector3 Point = new Vector3();
    }

    public class GuiService : Instance
    {
        public GuiService()
        {
            IsService = true;
        }

        public bool AutoSelectGuiEnabled = true;
        public bool CoreGuiNavigationEnabled = true;
        public bool GuiNavigationEnabled = true;
        public GuiObject SelectedObject;
    }

    public class HapticService : Instance
    {
        public HapticService()
        {
            IsService = true;
        }
    }

    public class HeightmapImporterService : Instance
    {
        public HeightmapImporterService()
        {
            IsService = true;
        }
    }

    public class HttpRbxApiService : Instance
    {
        public HttpRbxApiService()
        {
            IsService = true;
        }
    }

    public class HttpService : Instance
    {
        public HttpService()
        {
            IsService = true;
        }

        public bool HttpEnabled;
    }

    public class Humanoid : Instance
    {
        public bool AutoJumpEnabled = true;
        public bool AutoRotate = true;
        public bool AutomaticScalingEnabled = true;
        public bool BreakJointsOnDeath = true;
        public HumanoidCollisionType CollisionType = HumanoidCollisionType.OuterBox;
        public HumanoidDisplayDistanceType DisplayDistanceType = HumanoidDisplayDistanceType.Viewer;
        public string DisplayName = "";

        public float Health
        {
            get => Health_XML;
            set => Health_XML = value;
        }

        public float HealthDisplayDistance = 100;
        public HumanoidHealthDisplayType HealthDisplayType = HumanoidHealthDisplayType.DisplayWhenDamaged;
        public float Health_XML = 100;
        public float HipHeight;
        public Vector3 InternalBodyScale = new Vector3(1, 1, 1);
        public float InternalHeadScale = 1;
        public float JumpHeight = 7.2f;
        public float JumpPower = 50;
        public float MaxHealth = 100;
        public float MaxSlopeAngle = 89;
        public float NameDisplayDistance = 100;
        public NameOcclusion NameOcclusion = NameOcclusion.OccludeAll;
        public bool RequiresNeck = true;
        public HumanoidRigType RigType = HumanoidRigType.R6;
        public bool UseJumpPower = true;
        public float WalkSpeed = 16;

        [Obsolete]
        public float maxHealth
        {
            get => MaxHealth;
            set => MaxHealth = value;
        }
    }

    public class HumanoidDescription : Instance
    {
        public string BackAccessory = "";
        public float BodyTypeScale = 0.3f;
        public long ClimbAnimation;
        public float DepthScale = 1;
        public string EmotesDataInternal = "";
        public string EquippedEmotesDataInternal = "";
        public long Face;
        public string FaceAccessory = "";
        public long FallAnimation;
        public string FrontAccessory = "";
        public long GraphicTShirt;
        public string HairAccessory = "";
        public string HatAccessory = "";
        public long Head;
        public Color3 HeadColor = new Color3();
        public float HeadScale = 1;
        public float HeightScale = 1;
        public long IdleAnimation;
        public long JumpAnimation;
        public long LeftArm;
        public Color3 LeftArmColor = new Color3();
        public long LeftLeg;
        public Color3 LeftLegColor = new Color3();
        public string NeckAccessory = "";
        public long Pants;
        public float ProportionScale = 1;
        public long RightArm;
        public Color3 RightArmColor = new Color3();
        public long RightLeg;
        public Color3 RightLegColor = new Color3();
        public long RunAnimation;
        public long Shirt;
        public string ShouldersAccessory = "";
        public long SwimAnimation;
        public long Torso;
        public Color3 TorsoColor = new Color3();
        public string WaistAccessory = "";
        public long WalkAnimation;
        public float WidthScale = 1;
    }

    public abstract class ILegacyStudioBridge : Instance
    {
        public ILegacyStudioBridge()
        {
            IsService = true;
        }
    }

    public class LegacyStudioBridge : ILegacyStudioBridge
    {
        public LegacyStudioBridge()
        {
            IsService = true;
        }
    }

    public class InsertService : Instance
    {
        public InsertService()
        {
            IsService = true;
        }

        public bool AllowClientInsertModels;

        [Obsolete]
        public bool AllowInsertFreeModels;
    }

    public abstract class JointInstance : Instance
    {
        public CFrame C0 = new CFrame();
        public CFrame C1 = new CFrame();
        public bool Enabled = true;
        public BasePart Part0;
        public BasePart Part1;
    }

    public abstract class DynamicRotate : JointInstance
    {
        public float BaseAngle;
    }

    public class RotateP : DynamicRotate
    {
    }

    public class RotateV : DynamicRotate
    {
    }

    public class Glue : JointInstance
    {
        public Vector3 F0 = new Vector3();
        public Vector3 F1 = new Vector3();
        public Vector3 F2 = new Vector3();
        public Vector3 F3 = new Vector3();
    }

    public abstract class ManualSurfaceJointInstance : JointInstance
    {
        public int Surface0 = -1;
        public int Surface1 = -1;
    }

    public class ManualGlue : ManualSurfaceJointInstance
    {
    }

    public class ManualWeld : ManualSurfaceJointInstance
    {
    }

    public class Motor : JointInstance
    {
        public float DesiredAngle;
        public float MaxVelocity;
    }

    public class Motor6D : Motor
    {
    }

    public class Rotate : JointInstance
    {
    }

    public class Snap : JointInstance
    {
    }

    public class VelocityMotor : JointInstance
    {
        public float CurrentAngle;
        public float DesiredAngle;
        public Hole Hole;
        public float MaxVelocity;
    }

    public class Weld : JointInstance
    {
    }

    public class JointsService : Instance
    {
        public JointsService()
        {
            IsService = true;
        }
    }

    public class KeyboardService : Instance
    {
        public KeyboardService()
        {
            IsService = true;
        }
    }

    public class Keyframe : Instance
    {
        public float Time;
    }

    public class KeyframeMarker : Instance
    {
        public string Value = "";
    }

    public class KeyframeSequence : Instance
    {
        public float AuthoredHipHeight = 2;
        public bool Loop = true;
        public AnimationPriority Priority = AnimationPriority.Action;
    }

    public class KeyframeSequenceProvider : Instance
    {
        public KeyframeSequenceProvider()
        {
            IsService = true;
        }
    }

    public class LanguageService : Instance
    {
        public LanguageService()
        {
            IsService = true;
        }
    }

    public abstract class Light : Instance
    {
        public float Brightness = 1;
        public Color3 Color = new Color3(1, 1, 1);
        public bool Enabled = true;
        public bool Shadows;
    }

    public class PointLight : Light
    {
        public float Range = 8;
    }

    public class SpotLight : Light
    {
        public float Angle = 90;
        public NormalId Face = NormalId.Front;
        public float Range = 16;
    }

    public class SurfaceLight : Light
    {
        public float Angle = 90;
        public NormalId Face = NormalId.Front;
        public float Range = 16;
    }

    public class Lighting : Instance
    {
        public Lighting()
        {
            IsService = true;
        }

        public Color3 Ambient = Color3.FromRGB(127, 127, 127);
        public float Brightness = 1;
        public Color3 ColorShift_Bottom = new Color3();
        public Color3 ColorShift_Top = new Color3();
        public float EnvironmentDiffuseScale;
        public float EnvironmentSpecularScale;
        public float ExposureCompensation;
        public Color3 FogColor = Color3.FromRGB(191, 191, 191);
        public float FogEnd = 100000;
        public float FogStart;
        public float GeographicLatitude = 41.7333f;
        public bool GlobalShadows;
        public Color3 OutdoorAmbient = Color3.FromRGB(127, 127, 127);

        [Obsolete]
        public bool Outlines = true;

        [Obsolete]
        public Color3 ShadowColor = Color3.FromRGB(178, 178, 183);

        public float ShadowSoftness = 0.5f;
        public Technology Technology = Technology.Compatibility;
        public string TimeOfDay = "14:00:00";
    }

    public abstract class LocalStorageService : Instance
    {
        public LocalStorageService()
        {
            IsService = true;
        }
    }

    public class AppStorageService : LocalStorageService
    {
        public AppStorageService()
        {
            IsService = true;
        }
    }

    public class LocalizationService : Instance
    {
        public LocalizationService()
        {
            IsService = true;
        }
    }

    public class LocalizationTable : Instance
    {
        public string Contents = "[]";

        [Obsolete]
        public string DevelopmentLanguage
        {
            get => SourceLocaleId;
            set => SourceLocaleId = value;
        }

        public string SourceLocaleId = "en-us";
    }

    public class LogService : Instance
    {
        public LogService()
        {
            IsService = true;
        }
    }

    public abstract class LuaSourceContainer : Instance
    {
        public Content LinkedSource = "";
        public string ScriptGuid = "";
        public ProtectedString Source = "";
    }

    public abstract class BaseScript : LuaSourceContainer
    {
        public bool Disabled;
    }

    public class Script : BaseScript
    {
    }

    public class LocalScript : Script
    {
    }

    public class ModuleScript : LuaSourceContainer
    {
    }

    public class LuaWebService : Instance
    {
        public LuaWebService()
        {
            IsService = true;
        }
    }

    public class MarketplaceService : Instance
    {
        public MarketplaceService()
        {
            IsService = true;
        }
    }

    public class MemStorageService : Instance
    {
        public MemStorageService()
        {
            IsService = true;
        }
    }

    public class Message : Instance
    {
        public string Text = "";
    }

    public class Hint : Message
    {
    }

    public class MessagingService : Instance
    {
        public MessagingService()
        {
            IsService = true;
        }
    }

    public class MouseService : Instance
    {
        public MouseService()
        {
            IsService = true;
        }
    }

    public abstract class NetworkPeer : Instance
    {
    }

    public class NetworkClient : NetworkPeer
    {
        public NetworkClient()
        {
            IsService = true;
        }
    }

    public class NoCollisionConstraint : Instance
    {
        public bool Enabled = true;
        public BasePart Part0;
        public BasePart Part1;
    }

    public class NotificationService : Instance
    {
        public NotificationService()
        {
            IsService = true;
        }
    }

    public abstract class PVInstance : Instance
    {
    }

    public abstract class BasePart : PVInstance
    {
        public bool Anchored;
        public float BackParamA = -0.5f;
        public float BackParamB = 0.5f;
        public SurfaceType BackSurface = SurfaceType.Smooth;
        public InputType BackSurfaceInput = InputType.NoInput;
        public float BottomParamA = -0.5f;
        public float BottomParamB = 0.5f;
        public SurfaceType BottomSurface = SurfaceType.Smooth;
        public InputType BottomSurfaceInput = InputType.NoInput;

        public BrickColor BrickColor
        {
            get => BrickColor.FromColor3(Color);
            set => Color = value?.Color;
        }

        public CFrame CFrame = new CFrame();
        public bool CanCollide = true;
        public bool CastShadow = true;
        public int CollisionGroupId;

        public Color3 Color
        {
            get => Color3uint8;
            set => Color3uint8 = value;
        }

        public Color3uint8 Color3uint8 = Color3.FromRGB(163, 162, 165);
        public PhysicalProperties CustomPhysicalProperties;

        [Obsolete]
        public float Elasticity = 0.5f;

        [Obsolete]
        public float Friction = 0.3f;

        public float FrontParamA = -0.5f;
        public float FrontParamB = 0.5f;
        public SurfaceType FrontSurface = SurfaceType.Smooth;
        public InputType FrontSurfaceInput = InputType.NoInput;
        public float LeftParamA = -0.5f;
        public float LeftParamB = 0.5f;
        public SurfaceType LeftSurface = SurfaceType.Smooth;
        public InputType LeftSurfaceInput = InputType.NoInput;
        public bool Locked;
        public bool Massless;
        public Material Material = Material.Plastic;

        public Vector3 Position
        {
            get => CFrame.Position;
            set => CFrame.Position = value;
        }

        public float Reflectance;
        public float RightParamA = -0.5f;
        public float RightParamB = 0.5f;
        public SurfaceType RightSurface = SurfaceType.Smooth;
        public InputType RightSurfaceInput = InputType.NoInput;
        public int RootPriority;
        public Vector3 RotVelocity = new Vector3();

        public Vector3 Size
        {
            get => size;
            set => size = value;
        }

        public float TopParamA = -0.5f;
        public float TopParamB = 0.5f;
        public SurfaceType TopSurface = SurfaceType.Smooth;
        public InputType TopSurfaceInput = InputType.NoInput;
        public float Transparency;
        public Vector3 Velocity = new Vector3();

        [Obsolete]
        public BrickColor brickColor
        {
            get => BrickColor;
            set => BrickColor = value;
        }

        public Vector3 size = new Vector3(4, 1.2f, 2);
    }

    public class CornerWedgePart : BasePart
    {
    }

    public abstract class FormFactorPart : BasePart
    {
        [Obsolete]
        public FormFactor FormFactor
        {
            get => formFactorRaw;
            set => formFactorRaw = value;
        }

        [Obsolete]
        public FormFactor formFactor
        {
            get => FormFactor;
            set => FormFactor = value;
        }

        public FormFactor formFactorRaw = FormFactor.Brick;
    }

    public class Part : FormFactorPart
    {
        public PartType Shape
        {
            get => shape;
            set => shape = value;
        }

        public PartType shape = PartType.Block;
    }

    public class FlagStand : Part
    {
        public BrickColor TeamColor = BrickColor.FromNumber(194);
    }

    public class Seat : Part
    {
        public bool Disabled;
    }

    public class SkateboardPlatform : Part
    {
        public int Steer;
        public bool StickyWheels = true;
        public int Throttle;
    }

    public class SpawnLocation : Part
    {
        public bool AllowTeamChangeOnTouch;
        public int Duration = 10;
        public bool Enabled = true;
        public bool Neutral = true;
        public BrickColor TeamColor = BrickColor.FromNumber(194);
    }

    public class WedgePart : FormFactorPart
    {
    }

    public class Terrain : BasePart
    {
        public byte[] ClusterGridV3 = Array.Empty<byte>();
        public bool Decoration;
        public byte[] MaterialColors = Convert.FromBase64String("AAAAAAAAan8/P39rf2Y/ilY+j35fi21PZmxvZbDqw8faiVpHOi4kHh4lZlw76JxKc3trhHtagcLgc4RKxr21zq2UlJSM");
        public byte[] PhysicsGrid = Convert.FromBase64String("AgMAAAAAAAAAAAAAAAA=");
        public byte[] SmoothGrid = Convert.FromBase64String("AQU=");
        public Color3 WaterColor = Color3.FromRGB(12, 84, 91);
        public float WaterReflectance = 1;
        public float WaterTransparency = 0.3f;
        public float WaterWaveSize = 0.15f;
        public float WaterWaveSpeed = 10;
    }

    public abstract class TriangleMeshPart : BasePart
    {
        public Vector3 InitialSize = new Vector3(1, 1, 1);
        public byte[] LODData = Array.Empty<byte>();
        public SharedString PhysicalConfigData = SharedString.FromBase64("1B2M2Y8AsgTpgAmY7PhCfg==");
        public byte[] PhysicsData = Array.Empty<byte>();
    }

    public class MeshPart : TriangleMeshPart
    {
        public bool DoubleSided;
        public bool HasJointOffset;
        public bool HasSkinnedMesh;
        public Vector3 JointOffset = new Vector3();

        [Obsolete]
        public Content MeshID
        {
            get => MeshId;
            set => MeshId = value;
        }

        public Content MeshId = "";
        public RenderFidelity RenderFidelity = RenderFidelity.Precise;
        public Content TextureID = "";
    }

    public class PartOperation : TriangleMeshPart
    {
        public Content AssetId = "";
        public byte[] ChildData = Array.Empty<byte>();
        public FormFactor FormFactor = FormFactor.Custom;
        public byte[] MeshData = Array.Empty<byte>();
        public RenderFidelity RenderFidelity = RenderFidelity.Precise;
        public float SmoothingAngle;
        public bool UsePartColor;
    }

    public class NegateOperation : PartOperation
    {
    }

    public class UnionOperation : PartOperation
    {
    }

    public class TrussPart : BasePart
    {
        public Style Style
        {
            get => style;
            set => style = value;
        }

        public Style style = Style.AlternatingSupports;
    }

    public class VehicleSeat : BasePart
    {
        public bool Disabled;
        public bool HeadsUpDisplay = true;
        public float MaxSpeed = 25;
        public int Steer;
        public float SteerFloat;
        public int Throttle;
        public float ThrottleFloat;
        public float Torque = 10;
        public float TurnSpeed = 1;
    }

    public class Model : PVInstance
    {
        public ModelLevelOfDetail LevelOfDetail = ModelLevelOfDetail.Automatic;
        public CFrame ModelInPrimary = new CFrame();
        public CFrame ModelMeshCFrame = new CFrame();
        public SharedString ModelMeshData;
        public Vector3 ModelMeshSize = new Vector3();
        public BasePart PrimaryPart;
    }

    public class Actor : Model
    {
    }

    public abstract class WorldRoot : Model
    {
    }

    public class Workspace : WorldRoot
    {
        public Workspace()
        {
            IsService = true;
        }

        public bool AllowThirdPartySales;
        public string CollisionGroups = "Default^0^1";
        public Camera CurrentCamera;
        public double DistributedGameTime;
        public bool ExplicitAutoJoints = true;
        public float FallenPartsDestroyHeight = -500;
        public bool FilteringEnabled;
        public float Gravity = 196.2f;
        public InterpolationThrottlingMode InterpolationThrottling = InterpolationThrottlingMode.Default;
        public MeshPartHeads MeshPartHeads = MeshPartHeads.Default;
        public bool StreamingEnabled;
        public int StreamingMinRadius = 64;
        public StreamingPauseMode StreamingPauseMode = StreamingPauseMode.Default;
        public int StreamingTargetRadius = 1024;
        public bool TerrainWeldsFixed = true;
    }

    public class WorldModel : WorldRoot
    {
    }

    public class PackageLink : Instance
    {
        public bool AutoUpdate;
        public Content PackageIdSerialize = "";
        public long VersionIdSerialize;
    }

    public class PackageService : Instance
    {
        public PackageService()
        {
            IsService = true;
        }
    }

    public class PartOperationAsset : Instance
    {
        public byte[] ChildData = Array.Empty<byte>();
        public byte[] MeshData = Array.Empty<byte>();
    }

    public class ParticleEmitter : Instance
    {
        public Vector3 Acceleration = new Vector3();
        public ColorSequence Color = new ColorSequence(1, 1, 1);
        public float Drag;
        public NormalId EmissionDirection = NormalId.Top;
        public bool Enabled = true;
        public NumberRange Lifetime = new NumberRange(5, 10);
        public float LightEmission;
        public float LightInfluence;
        public bool LockedToPart;
        public float Rate = 20;
        public NumberRange RotSpeed = new NumberRange(0);
        public NumberRange Rotation = new NumberRange(0);
        public NumberSequence Size = new NumberSequence(1);
        public NumberRange Speed = new NumberRange(5);
        public Vector2 SpreadAngle = new Vector2();
        public Content Texture = "rbxasset://textures/particles/sparkles_main.dds";
        public NumberSequence Transparency = new NumberSequence(0);
        public float VelocityInheritance;

        [Obsolete]
        public float VelocitySpread
        {
            get => SpreadAngle.X;
            set => SpreadAngle = new Vector2(value, value);
        }

        public float ZOffset;
    }

    public class PathfindingService : Instance
    {
        public PathfindingService()
        {
            IsService = true;
        }

        [Obsolete]
        public float EmptyCutoff;
    }

    public class PermissionsService : Instance
    {
        public PermissionsService()
        {
            IsService = true;
        }
    }

    public class PhysicsService : Instance
    {
        public PhysicsService()
        {
            IsService = true;
        }
    }

    public class PlayerEmulatorService : Instance
    {
        public PlayerEmulatorService()
        {
            IsService = true;
        }

        public string EmulatedCountryCode = "";
        public string EmulatedGameLocale = "";
        public bool PlayerEmulationEnabled;
        public string SerializedEmulatedPolicyInfo = "";
    }

    public class Players : Instance
    {
        public Players()
        {
            IsService = true;
        }

        public bool CharacterAutoLoads = true;
        public int MaxPlayersInternal = 16;
        public int PreferredPlayersInternal;
        public float RespawnTime = 5;
    }

    public class PluginAction : Instance
    {
    }

    public class PluginGuiService : Instance
    {
        public PluginGuiService()
        {
            IsService = true;
        }
    }

    public class PointsService : Instance
    {
        public PointsService()
        {
            IsService = true;
        }
    }

    public class PolicyService : Instance
    {
        public PolicyService()
        {
            IsService = true;
        }

        public TriStateBoolean IsLuobuServer = TriStateBoolean.Unknown;
        public TriStateBoolean LuobuWhitelisted = TriStateBoolean.Unknown;
    }

    public abstract class PoseBase : Instance
    {
        public PoseEasingDirection EasingDirection = PoseEasingDirection.In;
        public PoseEasingStyle EasingStyle = PoseEasingStyle.Linear;
        public float Weight = 1;
    }

    public class NumberPose : PoseBase
    {
        public double Value;
    }

    public class Pose : PoseBase
    {
        public CFrame CFrame = new CFrame();

        [Obsolete]
        public float MaskWeight;
    }

    public abstract class PostEffect : Instance
    {
        public bool Enabled = true;
    }

    public class BloomEffect : PostEffect
    {
        public float Intensity = 0.4f;
        public float Size = 24;
        public float Threshold = 0.95f;
    }

    public class BlurEffect : PostEffect
    {
        public float Size = 24;
    }

    public class ColorCorrectionEffect : PostEffect
    {
        public float Brightness;
        public float Contrast;
        public float Saturation;
        public Color3 TintColor = new Color3(1, 1, 1);
    }

    public class DepthOfFieldEffect : PostEffect
    {
        public float FarIntensity = 0.75f;
        public float FocusDistance = 0.05f;
        public float InFocusRadius = 10;
        public float NearIntensity = 0.75f;
    }

    public class SunRaysEffect : PostEffect
    {
        public float Intensity = 0.25f;
        public float Spread = 1;
    }

    public class ProximityPrompt : Instance
    {
        public string ActionText = "Interact";
        public bool AutoLocalize = true;
        public bool ClickablePrompt = true;
        public bool Enabled = true;
        public ProximityPromptExclusivity Exclusivity = ProximityPromptExclusivity.OnePerButton;
        public KeyCode GamepadKeyCode = KeyCode.ButtonX;
        public float HoldDuration;
        public KeyCode KeyboardKeyCode = KeyCode.E;
        public float MaxActivationDistance = 10;
        public string ObjectText = "";
        public bool RequiresLineOfSight = true;
        public LocalizationTable RootLocalizationTable;
        public ProximityPromptStyle Style = ProximityPromptStyle.Default;
        public Vector2 UIOffset = new Vector2();
    }

    public class ProximityPromptService : Instance
    {
        public ProximityPromptService()
        {
            IsService = true;
        }

        public bool Enabled = true;
        public int MaxPromptsVisible = 16;
    }

    public class RbxAnalyticsService : Instance
    {
        public RbxAnalyticsService()
        {
            IsService = true;
        }
    }

    public class ReflectionMetadata : Instance
    {
    }

    public class ReflectionMetadataCallbacks : Instance
    {
    }

    public class ReflectionMetadataClasses : Instance
    {
    }

    public class ReflectionMetadataEnums : Instance
    {
    }

    public class ReflectionMetadataEvents : Instance
    {
    }

    public class ReflectionMetadataFunctions : Instance
    {
    }

    public abstract class ReflectionMetadataItem : Instance
    {
        public bool Browsable = true;
        public string ClassCategory = "";
        public bool ClientOnly;
        public string Constraint = "";
        public bool Deprecated;
        public bool EditingDisabled;
        public bool IsBackend;
        public string ScriptContext = "";
        public bool ServerOnly;
        public double UIMaximum;
        public double UIMinimum;
        public double UINumTicks;
        public string summary = "";
    }

    public class ReflectionMetadataClass : ReflectionMetadataItem
    {
        public int ExplorerImageIndex;
        public int ExplorerOrder = int.MaxValue;
        public bool Insertable = true;
        public string PreferredParent = "";
    }

    public class ReflectionMetadataEnum : ReflectionMetadataItem
    {
    }

    public class ReflectionMetadataEnumItem : ReflectionMetadataItem
    {
    }

    public class ReflectionMetadataMember : ReflectionMetadataItem
    {
    }

    public class ReflectionMetadataProperties : Instance
    {
    }

    public class ReflectionMetadataYieldFunctions : Instance
    {
    }

    public class RemoteEvent : Instance
    {
    }

    public class RemoteFunction : Instance
    {
    }

    public class RenderingTest : Instance
    {
        public CFrame CFrame = new CFrame();
        public int ComparisonDiffThreshold = 10;
        public RenderingTestComparisonMethod ComparisonMethod = RenderingTestComparisonMethod.psnr;
        public float ComparisonPsnrThreshold = 50;
        public string Description = "";
        public float FieldOfView = 70;
        public int QualityLevel = 21;
        public bool ShouldSkip;
        public string Ticket = "";
    }

    public class ReplicatedFirst : Instance
    {
        public ReplicatedFirst()
        {
            IsService = true;
        }
    }

    public class ReplicatedScriptService : Instance
    {
        public ReplicatedScriptService()
        {
            IsService = true;
        }
    }

    public class ReplicatedStorage : Instance
    {
        public ReplicatedStorage()
        {
            IsService = true;
        }
    }

    public class RobloxPluginGuiService : Instance
    {
        public RobloxPluginGuiService()
        {
            IsService = true;
        }
    }

    public class RobloxReplicatedStorage : Instance
    {
        public RobloxReplicatedStorage()
        {
            IsService = true;
        }
    }

    public class RunService : Instance
    {
        public RunService()
        {
            IsService = true;
        }
    }

    public class ScriptContext : Instance
    {
        public ScriptContext()
        {
            IsService = true;
        }
    }

    public class ScriptService : Instance
    {
        public ScriptService()
        {
            IsService = true;
        }
    }

    public class Selection : Instance
    {
        public Selection()
        {
            IsService = true;
        }
    }

    public class ServerScriptService : Instance
    {
        public ServerScriptService()
        {
            IsService = true;
        }

        public bool LoadStringEnabled;
    }

    public class ServerStorage : Instance
    {
        public ServerStorage()
        {
            IsService = true;
        }
    }

    public class SessionService : Instance
    {
        public SessionService()
        {
            IsService = true;
        }
    }

    public class Sky : Instance
    {
        public bool CelestialBodiesShown = true;
        public float MoonAngularSize = 11;
        public Content MoonTextureId = "rbxasset://sky/moon.jpg";
        public Content SkyboxBk = "rbxasset://textures/sky/sky512_bk.tex";
        public Content SkyboxDn = "rbxasset://textures/sky/sky512_dn.tex";
        public Content SkyboxFt = "rbxasset://textures/sky/sky512_ft.tex";
        public Content SkyboxLf = "rbxasset://textures/sky/sky512_lf.tex";
        public Content SkyboxRt = "rbxasset://textures/sky/sky512_rt.tex";
        public Content SkyboxUp = "rbxasset://textures/sky/sky512_up.tex";
        public int StarCount = 3000;
        public float SunAngularSize = 21;
        public Content SunTextureId = "rbxasset://sky/sun.jpg";
    }

    public class Smoke : Instance
    {
        public Color3 Color = new Color3(1, 1, 1);
        public bool Enabled = true;

        public float Opacity
        {
            get => opacity_xml;
            set => opacity_xml = value;
        }

        public float RiseVelocity
        {
            get => riseVelocity_xml;
            set => riseVelocity_xml = value;
        }

        public float Size
        {
            get => size_xml;
            set => size_xml = value;
        }

        public float opacity_xml = 0.5f;
        public float riseVelocity_xml = 1;
        public float size_xml = 1;
    }

    public class SocialService : Instance
    {
        public SocialService()
        {
            IsService = true;
        }
    }

    public class Sound : Instance
    {
        [Obsolete]
        public float EmitterSize = 10;

        public bool Looped;

        [Obsolete]
        public float MaxDistance
        {
            get => xmlRead_MaxDistance_3;
            set => xmlRead_MaxDistance_3 = value;
        }

        [Obsolete]
        public float MinDistance
        {
            get => EmitterSize;
            set => EmitterSize = value;
        }

        [Obsolete]
        public float Pitch
        {
            get => PlaybackSpeed;
            set => PlaybackSpeed = value;
        }

        public bool PlayOnRemove;
        public float PlaybackSpeed = 1;
        public bool Playing;
        public RollOffMode RollOffMode = RollOffMode.Inverse;
        public SoundGroup SoundGroup;
        public Content SoundId = "";
        public double TimePosition;
        public float Volume = 0.5f;
        public float xmlRead_MaxDistance_3 = 10000;

        public float xmlRead_MinDistance_3
        {
            get => EmitterSize;
            set => EmitterSize = value;
        }
    }

    public abstract class SoundEffect : Instance
    {
        public bool Enabled = true;
        public int Priority;
    }

    public class ChorusSoundEffect : SoundEffect
    {
        public float Depth = 0.15f;
        public float Mix = 0.5f;
        public float Rate = 0.5f;
    }

    public class CompressorSoundEffect : SoundEffect
    {
        public float Attack = 0.1f;
        public float GainMakeup;
        public float Ratio = 40;
        public float Release = 0.1f;
        public Instance SideChain;
        public float Threshold = -40;
    }

    public class DistortionSoundEffect : SoundEffect
    {
        public float Level = 0.75f;
    }

    public class EchoSoundEffect : SoundEffect
    {
        public float Delay = 1;
        public float DryLevel;
        public float Feedback = 0.5f;
        public float WetLevel;
    }

    public class EqualizerSoundEffect : SoundEffect
    {
        public float HighGain;
        public float LowGain = -20;
        public float MidGain = -10;
    }

    public class FlangeSoundEffect : SoundEffect
    {
        public float Depth = 0.45f;
        public float Mix = 0.85f;
        public float Rate = 5;
    }

    public class PitchShiftSoundEffect : SoundEffect
    {
        public float Octave = 1.25f;
    }

    public class ReverbSoundEffect : SoundEffect
    {
        public float DecayTime = 1.5f;
        public float Density = 1;
        public float Diffusion = 1;
        public float DryLevel = -6;
        public float WetLevel;
    }

    public class TremoloSoundEffect : SoundEffect
    {
        public float Depth = 1;
        public float Duty = 0.5f;
        public float Frequency = 5;
    }

    public class SoundGroup : Instance
    {
        public float Volume = 0.5f;
    }

    public class SoundService : Instance
    {
        public SoundService()
        {
            IsService = true;
        }

        public ReverbType AmbientReverb = ReverbType.NoReverb;
        public float DistanceFactor = 3.33f;
        public float DopplerScale = 1;
        public bool RespectFilteringEnabled;
        public float RolloffScale = 1;
    }

    public class Sparkles : Instance
    {
        public Color3 Color
        {
            get => SparkleColor;
            set => SparkleColor = value;
        }

        public bool Enabled = true;
        public Color3 SparkleColor = Color3.FromRGB(144, 25, 255);
    }

    public class SpawnerService : Instance
    {
        public SpawnerService()
        {
            IsService = true;
        }
    }

    public class StandalonePluginScripts : Instance
    {
    }

    public class StarterGear : Instance
    {
    }

    public class StarterPack : Instance
    {
        public StarterPack()
        {
            IsService = true;
        }
    }

    public class StarterPlayer : Instance
    {
        public StarterPlayer()
        {
            IsService = true;
        }

        public bool AllowCustomAnimations = true;
        public bool AutoJumpEnabled = true;
        public float CameraMaxZoomDistance = 400;
        public float CameraMinZoomDistance = 0.5f;
        public CameraMode CameraMode = CameraMode.Classic;
        public float CharacterJumpHeight = 7.2f;
        public float CharacterJumpPower = 50;
        public float CharacterMaxSlopeAngle = 89;
        public bool CharacterUseJumpPower = true;
        public float CharacterWalkSpeed = 16;
        public DevCameraOcclusionMode DevCameraOcclusionMode = DevCameraOcclusionMode.Zoom;
        public DevComputerCameraMovementMode DevComputerCameraMovementMode = DevComputerCameraMovementMode.UserChoice;
        public DevComputerMovementMode DevComputerMovementMode = DevComputerMovementMode.UserChoice;
        public DevTouchCameraMovementMode DevTouchCameraMovementMode = DevTouchCameraMovementMode.UserChoice;
        public DevTouchMovementMode DevTouchMovementMode = DevTouchMovementMode.UserChoice;
        public bool EnableMouseLockOption = true;
        public long GameSettingsAssetIDFace;
        public long GameSettingsAssetIDHead;
        public long GameSettingsAssetIDLeftArm;
        public long GameSettingsAssetIDLeftLeg;
        public long GameSettingsAssetIDPants;
        public long GameSettingsAssetIDRightArm;
        public long GameSettingsAssetIDRightLeg;
        public long GameSettingsAssetIDShirt;
        public long GameSettingsAssetIDTeeShirt;
        public long GameSettingsAssetIDTorso;
        public GameAvatarType GameSettingsAvatar = GameAvatarType.R15;
        public R15CollisionType GameSettingsR15Collision = R15CollisionType.OuterBox;
        public NumberRange GameSettingsScaleRangeBodyType = new NumberRange(0, 1);
        public NumberRange GameSettingsScaleRangeHead = new NumberRange(0.95f, 1);
        public NumberRange GameSettingsScaleRangeHeight = new NumberRange(0.9f, 1.05f);
        public NumberRange GameSettingsScaleRangeProportion = new NumberRange(0, 1);
        public NumberRange GameSettingsScaleRangeWidth = new NumberRange(0.7f, 1);
        public float HealthDisplayDistance = 100;
        public bool LoadCharacterAppearance = true;
        public float NameDisplayDistance = 100;
        public bool UserEmotesEnabled = true;
    }

    public class StarterPlayerScripts : Instance
    {
    }

    public class StarterCharacterScripts : StarterPlayerScripts
    {
    }

    public class Stats : Instance
    {
        public Stats()
        {
            IsService = true;
        }
    }

    public class StudioData : Instance
    {
        public StudioData()
        {
            IsService = true;
        }

        public long CommitInflightAuthorId;
        public string CommitInflightGuid = "";
        public int CommitInflightPlaceVersion;
        public bool EnableScriptCollabByDefaultOnLoad;
        public bool EnableScriptCollabOnLoad;
        public bool EnableScriptCollabVersionHistoryOnLoad;
        public long SrcPlaceId;
        public long SrcUniverseId;
    }

    public class StudioService : Instance
    {
        public StudioService()
        {
            IsService = true;
        }
    }

    public class SurfaceAppearance : Instance
    {
        public AlphaMode AlphaMode = AlphaMode.Overlay;
        public Content ColorMap = "";
        public Content MetalnessMap = "";
        public Content NormalMap = "";
        public Content RoughnessMap = "";
        public Content TexturePack = "";
    }

    public class Team : Instance
    {
        public bool AutoAssignable = true;

        [Obsolete]
        public bool AutoColorCharacters = true;

        [Obsolete]
        public int Score;

        public BrickColor TeamColor = BrickColor.FromNumber(1);
    }

    public class Teams : Instance
    {
        public Teams()
        {
            IsService = true;
        }
    }

    public class TeleportOptions : Instance
    {
        public string ReservedServerAccessCode = "";
        public string ServerInstanceId = "";
        public bool ShouldReserveServer;
    }

    public class TeleportService : Instance
    {
        public TeleportService()
        {
            IsService = true;
        }

        [Obsolete]
        public bool CustomizedTeleportUI;
    }

    public class TerrainRegion : Instance
    {
        public Vector3int16 ExtentsMax = new Vector3int16();
        public Vector3int16 ExtentsMin = new Vector3int16();
        public byte[] GridV3 = Array.Empty<byte>();
        public byte[] SmoothGrid = Convert.FromBase64String("AQU=");
    }

    public class TestService : Instance
    {
        public TestService()
        {
            IsService = true;
        }

        public bool AutoRuns = true;
        public string Description = "";
        public bool ExecuteWithStudioRun;
        public bool Is30FpsThrottleEnabled = true;
        public bool IsPhysicsEnvironmentalThrottled = true;
        public bool IsSleepAllowed = true;
        public int NumberOfPlayers;
        public double SimulateSecondsLag;
        public double Timeout = 10;
    }

    public class TextService : Instance
    {
        public TextService()
        {
            IsService = true;
        }
    }

    public class TimerService : Instance
    {
        public TimerService()
        {
            IsService = true;
        }
    }

    public class TouchInputService : Instance
    {
        public TouchInputService()
        {
            IsService = true;
        }
    }

    public class TracerService : Instance
    {
        public TracerService()
        {
            IsService = true;
        }
    }

    public class Trail : Instance
    {
        public Attachment Attachment0;
        public Attachment Attachment1;
        public ColorSequence Color = new ColorSequence(1, 1, 1);
        public bool Enabled = true;
        public bool FaceCamera;
        public float Lifetime = 2;
        public float LightEmission;
        public float LightInfluence;
        public float MaxLength;
        public float MinLength = 0.1f;
        public Content Texture = "";
        public float TextureLength = 1;
        public TextureMode TextureMode = TextureMode.Stretch;
        public NumberSequence Transparency = new NumberSequence(0.5f);
        public NumberSequence WidthScale = new NumberSequence(1);
    }

    public abstract class TweenBase : Instance
    {
    }

    public class Tween : TweenBase
    {
    }

    public class TweenService : Instance
    {
        public TweenService()
        {
            IsService = true;
        }
    }

    public class UGCValidationService : Instance
    {
        public UGCValidationService()
        {
            IsService = true;
        }
    }

    public abstract class UIBase : Instance
    {
    }

    public abstract class UIComponent : UIBase
    {
    }

    public abstract class UIConstraint : UIComponent
    {
    }

    public class UIAspectRatioConstraint : UIConstraint
    {
        public float AspectRatio = 1;
        public AspectType AspectType = AspectType.FitWithinMaxSize;
        public DominantAxis DominantAxis = DominantAxis.Width;
    }

    public class UISizeConstraint : UIConstraint
    {
        public Vector2 MaxSize = new Vector2(float.MaxValue, float.MaxValue);
        public Vector2 MinSize = new Vector2();
    }

    public class UITextSizeConstraint : UIConstraint
    {
        public int MaxTextSize = 100;
        public int MinTextSize = 1;
    }

    public class UICorner : UIComponent
    {
        public UDim CornerRadius = new UDim(0, 8);
    }

    public class UIGradient : UIComponent
    {
        public ColorSequence Color = new ColorSequence(1, 1, 1);
        public bool Enabled = true;
        public Vector2 Offset = new Vector2();
        public float Rotation;
        public NumberSequence Transparency = new NumberSequence(0);
    }

    public abstract class UILayout : UIComponent
    {
    }

    public abstract class UIGridStyleLayout : UILayout
    {
        public FillDirection FillDirection = FillDirection.Horizontal;
        public HorizontalAlignment HorizontalAlignment = HorizontalAlignment.Left;
        public SortOrder SortOrder = SortOrder.Name;
        public VerticalAlignment VerticalAlignment = VerticalAlignment.Top;
    }

    public class UIGridLayout : UIGridStyleLayout
    {
        public UDim2 CellPadding = new UDim2(0, 5, 0, 5);
        public UDim2 CellSize = new UDim2(0, 100, 0, 100);
        public int FillDirectionMaxCells;
        public StartCorner StartCorner = StartCorner.TopLeft;
    }

    public class UIListLayout : UIGridStyleLayout
    {
        public UDim Padding = new UDim();
    }

    public class UIPageLayout : UIGridStyleLayout
    {
        public bool Animated = true;
        public bool Circular;
        public EasingDirection EasingDirection = EasingDirection.Out;
        public EasingStyle EasingStyle = EasingStyle.Back;
        public bool GamepadInputEnabled = true;
        public UDim Padding = new UDim();
        public bool ScrollWheelInputEnabled = true;
        public bool TouchInputEnabled = true;
        public float TweenTime = 1;
    }

    public class UITableLayout : UIGridStyleLayout
    {
        public bool FillEmptySpaceColumns;
        public bool FillEmptySpaceRows;
        public TableMajorAxis MajorAxis = TableMajorAxis.RowMajor;
        public UDim2 Padding = new UDim2();
    }

    public class UIPadding : UIComponent
    {
        public UDim PaddingBottom = new UDim();
        public UDim PaddingLeft = new UDim();
        public UDim PaddingRight = new UDim();
        public UDim PaddingTop = new UDim();
    }

    public class UIScale : UIComponent
    {
        public float Scale = 1;
    }

    public class UnvalidatedAssetService : Instance
    {
        public UnvalidatedAssetService()
        {
            IsService = true;
        }
    }

    public class UserInputService : Instance
    {
        public UserInputService()
        {
            IsService = true;
        }

        public bool LegacyInputEventsEnabled = true;
        public MouseBehavior MouseBehavior = MouseBehavior.Default;
        public bool MouseIconEnabled = true;
    }

    public class UserService : Instance
    {
        public UserService()
        {
            IsService = true;
        }
    }

    public class VRService : Instance
    {
        public VRService()
        {
            IsService = true;
        }
    }

    public abstract class ValueBase : Instance
    {
    }

    public class BinaryStringValue : ValueBase
    {
        public byte[] Value = Array.Empty<byte>();
    }

    public class BoolValue : ValueBase
    {
        public bool Value;
    }

    public class BrickColorValue : ValueBase
    {
        public BrickColor Value = BrickColor.FromNumber(194);
    }

    public class CFrameValue : ValueBase
    {
        public CFrame Value = new CFrame();
    }

    public class Color3Value : ValueBase
    {
        public Color3 Value = new Color3();
    }

    public class DoubleConstrainedValue : ValueBase
    {
        public double ConstrainedValue
        {
            get => value;
            set => this.value = value;
        }

        public double MaxValue = 1;
        public double MinValue;

        public double Value
        {
            get => value;
            set => this.value = value;
        }

        public double value;
    }

    public class IntConstrainedValue : ValueBase
    {
        public long ConstrainedValue
        {
            get => value;
            set => this.value = value;
        }

        public long MaxValue = 10;
        public long MinValue;

        public long Value
        {
            get => value;
            set => this.value = value;
        }

        public long value;
    }

    public class IntValue : ValueBase
    {
        public long Value;
    }

    public class NumberValue : ValueBase
    {
        public double Value;
    }

    public class ObjectValue : ValueBase
    {
        public Instance Value;
    }

    public class RayValue : ValueBase
    {
        public Ray Value = new Ray();
    }

    public class StringValue : ValueBase
    {
        public string Value = "";
    }

    public class Vector3Value : ValueBase
    {
        public Vector3 Value = new Vector3();
    }

    public class VersionControlService : Instance
    {
        public VersionControlService()
        {
            IsService = true;
        }
    }

    public class VirtualInputManager : Instance
    {
        public VirtualInputManager()
        {
            IsService = true;
        }
    }

    public class VirtualUser : Instance
    {
        public VirtualUser()
        {
            IsService = true;
        }
    }

    public class Visit : Instance
    {
        public Visit()
        {
            IsService = true;
        }
    }

    public class WeldConstraint : Instance
    {
        public CFrame CFrame0 = new CFrame();
        public CFrame CFrame1 = new CFrame();

        public bool Enabled
        {
            get => EnabledInternal;
            set => EnabledInternal = value;
        }

        public bool EnabledInternal = true;

        public BasePart Part0
        {
            get => Part0Internal;
            set => Part0Internal = value;
        }

        public BasePart Part0Internal;

        public BasePart Part1
        {
            get => Part1Internal;
            set => Part1Internal = value;
        }

        public BasePart Part1Internal;
        public int State = 3;
    }
}
