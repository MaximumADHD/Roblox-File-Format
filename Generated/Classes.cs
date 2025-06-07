// Auto-generated list of creatable Roblox classes.
// Updated as of 0.676.0.6760531

using System;

using RobloxFiles.DataTypes;
using RobloxFiles.Enums;
using RobloxFiles.Utility;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CS0612 // Type or member is obsolete

namespace RobloxFiles
{
    public class EditableImage : RbxObject
    {
        public byte[] ImageData;
    }

    public class EditableMesh : RbxObject
    {
        public SharedString MeshData = SharedString.None;

        [Obsolete]
        public bool SkinningEnabled;
    }

    public class AccessoryDescription : Instance
    {
        public AccessoryType AccessoryType = AccessoryType.Unknown;
        public long AssetId = 0;
        public Instance Instance = null;
        public bool IsLayered;
        public int Order = 0;
        public Vector3 Position = Vector3.zero;
        public float Puffiness = 1;
        public Vector3 Rotation = Vector3.zero;
        public Vector3 Scale = Vector3.one;
    }

    [RbxService]
    public class AccountService : Instance
    {
    }

    public class Accoutrement : Instance
    {
        public CFrame AttachmentPoint = CFrame.identity;
    }

    public class Accessory : Accoutrement
    {
        public AccessoryType AccessoryType = AccessoryType.Unknown;
    }

    public class Hat : Accoutrement
    {
    }

    [RbxService]
    public class AchievementService : Instance
    {
    }

    [RbxService]
    public class ActivityHistoryEventService : Instance
    {
    }

    public class AdPortal : Instance
    {
    }

    [RbxService]
    public class AdService : Instance
    {
    }

    public class AdvancedDragger : Instance
    {
    }

    [RbxService]
    public class AnalyticsService : Instance
    {
        [Obsolete]
        public string ApiKey = "";
    }

    public class Animation : Instance
    {
        public ContentId AnimationId = "";
    }

    public abstract class AnimationClip : Instance
    {
        public byte[] GuidBinaryString;
        public bool Loop = true;
        public AnimationPriority Priority = AnimationPriority.Action;
    }

    public class CurveAnimation : AnimationClip
    {
    }

    public class KeyframeSequence : AnimationClip
    {
        public float AuthoredHipHeight = 2;
    }

    [RbxService]
    public class AnimationClipProvider : Instance
    {
    }

    public class AnimationController : Instance
    {
    }

    [RbxService]
    public class AnimationFromVideoCreatorService : Instance
    {
    }

    [RbxService]
    public class AnimationFromVideoCreatorStudioService : Instance
    {
    }

    public class AnimationRigData : Instance
    {
        public byte[] label = Convert.FromBase64String("AQAAAAEAAAAAAAAA");
        public byte[] name = Convert.FromBase64String("AQAAAAEAAAAAAAAA");
        public byte[] parent = Convert.FromBase64String("AQAAAAEAAAAAAA==");
        public byte[] postTransform = Convert.FromBase64String("AQAAAAEAAAAAAIA/AAAAAAAAAAAAAAAAAACAPwAAAAAAAAAAAAAAAAAAgD8AAAAAAAAAAAAAAAA=");
        public byte[] preTransform = Convert.FromBase64String("AQAAAAEAAAAAAIA/AAAAAAAAAAAAAAAAAACAPwAAAAAAAAAAAAAAAAAAgD8AAAAAAAAAAAAAAAA=");
        public byte[] transform = Convert.FromBase64String("AQAAAAEAAAAAAIA/AAAAAAAAAAAAAAAAAACAPwAAAAAAAAAAAAAAAAAAgD8AAAAAAAAAAAAAAAA=");
    }

    public class Animator : Instance
    {
        public bool PreferLodEnabled = true;
    }

    public class Annotation : Instance
    {
    }

    public class WorkspaceAnnotation : Annotation
    {
    }

    [RbxService]
    public class AnnotationsService : Instance
    {
    }

    [RbxService]
    public class AppLifecycleObserverService : Instance
    {
    }

    [RbxService]
    public class AppUpdateService : Instance
    {
    }

    [RbxService]
    public class AssetCounterService : Instance
    {
    }

    [RbxService]
    public class AssetDeliveryProxy : Instance
    {
        public string Interface = "";
        public int Port = 0;
        public bool StartServer;
    }

    [RbxService]
    public class AssetImportService : Instance
    {
    }

    [RbxService]
    public class AssetManagerService : Instance
    {
    }

    [RbxService]
    public class AssetService : Instance
    {
    }

    public class Atmosphere : Instance
    {
        public Color3 Color = Color3.FromRGB(199, 170, 107);
        public Color3 Decay = Color3.FromRGB(92, 60, 13);
        public float Density = 0.395f;
        public float Glare = 0;
        public float Haze = 0;
        public float Offset = 0;
    }

    public class Attachment : Instance
    {
        public CFrame CFrame = CFrame.identity;
        public bool Visible;
    }

    public class Bone : Attachment
    {
    }

    public class AudioAnalyzer : Instance
    {
        public bool SpectrumEnabled = true;
        public AudioWindowSize WindowSize = AudioWindowSize.Medium;
    }

    public class AudioChannelMixer : Instance
    {
        public AudioChannelLayout Layout = AudioChannelLayout.Stereo;
    }

    public class AudioChannelSplitter : Instance
    {
        public AudioChannelLayout Layout = AudioChannelLayout.Stereo;
    }

    public class AudioChorus : Instance
    {
        public bool Bypass;
        public float Depth = 0.45f;
        public float Mix = 0.85f;
        public float Rate = 5;
    }

    public class AudioCompressor : Instance
    {
        public float Attack = 0.1f;
        public bool Bypass;
        public float MakeupGain = 0;
        public float Ratio = 40;
        public float Release = 0.1f;
        public float Threshold = -40;
    }

    public class AudioDeviceInput : Instance
    {
        public AccessModifierType AccessType = AccessModifierType.Deny;
        public bool Active = true;
        public bool Muted;
        public float Volume = 1;
    }

    public class AudioDeviceOutput : Instance
    {
    }

    public class AudioDistortion : Instance
    {
        public bool Bypass;
        public float Level = 0.5f;
    }

    public class AudioEcho : Instance
    {
        public bool Bypass;
        public float DelayTime = 1;
        public float DryLevel = 0;
        public float Feedback = 0.5f;
        public float RampTime = 0;
        public float WetLevel = 0;
    }

    public class AudioEmitter : Instance
    {
        public byte[] AngleAttenuation;
        public string AudioInteractionGroup = "";
        public byte[] DistanceAttenuation;
        public AudioSimulationFidelity SimulationFidelity = AudioSimulationFidelity.Automatic;
    }

    public class AudioEqualizer : Instance
    {
        public bool Bypass;
        public float HighGain = 0;
        public float LowGain = 0;
        public float MidGain = 0;
        public NumberRange MidRange = new NumberRange(400, 4000);
    }

    public class AudioFader : Instance
    {
        public bool Bypass;
        public float Volume = 1;
    }

    public class AudioFilter : Instance
    {
        public bool Bypass;
        public AudioFilterType FilterType = AudioFilterType.Peak;
        public float Frequency = 2000;
        public float Gain = 0;
        public float Q = 0.707f;
    }

    public class AudioFlanger : Instance
    {
        public bool Bypass;
        public float Depth = 0.45f;
        public float Mix = 0.85f;
        public float Rate = 5;
    }

    [RbxService]
    public class AudioFocusService : Instance
    {
    }

    public class AudioLimiter : Instance
    {
        public bool Bypass;
        public float MaxLevel = 0;
        public float Release = 0.01f;
    }

    public class AudioListener : Instance
    {
        public byte[] AngleAttenuation;
        public string AudioInteractionGroup = "";
        public byte[] DistanceAttenuation;
        public AudioSimulationFidelity SimulationFidelity = AudioSimulationFidelity.Automatic;
    }

    public class AudioPitchShifter : Instance
    {
        public bool Bypass;
        public float Pitch = 1.25f;
        public AudioWindowSize WindowSize = AudioWindowSize.Medium;
    }

    public class AudioPlayer : Instance
    {
        public ContentId Asset = "";

        [Obsolete]
        public string AssetId
        {
            get => Asset;
            set => Asset = value;
        }

        public bool AutoLoad = true;
        public NumberRange LoopRegion = new NumberRange(0, 60000);
        public bool Looping;
        public NumberRange PlaybackRegion = new NumberRange(0, 60000);
        public double PlaybackSpeed = 1;
        public double TimePosition = 0;
        public float Volume = 1;
    }

    public class AudioRecorder : Instance
    {
        public bool IsRecording;
    }

    public class AudioReverb : Instance
    {
        public bool Bypass;
        public float DecayRatio = 0.5f;
        public float DecayTime = 1.5f;
        public float Density = 1;
        public float Diffusion = 1;
        public float DryLevel = 0;
        public float EarlyDelayTime = 0.02f;
        public float HighCutFrequency = 20000;
        public float LateDelayTime = 0.04f;
        public float LowShelfFrequency = 250;
        public float LowShelfGain = 0;
        public float ReferenceFrequency = 5000;
        public float WetLevel = -6;
    }

    public class AudioSearchParams : Instance
    {
        public string Album = "";
        public string Artist = "";
        public AudioSubType AudioSubType = AudioSubType.Music;

        [Obsolete]
        public AudioSubType AudioSubtype
        {
            get => AudioSubType;
            set => AudioSubType = value;
        }

        public int MaxDuration = int.MaxValue;
        public int MinDuration = 0;
        public string SearchKeyword = "";
        public string Tag = "";
        public string Title = "";
    }

    public class AudioTextToSpeech : Instance
    {
        public bool Looping;
        public float Pitch = 0;
        public float PlaybackSpeed = 1;
        public float Speed = 1;
        public string Text = "";
        public double TimePosition = 0;
        public string VoiceId = "";
        public float Volume = 1;
    }

    [RbxService]
    public class AuroraScriptService : Instance
    {
    }

    [RbxService]
    public class AuroraService : Instance
    {
        public double HashRoundingPoint = 0;
        public bool IgnoreRotation;
        public int RollbackOffset = 0;
    }

    public class AvatarAccessoryRules : Instance
    {
        public AvatarSettingsAccessoryMode AccessoryMode = AvatarSettingsAccessoryMode.PlayerChoice;
        public AvatarSettingsCustomAccessoryMode CustomAccessoryMode = AvatarSettingsCustomAccessoryMode.PlayerChoice;
        public bool CustomBackAccessoryEnabled;
        public long CustomBackAccessoryId = 0;
        public bool CustomFaceAccessoryEnabled;
        public long CustomFaceAccessoryId = 0;
        public bool CustomFrontAccessoryEnabled;
        public long CustomFrontAccessoryId = 0;
        public bool CustomHairAccessoryEnabled;
        public long CustomHairAccessoryId = 0;
        public bool CustomHeadAccessoryEnabled;
        public long CustomHeadAccessoryId = 0;
        public bool CustomNeckAccessoryEnabled;
        public long CustomNeckAccessoryId = 0;
        public bool CustomShoulderAccessoryEnabled;
        public long CustomShoulderAccessoryId = 0;
        public bool CustomWaistAccessoryEnabled;
        public long CustomWaistAccessoryId = 0;
        public bool EnableSound;
        public bool EnableVFX;
        public Vector3 LimitBounds = Vector3.zero;
        public AvatarSettingsAccessoryLimitMethod LimitMethod = AvatarSettingsAccessoryLimitMethod.Remove;
    }

    public class AvatarAnimationRules : Instance
    {
        public AvatarSettingsAnimationClipsMode AnimationClipsMode = AvatarSettingsAnimationClipsMode.PlayerChoice;
        public AvatarSettingsAnimationPacksMode AnimationPacksMode = AvatarSettingsAnimationPacksMode.PlayerChoice;
        public bool CustomClimbAnimationEnabled;
        public long CustomClimbAnimationId = 0;
        public bool CustomFallAnimationEnabled;
        public long CustomFallAnimationId = 0;
        public bool CustomIdleAlt1AnimationEnabled;
        public long CustomIdleAlt1AnimationId = 0;
        public bool CustomIdleAlt2AnimationEnabled;
        public long CustomIdleAlt2AnimationId = 0;
        public bool CustomIdleAnimationEnabled;
        public long CustomIdleAnimationId = 0;
        public bool CustomJumpAnimationEnabled;
        public long CustomJumpAnimationId = 0;
        public bool CustomRunAnimationEnabled;
        public long CustomRunAnimationId = 0;
        public bool CustomSwimAnimationEnabled;
        public long CustomSwimAnimationId = 0;
        public bool CustomSwimIdleAnimationEnabled;
        public long CustomSwimIdleAnimationId = 0;
        public bool CustomWalkAnimationEnabled;
        public long CustomWalkAnimationId = 0;
    }

    public class AvatarBodyRules : Instance
    {
        public AvatarSettingsAppearanceMode AppearanceMode = AvatarSettingsAppearanceMode.PlayerChoice;
        public AvatarSettingsBuildMode BuildMode = AvatarSettingsBuildMode.PlayerChoice;
        public long CustomBodyBundleId = 0;
        public AvatarSettingsCustomBodyType CustomBodyType = AvatarSettingsCustomBodyType.AvatarReference;
        public NumberRange CustomBodyTypeScale;
        public bool CustomHeadEnabled;
        public long CustomHeadId = 0;
        public NumberRange CustomHeadScale;
        public NumberRange CustomHeight;
        public NumberRange CustomHeightScale;
        public bool CustomLeftArmEnabled;
        public long CustomLeftArmId = 0;
        public bool CustomLeftLegEnabled;
        public long CustomLeftLegId = 0;
        public NumberRange CustomProportionsScale;
        public bool CustomRightArmEnabled;
        public long CustomRightArmId = 0;
        public bool CustomRightLegEnabled;
        public long CustomRightLegId = 0;
        public bool CustomTorsoEnabled;
        public long CustomTorsoId = 0;
        public NumberRange CustomWidthScale;
        public bool KeepPlayerHead;
        public AvatarSettingsScaleMode ScaleMode = AvatarSettingsScaleMode.PlayerChoice;
    }

    [RbxService]
    public class AvatarChatService : Instance
    {
    }

    public class AvatarClothingRules : Instance
    {
        public AvatarSettingsClothingMode ClothingMode = AvatarSettingsClothingMode.PlayerChoice;
        public bool CustomClassicPantsAccessoryEnabled;
        public long CustomClassicPantsAccessoryId = 0;
        public bool CustomClassicShirtsAccessoryEnabled;
        public long CustomClassicShirtsAccessoryId = 0;
        public bool CustomClassicTShirtsAccessoryEnabled;
        public long CustomClassicTShirtsAccessoryId = 0;
        public AvatarSettingsCustomClothingMode CustomClothingMode = AvatarSettingsCustomClothingMode.PlayerChoice;
        public bool CustomDressSkirtAccessoryEnabled;
        public long CustomDressSkirtAccessoryId = 0;
        public bool CustomJacketAccessoryEnabled;
        public long CustomJacketAccessoryId = 0;
        public bool CustomLeftShoesAccessoryEnabled;
        public long CustomLeftShoesAccessoryId = 0;
        public bool CustomPantsAccessoryEnabled;
        public long CustomPantsAccessoryId = 0;
        public bool CustomRightShoesAccessoryEnabled;
        public long CustomRightShoesAccessoryId = 0;
        public bool CustomShirtAccessoryEnabled;
        public long CustomShirtAccessoryId = 0;
        public bool CustomShortsAccessoryEnabled;
        public long CustomShortsAccessoryId = 0;
        public bool CustomSweaterAccessoryEnabled;
        public long CustomSweaterAccessoryId = 0;
        public bool CustomTShirtAccessoryEnabled;
        public long CustomTShirtAccessoryId = 0;
        public Vector3 LimitBounds = Vector3.zero;
    }

    public class AvatarCollisionRules : Instance
    {
        public AvatarSettingsCollisionMode CollisionMode = AvatarSettingsCollisionMode.Default;
        public AvatarSettingsHitAndTouchDetectionMode HitAndTouchDetectionMode = AvatarSettingsHitAndTouchDetectionMode.UseParts;
        public AvatarSettingsLegacyCollisionMode LegacyCollisionMode = AvatarSettingsLegacyCollisionMode.R6Colliders;
        public Vector3 SingleColliderSize = new Vector3(2, 4, 1);
    }

    [RbxService]
    public class AvatarCreationService : Instance
    {
    }

    [RbxService]
    public class AvatarEditorService : Instance
    {
    }

    [RbxService]
    public class AvatarImportService : Instance
    {
    }

    [RbxService]
    public class AvatarPreloader : Instance
    {
    }

    public class AvatarRules : Instance
    {
        public GameAvatarType AvatarType = GameAvatarType.R15;
    }

    [RbxService]
    public class AvatarSettings : Instance
    {
    }

    public class Backpack : Instance
    {
    }

    [RbxService]
    public class BadgeService : Instance
    {
    }

    public abstract class BasePlayerGui : Instance
    {
    }

    [RbxService]
    public class CoreGui : BasePlayerGui
    {
        public GuiObject SelectionImageObject;
    }

    [RbxService]
    public class StarterGui : BasePlayerGui
    {
        [Obsolete]
        public bool ResetPlayerGuiOnSpawn = true;

        public RtlTextSupport RtlTextSupport = RtlTextSupport.Default;
        public ScreenOrientation ScreenOrientation = ScreenOrientation.LandscapeSensor;
        public bool ShowDevelopmentGui = true;
        public StyleSheet StudioDefaultStyleSheet;
        public StyleSheet StudioInsertWidgetLayerCollectorAutoLinkStyleSheet;
        public VirtualCursorMode VirtualCursorMode = VirtualCursorMode.Default;
    }

    public abstract class BaseRemoteEvent : Instance
    {
    }

    public class RemoteEvent : BaseRemoteEvent
    {
    }

    public class UnreliableRemoteEvent : BaseRemoteEvent
    {
    }

    public abstract class BaseWrap : Instance
    {
        public Content CageMeshContent = Content.None;

        public ContentId CageMeshId
        {
            get => CageMeshContent;
            set => CageMeshContent = value;
        }

        public CFrame CageOrigin = CFrame.identity;
        public ContentId HSRAssetId;
        public SharedString HSRData = SharedString.None;
        public SharedString HSRMeshIdData = SharedString.None;
        public CFrame ImportOrigin = CFrame.identity;
        public ContentId TemporaryCageMeshId;
    }

    public class WrapDeformer : BaseWrap
    {
    }

    public class WrapLayer : BaseWrap
    {
        public WrapLayerAutoSkin AutoSkin = WrapLayerAutoSkin.Disabled;
        public CFrame BindOffset = CFrame.identity;
        public bool Enabled = true;
        public Vector3 MaxSize = Vector3.zero;
        public Vector3 Offset = Vector3.zero;
        public int Order = 1;
        public float Puffiness = 1;
        public Content ReferenceMeshContent = Content.None;

        public ContentId ReferenceMeshId
        {
            get => ReferenceMeshContent;
            set => ReferenceMeshContent = value;
        }

        public CFrame ReferenceOrigin = CFrame.identity;
        public float ShrinkFactor = 0;
        public ContentId TemporaryReferenceId;
    }

    public class WrapTarget : BaseWrap
    {
        public float Stiffness = 0;
    }

    public class Beam : Instance
    {
        public Attachment Attachment0 = null;
        public Attachment Attachment1 = null;
        public float Brightness = 1;
        public ColorSequence Color = new ColorSequence(1, 1, 1);
        public float CurveSize0 = 0;
        public float CurveSize1 = 0;
        public bool Enabled = true;
        public bool FaceCamera;
        public float LightEmission = 0;
        public float LightInfluence = 0;
        public int Segments = 10;
        public ContentId Texture = "";
        public float TextureLength = 1;
        public TextureMode TextureMode = TextureMode.Stretch;
        public float TextureSpeed = 1;
        public NumberSequence Transparency = new NumberSequence(0.5f);
        public float Width0 = 1;
        public float Width1 = 1;
        public float ZOffset = 0;
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
        public Vector3 Force = Vector3.yAxis;

        [Obsolete]
        public Vector3 force
        {
            get => Force;
            set => Force = value;
        }
    }

    public class BodyGyro : BodyMover
    {
        public CFrame CFrame = CFrame.identity;
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
        public Vector3 Force = Vector3.yAxis;
        public Vector3 Location = Vector3.zero;

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
        public BasePart Target = null;
        public Vector3 TargetOffset = Vector3.zero;
        public float TargetRadius = 4;
        public float ThrustD = 0.001f;
        public float ThrustP = 5;
        public float TurnD = 500;
        public float TurnP = 3000;
    }

    public class BodyPartDescription : Instance
    {
        public long AssetId = 0;
        public BodyPart BodyPart = BodyPart.Head;
        public Color3 Color = new Color3();
        public Instance Instance = null;
    }

    public class Breakpoint : Instance
    {
    }

    [RbxService]
    public class BrowserService : Instance
    {
    }

    [RbxService]
    public class BugReporterService : Instance
    {
    }

    [RbxService]
    public class BulkImportService : Instance
    {
    }

    [RbxService]
    public class CacheableContentProvider : Instance
    {
    }

    [RbxService]
    public class HSRDataContentProvider : CacheableContentProvider
    {
    }

    [RbxService]
    public class MeshContentProvider : CacheableContentProvider
    {
    }

    [RbxService]
    public class SlimContentProvider : CacheableContentProvider
    {
    }

    [RbxService]
    public class SolidModelContentProvider : CacheableContentProvider
    {
    }

    [RbxService]
    public class CalloutService : Instance
    {
    }

    [RbxService]
    public class CaptureService : Instance
    {
    }

    [RbxService]
    public class ChangeHistoryService : Instance
    {
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
        public long BaseTextureId = 0;
        public BodyPart BodyPart = BodyPart.Head;
        public long MeshId = 0;
        public long OverlayTextureId = 0;
    }

    public abstract class Clothing : CharacterAppearance
    {
        public Color3 Color3 = new Color3(1, 1, 1);
    }

    public class Pants : Clothing
    {
        public ContentId PantsTemplate = "";
    }

    public class Shirt : Clothing
    {
        public ContentId ShirtTemplate = "";
    }

    public class ShirtGraphic : CharacterAppearance
    {
        public Color3 Color3 = new Color3(1, 1, 1);
        public ContentId Graphic = "";
    }

    public class Skin : CharacterAppearance
    {
        public BrickColor SkinColor = BrickColorId.Cool_yellow;
    }

    [RbxService]
    public class Chat : Instance
    {
        public bool BubbleChatEnabled;
        public bool IsAutoMigrated;
        public bool LoadDefaultChat = true;
    }

    [RbxService]
    public class ChatbotUIService : Instance
    {
    }

    public class ClickDetector : Instance
    {
        public ContentId CursorIcon = "";
        public float MaxActivationDistance = 32;
    }

    public class DragDetector : ClickDetector
    {
        public ContentId ActivatedCursorIcon = "";
        public bool ApplyAtCenterOfMass;
        public CFrame DragFrame = CFrame.identity;
        public DragDetectorDragStyle DragStyle = DragDetectorDragStyle.TranslatePlane;
        public bool Enabled = true;
        public KeyCode GamepadModeSwitchKeyCode = KeyCode.ButtonR1;
        public KeyCode KeyboardModeSwitchKeyCode = KeyCode.LeftControl;
        public float MaxDragAngle = 0;
        public Vector3 MaxDragTranslation = Vector3.zero;
        public float MaxForce = 10000000;
        public float MaxTorque = 10000;
        public float MinDragAngle = 0;
        public Vector3 MinDragTranslation = Vector3.zero;
        public Vector3 Orientation = new Vector3(0, 180, 90);
        public DragDetectorPermissionPolicy PermissionPolicy = DragDetectorPermissionPolicy.Everybody;
        public Instance ReferenceInstance = null;
        public DragDetectorResponseStyle ResponseStyle = DragDetectorResponseStyle.Physical;
        public float Responsiveness = 10;
        public bool RunLocally;
        public float TrackballRadialPullFactor = 1;
        public float TrackballRollFactor = 1;
        public KeyCode VRSwitchKeyCode = KeyCode.ButtonL2;
    }

    [RbxService]
    public class CloudCRUDService : Instance
    {
    }

    public class Clouds : Instance
    {
        public Color3 Color = new Color3(1, 1, 1);
        public float Cover = 0.5f;
        public float Density = 0.7f;
        public bool Enabled = true;
    }

    [RbxService]
    public class ClusterPacketCache : Instance
    {
    }

    [RbxService]
    public class CollaboratorsService : Instance
    {
    }

    [RbxService]
    public class CollectionService : Instance
    {
    }

    [RbxService]
    public class CommandService : Instance
    {
    }

    [RbxService]
    public class CommerceService : Instance
    {
    }

    [RbxService]
    public class ConfigService : Instance
    {
    }

    public class Configuration : Instance
    {
    }

    [RbxService]
    public class ConfigureServerService : Instance
    {
    }

    [RbxService]
    public class ConnectivityService : Instance
    {
    }

    public abstract class Constraint : Instance
    {
        public Attachment Attachment0 = null;
        public Attachment Attachment1 = null;
        public BrickColor Color = BrickColorId.Bright_blue;
        public bool Enabled = true;
        public bool Visible;
    }

    public class AlignOrientation : Constraint
    {
        public AlignType AlignType = AlignType.AllAxes;
        public CFrame CFrame = CFrame.identity;
        public float MaxAngularVelocity = float.MaxValue;
        public float MaxTorque = 10000;
        public OrientationAlignmentMode Mode = OrientationAlignmentMode.TwoAttachment;
        public bool PrimaryAxisOnly;
        public bool ReactionTorqueEnabled;
        public float Responsiveness = 10;
        public bool RigidityEnabled;
    }

    public class AlignPosition : Constraint
    {
        public AlignPosition() : base()
        {
            Color = BrickColorId.Medium_stone_grey;
        }

        public bool ApplyAtCenterOfMass;
        public ForceLimitMode ForceLimitMode = ForceLimitMode.Magnitude;
        public ActuatorRelativeTo ForceRelativeTo = ActuatorRelativeTo.World;
        public Vector3 MaxAxesForce = new Vector3(10000, 10000, 10000);
        public float MaxForce = 10000;
        public float MaxVelocity = float.MaxValue;
        public PositionAlignmentMode Mode = PositionAlignmentMode.TwoAttachment;
        public Vector3 Position = Vector3.zero;
        public bool ReactionForceEnabled;
        public float Responsiveness = 10;
        public bool RigidityEnabled;
    }

    public class AngularVelocity : Constraint
    {
        public Vector3 AngularVelocity_ = Vector3.zero;
        public float MaxTorque = 0;
        public bool ReactionTorqueEnabled;
        public ActuatorRelativeTo RelativeTo = ActuatorRelativeTo.World;
    }

    public class AnimationConstraint : Constraint
    {
        public bool IsKinematic;
        public float MaxForce = 10000;
        public float MaxTorque = 10000;
        public CFrame Transform = CFrame.identity;
    }

    public class BallSocketConstraint : Constraint
    {
        public BallSocketConstraint() : base()
        {
            Color = BrickColorId.New_Yeller;
        }

        public bool LimitsEnabled;
        public float MaxFrictionTorqueXml = 0;
        public float Radius = 0.15f;
        public float Restitution = 0;
        public bool TwistLimitsEnabled;
        public float TwistLowerAngle = -45;
        public float TwistUpperAngle = 45;
        public float UpperAngle = 45;
    }

    public class HingeConstraint : Constraint
    {
        public HingeConstraint() : base()
        {
            Color = BrickColorId.New_Yeller;
        }

        public ActuatorType ActuatorType = ActuatorType.None;
        public float AngularResponsiveness = 45;
        public float AngularSpeed = 0;
        public float AngularVelocity = 0;
        public bool LimitsEnabled;
        public float LowerAngle = -45;
        public float MotorMaxAcceleration = 500000;
        public float MotorMaxTorque = 0;
        public float Radius = 0.15f;
        public float Restitution = 0;
        public float ServoMaxTorque = 0;

        [Obsolete]
        public bool SoftlockServoUponReachingTarget;

        public float TargetAngle = 0;
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

    public class LinearVelocity : Constraint
    {
        public LinearVelocity() : base()
        {
            Color = BrickColorId.Black;
        }

        public ForceLimitMode ForceLimitMode = ForceLimitMode.Magnitude;
        public bool ForceLimitsEnabled = true;
        public Vector3 LineDirection = Vector3.xAxis;
        public float LineVelocity = 0;
        public Vector3 MaxAxesForce = new Vector3(1000, 1000, 1000);
        public float MaxForce = 1000;
        public Vector2 MaxPlanarAxesForce = new Vector2(1000, 1000);
        public Vector2 PlaneVelocity = Vector2.zero;
        public Vector3 PrimaryTangentAxis = Vector3.xAxis;
        public bool ReactionForceEnabled = true;
        public ActuatorRelativeTo RelativeTo = ActuatorRelativeTo.World;
        public Vector3 SecondaryTangentAxis = Vector3.yAxis;
        public Vector3 VectorVelocity = Vector3.zero;
        public VelocityConstraintMode VelocityConstraintMode = VelocityConstraintMode.Vector;
    }

    public class PlaneConstraint : Constraint
    {
        public PlaneConstraint() : base()
        {
            Color = BrickColorId.Medium_stone_grey;
        }
    }

    public class Plane : PlaneConstraint
    {
        public Plane() : base()
        {
            Color = BrickColorId.Medium_stone_grey;
        }
    }

    public class RigidConstraint : Constraint
    {
        public RigidConstraint() : base()
        {
            Color = BrickColorId.Medium_stone_grey;
        }
    }

    public class RodConstraint : Constraint
    {
        public RodConstraint() : base()
        {
            Color = BrickColorId.Black;
        }

        public float Length = 5;
        public float LimitAngle0 = 90;
        public float LimitAngle1 = 90;
        public bool LimitsEnabled;
        public float Thickness = 0.1f;
    }

    public class RopeConstraint : Constraint
    {
        public RopeConstraint() : base()
        {
            Color = BrickColorId.Earth_orange;
        }

        public float Length = 5;
        public float Restitution = 0;
        public float Thickness = 0.1f;
        public bool WinchEnabled;
        public float WinchForce = 10000;
        public float WinchResponsiveness = 45;
        public float WinchSpeed = 2;
        public float WinchTarget = 5;
    }

    public abstract class SlidingBallConstraint : Constraint
    {
        public SlidingBallConstraint() : base()
        {
            Color = BrickColorId.New_Yeller;
        }

        public ActuatorType ActuatorType = ActuatorType.None;
        public bool LimitsEnabled;
        public float LinearResponsiveness = 45;
        public float LowerLimit = 0;
        public float MotorMaxAcceleration = float.MaxValue;
        public float MotorMaxForce = 0;
        public float Restitution = 0;
        public float ServoMaxForce = 0;
        public float Size = 0.15f;

        [Obsolete]
        public bool SoftlockServoUponReachingTarget;

        public float Speed = 0;
        public float TargetPosition = 0;
        public float UpperLimit = 5;
        public float Velocity = 0;
    }

    public class CylindricalConstraint : SlidingBallConstraint
    {
        public CylindricalConstraint() : base()
        {
            Color = BrickColorId.New_Yeller;
        }

        public ActuatorType AngularActuatorType = ActuatorType.None;
        public bool AngularLimitsEnabled;
        public float AngularResponsiveness = 45;
        public float AngularRestitution = 0;
        public float AngularSpeed = 0;
        public float AngularVelocity = 0;
        public float InclinationAngle = 0;
        public float LowerAngle = -45;
        public float MotorMaxAngularAcceleration = 500000;
        public float MotorMaxTorque = 0;
        public bool RotationAxisVisible;
        public float ServoMaxTorque = 0;

        [Obsolete]
        public bool SoftlockAngularServoUponReachingTarget;

        public float TargetAngle = 0;
        public float UpperAngle = 45;
    }

    public class PrismaticConstraint : SlidingBallConstraint
    {
        public PrismaticConstraint() : base()
        {
            Color = BrickColorId.New_Yeller;
        }
    }

    public class SpringConstraint : Constraint
    {
        public SpringConstraint() : base()
        {
            Color = BrickColorId.Lemon_metalic;
        }

        public float Coils = 3;
        public float Damping = 0;
        public float FreeLength = 1;
        public bool LimitsEnabled;
        public float MaxForce = float.MaxValue;
        public float MaxLength = 5;
        public float MinLength = 0;
        public float Radius = 0.4f;
        public float Stiffness = 0;
        public float Thickness = 0.1f;
    }

    public class Torque : Constraint
    {
        public ActuatorRelativeTo RelativeTo = ActuatorRelativeTo.Attachment0;
        public Vector3 Torque_ = Vector3.zero;
    }

    public class TorsionSpringConstraint : Constraint
    {
        public TorsionSpringConstraint() : base()
        {
            Color = BrickColorId.Lemon_metalic;
        }

        public float Coils = 8;
        public float Damping = 0.01f;

        [Obsolete]
        public bool LimitEnabled;

        public bool LimitsEnabled;
        public float MaxAngle = 45;
        public float MaxTorque = float.MaxValue;
        public float Radius = 0.4f;
        public float Restitution = 0;
        public float Stiffness = 100;
    }

    public class UniversalConstraint : Constraint
    {
        public UniversalConstraint() : base()
        {
            Color = BrickColorId.New_Yeller;
        }

        public bool LimitsEnabled;
        public float MaxAngle = 45;
        public float Radius = 0.2f;
        public float Restitution = 0;
    }

    public class VectorForce : Constraint
    {
        public bool ApplyAtCenterOfMass;
        public Vector3 Force = new Vector3(1000, 0, 0);
        public ActuatorRelativeTo RelativeTo = ActuatorRelativeTo.Attachment0;
    }

    [RbxService]
    public class ContentProvider : Instance
    {
    }

    [RbxService]
    public class ContextActionService : Instance
    {
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

    public abstract class ControllerBase : Instance
    {
        public bool BalanceRigidityEnabled;
        public float MoveSpeedFactor = 1;
    }

    public class AirController : ControllerBase
    {
        public float BalanceMaxTorque = 10000;
        public float BalanceSpeed = 100;
        public bool MaintainAngularMomentum = true;
        public bool MaintainLinearMomentum = true;
        public float MoveMaxForce = 1000;
        public float TurnMaxTorque = 10000;
        public float TurnSpeedFactor = 1;
    }

    public class ClimbController : ControllerBase
    {
        public float AccelerationTime = 0;
        public float BalanceMaxTorque = 10000;
        public float BalanceSpeed = 100;
        public float MoveMaxForce = 10000;
    }

    public class GroundController : ControllerBase
    {
        public float AccelerationLean = 1;
        public float AccelerationTime = 0;
        public float BalanceMaxTorque = 10000;
        public float BalanceSpeed = 100;
        public float DecelerationTime = 0;
        public float Friction = 2;
        public float FrictionWeight = 1;
        public float GroundOffset = 1;
        public float StandForce = 10000;
        public float StandSpeed = 100;
        public float TurnSpeedFactor = 1;
    }

    public class SwimController : ControllerBase
    {
        public float AccelerationTime = 0;
        public float PitchMaxTorque = 10000;
        public float PitchSpeedFactor = 1;
        public float RollMaxTorque = 10000;
        public float RollSpeedFactor = 1;
    }

    public class ControllerManager : Instance
    {
        public ControllerBase ActiveController = null;
        public float BaseMoveSpeed = 16;
        public float BaseTurnSpeed = 8;
        public ControllerSensor ClimbSensor = null;
        public Vector3 FacingDirection = Vector3.zAxis;
        public ControllerSensor GroundSensor = null;
        public Vector3 MovingDirection = Vector3.zero;
        public BasePart RootPart = null;
        public Vector3 UpDirection = Vector3.yAxis;
    }

    [RbxService]
    public class ControllerService : Instance
    {
    }

    [RbxService]
    public class ConversationalAIAcceptanceService : Instance
    {
    }

    [RbxService]
    public class CookiesService : Instance
    {
    }

    [RbxService]
    public class CorePackages : Instance
    {
    }

    [RbxService]
    public class CoreScriptDebuggingManagerHelper : Instance
    {
    }

    [RbxService]
    public class CoreScriptSyncService : Instance
    {
    }

    [RbxService]
    public class CreationDBService : Instance
    {
    }

    [RbxService]
    public class CreatorStoreService : Instance
    {
    }

    [RbxService]
    public class CrossDMScriptChangeListener : Instance
    {
    }

    public class CustomEvent : Instance
    {
        public float PersistedCurrentValue = 0;
    }

    public class CustomEventReceiver : Instance
    {
        public Instance Source = null;
    }

    public class CustomLog : Instance
    {
    }

    public abstract class DataModelMesh : Instance
    {
        public Vector3 Offset = Vector3.zero;
        public Vector3 Scale = Vector3.one;
        public Vector3 VertexColor = Vector3.one;
    }

    public abstract class BevelMesh : DataModelMesh
    {
        public float Bevel = 0;
        public float Bevel_Roundness = 0;
        public float Bulge = 0;
    }

    public class BlockMesh : BevelMesh
    {
    }

    public class CylinderMesh : BevelMesh
    {
    }

    public class FileMesh : DataModelMesh
    {
        public ContentId MeshId = "";
        public ContentId TextureId = "";
    }

    public class SpecialMesh : FileMesh
    {
        public MeshType MeshType = MeshType.Head;
    }

    [RbxService]
    public class DataModelPatchService : Instance
    {
    }

    public class DataStoreGetOptions : Instance
    {
        public bool UseCache = true;
    }

    public class DataStoreIncrementOptions : Instance
    {
    }

    public class DataStoreOptions : Instance
    {
        public bool AllScopes;
    }

    [RbxService]
    public class DataStoreService : Instance
    {
        public bool AutomaticRetry = true;

        [Obsolete]
        public bool LegacyNamingScheme;
    }

    public class DataStoreSetOptions : Instance
    {
    }

    [RbxService]
    public class Debris : Instance
    {
        [Obsolete]
        public int MaxItems = 1000;
    }

    [RbxService]
    public class DebuggablePluginWatcher : Instance
    {
    }

    [RbxService]
    public class DebuggerConnectionManager : Instance
    {
        public double Timeout = 0;
    }

    [RbxService]
    public class DebuggerManager : Instance
    {
    }

    [RbxService]
    public class DebuggerUIService : Instance
    {
    }

    public class DebuggerWatch : Instance
    {
        public string Expression = "";
    }

    [RbxService]
    public class DeviceIdService : Instance
    {
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
        public float TriggerDistance = 0;
        public Vector3 TriggerOffset = Vector3.zero;
    }

    public class DialogChoice : Instance
    {
        public bool GoodbyeChoiceActive = true;
        public string GoodbyeDialog = "";
        public string ResponseDialog = "";
        public string UserDialog = "";
    }

    [RbxService]
    public class DraftsService : Instance
    {
    }

    public class Dragger : Instance
    {
    }

    [RbxService]
    public class DraggerService : Instance
    {
    }

    [RbxService]
    public class EditableService : Instance
    {
    }

    public class EulerRotationCurve : Instance
    {
        public RotationOrder RotationOrder = RotationOrder.XYZ;
    }

    [RbxService]
    public class EventIngestService : Instance
    {
    }

    [RbxService]
    public class ExampleService : Instance
    {
    }

    [RbxService]
    public class ExperienceAuthService : Instance
    {
    }

    public class ExperienceInviteOptions : Instance
    {
        public string InviteMessageId = "";
        public long InviteUser = 0;
        public string LaunchData = "";
        public string PromptMessage = "";
    }

    [RbxService]
    public class ExperienceNotificationService : Instance
    {
    }

    [RbxService]
    public class ExperienceService : Instance
    {
    }

    [RbxService]
    public class ExperienceStateCaptureService : Instance
    {
    }

    public class ExplorerFilter : Instance
    {
    }

    [RbxService]
    public class ExplorerServiceVisibilityService : Instance
    {
    }

    public class Explosion : Instance
    {
        public float BlastPressure = 500000;
        public float BlastRadius = 4;
        public float DestroyJointRadiusPercent = 1;
        public ExplosionType ExplosionType = ExplosionType.Craters;
        public Vector3 Position = Vector3.zero;
        public float TimeScale = 1;
        public bool Visible = true;
    }

    [RbxService]
    public class FaceAnimatorService : Instance
    {
    }

    public class FaceControls : Instance
    {
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
        public float Specular = 0;

        public ContentId Texture
        {
            get => TextureContent;
            set => TextureContent = value;
        }

        public Content TextureContent = Content.None;
        public float Transparency = 0;
        public int ZIndex = 1;
    }

    public class Texture : Decal
    {
        public float OffsetStudsU = 0;
        public float OffsetStudsV = 0;
        public float StudsPerTileU = 2;
        public float StudsPerTileV = 2;
    }

    [RbxService]
    public class FacialAgeEstimationService : Instance
    {
    }

    [RbxService]
    public class FacialAnimationRecordingService : Instance
    {
    }

    [RbxService]
    public class FacialAnimationStreamingServiceV2 : Instance
    {
        public int ServiceState = 0;
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

    [RbxService]
    public class FeatureRestrictionManager : Instance
    {
    }

    [RbxService]
    public class FeedService : Instance
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

        public float TimeScale = 1;
        public float heat_xml = 9;

        [Obsolete]
        public float size
        {
            get => Size;
            set => Size = value;
        }

        public float size_xml = 5;
    }

    [RbxService]
    public class FlagStandService : Instance
    {
    }

    public class FloatCurve : Instance
    {
        public byte[] ValuesAndTimes = Convert.FromBase64String("AAAAAAEAAAAKAAAAAAAAFkUAAAAA");
    }

    [RbxService]
    public class FlyweightService : Instance
    {
    }

    [RbxService]
    public class CSGDictionaryService : FlyweightService
    {
    }

    [RbxService]
    public class NonReplicatedCSGDictionaryService : FlyweightService
    {
    }

    public class Folder : Instance
    {
    }

    public class ForceField : Instance
    {
        public bool Visible = true;
    }

    [RbxService]
    public class FriendService : Instance
    {
    }

    public class FunctionalTest : Instance
    {
        public string Description = "?";
        public bool HasMigratedSettingsToTestService;
    }

    [RbxService]
    public class GamePassService : Instance
    {
    }

    [RbxService]
    public class GamepadService : Instance
    {
        public bool GamepadCursorEnabled;
    }

    [RbxService]
    public class GenerationService : Instance
    {
    }

    [RbxService]
    public class GenericChallengeService : Instance
    {
    }

    [RbxService]
    public class Geometry : Instance
    {
    }

    [RbxService]
    public class GeometryService : Instance
    {
    }

    public class GetTextBoundsParams : Instance
    {
        public FontFace Font = FontFace.FromEnum(Enums.Font.SourceSans);
        public bool RichText;
        public float Size = 20;
        public string Text = "";
        public float Width = 0;
    }

    [RbxService]
    public class GroupService : Instance
    {
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

        public LocalizationTable RootLocalizationTable = null;
        public SelectionBehavior SelectionBehaviorDown = SelectionBehavior.Escape;
        public SelectionBehavior SelectionBehaviorLeft = SelectionBehavior.Escape;
        public SelectionBehavior SelectionBehaviorRight = SelectionBehavior.Escape;
        public SelectionBehavior SelectionBehaviorUp = SelectionBehavior.Escape;
        public bool SelectionGroup;
    }

    public abstract class GuiObject : GuiBase2d
    {
        public bool Active;
        public Vector2 AnchorPoint = Vector2.zero;
        public AutomaticSize AutomaticSize = AutomaticSize.None;

        [Obsolete]
        public BrickColor BackgroundColor
        {
            get => BrickColor.FromColor3(BackgroundColor3);
            set => BackgroundColor3 = value?.Color;
        }

        public Color3 BackgroundColor3 = Color3.FromRGB(163, 162, 165);
        public float BackgroundTransparency = 0;

        [Obsolete]
        public BrickColor BorderColor
        {
            get => BrickColor.FromColor3(BorderColor3);
            set => BorderColor3 = value?.Color;
        }

        public Color3 BorderColor3 = Color3.FromRGB(27, 42, 53);
        public BorderMode BorderMode = BorderMode.Outline;
        public int BorderSizePixel = 1;
        public bool ClipsDescendants = true;

        [Obsolete]
        public bool Draggable;

        public bool Interactable = true;
        public int LayoutOrder = 0;
        public GuiObject NextSelectionDown = null;
        public GuiObject NextSelectionLeft = null;
        public GuiObject NextSelectionRight = null;
        public GuiObject NextSelectionUp = null;
        public UDim2 Position = new UDim2();
        public float Rotation = 0;
        public bool Selectable;
        public GuiObject SelectionImageObject = null;
        public int SelectionOrder = 0;
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

    public class CanvasGroup : GuiObject
    {
        public Color3 GroupColor3 = new Color3(1, 1, 1);
        public float GroupTransparency = 0;
    }

    public class Frame : GuiObject
    {
        public Frame() : base()
        {
            ClipsDescendants = false;
        }

        public FrameStyle Style = FrameStyle.Custom;
    }

    public abstract class GuiButton : GuiObject
    {
        public GuiButton() : base()
        {
            Active = true;
            ClipsDescendants = false;
            Selectable = true;
        }

        public bool AutoButtonColor = true;
        public HapticEffect HoverHapticEffect = null;
        public bool Modal;
        public HapticEffect PressHapticEffect = null;
        public bool Selected;
        public ButtonStyle Style = ButtonStyle.Custom;
    }

    public class ImageButton : GuiButton
    {
        public ImageButton() : base()
        {
            Active = true;
            ClipsDescendants = false;
            Selectable = true;
        }

        public ContentId HoverImage
        {
            get => HoverImageContent;
            set => HoverImageContent = value;
        }

        public Content HoverImageContent = Content.None;

        public ContentId Image
        {
            get => ImageContent;
            set => ImageContent = value;
        }

        public Color3 ImageColor3 = new Color3(1, 1, 1);
        public Content ImageContent = Content.None;
        public Vector2 ImageRectOffset = Vector2.zero;
        public Vector2 ImageRectSize = Vector2.zero;
        public float ImageTransparency = 0;

        public ContentId PressedImage
        {
            get => PressedImageContent;
            set => PressedImageContent = value;
        }

        public Content PressedImageContent = Content.None;
        public ResamplerMode ResampleMode = ResamplerMode.Default;
        public ScaleType ScaleType = ScaleType.Stretch;
        public Rect SliceCenter = new Rect();
        public float SliceScale = 1;
        public UDim2 TileSize = new UDim2(1, 0, 1, 0);
    }

    public class TextButton : GuiButton
    {
        public TextButton() : base()
        {
            Active = true;
            ClipsDescendants = false;
            Selectable = true;
        }

        public Font Font
        {
            get => FontUtility.GetLegacyFont(FontFace);
            set => FontUtility.TryGetFontFace(value, out FontFace);
        }

        public FontFace FontFace = FontFace.FromEnum(Enums.Font.Legacy);

        [Obsolete]
        public FontSize FontSize
        {
            get => FontUtility.GetFontSize(TextSize);
            set => TextSize = FontUtility.GetFontSize(value);
        }

        public float LineHeight = 1;
        public string LocalizationMatchIdentifier = "";
        public string LocalizationMatchedSourceText = "";
        public int MaxVisibleGraphemes = -1;
        public string OpenTypeFeatures = "";
        public bool RichText;
        public string Text = "Button";

        [Obsolete]
        public BrickColor TextColor
        {
            get => BrickColor.FromColor3(TextColor3);
            set => TextColor3 = value?.Color;
        }

        public Color3 TextColor3 = Color3.FromRGB(27, 42, 53);
        public TextDirection TextDirection = TextDirection.Auto;
        public bool TextScaled;
        public float TextSize = 8;
        public Color3 TextStrokeColor3 = new Color3();
        public float TextStrokeTransparency = 1;
        public float TextTransparency = 0;
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
    }

    public abstract class GuiLabel : GuiObject
    {
        public GuiLabel() : base()
        {
            ClipsDescendants = false;
        }
    }

    public class ImageLabel : GuiLabel
    {
        public ImageLabel() : base()
        {
            ClipsDescendants = false;
        }

        public ContentId Image
        {
            get => ImageContent;
            set => ImageContent = value;
        }

        public Color3 ImageColor3 = new Color3(1, 1, 1);
        public Content ImageContent = Content.None;
        public Vector2 ImageRectOffset = Vector2.zero;
        public Vector2 ImageRectSize = Vector2.zero;
        public float ImageTransparency = 0;
        public ResamplerMode ResampleMode = ResamplerMode.Default;
        public ScaleType ScaleType = ScaleType.Stretch;
        public Rect SliceCenter = new Rect();
        public float SliceScale = 1;
        public UDim2 TileSize = new UDim2(1, 0, 1, 0);
    }

    public class TextLabel : GuiLabel
    {
        public TextLabel() : base()
        {
            ClipsDescendants = false;
        }

        public Font Font
        {
            get => FontUtility.GetLegacyFont(FontFace);
            set => FontUtility.TryGetFontFace(value, out FontFace);
        }

        public FontFace FontFace = FontFace.FromEnum(Enums.Font.Legacy);

        [Obsolete]
        public FontSize FontSize
        {
            get => FontUtility.GetFontSize(TextSize);
            set => TextSize = FontUtility.GetFontSize(value);
        }

        public float LineHeight = 1;
        public string LocalizationMatchIdentifier = "";
        public string LocalizationMatchedSourceText = "";
        public int MaxVisibleGraphemes = -1;
        public string OpenTypeFeatures = "";
        public bool RichText;
        public string Text = "Label";

        [Obsolete]
        public BrickColor TextColor
        {
            get => BrickColor.FromColor3(TextColor3);
            set => TextColor3 = value?.Color;
        }

        public Color3 TextColor3 = Color3.FromRGB(27, 42, 53);
        public TextDirection TextDirection = TextDirection.Auto;
        public bool TextScaled;
        public float TextSize = 8;
        public Color3 TextStrokeColor3 = new Color3();
        public float TextStrokeTransparency = 1;
        public float TextTransparency = 0;
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
    }

    public class RelativeGui : GuiObject
    {
    }

    public class ScrollingFrame : GuiObject
    {
        public ScrollingFrame() : base()
        {
            Selectable = true;
            SelectionGroup = true;
        }

        public AutomaticSize AutomaticCanvasSize = AutomaticSize.None;
        public ContentId BottomImage = "rbxasset://textures/ui/Scroll/scroll-bottom.png";
        public Vector2 CanvasPosition = Vector2.zero;
        public UDim2 CanvasSize = new UDim2(0, 0, 2, 0);
        public ElasticBehavior ElasticBehavior = ElasticBehavior.WhenScrollable;
        public ScrollBarInset HorizontalScrollBarInset = ScrollBarInset.None;
        public ContentId MidImage = "rbxasset://textures/ui/Scroll/scroll-middle.png";
        public Color3 ScrollBarImageColor3 = new Color3(1, 1, 1);
        public float ScrollBarImageTransparency = 0;
        public int ScrollBarThickness = 12;
        public ScrollingDirection ScrollingDirection = ScrollingDirection.XY;
        public bool ScrollingEnabled = true;
        public ContentId TopImage = "rbxasset://textures/ui/Scroll/scroll-top.png";
        public ScrollBarInset VerticalScrollBarInset = ScrollBarInset.None;
        public VerticalScrollBarPosition VerticalScrollBarPosition = VerticalScrollBarPosition.Right;
    }

    public class TextBox : GuiObject
    {
        public TextBox() : base()
        {
            Active = true;
            ClipsDescendants = false;
            Selectable = true;
        }

        public bool ClearTextOnFocus = true;

        public Font Font
        {
            get => FontUtility.GetLegacyFont(FontFace);
            set => FontUtility.TryGetFontFace(value, out FontFace);
        }

        public FontFace FontFace = FontFace.FromEnum(Enums.Font.Legacy);

        [Obsolete]
        public FontSize FontSize
        {
            get => FontUtility.GetFontSize(TextSize);
            set => TextSize = FontUtility.GetFontSize(value);
        }

        public float LineHeight = 1;
        public string LocalizationMatchIdentifier = "";
        public string LocalizationMatchedSourceText = "";
        public int MaxVisibleGraphemes = -1;
        public bool MultiLine;
        public string OpenTypeFeatures = "";
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
        public TextDirection TextDirection = TextDirection.Auto;
        public bool TextEditable = true;
        public bool TextScaled;
        public float TextSize = 8;
        public Color3 TextStrokeColor3 = new Color3();
        public float TextStrokeTransparency = 1;
        public float TextTransparency = 0;
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
    }

    public class VideoDisplay : GuiObject
    {
        public VideoDisplay() : base()
        {
            ClipsDescendants = false;
        }

        public ResamplerMode ResampleMode = ResamplerMode.Default;
        public ScaleType ScaleType = ScaleType.Stretch;
        public UDim2 TileSize = new UDim2(1, 0, 1, 0);
        public Color3 VideoColor3 = new Color3(1, 1, 1);
        public Vector2 VideoRectOffset = Vector2.zero;
        public Vector2 VideoRectSize = Vector2.zero;
        public float VideoTransparency = 0;
    }

    public class VideoFrame : GuiObject
    {
        public VideoFrame() : base()
        {
            ClipsDescendants = false;
        }

        public bool Looped;
        public bool Playing;
        public double TimePosition = 0;
        public ContentId Video = "";
        public Content VideoContent;
        public float Volume = 1;
    }

    public class ViewportFrame : GuiObject
    {
        public ViewportFrame() : base()
        {
            ClipsDescendants = false;
        }

        public Color3 Ambient = Color3.FromRGB(200, 200, 200);
        public CFrame CameraCFrame = CFrame.identity;
        public float CameraFieldOfView = 70;
        public Color3 ImageColor3 = new Color3(1, 1, 1);
        public float ImageTransparency = 0;
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
        public Instance Adornee = null;
        public bool AlwaysOnTop;
        public float Brightness = 1;
        public bool ClipsDescendants;
        public float DistanceLowerLimit = 0;
        public float DistanceStep = 0;
        public float DistanceUpperLimit = -1;
        public Vector3 ExtentsOffset = Vector3.zero;
        public Vector3 ExtentsOffsetWorldSpace = Vector3.zero;
        public float LightInfluence = 0;
        public float MaxDistance = float.MaxValue;
        public Instance PlayerToHideFrom = null;
        public UDim2 Size = new UDim2();
        public Vector2 SizeOffset = Vector2.zero;
        public Vector3 StudsOffset = Vector3.zero;
        public Vector3 StudsOffsetWorldSpace = Vector3.zero;
    }

    public class ScreenGui : LayerCollector
    {
        public bool ClipToDeviceSafeArea = true;
        public int DisplayOrder = 0;
        public SafeAreaCompatibility SafeAreaCompatibility = SafeAreaCompatibility.FullscreenExtension;
        public ScreenInsets ScreenInsets = ScreenInsets.CoreUISafeInsets;
    }

    public class GuiMain : ScreenGui
    {
    }

    public abstract class SurfaceGuiBase : LayerCollector
    {
        public bool Active;
        public Instance Adornee;
        public NormalId Face = NormalId.Right;
    }

    public class AdGui : SurfaceGuiBase
    {
        public AdShape AdShape = AdShape.HorizontalRectangle;
        public bool EnableVideoAds;
        public ContentId FallbackImage;
    }

    public class SurfaceGui : SurfaceGuiBase
    {
        public bool AlwaysOnTop;
        public float Brightness = 1;
        public Vector2 CanvasSize = new Vector2(800, 600);
        public bool ClipsDescendants;
        public float LightInfluence = 0;
        public float MaxDistance = 0;
        public float PixelsPerStud = 50;
        public SurfaceGuiSizingMode SizingMode = SurfaceGuiSizingMode.FixedSize;
        public float ToolPunchThroughDistance = 0;
        public float ZOffset = 0;
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
        public float Transparency = 0;
        public bool Visible = true;
    }

    public class FloorWire : GuiBase3d
    {
        public float CycleOffset = 0;
        public BasePart From = null;
        public float StudsBetweenTextures = 4;
        public ContentId Texture = "";
        public Vector2 TextureSize = Vector2.one;
        public BasePart To = null;
        public float Velocity = 2;
        public float WireRadius = 0.0625f;
    }

    public abstract class InstanceAdornment : GuiBase3d
    {
        public Instance Adornee = null;
    }

    public class SelectionBox : InstanceAdornment
    {
        public float LineThickness = 0.15f;
        public bool StudioSelectionBox;

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
        public PVInstance Adornee = null;
    }

    public abstract class HandleAdornment : PVAdornment
    {
        public AdornCullingMode AdornCullingMode = AdornCullingMode.Automatic;
        public bool AlwaysOnTop;
        public CFrame CFrame = CFrame.identity;
        public Vector3 SizeRelativeOffset = Vector3.zero;
        public int ZIndex = -1;
    }

    public class BoxHandleAdornment : HandleAdornment
    {
        public Vector3 Size = Vector3.one;
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
        public float InnerRadius = 0;
        public float Radius = 1;
    }

    public class ImageHandleAdornment : HandleAdornment
    {
        public ImageHandleAdornment() : base()
        {
            Color = BrickColorId.White;
            Color3 = Color3.FromRGB(242, 243, 243);
        }

        public ContentId Image = "rbxasset://textures/SurfacesDefault.png";
        public Vector2 Size = Vector2.one;
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

    public class WireframeHandleAdornment : HandleAdornment
    {
        public Vector3 Scale = Vector3.one;
        public float Thickness = 1;
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
        public BasePart Adornee = null;
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
        public Humanoid Humanoid = null;
    }

    public class SelectionPartLasso : SelectionLasso
    {
        public BasePart Part = null;
    }

    public class SelectionPointLasso : SelectionLasso
    {
        public Vector3 Point = Vector3.zero;
    }

    public class Path2D : GuiBase
    {
        public bool Closed;
        public Color3 Color3 = new Color3();
        public byte[] PropertiesSerialize;
        public float Thickness = 1;
        public float Transparency = 0;
        public bool Visible = true;
        public int ZIndex = 1;
    }

    [RbxService]
    public class GuiService : Instance
    {
        public bool AutoSelectGuiEnabled = true;
        public bool GuiNavigationEnabled = true;
        public GuiObject SelectedObject = null;
    }

    [RbxService]
    public class GuidRegistryService : Instance
    {
    }

    public class HandRigDescription : Instance
    {
        public Instance Index1 = null;
        public CFrame Index1TposeAdjustment = CFrame.identity;
        public Instance Index2 = null;
        public CFrame Index2TposeAdjustment = CFrame.identity;
        public Instance Index3 = null;
        public CFrame Index3TposeAdjustment = CFrame.identity;
        public Vector3 IndexRange = Vector3.zero;
        public float IndexSize = 0;
        public Instance Middle1 = null;
        public CFrame Middle1TposeAdjustment = CFrame.identity;
        public Instance Middle2 = null;
        public CFrame Middle2TposeAdjustment = CFrame.identity;
        public Instance Middle3 = null;
        public CFrame Middle3TposeAdjustment = CFrame.identity;
        public Vector3 MiddleRange = Vector3.zero;
        public float MiddleSize = 0;
        public Instance Pinky1 = null;
        public CFrame Pinky1TposeAdjustment = CFrame.identity;
        public Instance Pinky2 = null;
        public CFrame Pinky2TposeAdjustment = CFrame.identity;
        public Instance Pinky3 = null;
        public CFrame Pinky3TposeAdjustment = CFrame.identity;
        public Vector3 PinkyRange = Vector3.zero;
        public float PinkySize = 0;
        public Instance Ring1 = null;
        public CFrame Ring1TposeAdjustment = CFrame.identity;
        public Instance Ring2 = null;
        public CFrame Ring2TposeAdjustment = CFrame.identity;
        public Instance Ring3 = null;
        public CFrame Ring3TposeAdjustment = CFrame.identity;
        public Vector3 RingRange = Vector3.zero;
        public float RingSize = 0;
        public HandRigDescriptionSide Side = HandRigDescriptionSide.None;
        public Instance Thumb1 = null;
        public CFrame Thumb1TposeAdjustment = CFrame.identity;
        public Instance Thumb2 = null;
        public CFrame Thumb2TposeAdjustment = CFrame.identity;
        public Instance Thumb3 = null;
        public CFrame Thumb3TposeAdjustment = CFrame.identity;
        public Vector3 ThumbRange = Vector3.zero;
        public float ThumbSize = 0;
    }

    public class HapticEffect : Instance
    {
        public bool Looped;
        public Vector3 Position = Vector3.zero;
        public float Radius = 3;
        public HapticEffectType Type = HapticEffectType.UIClick;
        public FloatCurve Waveform;
    }

    [RbxService]
    public class HapticService : Instance
    {
    }

    [RbxService]
    public class HeapProfilerService : Instance
    {
    }

    [RbxService]
    public class HeatmapService : Instance
    {
    }

    [RbxService]
    public class HeightmapImporterService : Instance
    {
    }

    public class HiddenSurfaceRemovalAsset : Instance
    {
        public byte[] HSRData;
        public byte[] HSRMeshIdData;
    }

    public class Highlight : Instance
    {
        public Instance Adornee = null;
        public HighlightDepthMode DepthMode = HighlightDepthMode.AlwaysOnTop;
        public bool Enabled = true;
        public Color3 FillColor = new Color3(1, 0, 0);
        public float FillTransparency = 0.5f;
        public Color3 OutlineColor = new Color3(1, 1, 1);
        public float OutlineTransparency = 0;
    }

    [RbxService]
    public class Hopper : Instance
    {
    }

    [RbxService]
    public class HttpRbxApiService : Instance
    {
    }

    [RbxService]
    public class HttpService : Instance
    {
        public bool HttpEnabled;
    }

    public class Humanoid : Instance
    {
        public bool AutoJumpEnabled = true;
        public bool AutoRotate = true;
        public bool AutomaticScalingEnabled = true;
        public bool BreakJointsOnDeath = true;

        [Obsolete]
        public HumanoidCollisionType CollisionType = HumanoidCollisionType.OuterBox;

        public HumanoidDisplayDistanceType DisplayDistanceType = HumanoidDisplayDistanceType.Viewer;
        public string DisplayName = "";
        public bool EvaluateStateMachine = true;

        public float Health
        {
            get => Health_XML;
            set => Health_XML = value;
        }

        public float HealthDisplayDistance = 100;
        public HumanoidHealthDisplayType HealthDisplayType = HumanoidHealthDisplayType.DisplayWhenDamaged;
        public float Health_XML = 100;
        public float HipHeight = 0;
        public Vector3 InternalBodyScale = Vector3.one;
        public float InternalHeadScale = 1;
        public float JumpHeight = 7.2f;
        public float JumpPower = 50;

        [Obsolete]
        public BasePart LeftLeg = null;

        public float MaxHealth = 100;
        public float MaxSlopeAngle = 89;
        public float NameDisplayDistance = 100;
        public NameOcclusion NameOcclusion = NameOcclusion.OccludeAll;
        public bool RequiresNeck = true;
        public HumanoidRigType RigType = HumanoidRigType.R6;

        [Obsolete]
        public BasePart RightLeg = null;

        [Obsolete]
        public BasePart Torso = null;

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
        public float BodyTypeScale = 0.3f;
        public long ClimbAnimation = 0;
        public float DepthScale = 1;
        public string EmotesDataInternal = "[]";
        public string EquippedEmotesDataInternal = "[]";
        public long Face = 0;
        public long FallAnimation = 0;
        public long GraphicTShirt = 0;

        public long Head
        {
            get => Specials.GetBodyPart(this, BodyPart.Head).AssetId;
            set => Specials.GetBodyPart(this, BodyPart.Head).AssetId = value;
        }

        public Color3 HeadColor
        {
            get => Specials.GetBodyPart(this, BodyPart.Head).Color;
            set => Specials.GetBodyPart(this, BodyPart.Head).Color = value;
        }

        public float HeadScale = 1;
        public float HeightScale = 1;
        public long IdleAnimation = 0;
        public long JumpAnimation = 0;

        public long LeftArm
        {
            get => Specials.GetBodyPart(this, BodyPart.LeftArm).AssetId;
            set => Specials.GetBodyPart(this, BodyPart.LeftArm).AssetId = value;
        }

        public Color3 LeftArmColor
        {
            get => Specials.GetBodyPart(this, BodyPart.LeftArm).Color;
            set => Specials.GetBodyPart(this, BodyPart.LeftArm).Color = value;
        }

        public long LeftLeg
        {
            get => Specials.GetBodyPart(this, BodyPart.LeftLeg).AssetId;
            set => Specials.GetBodyPart(this, BodyPart.LeftLeg).AssetId = value;
        }

        public Color3 LeftLegColor
        {
            get => Specials.GetBodyPart(this, BodyPart.LeftLeg).Color;
            set => Specials.GetBodyPart(this, BodyPart.LeftLeg).Color = value;
        }

        public long MoodAnimation = 0;
        public long Pants = 0;
        public float ProportionScale = 1;

        public long RightArm
        {
            get => Specials.GetBodyPart(this, BodyPart.RightArm).AssetId;
            set => Specials.GetBodyPart(this, BodyPart.RightArm).AssetId = value;
        }

        public Color3 RightArmColor
        {
            get => Specials.GetBodyPart(this, BodyPart.RightArm).Color;
            set => Specials.GetBodyPart(this, BodyPart.RightArm).Color = value;
        }

        public long RightLeg
        {
            get => Specials.GetBodyPart(this, BodyPart.RightLeg).AssetId;
            set => Specials.GetBodyPart(this, BodyPart.RightLeg).AssetId = value;
        }

        public Color3 RightLegColor
        {
            get => Specials.GetBodyPart(this, BodyPart.RightLeg).Color;
            set => Specials.GetBodyPart(this, BodyPart.RightLeg).Color = value;
        }

        public long RunAnimation = 0;
        public long Shirt = 0;
        public long SwimAnimation = 0;

        public long Torso
        {
            get => Specials.GetBodyPart(this, BodyPart.Torso).AssetId;
            set => Specials.GetBodyPart(this, BodyPart.Torso).AssetId = value;
        }

        public Color3 TorsoColor
        {
            get => Specials.GetBodyPart(this, BodyPart.Torso).Color;
            set => Specials.GetBodyPart(this, BodyPart.Torso).Color = value;
        }

        public long WalkAnimation = 0;
        public float WidthScale = 1;
    }

    public class HumanoidRigDescription : Instance
    {
        public Instance Chest = null;
        public Vector3 ChestRangeMax = Vector3.zero;
        public Vector3 ChestRangeMin = Vector3.zero;
        public float ChestSize = 0;
        public CFrame ChestTposeAdjustment = CFrame.identity;
        public Instance HeadBase = null;
        public Vector3 HeadBaseRangeMax = Vector3.zero;
        public Vector3 HeadBaseRangeMin = Vector3.zero;
        public float HeadBaseSize = 0;
        public CFrame HeadBaseTposeAdjustment = CFrame.identity;
        public Instance LeftAnkle = null;
        public Vector3 LeftAnkleRangeMax = Vector3.zero;
        public Vector3 LeftAnkleRangeMin = Vector3.zero;
        public float LeftAnkleSize = 0;
        public CFrame LeftAnkleTposeAdjustment = CFrame.identity;
        public Instance LeftClavicle = null;
        public Vector3 LeftClavicleRangeMax = Vector3.zero;
        public Vector3 LeftClavicleRangeMin = Vector3.zero;
        public float LeftClavicleSize = 0;
        public CFrame LeftClavicleTposeAdjustment = CFrame.identity;
        public Instance LeftElbow = null;
        public Vector3 LeftElbowRangeMax = Vector3.zero;
        public Vector3 LeftElbowRangeMin = Vector3.zero;
        public float LeftElbowSize = 0;
        public CFrame LeftElbowTposeAdjustment = CFrame.identity;
        public Instance LeftHip = null;
        public Vector3 LeftHipRangeMax = Vector3.zero;
        public Vector3 LeftHipRangeMin = Vector3.zero;
        public float LeftHipSize = 0;
        public CFrame LeftHipTposeAdjustment = CFrame.identity;
        public Instance LeftKnee = null;
        public Vector3 LeftKneeRangeMax = Vector3.zero;
        public Vector3 LeftKneeRangeMin = Vector3.zero;
        public float LeftKneeSize = 0;
        public CFrame LeftKneeTposeAdjustment = CFrame.identity;
        public Instance LeftShoulder = null;
        public Vector3 LeftShoulderRangeMax = Vector3.zero;
        public Vector3 LeftShoulderRangeMin = Vector3.zero;
        public float LeftShoulderSize = 0;
        public CFrame LeftShoulderTposeAdjustment = CFrame.identity;
        public Instance LeftToes = null;
        public Vector3 LeftToesRangeMax = Vector3.zero;
        public Vector3 LeftToesRangeMin = Vector3.zero;
        public float LeftToesSize = 0;
        public CFrame LeftToesTposeAdjustment = CFrame.identity;
        public Instance LeftWrist = null;
        public Vector3 LeftWristRangeMax = Vector3.zero;
        public Vector3 LeftWristRangeMin = Vector3.zero;
        public float LeftWristSize = 0;
        public CFrame LeftWristTposeAdjustment = CFrame.identity;
        public Instance Neck = null;
        public Vector3 NeckRangeMax = Vector3.zero;
        public Vector3 NeckRangeMin = Vector3.zero;
        public float NeckSize = 0;
        public CFrame NeckTposeAdjustment = CFrame.identity;
        public Instance Pelvis = null;
        public Vector3 PelvisRangeMax = Vector3.zero;
        public Vector3 PelvisRangeMin = Vector3.zero;
        public float PelvisSize = 0;
        public CFrame PelvisTposeAdjustment = CFrame.identity;
        public Instance RightAnkle = null;
        public Vector3 RightAnkleRangeMax = Vector3.zero;
        public Vector3 RightAnkleRangeMin = Vector3.zero;
        public float RightAnkleSize = 0;
        public CFrame RightAnkleTposeAdjustment = CFrame.identity;
        public Instance RightClavicle = null;
        public Vector3 RightClavicleRangeMax = Vector3.zero;
        public Vector3 RightClavicleRangeMin = Vector3.zero;
        public float RightClavicleSize = 0;
        public CFrame RightClavicleTposeAdjustment = CFrame.identity;
        public Instance RightElbow = null;
        public Vector3 RightElbowRangeMax = Vector3.zero;
        public Vector3 RightElbowRangeMin = Vector3.zero;
        public float RightElbowSize = 0;
        public CFrame RightElbowTposeAdjustment = CFrame.identity;
        public Instance RightHip = null;
        public Vector3 RightHipRangeMax = Vector3.zero;
        public Vector3 RightHipRangeMin = Vector3.zero;
        public float RightHipSize = 0;
        public CFrame RightHipTposeAdjustment = CFrame.identity;
        public Instance RightKnee = null;
        public Vector3 RightKneeRangeMax = Vector3.zero;
        public Vector3 RightKneeRangeMin = Vector3.zero;
        public float RightKneeSize = 0;
        public CFrame RightKneeTposeAdjustment = CFrame.identity;
        public Instance RightShoulder = null;
        public Vector3 RightShoulderRangeMax = Vector3.zero;
        public Vector3 RightShoulderRangeMin = Vector3.zero;
        public float RightShoulderSize = 0;
        public CFrame RightShoulderTposeAdjustment = CFrame.identity;
        public Instance RightToes = null;
        public Vector3 RightToesRangeMax = Vector3.zero;
        public Vector3 RightToesRangeMin = Vector3.zero;
        public float RightToesSize = 0;
        public CFrame RightToesTposeAdjustment = CFrame.identity;
        public Instance RightWrist = null;
        public Vector3 RightWristRangeMax = Vector3.zero;
        public Vector3 RightWristRangeMin = Vector3.zero;
        public float RightWristSize = 0;
        public CFrame RightWristTposeAdjustment = CFrame.identity;
        public Instance Root = null;
        public Vector3 RootRangeMax = Vector3.zero;
        public Vector3 RootRangeMin = Vector3.zero;
        public float RootSize = 0;
        public CFrame RootTposeAdjustment = CFrame.identity;
        public Instance Waist = null;
        public Vector3 WaistRangeMax = Vector3.zero;
        public Vector3 WaistRangeMin = Vector3.zero;
        public float WaistSize = 0;
        public CFrame WaistTposeAdjustment = CFrame.identity;
    }

    public class IKControl : Instance
    {
        public Instance ChainRoot = null;
        public bool Enabled = true;
        public Instance EndEffector = null;
        public CFrame EndEffectorOffset = CFrame.identity;
        public CFrame Offset = CFrame.identity;
        public Instance Pole = null;
        public int Priority = 0;
        public float SmoothTime = 0.05f;
        public Instance Target = null;
        public IKControlType Type = IKControlType.Transform;
        public float Weight = 1;
    }

    [RbxService]
    public class ILegacyStudioBridge : Instance
    {
    }

    [RbxService]
    public class LegacyStudioBridge : ILegacyStudioBridge
    {
    }

    [RbxService]
    public class IXPService : Instance
    {
    }

    [RbxService]
    public class IncrementalPatchBuilder : Instance
    {
        public bool AddPathsToBundle;
        public double BuildDebouncePeriod = 0.1;
        public bool HighCompression;
        public bool SerializePatch = true;
        public bool ZstdCompression;
    }

    public class InputAction : Instance
    {
        public bool Enabled = true;
        public InputActionType Type = InputActionType.Bool;
    }

    public class InputBinding : Instance
    {
        public KeyCode Down = KeyCode.Unknown;
        public KeyCode KeyCode = KeyCode.Unknown;
        public KeyCode Left = KeyCode.Unknown;
        public float PressedThreshold = 0.5f;
        public float ReleasedThreshold = 0.2f;
        public KeyCode Right = KeyCode.Unknown;
        public float Scale = 1;
        public GuiButton UIButton = null;
        public KeyCode Up = KeyCode.Unknown;
        public Vector2 Vector2Scale = Vector2.one;
    }

    public class InputContext : Instance
    {
        public bool Enabled = true;
        public int Priority = 1000;
        public bool Sink;
    }

    [RbxService]
    public class InsertService : Instance
    {
        public bool AllowClientInsertModels;

        [Obsolete]
        public bool AllowInsertFreeModels;
    }

    public class InternalSyncItem : Instance
    {
        public bool AutoSync;
        public bool Enabled;
        public string Path = "";
    }

    [RbxService]
    public class InternalSyncService : Instance
    {
    }

    public abstract class JointInstance : Instance
    {
        public CFrame C0 = CFrame.identity;
        public CFrame C1 = CFrame.identity;
        public bool Enabled = true;
        public BasePart Part0 = null;
        public BasePart Part1 = null;
    }

    public abstract class DynamicRotate : JointInstance
    {
        public float BaseAngle = 0;
    }

    public class RotateP : DynamicRotate
    {
    }

    public class RotateV : DynamicRotate
    {
    }

    public class Glue : JointInstance
    {
        public Vector3 F0 = Vector3.zero;
        public Vector3 F1 = Vector3.zero;
        public Vector3 F2 = Vector3.zero;
        public Vector3 F3 = Vector3.zero;
    }

    public abstract class ManualSurfaceJointInstance : JointInstance
    {
    }

    public class ManualGlue : ManualSurfaceJointInstance
    {
    }

    public class ManualWeld : ManualSurfaceJointInstance
    {
    }

    public class Motor : JointInstance
    {
        public float DesiredAngle = 0;
        public float MaxVelocity = 0;
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
        public float CurrentAngle = 0;
        public float DesiredAngle = 0;
        public Hole Hole = null;
        public float MaxVelocity = 0;
    }

    public class Weld : JointInstance
    {
    }

    [RbxService]
    public class JointsService : Instance
    {
    }

    [RbxService]
    public class KeyboardService : Instance
    {
    }

    public class Keyframe : Instance
    {
        public float Time = 0;
    }

    public class KeyframeMarker : Instance
    {
        public string Value = "";
    }

    [RbxService]
    public class KeyframeSequenceProvider : Instance
    {
    }

    [RbxService]
    public class LSPFileSyncService : Instance
    {
    }

    [RbxService]
    public class LanguageService : Instance
    {
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

    [RbxService(IsRooted = false)]
    public class Lighting : Instance
    {
        public Color3 Ambient = Color3.FromRGB(127, 127, 127);
        public float Brightness = 1;
        public Color3 ColorShift_Bottom = new Color3();
        public Color3 ColorShift_Top = new Color3();
        public float EnvironmentDiffuseScale = 0;
        public float EnvironmentSpecularScale = 0;
        public float ExposureCompensation = 0;
        public Color3 FogColor = Color3.FromRGB(191, 191, 191);
        public float FogEnd = 100000;
        public float FogStart = 0;
        public float GeographicLatitude = 41.7333f;
        public bool GlobalShadows;
        public LightingStyle LightingStyle = LightingStyle.Realistic;
        public Color3 OutdoorAmbient = Color3.FromRGB(127, 127, 127);

        [Obsolete]
        public bool Outlines = true;

        public bool PrioritizeLightingQuality;

        [Obsolete]
        public Color3 ShadowColor = Color3.FromRGB(178, 178, 183);

        public float ShadowSoftness = 0.5f;
        public Technology Technology = Technology.Compatibility;
        public string TimeOfDay = "14:00:00";
    }

    [RbxService]
    public class LinkingService : Instance
    {
    }

    [RbxService]
    public class LiveScriptingService : Instance
    {
    }

    [RbxService]
    public class LiveSyncService : Instance
    {
    }

    [RbxService]
    public class LocalStorageService : Instance
    {
    }

    [RbxService]
    public class AppStorageService : LocalStorageService
    {
    }

    [RbxService]
    public class UserStorageService : LocalStorageService
    {
    }

    [RbxService]
    public class LocalizationService : Instance
    {
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

    [RbxService]
    public class LodDataService : Instance
    {
    }

    [RbxService]
    public class LogReporterService : Instance
    {
    }

    [RbxService]
    public class LogService : Instance
    {
    }

    [RbxService]
    public class LoginService : Instance
    {
    }

    public abstract class LuaSourceContainer : Instance
    {
        public string ScriptGuid = "";
    }

    public class AuroraScript : LuaSourceContainer
    {
        public bool EnableCulling;
        public bool EnableLOD;
        public int LODCriticality = 0;
        public int Priority = 0;
        public ProtectedString Source = "";
    }

    public abstract class BaseScript : LuaSourceContainer
    {
        public bool Disabled;

        [Obsolete]
        public ContentId LinkedSource = "";

        public RunContext RunContext = RunContext.Legacy;
    }

    public class Script : BaseScript
    {
        public ProtectedString Source = "";
    }

    public class LocalScript : Script
    {
    }

    public class ModuleScript : LuaSourceContainer
    {
        [Obsolete]
        public ContentId LinkedSource = "";

        public ProtectedString Source = "";
    }

    [RbxService]
    public class LuaWebService : Instance
    {
    }

    [RbxService]
    public class LuauScriptAnalyzerService : Instance
    {
    }

    [RbxService]
    public class MLModelDeliveryService : Instance
    {
    }

    [RbxService]
    public class MLService : Instance
    {
    }

    public class MarkerCurve : Instance
    {
        public byte[] ValuesAndTimes = Convert.FromBase64String("AAAAAAEAAAAKAAAAAAAAFkUAAAAA");
    }

    [RbxService]
    public class MarketplaceService : Instance
    {
    }

    [RbxService]
    public class MatchmakingService : Instance
    {
    }

    [RbxService]
    public class MaterialGenerationService : Instance
    {
    }

    [RbxService]
    public class MaterialService : Instance
    {
        public string AsphaltName = "Asphalt";
        public string BasaltName = "Basalt";
        public string BrickName = "Brick";
        public string CardboardName = "Cardboard";
        public string CarpetName = "Carpet";
        public string CeramicTilesName = "CeramicTiles";
        public string ClayRoofTilesName = "ClayRoofTiles";
        public string CobblestoneName = "Cobblestone";
        public string ConcreteName = "Concrete";
        public string CorrodedMetalName = "CorrodedMetal";
        public string CrackedLavaName = "CrackedLava";
        public string DiamondPlateName = "DiamondPlate";
        public string FabricName = "Fabric";
        public string FoilName = "Foil";
        public string GlacierName = "Glacier";
        public string GraniteName = "Granite";
        public string GrassName = "Grass";
        public string GroundName = "Ground";
        public string IceName = "Ice";
        public string LeafyGrassName = "LeafyGrass";
        public string LeatherName = "Leather";
        public string LimestoneName = "Limestone";
        public string MarbleName = "Marble";
        public string MetalName = "Metal";
        public string MudName = "Mud";
        public string PavementName = "Pavement";
        public string PebbleName = "Pebble";
        public string PlasterName = "Plaster";
        public string PlasticName = "Plastic";
        public string RockName = "Rock";
        public string RoofShinglesName = "RoofShingles";
        public string RubberName = "Rubber";
        public string SaltName = "Salt";
        public string SandName = "Sand";
        public string SandstoneName = "Sandstone";
        public string SlateName = "Slate";
        public string SmoothPlasticName = "SmoothPlastic";
        public string SnowName = "Snow";
        public bool Use2022MaterialsXml;
        public string WoodName = "Wood";
        public string WoodPlanksName = "WoodPlanks";
    }

    public class MaterialVariant : Instance
    {
        public Material BaseMaterial = Material.Plastic;

        public ContentId ColorMap
        {
            get => ColorMapContent;
            set => ColorMapContent = value;
        }

        public Content ColorMapContent = Content.None;
        public PhysicalProperties CustomPhysicalProperties;
        public MaterialPattern MaterialPattern = MaterialPattern.Regular;

        public ContentId MetalnessMap
        {
            get => MetalnessMapContent;
            set => MetalnessMapContent = value;
        }

        public Content MetalnessMapContent = Content.None;

        public ContentId NormalMap
        {
            get => NormalMapContent;
            set => NormalMapContent = value;
        }

        public Content NormalMapContent = Content.None;

        public ContentId RoughnessMap
        {
            get => RoughnessMapContent;
            set => RoughnessMapContent = value;
        }

        public Content RoughnessMapContent = Content.None;
        public float StudsPerTile = 10;
        public ContentId TexturePack;
    }

    [RbxService]
    public class MemStorageService : Instance
    {
    }

    [RbxService]
    public class MemoryStoreService : Instance
    {
    }

    public class Message : Instance
    {
        public string Text = "";
    }

    public class Hint : Message
    {
    }

    [RbxService]
    public class MessageBusService : Instance
    {
    }

    [RbxService]
    public class MessagingService : Instance
    {
    }

    public class MetaBreakpoint : Instance
    {
        public string Condition = "";
        public bool ContinueExecution;
        public bool Enabled;
        public int Line = 0;
        public string LogMessage = "";
        public bool RemoveOnHit;
        public string Script = "";
    }

    public class MetaBreakpointContext : Instance
    {
        public string ContextDataInternal = "0 1 2 ";
    }

    [RbxService]
    public class MetaBreakpointManager : Instance
    {
    }

    [RbxService]
    public class MouseService : Instance
    {
    }

    public abstract class NetworkPeer : Instance
    {
    }

    [RbxService]
    public class NetworkClient : NetworkPeer
    {
    }

    [RbxService]
    public class NetworkServer : NetworkPeer
    {
    }

    [RbxService]
    public class NetworkSettings : Instance
    {
        public bool HttpProxyEnabled;
        public string HttpProxyURL = "";
        public double IncomingReplicationLag = 0;
        public bool PrintJoinSizeBreakdown;
        public bool PrintPhysicsErrors;
        public bool PrintStreamInstanceQuota;
        public bool RandomizeJoinInstanceOrder;
        public bool RenderStreamedRegions;
        public bool ShowActiveAnimationAsset;
    }

    public class NoCollisionConstraint : Instance
    {
        public bool Enabled = true;
        public BasePart Part0 = null;
        public BasePart Part1 = null;
    }

    public class Noise : Instance
    {
        public NoiseType NoiseType = NoiseType.SimplexGabor;
        public int Seed = 1234;
    }

    [RbxService]
    public class NotificationService : Instance
    {
    }

    [RbxService]
    public class OmniRecommendationsService : Instance
    {
    }

    [RbxService]
    public class OpenCloudService : Instance
    {
    }

    public class OperationGraph : Instance
    {
    }

    public abstract class PVInstance : Instance
    {
    }

    public abstract class BasePart : PVInstance
    {
        public bool Anchored;
        public bool AudioCanCollide = true;

        [Obsolete]
        public float BackParamA = -0.5f;

        [Obsolete]
        public float BackParamB = 0.5f;

        public SurfaceType BackSurface = SurfaceType.Smooth;

        [Obsolete]
        public InputType BackSurfaceInput = InputType.NoInput;

        [Obsolete]
        public float BottomParamA = -0.5f;

        [Obsolete]
        public float BottomParamB = 0.5f;

        public SurfaceType BottomSurface = SurfaceType.Smooth;

        [Obsolete]
        public InputType BottomSurfaceInput = InputType.NoInput;

        public BrickColor BrickColor
        {
            get => BrickColor.FromColor3(Color);
            set => Color = value?.Color;
        }

        public CFrame CFrame = CFrame.identity;
        public bool CanCollide = true;
        public bool CanQuery = true;
        public bool CanTouch = true;
        public bool CastShadow = true;
        public string CollisionGroup = "Default";

        [Obsolete]
        public int CollisionGroupId = 0;

        public Color3 Color
        {
            get => Color3uint8;
            set => Color3uint8 = value;
        }

        public Color3uint8 Color3uint8 = Color3.FromRGB(163, 162, 165);
        public PhysicalProperties CustomPhysicalProperties;

        [Obsolete]
        public float Elasticity = 0.5f;

        public bool EnableFluidForces = true;

        [Obsolete]
        public float Friction = 0.3f;

        [Obsolete]
        public float FrontParamA = -0.5f;

        [Obsolete]
        public float FrontParamB = 0.5f;

        public SurfaceType FrontSurface = SurfaceType.Smooth;

        [Obsolete]
        public InputType FrontSurfaceInput = InputType.NoInput;

        [Obsolete]
        public float LeftParamA = -0.5f;

        [Obsolete]
        public float LeftParamB = 0.5f;

        public SurfaceType LeftSurface = SurfaceType.Smooth;

        [Obsolete]
        public InputType LeftSurfaceInput = InputType.NoInput;

        public bool Locked;
        public bool Massless;
        public Material Material = Material.Plastic;
        public string MaterialVariantSerialized = "";
        public CFrame PivotOffset = CFrame.identity;
        public float Reflectance = 0;

        [Obsolete]
        public float RightParamA = -0.5f;

        [Obsolete]
        public float RightParamB = 0.5f;

        public SurfaceType RightSurface = SurfaceType.Smooth;

        [Obsolete]
        public InputType RightSurfaceInput = InputType.NoInput;

        public int RootPriority = 0;

        [Obsolete]
        public Vector3 RotVelocity = Vector3.zero;

        public Vector3 Size
        {
            get => size;
            set => size = value;
        }

        [Obsolete]
        public float TopParamA = -0.5f;

        [Obsolete]
        public float TopParamB = 0.5f;

        public SurfaceType TopSurface = SurfaceType.Smooth;

        [Obsolete]
        public InputType TopSurfaceInput = InputType.NoInput;

        public float Transparency = 0;

        [Obsolete]
        public Vector3 Velocity = Vector3.zero;

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
        public FormFactorPart() : base()
        {
            BottomSurface = SurfaceType.Inlet;
            Size = new Vector3(4, 1.2f, 2);
            TopSurface = SurfaceType.Studs;
            size = new Vector3(4, 1.2f, 2);
        }

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
        public Part() : base()
        {
            BottomSurface = SurfaceType.Inlet;
            Size = new Vector3(4, 1.2f, 2);
            TopSurface = SurfaceType.Studs;
            size = new Vector3(4, 1.2f, 2);
        }

        public PartType Shape
        {
            get => shape;
            set => shape = value;
        }

        public PartType shape = PartType.Block;
    }

    public class FlagStand : Part
    {
        public FlagStand() : base()
        {
            BottomSurface = SurfaceType.Inlet;
            Size = new Vector3(4, 1.2f, 2);
            TopSurface = SurfaceType.Studs;
            size = new Vector3(4, 1.2f, 2);
        }

        public BrickColor TeamColor = BrickColorId.Medium_stone_grey;
    }

    public class Seat : Part
    {
        public Seat() : base()
        {
            BottomSurface = SurfaceType.Inlet;
            Size = new Vector3(4, 1.2f, 2);
            TopSurface = SurfaceType.Studs;
            size = new Vector3(4, 1.2f, 2);
        }

        public bool Disabled;
    }

    public class SkateboardPlatform : Part
    {
        public SkateboardPlatform() : base()
        {
            BottomSurface = SurfaceType.Inlet;
            Size = new Vector3(4, 1.2f, 2);
            TopSurface = SurfaceType.Studs;
            size = new Vector3(4, 1.2f, 2);
        }

        public int Steer = 0;
        public bool StickyWheels = true;
        public int Throttle = 0;
    }

    public class SpawnLocation : Part
    {
        public SpawnLocation() : base()
        {
            BottomSurface = SurfaceType.Inlet;
            Size = new Vector3(4, 1.2f, 2);
            TopSurface = SurfaceType.Studs;
            size = new Vector3(4, 1.2f, 2);
        }

        public bool AllowTeamChangeOnTouch;
        public int Duration = 10;
        public bool Enabled = true;
        public bool Neutral = true;
        public BrickColor TeamColor = BrickColorId.Medium_stone_grey;
    }

    public class WedgePart : FormFactorPart
    {
        public WedgePart() : base()
        {
            BottomSurface = SurfaceType.Inlet;
            Size = new Vector3(4, 1.2f, 2);
            size = new Vector3(4, 1.2f, 2);
        }
    }

    public class Terrain : BasePart
    {
        public TerrainAcquisitionMethod AcquisitionMethod = TerrainAcquisitionMethod.None;
        public bool Decoration;
        public float GrassLength = 0.7f;
        public byte[] MaterialColors = Convert.FromBase64String("AAAAAAAAan8/P39rf2Y/ilY+j35fi21PZmxvZbDqw8faiVpHOi4kHh4lZlw76JxKc3trhHtagcLgc4RKxr21zq2UlJSM");
        public byte[] PhysicsGrid = Convert.FromBase64String("AgMAAAAAAAAAAAAAAAA=");
        public byte[] SmoothGrid = Convert.FromBase64String("AQU=");
        public bool SmoothVoxelsUpgraded;
        public Color3 WaterColor = Color3.FromRGB(12, 84, 91);
        public float WaterReflectance = 1;
        public float WaterTransparency = 0.3f;
        public float WaterWaveSize = 0.15f;
        public float WaterWaveSpeed = 10;
    }

    public abstract class TriangleMeshPart : BasePart
    {
        public TriangleMeshPart() : base()
        {
            Size = new Vector3(4, 1.2f, 2);
            size = new Vector3(4, 1.2f, 2);
        }

        public SharedString AeroMeshData = SharedString.None;
        public FluidFidelity FluidFidelityInternal = FluidFidelity.Automatic;
        public SharedString PhysicalConfigData = SharedString.FromBase64("1B2M2Y8AsgTpgAmY7PhCfg==");
        public Vector3 UnscaledCofm = Vector3.zero;
        public Vector3 UnscaledVolInertiaDiags = Vector3.zero;
        public Vector3 UnscaledVolInertiaOffDiags = Vector3.zero;
        public float UnscaledVolume = 0;
    }

    public class MeshPart : TriangleMeshPart
    {
        public MeshPart() : base()
        {
            Size = new Vector3(4, 1.2f, 2);
            size = new Vector3(4, 1.2f, 2);
        }

        public bool DoubleSided;
        public bool HasJointOffset;
        public bool HasSkinnedMesh;
        public Vector3 InitialSize = Vector3.zero;
        public Vector3 JointOffset = Vector3.zero;
        public Content MeshContent = Content.None;

        [Obsolete]
        public ContentId MeshID
        {
            get => MeshContent;
            set => MeshContent = value;
        }

        public ContentId MeshId
        {
            get => MeshContent;
            set => MeshContent = value;
        }

        public byte[] PhysicsData;
        public RenderFidelity RenderFidelity = RenderFidelity.Automatic;
        public Content TextureContent = Content.None;

        public ContentId TextureID
        {
            get => TextureContent;
            set => TextureContent = value;
        }

        public int VertexCount = 0;
    }

    public class PartOperation : TriangleMeshPart
    {
        public PartOperation() : base()
        {
            BrickColor = BrickColorId.Institutional_white;
            Color = new Color3(1, 1, 1);
            Size = new Vector3(4, 1.2f, 2);
            brickColor = BrickColorId.Institutional_white;
            size = new Vector3(4, 1.2f, 2);
        }

        public ContentId AssetId;
        public byte[] ChildData;
        public SharedString ChildData2 = SharedString.None;
        public int ComponentIndex = -1;
        public FormFactor FormFactor = FormFactor.Custom;
        public Vector3 InitialSize = Vector3.one;
        public byte[] MeshData;
        public SharedString MeshData2 = SharedString.None;
        public bool OffCentered;
        public byte[] PhysicsData;
        public RenderFidelity RenderFidelity = RenderFidelity.Automatic;
        public float SmoothingAngle = 0;
        public bool UsePartColor;
    }

    public class IntersectOperation : PartOperation
    {
        public IntersectOperation() : base()
        {
            BrickColor = BrickColorId.Institutional_white;
            Color = new Color3(1, 1, 1);
            Size = new Vector3(4, 1.2f, 2);
            brickColor = BrickColorId.Institutional_white;
            size = new Vector3(4, 1.2f, 2);
        }
    }

    public class NegateOperation : PartOperation
    {
        public NegateOperation() : base()
        {
            Anchored = true;
            BrickColor = BrickColorId.Institutional_white;
            CanCollide = false;
            Color = new Color3(1, 1, 1);
            Size = new Vector3(4, 1.2f, 2);
            brickColor = BrickColorId.Institutional_white;
            size = new Vector3(4, 1.2f, 2);
        }

        public NegateOperationHiddenHistory PreviousOperation = NegateOperationHiddenHistory.None;
    }

    public class UnionOperation : PartOperation
    {
        public UnionOperation() : base()
        {
            BrickColor = BrickColorId.Institutional_white;
            Color = new Color3(1, 1, 1);
            Size = new Vector3(4, 1.2f, 2);
            brickColor = BrickColorId.Institutional_white;
            size = new Vector3(4, 1.2f, 2);
        }
    }

    public class TrussPart : BasePart
    {
        public TrussPart() : base()
        {
            BackSurface = SurfaceType.Universal;
            BottomSurface = SurfaceType.Universal;
            FrontSurface = SurfaceType.Universal;
            LeftSurface = SurfaceType.Universal;
            RightSurface = SurfaceType.Universal;
            TopSurface = SurfaceType.Universal;
        }

        public Style Style
        {
            get => style;
            set => style = value;
        }

        public Style style = Style.AlternatingSupports;
    }

    public class VehicleSeat : BasePart
    {
        public VehicleSeat() : base()
        {
            BottomSurface = SurfaceType.Inlet;
            Size = new Vector3(4, 1.2f, 2);
            TopSurface = SurfaceType.Studs;
            size = new Vector3(4, 1.2f, 2);
        }

        public bool Disabled;
        public bool HeadsUpDisplay = true;
        public float MaxSpeed = 25;
        public int Steer = 0;
        public float SteerFloat = 0;
        public int Throttle = 0;
        public float ThrottleFloat = 0;
        public float Torque = 10;
        public float TurnSpeed = 1;
    }

    public class Camera : PVInstance
    {
        public CFrame CFrame = new CFrame(0, 20, 20, 1, 0, 0, 0, 0.70711f, 0.70711f, 0, -0.70711f, 0.70711f);
        public Instance CameraSubject = null;
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
        public bool VRTiltAndRollEnabled;

        [Obsolete]
        public CFrame focus
        {
            get => Focus;
            set => Focus = value;
        }
    }

    public class Model : PVInstance
    {
        public ModelLevelOfDetail LevelOfDetail = ModelLevelOfDetail.Automatic;
        public CFrame ModelMeshCFrame = CFrame.identity;
        public SharedString ModelMeshData = SharedString.None;
        public Vector3 ModelMeshSize = Vector3.zero;
        public ModelStreamingMode ModelStreamingMode = ModelStreamingMode.Default;
        public bool NeedsPivotMigration;
        public BasePart PrimaryPart = null;
        public float ScaleFactor = 1;
        public Optional<CFrame> WorldPivotData;
    }

    public class Actor : Model
    {
    }

    public abstract class BackpackItem : Model
    {
        public ContentId TextureId = "";
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
        public CFrame Grip = CFrame.identity;
        public bool ManualActivationOnly;
        public bool RequiresHandle = true;
        public string ToolTip = "";
    }

    public class Flag : Tool
    {
        public BrickColor TeamColor = BrickColorId.Medium_stone_grey;
    }

    public abstract class WorldRoot : Model
    {
    }

    [RbxService]
    public class Workspace : WorldRoot
    {
        public float AirDensity = 0.0012f;
        public bool AllowThirdPartySales;
        public AvatarUnificationMode AvatarUnificationMode = AvatarUnificationMode.Default;
        public ClientAnimatorThrottlingMode ClientAnimatorThrottling = ClientAnimatorThrottlingMode.Default;
        public byte[] CollisionGroupData = Convert.FromBase64String("AQEABP////8HRGVmYXVsdA==");
        public Camera CurrentCamera = null;
        public double DistributedGameTime = 0;
        public bool ExplicitAutoJoints = true;
        public bool FallHeightEnabled = true;
        public float FallenPartsDestroyHeight = -500;
        public FluidForces FluidForces = FluidForces.Default;
        public Vector3 GlobalWind = Vector3.zero;
        public float Gravity = 196.2f;
        public IKControlConstraintSupport IKControlConstraintSupport = IKControlConstraintSupport.Default;
        public MeshPartHeadsAndAccessories MeshPartHeadsAndAccessories = MeshPartHeadsAndAccessories.Default;
        public ModelStreamingBehavior ModelStreamingBehavior = ModelStreamingBehavior.Default;
        public MoverConstraintRootBehaviorMode MoverConstraintRootBehavior = MoverConstraintRootBehaviorMode.Default;
        public PathfindingUseImprovedSearch PathfindingUseImprovedSearch = PathfindingUseImprovedSearch.Default;
        public RolloutState PhysicsImprovedSleep = RolloutState.Default;
        public PhysicsSteppingMethod PhysicsSteppingMethod = PhysicsSteppingMethod.Default;
        public PlayerCharacterDestroyBehavior PlayerCharacterDestroyBehavior = PlayerCharacterDestroyBehavior.Default;
        public PrimalPhysicsSolver PrimalPhysicsSolver = PrimalPhysicsSolver.Default;
        public RejectCharacterDeletions RejectCharacterDeletions = RejectCharacterDeletions.Default;
        public RenderingCacheOptimizationMode RenderingCacheOptimizations = RenderingCacheOptimizationMode.Default;
        public ReplicateInstanceDestroySetting ReplicateInstanceDestroySetting = ReplicateInstanceDestroySetting.Default;
        public AnimatorRetargetingMode Retargeting = AnimatorRetargetingMode.Default;
        public SandboxedInstanceMode SandboxedInstanceMode = SandboxedInstanceMode.Default;
        public SignalBehavior SignalBehavior2 = SignalBehavior.Default;
        public StreamOutBehavior StreamOutBehavior = StreamOutBehavior.Default;
        public bool StreamingEnabled;
        public StreamingIntegrityMode StreamingIntegrityMode = StreamingIntegrityMode.Default;
        public int StreamingMinRadius = 64;
        public int StreamingTargetRadius = 1024;
        public bool TerrainWeldsFixed = true;
        public RolloutState TouchEventsUseCollisionGroups = RolloutState.Default;
        public bool TouchesUseCollisionGroups;
    }

    public class WorldModel : WorldRoot
    {
    }

    public class PackageLink : Instance
    {
        public bool AutoUpdate;
        public string DefaultName = "";
        public int ModifiedState = 0;
        public ContentId PackageIdSerialize;
        public byte[] SerializedDefaultAttributes;
        public long VersionIdSerialize = 0;
    }

    [RbxService]
    public class PackageService : Instance
    {
    }

    [RbxService]
    public class PackageUIService : Instance
    {
    }

    public class PartOperationAsset : Instance
    {
        public byte[] ChildData;
        public byte[] MeshData;
    }

    public class ParticleEmitter : Instance
    {
        public Vector3 Acceleration = Vector3.zero;
        public float Brightness = 1;
        public ColorSequence Color = new ColorSequence(1, 1, 1);
        public float Drag = 0;
        public NormalId EmissionDirection = NormalId.Top;
        public bool Enabled = true;
        public NumberRange FlipbookFramerate = new NumberRange(1);
        public string FlipbookIncompatible = "Particle texture must be 1024 by 1024 to use flipbooks.";
        public ParticleFlipbookLayout FlipbookLayout = ParticleFlipbookLayout.None;
        public ParticleFlipbookMode FlipbookMode = ParticleFlipbookMode.Loop;
        public bool FlipbookStartRandom;
        public NumberRange Lifetime = new NumberRange(5, 10);
        public float LightEmission = 0;
        public float LightInfluence = 0;
        public bool LockedToPart;
        public ParticleOrientation Orientation = ParticleOrientation.FacingCamera;
        public float Rate = 20;
        public NumberRange RotSpeed = new NumberRange(0);
        public NumberRange Rotation = new NumberRange(0);
        public ParticleEmitterShape Shape = ParticleEmitterShape.Box;
        public ParticleEmitterShapeInOut ShapeInOut = ParticleEmitterShapeInOut.Outward;
        public float ShapePartial = 1;
        public ParticleEmitterShapeStyle ShapeStyle = ParticleEmitterShapeStyle.Volume;
        public NumberSequence Size = new NumberSequence(1);
        public NumberRange Speed = new NumberRange(5);
        public Vector2 SpreadAngle = Vector2.zero;
        public NumberSequence Squash = new NumberSequence(0);
        public ContentId Texture = "rbxasset://textures/particles/sparkles_main.dds";
        public float TimeScale = 1;
        public NumberSequence Transparency = new NumberSequence(0);
        public float VelocityInheritance = 0;

        [Obsolete]
        public float VelocitySpread
        {
            get => SpreadAngle.X;
            set => SpreadAngle = new Vector2(value, value);
        }

        public bool WindAffectsDrag;
        public float ZOffset = 0;
    }

    [RbxService]
    public class PatchBundlerFileWatch : Instance
    {
    }

    public class PathfindingLink : Instance
    {
        public Attachment Attachment0 = null;
        public Attachment Attachment1 = null;
        public bool IsBidirectional = true;
        public string Label = "";
    }

    public class PathfindingModifier : Instance
    {
        public string Label = "";
        public bool PassThrough;
    }

    [RbxService]
    public class PathfindingService : Instance
    {
        [Obsolete]
        public float EmptyCutoff = 0;
    }

    [RbxService]
    public class PerformanceControlService : Instance
    {
    }

    [RbxService]
    public class PermissionsService : Instance
    {
    }

    [RbxService]
    public class PhysicsService : Instance
    {
    }

    [RbxService]
    public class PlaceAssetIdsService : Instance
    {
    }

    [RbxService]
    public class PlaceStatsService : Instance
    {
    }

    [RbxService]
    public class PlacesService : Instance
    {
    }

    [RbxService]
    public class PlatformCloudStorageService : Instance
    {
    }

    [RbxService]
    public class PlatformFriendsService : Instance
    {
    }

    [RbxService]
    public class PlayerDataService : Instance
    {
        public PlayerDataLoadFailureBehavior LoadFailureBehavior = PlayerDataLoadFailureBehavior.Failure;
    }

    [RbxService]
    public class PlayerEmulatorService : Instance
    {
        public bool CustomPoliciesEnabled;
        public string EmulatedCountryCode = "";
        public string EmulatedGameLocale = "";
        public bool PlayerEmulationEnabled;
        public bool PseudolocalizationEnabled;
        public byte[] SerializedEmulatedPolicyInfo;
        public int TextElongationFactor = 0;
    }

    [RbxService]
    public class PlayerHydrationService : Instance
    {
    }

    [RbxService]
    public class PlayerViewService : Instance
    {
    }

    [RbxService]
    public class Players : Instance
    {
        public bool BanningEnabled;
        public bool CharacterAutoLoads = true;
        public int MaxPlayersInternal = 16;
        public int PreferredPlayersInternal = 0;
        public float RespawnTime = 5;
        public bool UseStrafingAnimations;
    }

    public class PluginAction : Instance
    {
    }

    public class PluginCapabilities : Instance
    {
        public string Manifest = "{\"Metadata\":{\"TargetDataModels\": [\"Edit\", \"Server\", \"Client\"]},\"Permissions\":{}}";
    }

    [RbxService]
    public class PluginDebugService : Instance
    {
    }

    [RbxService]
    public class PluginGuiService : Instance
    {
    }

    [RbxService]
    public class PluginManagementService : Instance
    {
    }

    [RbxService]
    public class PluginPolicyService : Instance
    {
    }

    [RbxService]
    public class PointsService : Instance
    {
    }

    [RbxService]
    public class PolicyService : Instance
    {
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
        public double Value = 0;
    }

    public class Pose : PoseBase
    {
        public CFrame CFrame = CFrame.identity;

        [Obsolete]
        public float MaskWeight = 0;
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
        public float Brightness = 0;
        public float Contrast = 0;
        public float Saturation = 0;
        public Color3 TintColor = new Color3(1, 1, 1);
    }

    public class ColorGradingEffect : PostEffect
    {
        public TonemapperPreset TonemapperPreset = TonemapperPreset.Default;
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

    [RbxService]
    public class ProcessInstancePhysicsService : Instance
    {
    }

    public class ProximityPrompt : Instance
    {
        public string ActionText = "Interact";
        public bool AutoLocalize = true;
        public bool ClickablePrompt = true;
        public bool Enabled = true;
        public ProximityPromptExclusivity Exclusivity = ProximityPromptExclusivity.OnePerButton;
        public KeyCode GamepadKeyCode = KeyCode.ButtonX;
        public float HoldDuration = 0;
        public KeyCode KeyboardKeyCode = KeyCode.E;
        public float MaxActivationDistance = 10;
        public string ObjectText = "";
        public bool RequiresLineOfSight = true;
        public LocalizationTable RootLocalizationTable = null;
        public ProximityPromptStyle Style = ProximityPromptStyle.Default;
        public Vector2 UIOffset = Vector2.zero;
    }

    [RbxService]
    public class ProximityPromptService : Instance
    {
        public bool Enabled = true;
        public int MaxPromptsVisible = 16;
    }

    [RbxService]
    public class PublishService : Instance
    {
    }

    public class RTAnimationTracker : Instance
    {
    }

    [RbxService]
    public class RbxAnalyticsService : Instance
    {
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
        public string EditorType = "";
        public string FFlag = "";
        public bool IsBackend;
        public int PropertyOrder = 5000;
        public string ScriptContext = "";
        public bool ServerOnly;
        public string SliderScaling = "";
        public double UIMaximum = 0;
        public double UIMinimum = 0;
        public double UINumTicks = 0;
    }

    public class ReflectionMetadataClass : ReflectionMetadataItem
    {
        public int ExplorerImageIndex = 0;
        public int ExplorerOrder = int.MaxValue;
        public bool Insertable = true;
        public string PreferredParent = "";
        public ServiceVisibility ServiceVisibility = ServiceVisibility.Always;
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

    [RbxService]
    public class ReflectionService : Instance
    {
    }

    [RbxService]
    public class RemoteCursorService : Instance
    {
    }

    [RbxService]
    public class RemoteDebuggerServer : Instance
    {
    }

    public class RemoteFunction : Instance
    {
    }

    [RbxService]
    public class RenderSettings : Instance
    {
        public int AutoFRMLevel = 0;
        public bool EagerBulkExecution;
        public QualityLevel EditQualityLevel = QualityLevel.Automatic;
        public bool Enable_VR_Mode;
        public bool ExportMergeByMaterial;
        public FramerateManagerMode FrameRateManager = FramerateManagerMode.Automatic;
        public GraphicsMode GraphicsMode = GraphicsMode.Automatic;
        public int MeshCacheSize = 0;
        public MeshPartDetailLevel MeshPartDetailLevel = MeshPartDetailLevel.DistanceBased;
        public QualityLevel QualityLevel = QualityLevel.Automatic;
        public bool ReloadAssets;
        public bool RenderCSGTrianglesDebug;
        public bool ShowBoundingBoxes;
        public ViewMode ViewMode = ViewMode.None;
    }

    public class RenderingTest : Instance
    {
        public CFrame CFrame = CFrame.identity;
        public int ComparisonDiffThreshold = 10;
        public RenderingTestComparisonMethod ComparisonMethod = RenderingTestComparisonMethod.psnr;
        public float ComparisonPsnrThreshold = 50;
        public string Description = "";
        public float FieldOfView = 70;
        public bool PerfTest;
        public bool QualityAuto;
        public int QualityLevel = 21;
        public int RenderingTestFrameCount = 20;
        public bool ShouldSkip;
        public string Ticket = "";
        public int Timeout = 30;
    }

    [RbxService]
    public class ReplicatedFirst : Instance
    {
    }

    [RbxService]
    public class ReplicatedStorage : Instance
    {
    }

    [RbxService]
    public class RibbonNotificationService : Instance
    {
    }

    [RbxService]
    public class RobloxPluginGuiService : Instance
    {
    }

    [RbxService]
    public class RobloxReplicatedStorage : Instance
    {
    }

    public class RobloxSerializableInstance : Instance
    {
        public byte[] Data;
    }

    [RbxService]
    public class RobloxServerStorage : Instance
    {
    }

    [RbxService]
    public class RomarkRbxAnalyticsService : Instance
    {
    }

    [RbxService]
    public class RomarkService : Instance
    {
    }

    public class RotationCurve : Instance
    {
        public byte[] ValuesAndTimes = Convert.FromBase64String("AAAAAAEAAAAKAAAAAAAAFkUAAAAA");
    }

    [RbxService]
    public class RtMessagingService : Instance
    {
    }

    [RbxService]
    public class RunService : Instance
    {
    }

    [RbxService]
    public class RuntimeScriptService : Instance
    {
    }

    [RbxService]
    public class SafetyService : Instance
    {
        public bool IsCaptureModeForReport;
    }

    [RbxService]
    public class ScriptChangeService : Instance
    {
    }

    [RbxService]
    public class ScriptCloneWatcher : Instance
    {
    }

    [RbxService]
    public class ScriptCloneWatcherHelper : Instance
    {
    }

    [RbxService]
    public class ScriptCommitService : Instance
    {
    }

    [RbxService]
    public class ScriptContext : Instance
    {
    }

    public class ScriptDebugger : Instance
    {
        public string CoreScriptIdentifier = "";
        public string ScriptGuid = "";
    }

    [RbxService]
    public class ScriptEditorService : Instance
    {
    }

    [RbxService]
    public class ScriptProfilerService : Instance
    {
    }

    [RbxService]
    public class ScriptRegistrationService : Instance
    {
    }

    [RbxService]
    public class ScriptService : Instance
    {
    }

    [RbxService]
    public class Selection : Instance
    {
    }

    [RbxService]
    public class SelectionHighlightManager : Instance
    {
    }

    public abstract class SensorBase : Instance
    {
        public SensorUpdateType UpdateType = SensorUpdateType.OnRead;
    }

    public class AtmosphereSensor : SensorBase
    {
    }

    public class BuoyancySensor : SensorBase
    {
        public bool FullySubmerged;
        public bool TouchingSurface;
    }

    public abstract class ControllerSensor : SensorBase
    {
    }

    public class ControllerPartSensor : ControllerSensor
    {
        public CFrame HitFrame = CFrame.identity;
        public Vector3 HitNormal = Vector3.zero;
        public float SearchDistance = 0;
        public BasePart SensedPart = null;
        public SensorMode SensorMode = SensorMode.Floor;
    }

    public class FluidForceSensor : SensorBase
    {
    }

    [RbxService]
    public class SerializationService : Instance
    {
    }

    [RbxService]
    public class ServerScriptService : Instance
    {
        public bool LoadStringEnabled;
    }

    [RbxService]
    public class ServerStorage : Instance
    {
    }

    [RbxService]
    public class ServiceVisibilityService : Instance
    {
        public byte[] HiddenServices;
        public byte[] VisibleServices;
    }

    [RbxService]
    public class SessionService : Instance
    {
    }

    [RbxService]
    public class SharedTableRegistry : Instance
    {
    }

    public class Sky : Instance
    {
        public bool CelestialBodiesShown = true;
        public float MoonAngularSize = 11;
        public ContentId MoonTextureId = "rbxasset://sky/moon.jpg";
        public ContentId SkyboxBk = "rbxasset://textures/sky/sky512_bk.tex";
        public ContentId SkyboxDn = "rbxasset://textures/sky/sky512_dn.tex";
        public ContentId SkyboxFt = "rbxasset://textures/sky/sky512_ft.tex";
        public ContentId SkyboxLf = "rbxasset://textures/sky/sky512_lf.tex";
        public Vector3 SkyboxOrientation = Vector3.zero;
        public ContentId SkyboxRt = "rbxasset://textures/sky/sky512_rt.tex";
        public ContentId SkyboxUp = "rbxasset://textures/sky/sky512_up.tex";
        public int StarCount = 3000;
        public float SunAngularSize = 21;
        public ContentId SunTextureId = "rbxasset://sky/sun.jpg";
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

        public float TimeScale = 1;
        public float opacity_xml = 0.5f;
        public float riseVelocity_xml = 1;
        public float size_xml = 1;
    }

    [RbxService]
    public class SmoothVoxelsUpgraderService : Instance
    {
    }

    [RbxService]
    public class SnippetService : Instance
    {
    }

    [RbxService]
    public class SocialService : Instance
    {
    }

    public class Sound : Instance
    {
        [Obsolete]
        public float EmitterSize = 10;

        public NumberRange LoopRegion = new NumberRange(0, 60000);
        public bool Looped;

        [Obsolete]
        public float MinDistance
        {
            get => RollOffMinDistance;
            set => RollOffMinDistance = value;
        }

        [Obsolete]
        public float Pitch
        {
            get => PlaybackSpeed;
            set => PlaybackSpeed = value;
        }

        public bool PlayOnRemove;
        public NumberRange PlaybackRegion = new NumberRange(0, 60000);
        public bool PlaybackRegionsEnabled;
        public float PlaybackSpeed = 1;
        public bool Playing;
        public float RollOffMaxDistance = 10000;
        public float RollOffMinDistance = 10;
        public RollOffMode RollOffMode = RollOffMode.Inverse;
        public SoundGroup SoundGroup = null;
        public ContentId SoundId = "";
        public double TimePosition = 0;
        public float Volume = 0.5f;

        [Obsolete]
        public float xmlRead_MaxDistance_3
        {
            get => RollOffMaxDistance;
            set => RollOffMaxDistance = value;
        }

        [Obsolete]
        public float xmlRead_MinDistance_3
        {
            get => RollOffMinDistance;
            set => RollOffMinDistance = value;
        }
    }

    public abstract class SoundEffect : Instance
    {
        public bool Enabled = true;
        public int Priority = 0;
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
        public float GainMakeup = 0;
        public float Ratio = 40;
        public float Release = 0.1f;
        public Instance SideChain = null;
        public float Threshold = -40;
    }

    public class CustomSoundEffect : SoundEffect
    {
    }

    public class ChannelSelectorSoundEffect : CustomSoundEffect
    {
        public int Channel = 1;
    }

    public class DistortionSoundEffect : SoundEffect
    {
        public float Level = 0.75f;
    }

    public class EchoSoundEffect : SoundEffect
    {
        public float Delay = 1;
        public float DryLevel = 0;
        public float Feedback = 0.5f;
        public float WetLevel = 0;
    }

    public class EqualizerSoundEffect : SoundEffect
    {
        public float HighGain = 0;
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
        public float WetLevel = 0;
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

    [RbxService(IsRooted = false)]
    public class SoundService : Instance
    {
        public ReverbType AmbientReverb = ReverbType.NoReverb;
        public RolloutState AudioApiByDefault = RolloutState.Default;
        public RolloutState CharacterSoundsUseNewApi = RolloutState.Default;
        public ListenerLocation DefaultListenerLocation = ListenerLocation.Default;
        public float DistanceFactor = 3.33f;
        public float DopplerScale = 1;
        public bool IsNewExpForAudioApiByDefault;
        public bool RespectFilteringEnabled;
        public float RolloffScale = 1;
        public VolumetricAudio VolumetricAudio = VolumetricAudio.Automatic;
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
        public float TimeScale = 1;
    }

    [RbxService]
    public class SpawnerService : Instance
    {
    }

    public class StandalonePluginScripts : Instance
    {
    }

    [RbxService]
    public class StartPageService : Instance
    {
    }

    public class StarterGear : Instance
    {
    }

    [RbxService]
    public class StarterPack : Instance
    {
    }

    [RbxService]
    public class StarterPlayer : Instance
    {
        public bool AllowCustomAnimations = true;
        public bool AutoJumpEnabled = true;
        public RolloutState AvatarJointUpgrade_SerializedRollout = RolloutState.Default;
        public float CameraMaxZoomDistance = 400;
        public float CameraMinZoomDistance = 0.5f;
        public CameraMode CameraMode = CameraMode.Classic;
        public float CharacterJumpHeight = 7.2f;
        public float CharacterJumpPower = 50;
        public float CharacterMaxSlopeAngle = 89;
        public bool CharacterUseJumpPower = true;
        public float CharacterWalkSpeed = 16;
        public bool ClassicDeath = true;
        public DevCameraOcclusionMode DevCameraOcclusionMode = DevCameraOcclusionMode.Zoom;
        public DevComputerCameraMovementMode DevComputerCameraMovementMode = DevComputerCameraMovementMode.UserChoice;
        public DevComputerMovementMode DevComputerMovementMode = DevComputerMovementMode.UserChoice;
        public DevTouchCameraMovementMode DevTouchCameraMovementMode = DevTouchCameraMovementMode.UserChoice;
        public DevTouchMovementMode DevTouchMovementMode = DevTouchMovementMode.UserChoice;
        public LoadDynamicHeads EnableDynamicHeads = LoadDynamicHeads.Default;
        public bool EnableMouseLockOption = true;
        public long GameSettingsAssetIDFace = 0;
        public long GameSettingsAssetIDHead = 0;
        public long GameSettingsAssetIDLeftArm = 0;
        public long GameSettingsAssetIDLeftLeg = 0;
        public long GameSettingsAssetIDPants = 0;
        public long GameSettingsAssetIDRightArm = 0;
        public long GameSettingsAssetIDRightLeg = 0;
        public long GameSettingsAssetIDShirt = 0;
        public long GameSettingsAssetIDTeeShirt = 0;
        public long GameSettingsAssetIDTorso = 0;
        public GameAvatarType GameSettingsAvatar = GameAvatarType.R15;
        public R15CollisionType GameSettingsR15Collision = R15CollisionType.OuterBox;
        public NumberRange GameSettingsScaleRangeBodyType = new NumberRange(0, 1);
        public NumberRange GameSettingsScaleRangeHead = new NumberRange(0.95f, 1);
        public NumberRange GameSettingsScaleRangeHeight = new NumberRange(0.9f, 1.05f);
        public NumberRange GameSettingsScaleRangeProportion = new NumberRange(0, 1);
        public NumberRange GameSettingsScaleRangeWidth = new NumberRange(0.7f, 1);
        public float HealthDisplayDistance = 100;
        public bool LoadCharacterAppearance = true;
        public LoadCharacterLayeredClothing LoadCharacterLayeredClothing = LoadCharacterLayeredClothing.Default;
        public CharacterControlMode LuaCharacterController = CharacterControlMode.Default;
        public float NameDisplayDistance = 100;
        public bool RagdollDeath = true;
        public bool UserEmotesEnabled = true;
    }

    public class StarterPlayerScripts : Instance
    {
    }

    public class StarterCharacterScripts : StarterPlayerScripts
    {
    }

    [RbxService]
    public class StartupMessageService : Instance
    {
    }

    [RbxService]
    public class Stats : Instance
    {
    }

    [RbxService]
    public class StopWatchReporter : Instance
    {
    }

    [RbxService]
    public class StreamingService : Instance
    {
    }

    [RbxService]
    public class StudioAssetService : Instance
    {
    }

    public class StudioAttachment : Instance
    {
        public bool AutoHideParent;
        public bool IsArrowVisible;
        public Vector2 Offset = Vector2.zero;
        public Vector2 SourceAnchorPoint = Vector2.zero;
        public Vector2 TargetAnchorPoint = Vector2.zero;
    }

    public class StudioCallout : Instance
    {
    }

    [RbxService]
    public class StudioCameraService : Instance
    {
        public bool LockCameraSpeed;
    }

    [RbxService]
    public class StudioData : Instance
    {
        public bool EnableScriptCollabByDefaultOnLoad;
    }

    [RbxService]
    public class StudioDeviceEmulatorService : Instance
    {
    }

    [RbxService]
    public class StudioPublishService : Instance
    {
        public bool PublishLocked;
    }

    [RbxService]
    public class StudioScriptDebugEventListener : Instance
    {
    }

    [RbxService]
    public class StudioSdkService : Instance
    {
    }

    [RbxService]
    public class StudioService : Instance
    {
        public string Secrets = "";
    }

    [RbxService]
    public class StudioUserService : Instance
    {
    }

    [RbxService]
    public class StudioWidgetsService : Instance
    {
    }

    public abstract class StyleBase : Instance
    {
    }

    public class StyleRule : StyleBase
    {
        public int Priority = 0;
        public byte[] PropertiesSerialize;
        public string Selector = "";
    }

    public class StyleSheet : StyleBase
    {
    }

    public class StyleDerive : Instance
    {
        public int Priority = 0;
        public StyleSheet StyleSheet = null;
    }

    public class StyleLink : Instance
    {
        public StyleSheet StyleSheet = null;
    }

    [RbxService]
    public class StylingService : Instance
    {
    }

    public class SurfaceAppearance : Instance
    {
        public AlphaMode AlphaMode = AlphaMode.Overlay;
        public Color3 Color = new Color3(1, 1, 1);

        public ContentId ColorMap
        {
            get => ColorMapContent;
            set => ColorMapContent = value;
        }

        public Content ColorMapContent = Content.None;

        public ContentId MetalnessMap
        {
            get => MetalnessMapContent;
            set => MetalnessMapContent = value;
        }

        public Content MetalnessMapContent = Content.None;

        public ContentId NormalMap
        {
            get => NormalMapContent;
            set => NormalMapContent = value;
        }

        public Content NormalMapContent = Content.None;

        public ContentId RoughnessMap
        {
            get => RoughnessMapContent;
            set => RoughnessMapContent = value;
        }

        public Content RoughnessMapContent = Content.None;
        public ContentId TexturePack;
    }

    [RbxService]
    public class SystemThemeService : Instance
    {
    }

    [RbxService]
    public class TaskScheduler : Instance
    {
        public ThreadPoolConfig ThreadPoolConfig = ThreadPoolConfig.Auto;
    }

    public class Team : Instance
    {
        public bool AutoAssignable = true;

        [Obsolete]
        public bool AutoColorCharacters = true;

        [Obsolete]
        public int Score = 0;

        public BrickColor TeamColor = BrickColorId.White;
    }

    [RbxService]
    public class TeamCreateData : Instance
    {
    }

    [RbxService]
    public class TeamCreatePublishService : Instance
    {
    }

    [RbxService]
    public class TeamCreateService : Instance
    {
    }

    [RbxService(IsRooted = false)]
    public class Teams : Instance
    {
    }

    [RbxService]
    public class TelemetryService : Instance
    {
    }

    public class TeleportOptions : Instance
    {
        public string ReservedServerAccessCode = "";
        public string ServerInstanceId = "";
        public bool ShouldReserveServer;
    }

    [RbxService]
    public class TeleportService : Instance
    {
        [Obsolete]
        public bool CustomizedTeleportUI;
    }

    [RbxService]
    public class TemporaryCageMeshProvider : Instance
    {
    }

    [RbxService]
    public class TemporaryScriptService : Instance
    {
    }

    public class TerrainDetail : Instance
    {
        public ContentId ColorMap
        {
            get => ColorMapContent;
            set => ColorMapContent = value;
        }

        public Content ColorMapContent = Content.None;
        public TerrainFace Face = TerrainFace.Side;
        public MaterialPattern MaterialPattern = MaterialPattern.Regular;

        public ContentId MetalnessMap
        {
            get => MetalnessMapContent;
            set => MetalnessMapContent = value;
        }

        public Content MetalnessMapContent = Content.None;

        public ContentId NormalMap
        {
            get => NormalMapContent;
            set => NormalMapContent = value;
        }

        public Content NormalMapContent = Content.None;

        public ContentId RoughnessMap
        {
            get => RoughnessMapContent;
            set => RoughnessMapContent = value;
        }

        public Content RoughnessMapContent = Content.None;
        public float StudsPerTile = 10;
        public ContentId TexturePack;
    }

    public class TerrainRegion : Instance
    {
        public Vector3int16 ExtentsMax = new Vector3int16();
        public Vector3int16 ExtentsMin = new Vector3int16();
        public byte[] SmoothGrid = Convert.FromBase64String("AQU=");
    }

    [RbxService]
    public class TestService : Instance
    {
        public bool AutoRuns = true;
        public string Description = "";
        public bool ExecuteWithStudioRun;

        [Obsolete]
        public bool Is30FpsThrottleEnabled = true;

        public bool IsPhysicsEnvironmentalThrottled = true;
        public bool IsSleepAllowed = true;
        public int NumberOfPlayers = 0;
        public double SimulateSecondsLag = 0;
        public bool ThrottlePhysicsToRealtime = true;
        public double Timeout = 10;
    }

    [RbxService]
    public class TextBoxService : Instance
    {
    }

    public class TextChannel : Instance
    {
    }

    public class TextChatCommand : Instance
    {
        public bool AutocompleteVisible = true;
        public bool Enabled = true;
        public string PrimaryAlias = "";
        public string SecondaryAlias = "";
    }

    public abstract class TextChatConfigurations : Instance
    {
    }

    public class BubbleChatConfiguration : TextChatConfigurations
    {
        public string AdorneeName = "HumanoidRootPart";
        public Color3 BackgroundColor3 = Color3.FromRGB(250, 250, 250);
        public double BackgroundTransparency = 0.1;
        public float BubbleDuration = 15;
        public float BubblesSpacing = 6;
        public bool Enabled = true;
        public Font Font = Font.GothamMedium;
        public FontFace FontFace = FontFace.FromEnum(Enums.Font.GothamMedium);
        public Vector3 LocalPlayerStudsOffset = Vector3.zero;
        public float MaxBubbles = 3;
        public float MaxDistance = 100;
        public float MinimizeDistance = 40;
        public bool TailVisible = true;
        public Color3 TextColor3 = Color3.FromRGB(57, 59, 61);
        public long TextSize = 16;
        public float VerticalStudsOffset = 0;
    }

    public class ChannelTabsConfiguration : TextChatConfigurations
    {
        public Color3 BackgroundColor3 = Color3.FromRGB(25, 27, 29);
        public double BackgroundTransparency = 0;
        public bool Enabled;
        public FontFace FontFace = FontFace.FromEnum(Enums.Font.BuilderSansBold);
        public Color3 HoverBackgroundColor3 = Color3.FromRGB(125, 125, 125);
        public Color3 SelectedTabTextColor3 = new Color3(1, 1, 1);
        public Color3 TextColor3 = Color3.FromRGB(175, 175, 175);
        public long TextSize = 18;
        public Color3 TextStrokeColor3 = new Color3();
        public double TextStrokeTransparency = 1;
    }

    public class ChatInputBarConfiguration : TextChatConfigurations
    {
        public bool AutocompleteEnabled = true;
        public Color3 BackgroundColor3 = Color3.FromRGB(25, 27, 29);
        public double BackgroundTransparency = 0.2;
        public bool Enabled = true;
        public FontFace FontFace = FontFace.FromEnum(Enums.Font.GothamMedium);
        public KeyCode KeyboardKeyCode = KeyCode.Slash;
        public Color3 PlaceholderColor3 = Color3.FromRGB(178, 178, 178);
        public TextChannel TargetTextChannel = null;
        public Color3 TextColor3 = new Color3(1, 1, 1);
        public long TextSize = 14;
        public Color3 TextStrokeColor3 = new Color3();
        public double TextStrokeTransparency = 0.5;
    }

    public class ChatWindowConfiguration : TextChatConfigurations
    {
        public Color3 BackgroundColor3 = Color3.FromRGB(25, 27, 29);
        public double BackgroundTransparency = 0.3;
        public bool Enabled = true;
        public FontFace FontFace = FontFace.FromEnum(Enums.Font.GothamMedium);
        public float HeightScale = 1;
        public HorizontalAlignment HorizontalAlignment = HorizontalAlignment.Left;
        public Color3 TextColor3 = new Color3(1, 1, 1);
        public long TextSize = 14;
        public Color3 TextStrokeColor3 = new Color3();
        public double TextStrokeTransparency = 0.5;
        public VerticalAlignment VerticalAlignment = VerticalAlignment.Top;
        public float WidthScale = 1;
    }

    public class TextChatMessageProperties : Instance
    {
    }

    public class BubbleChatMessageProperties : TextChatMessageProperties
    {
    }

    [RbxService]
    public class TextChatService : Instance
    {
        public bool ChatTranslationFTUXShown;
        public bool ChatTranslationToggleEnabled;
        public ChatVersion ChatVersion = ChatVersion.LegacyChatService;
        public bool CreateDefaultCommands = true;
        public bool CreateDefaultTextChannels = true;
        public bool HasSeenDeprecationDialog;
        public bool isLegacyChatDisabled;
    }

    [RbxService]
    public class TextService : Instance
    {
    }

    [RbxService]
    public class TextureGenerationService : Instance
    {
    }

    [RbxService]
    public class ThirdPartyUserService : Instance
    {
    }

    [RbxService]
    public class TimerService : Instance
    {
    }

    [RbxService]
    public class ToastNotificationService : Instance
    {
    }

    [RbxService]
    public class TouchInputService : Instance
    {
    }

    [RbxService]
    public class TracerService : Instance
    {
    }

    public class TrackerStreamAnimation : Instance
    {
    }

    public class Trail : Instance
    {
        public Attachment Attachment0 = null;
        public Attachment Attachment1 = null;
        public float Brightness = 1;
        public ColorSequence Color = new ColorSequence(1, 1, 1);
        public bool Enabled = true;
        public bool FaceCamera;
        public float Lifetime = 2;
        public float LightEmission = 0;
        public float LightInfluence = 0;
        public float MaxLength = 0;
        public float MinLength = 0.1f;
        public ContentId Texture = "";
        public float TextureLength = 1;
        public TextureMode TextureMode = TextureMode.Stretch;
        public NumberSequence Transparency = new NumberSequence(0.5f);
        public NumberSequence WidthScale = new NumberSequence(1);
    }

    [RbxService]
    public class TutorialService : Instance
    {
    }

    public abstract class TweenBase : Instance
    {
    }

    public class Tween : TweenBase
    {
    }

    [RbxService]
    public class TweenService : Instance
    {
    }

    [RbxService]
    public class UGCAvatarService : Instance
    {
    }

    [RbxService]
    public class UGCValidationService : Instance
    {
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
        public Vector2 MinSize = Vector2.zero;
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

    public class UIDragDetector : UIComponent
    {
        public ContentId ActivatedCursorIcon = "";
        public UIDragDetectorBoundingBehavior BoundingBehavior = UIDragDetectorBoundingBehavior.Automatic;
        public GuiBase2d BoundingUI = null;
        public ContentId CursorIcon = "";
        public Vector2 DragAxis = Vector2.xAxis;
        public UIDragDetectorDragRelativity DragRelativity = UIDragDetectorDragRelativity.Absolute;
        public float DragRotation = 0;
        public UIDragDetectorDragSpace DragSpace = UIDragDetectorDragSpace.Parent;
        public UIDragDetectorDragStyle DragStyle = UIDragDetectorDragStyle.TranslatePlane;
        public UDim2 DragUDim2 = new UDim2();
        public bool Enabled = true;
        public float MaxDragAngle = 0;
        public UDim2 MaxDragTranslation = new UDim2();
        public float MinDragAngle = 0;
        public UDim2 MinDragTranslation = new UDim2();
        public GuiObject ReferenceUIInstance = null;
        public UIDragDetectorResponseStyle ResponseStyle = UIDragDetectorResponseStyle.Offset;
        public UDim2 SelectionModeDragSpeed = new UDim2(0, 300, 0, 300);
        public float SelectionModeRotateSpeed = 90;
        public UIDragSpeedAxisMapping UIDragSpeedAxisMapping = UIDragSpeedAxisMapping.XY;
    }

    public class UIFlexItem : UIComponent
    {
        public UIFlexMode FlexMode = UIFlexMode.None;
        public float GrowRatio = 0;
        public ItemLineAlignment ItemLineAlignment = ItemLineAlignment.Automatic;
        public float ShrinkRatio = 0;
    }

    public class UIGradient : UIComponent
    {
        public ColorSequence Color = new ColorSequence(1, 1, 1);
        public bool Enabled = true;
        public Vector2 Offset = Vector2.zero;
        public float Rotation = 0;
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
        public int FillDirectionMaxCells = 0;
        public StartCorner StartCorner = StartCorner.TopLeft;
    }

    public class UIListLayout : UIGridStyleLayout
    {
        public UIListLayout() : base()
        {
            FillDirection = FillDirection.Vertical;
        }

        public UIFlexAlignment HorizontalFlex = UIFlexAlignment.None;
        public ItemLineAlignment ItemLineAlignment = ItemLineAlignment.Automatic;
        public UDim Padding = new UDim();
        public UIFlexAlignment VerticalFlex = UIFlexAlignment.None;
        public bool Wraps;
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
        public UITableLayout() : base()
        {
            FillDirection = FillDirection.Vertical;
        }

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

    public class UIStroke : UIComponent
    {
        public ApplyStrokeMode ApplyStrokeMode = ApplyStrokeMode.Contextual;
        public Color3 Color = new Color3();
        public bool Enabled = true;
        public LineJoinMode LineJoinMode = LineJoinMode.Round;
        public float Thickness = 1;
        public float Transparency = 0;
    }

    [RbxService]
    public class UIDragDetectorService : Instance
    {
    }

    [RbxService]
    public class UniqueIdLookupService : Instance
    {
    }

    [RbxService]
    public class UnvalidatedAssetService : Instance
    {
        public string CachedData = "{\"lastSaveTime\":0,\"users\":[],\"lastKnownPublishRequest\":0}";
    }

    [RbxService]
    public class UserInputService : Instance
    {
        [Obsolete]
        public bool LegacyInputEventsEnabled = true;

        public MouseBehavior MouseBehavior = MouseBehavior.Default;
        public ContentId MouseIcon = "";
        public bool MouseIconEnabled = true;
    }

    [RbxService]
    public class UserService : Instance
    {
    }

    [RbxService]
    public class VRService : Instance
    {
        public VRScaling AutomaticScaling = VRScaling.World;
        public bool AvatarGestures;
        public VRControllerModelMode ControllerModels = VRControllerModelMode.Transparent;
        public bool FadeOutViewOnCollision = true;
        public VRLaserPointerMode LaserPointer = VRLaserPointerMode.Pointer;
    }

    [RbxService]
    public class VRStatusService : Instance
    {
    }

    public abstract class ValueBase : Instance
    {
    }

    public class BinaryStringValue : ValueBase
    {
        public byte[] Value;
    }

    public class BoolValue : ValueBase
    {
        public bool Value;
    }

    public class BrickColorValue : ValueBase
    {
        public BrickColor Value = BrickColorId.Medium_stone_grey;
    }

    public class CFrameValue : ValueBase
    {
        public CFrame Value = CFrame.identity;
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
        public double MinValue = 0;

        public double Value
        {
            get => value;
            set => this.value = value;
        }

        public double value = 0;
    }

    public class IntConstrainedValue : ValueBase
    {
        public long ConstrainedValue
        {
            get => value;
            set => this.value = value;
        }

        public long MaxValue = 10;
        public long MinValue = 0;

        public long Value
        {
            get => value;
            set => this.value = value;
        }

        public long value = 0;
    }

    public class IntValue : ValueBase
    {
        public long Value = 0;
    }

    public class NumberValue : ValueBase
    {
        public double Value = 0;
    }

    public class ObjectValue : ValueBase
    {
        public Instance Value = null;
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
        public Vector3 Value = Vector3.zero;
    }

    public class Vector3Curve : Instance
    {
    }

    [RbxService]
    public class VersionControlService : Instance
    {
    }

    [RbxService]
    public class VideoCaptureService : Instance
    {
    }

    public class VideoDeviceInput : Instance
    {
        public bool Active;
        public string CameraId = "";
        public VideoDeviceCaptureQuality CaptureQuality = VideoDeviceCaptureQuality.Default;
    }

    public class VideoPlayer : Instance
    {
        public ContentId Asset = "";
        public bool Looping;
        public float PlaybackSpeed = 1;
        public double TimePosition = 0;
        public float Volume = 1;
    }

    [RbxService]
    public class VideoService : Instance
    {
    }

    [RbxService]
    public class VirtualInputManager : Instance
    {
    }

    [RbxService]
    public class VirtualUser : Instance
    {
    }

    [RbxService]
    public class VisibilityCheckDispatcher : Instance
    {
    }

    [RbxService]
    public class Visit : Instance
    {
    }

    public class VisualizationMode : Instance
    {
        public bool Enabled;
        public string Title = "";
        public string ToolTip = "";
    }

    public class VisualizationModeCategory : Instance
    {
        public bool Enabled;
        public string Title = "";
    }

    [RbxService]
    public class VisualizationModeService : Instance
    {
    }

    [RbxService]
    public class VoiceChatInternal : Instance
    {
    }

    [RbxService]
    public class VoiceChatService : Instance
    {
        public VoiceChatDistanceAttenuationType DefaultDistanceAttenuation = VoiceChatDistanceAttenuationType.Inverse;
        public bool EnableDefaultVoice = true;
        public AudioApiRollout UseAudioApi = AudioApiRollout.Automatic;
    }

    [RbxService]
    public class WebSocketService : Instance
    {
    }

    [RbxService]
    public class WebViewService : Instance
    {
    }

    public class WeldConstraint : Instance
    {
        public CFrame CFrame0 = CFrame.identity;

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

    public class Wire : Instance
    {
        public Instance SourceInstance = null;
        public string SourceName = "Output";
        public Instance TargetInstance = null;
        public string TargetName = "Input";
    }
}
