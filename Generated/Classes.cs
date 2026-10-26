// Auto-generated list of creatable Roblox classes.
// Updated as of 0.745.0.7451137

using System;

using RobloxFiles.DataTypes;
using RobloxFiles.Enums;
using RobloxFiles.Utility;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CS0612 // Type or member is obsolete

namespace RobloxFiles
{
    public class AnimationNode : RbxObject
    {
    }

    public class AppHandle : RbxObject
    {
    }

    public class Capture : RbxObject
    {
    }

    public abstract class ScreenshotCapture : Capture
    {
    }

    public abstract class VideoCapture : Capture
    {
    }

    public class ConfigSnapshot : RbxObject
    {
    }

    public class DataModelDiff : RbxObject
    {
    }

    public class EditableImage : RbxObject
    {
        public byte[] ImageData;
    }

    public class EditableMesh : RbxObject
    {
        public SharedString MeshData;
    }

    public class ExecutedRemoteCommand : RbxObject
    {
    }

    public class FeatureMatchingSession : RbxObject
    {
    }

    public class AccessoryDescription : Instance
    {
        public AccessoryType AccessoryType = AccessoryType.Unknown;
        public long AssetId = 0;
        public Instance Instance;
        public bool IsLayered;
        public int Order = 0;
        public Vector3 Position = Vector3.zero;

        [Obsolete]
        public float Puffiness = 1;

        public Vector3 Rotation = Vector3.zero;
        public Vector3 Scale = Vector3.one;
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

    public class AdPlacement : Instance
    {
        public Instance ActivationInstance;
        public AdFormat AdFormat = AdFormat.RewardedVideo;
        public long PlacementId = 0;
        public Content RewardImageContent = Content.None;
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
        public string ApiKey;
    }

    [RbxService]
    public class AnimatedImageService : Instance
    {
        public byte[] UserCreatedTracks;
    }

    public class Animation : Instance
    {
        public Content AnimationContent = Content.None;

        public ContentId AnimationId
        {
            get => AnimationContent;
            set => AnimationContent = value;
        }
    }

    public abstract class AnimationClip : Instance
    {
        public byte[] GuidBinaryString;
        public bool Loop = true;
        public AnimationPriority Priority = AnimationPriority.Action;
    }

    public class AnimationGraphDefinition : AnimationClip
    {
    }

    public class CurveAnimation : AnimationClip
    {
    }

    public class KeyframeSequence : AnimationClip
    {
        public float AuthoredHipHeight;
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

    public class AnimationNodeDefinition : Instance
    {
        public byte[] InputPinData;
        public string NodeId;
        public AnimationNodeType NodeType = AnimationNodeType.InvalidNode;
    }

    public class AnimationPlayer : Instance
    {
        public Content AnimationContent;
        public bool AutoPlay;
        public bool Enabled;
        public bool Loop;
        public float Speed;
        public string Track;
    }

    public class AnimationRigData : Instance
    {
        public byte[] Generic;
        public byte[] label = Convert.FromBase64String("AQAAAAEAAAAAAAAA");
        public byte[] name = Convert.FromBase64String("AQAAAAEAAAAAAAAA");
        public byte[] parent = Convert.FromBase64String("AQAAAAEAAAAAAA==");
        public byte[] postTransform = Convert.FromBase64String("AQAAAAEAAAAAAIA/AAAAAAAAAAAAAAAAAACAPwAAAAAAAAAAAAAAAAAAgD8AAAAAAAAAAAAAAAA=");
        public byte[] preTransform = Convert.FromBase64String("AQAAAAEAAAAAAIA/AAAAAAAAAAAAAAAAAACAPwAAAAAAAAAAAAAAAAAAgD8AAAAAAAAAAAAAAAA=");
        public byte[] transform = Convert.FromBase64String("AQAAAAEAAAAAAIA/AAAAAAAAAAAAAAAAAACAPwAAAAAAAAAAAAAAAAAAgD8AAAAAAAAAAAAAAAA=");
    }

    public class AnimationValueNodeDefinition : Instance
    {
        public string NodeId;
        public AnimationValueNodeType NodeType = AnimationValueNodeType.Invalid;
    }

    public class AnimationValueOutputDefinition : Instance
    {
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
    public class AppAgeSignalsService : Instance
    {
    }

    [RbxService]
    public class AppLifecycleObserverService : Instance
    {
    }

    [RbxService]
    public class AppRatingPromptService : Instance
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
    public class AssetQualityService : Instance
    {
    }

    [RbxService]
    public class AssetService : Instance
    {
        public bool AllowInsertFreeAssets;
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

        [Obsolete("Use `Orientation` instead.")]
        public Vector3 Rotation = null;

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
        public bool Active;
        public bool Muted;
        public Player Player;
        public float Volume = 1;
    }

    public class AudioDeviceOutput : Instance
    {
        public Player Player;
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
        public bool AcousticSimulationEnabled = true;
        public byte[] AngleAttenuation;
        public string AudioInteractionGroup = "";
        public SimulationMode DiffractionEnabled = SimulationMode.Default;
        public byte[] DistanceAttenuation;
        public NumberRange DistanceAttenuationBounds = new NumberRange(4, 10000);
        public DistanceAttenuationMode DistanceAttenuationMode = DistanceAttenuationMode.Custom;
        public SimulationMode OcclusionEnabled = SimulationMode.Default;
        public Instance PositionInstance;
        public EmitterPositionType PositionType = EmitterPositionType.Parent;
        public SimulationMode ReverbEnabled = SimulationMode.Default;

        [Obsolete("Use `AcousticSimulationEnabled` instead.")]
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

    public class AudioGate : Instance
    {
        public float Attack = 0.01f;
        public bool Bypass;
        public float Release = 0.1f;
        public NumberRange Threshold = new NumberRange(-36, -24);
    }

    public class AudioLimiter : Instance
    {
        public bool Bypass;
        public float MaxLevel = 0;
        public float Release = 0.01f;
    }

    public class AudioListener : Instance
    {
        public bool AcousticSimulationEnabled = true;
        public byte[] AngleAttenuation;
        public string AudioInteractionGroup = "";
        public SimulationMode DiffractionEnabled = SimulationMode.Default;
        public byte[] DistanceAttenuation;
        public SimulationMode OcclusionEnabled = SimulationMode.Default;
        public Instance PositionInstance;
        public ListenerPositionType PositionType = ListenerPositionType.Parent;
        public SimulationMode ReverbEnabled = SimulationMode.Default;

        [Obsolete("Use `AcousticSimulationEnabled` instead.")]
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
        public ContentId Asset
        {
            get => AudioContent;
            set => AudioContent = value;
        }

        [Obsolete("Use `Asset` instead.")]
        public string AssetId
        {
            get => Asset;
            set => Asset = value;
        }

        public Content AudioContent = Content.None;
        public bool AutoLoad = true;
        public bool AutoPlay;
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

        [Obsolete("Use `AudioSubType` instead.")]
        public AudioSubType AudioSubtype
        {
            get => AudioSubType;
            set => AudioSubType = value;
        }

        public int MaxDuration = int.MaxValue;
        public int MaxPageSize = 0;
        public int MinDuration = 0;
        public string SearchKeyword = "";
        public AudioSortType SortType = AudioSortType.Relevance;
        public string Tag = "";
        public string Title = "";
    }

    public class AudioSpeechToText : Instance
    {
        public bool Enabled;
        public string Text = "";
    }

    public class AudioTextToSpeech : Instance
    {
        public bool AutoLocalize = true;
        public bool Looping;
        public float Pitch = 0;
        public float PlaybackSpeed = 1;
        public float Speed = 1;
        public string Text = "";
        public double TimePosition = 0;
        public string VoiceId = "";
        public float Volume = 1;
    }

    public class AudioTremolo : Instance
    {
        public bool Bypass;
        public float Depth = 1;
        public float Duty = 0.5f;
        public float Frequency = 5;
        public float Shape = 0;
        public float Skew = 0;
        public float Square = 0;
    }

    public class AudioWindSynthesizer : Instance
    {
        public bool Enabled = true;
        public Instance PositionInstance;
        public AudioPositionType PositionType = AudioPositionType.Parent;
        public WindSoundProfile Profile = WindSoundProfile.Turbulence;
        public float Volume = 1;
    }

    [Obsolete]
    [RbxService]
    public class AuroraScriptService : Instance
    {
    }

    [Obsolete]
    [RbxService]
    public class AuroraService : Instance
    {
        public double HashRoundingPoint;
        public bool IgnoreRotation;
        public bool LockStepIdOffset;
        public int RollbackOffset;
    }

    public class AvatarAbilityRules : Instance
    {
        public AvatarSettingsCharacterControllerMode CharacterControllerMode;
        public bool EnableClimbing;
        public bool EnableCrouching;
        public bool EnableFallingDown;
        public bool EnableGettingUp;
        public bool EnableHolding;
        public bool EnableJumping;
        public bool EnableReaching;
        public bool EnableRunning;
        public bool EnableSitting;
        public bool EnableSprinting;
        public bool EnableSwimming;
        public bool EnableTurning;
    }

    public class AvatarAccessoryRules : Instance
    {
        public AvatarSettingsAccessoryMode AccessoryMode = AvatarSettingsAccessoryMode.PlayerChoice;
        public long BackAccessoryOverride = 0;

        [Obsolete("Use `HairAccessoryOverride` instead.")]
        public AvatarSettingsCustomAccessoryMode CustomAccessoryMode;

        [Obsolete("Use `BackAccessoryOverride` instead.")]
        public bool CustomBackAccessoryEnabled;

        [Obsolete("Use `BackAccessoryOverride` instead.")]
        public long CustomBackAccessoryId;

        [Obsolete("Use `FaceAccessoryOverride` instead.")]
        public bool CustomFaceAccessoryEnabled;

        [Obsolete("Use `FaceAccessoryOverride` instead.")]
        public long CustomFaceAccessoryId;

        [Obsolete("Use `FrontAccessoryOverride` instead.")]
        public bool CustomFrontAccessoryEnabled;

        [Obsolete("Use `FrontAccessoryOverride` instead.")]
        public long CustomFrontAccessoryId;

        [Obsolete("Use `HairAccessoryOverride` instead.")]
        public bool CustomHairAccessoryEnabled;

        [Obsolete("Use `HairAccessoryOverride` instead.")]
        public long CustomHairAccessoryId;

        [Obsolete("Use `HeadAccessoryOverride` instead.")]
        public bool CustomHeadAccessoryEnabled;

        [Obsolete("Use `HeadAccessoryOverride` instead.")]
        public long CustomHeadAccessoryId;

        [Obsolete("Use `NeckAccessoryOverride` instead.")]
        public bool CustomNeckAccessoryEnabled;

        [Obsolete("Use `NeckAccessoryOverride` instead.")]
        public long CustomNeckAccessoryId;

        [Obsolete("Use `ShoulderAccessoryOverride` instead.")]
        public bool CustomShoulderAccessoryEnabled;

        [Obsolete("Use `ShoulderAccessoryOverride` instead.")]
        public long CustomShoulderAccessoryId;

        [Obsolete("Use `WaistAccessoryOverride` instead.")]
        public bool CustomWaistAccessoryEnabled;

        [Obsolete("Use `WaistAccessoryOverride` instead.")]
        public long CustomWaistAccessoryId;

        public bool EnableEmissives = true;
        public bool EnableSound = true;
        public bool EnableVFX = true;
        public long FaceAccessoryOverride = 0;
        public long FrontAccessoryOverride = 0;
        public long HairAccessoryOverride = 0;
        public long HeadAccessoryOverride = 0;
        public Vector3 LimitBounds = Vector3.zero;
        public AvatarSettingsAccessoryLimitMethod LimitMethod = AvatarSettingsAccessoryLimitMethod.Remove;
        public long NeckAccessoryOverride = 0;
        public long ShoulderAccessoryOverride = 0;
        public long WaistAccessoryOverride = 0;
    }

    public class AvatarAnimationRules : Instance
    {
        [Obsolete("Use `RunAnimationOverride` instead.")]
        public AvatarSettingsAnimationClipsMode AnimationClipsMode;

        public AvatarSettingsAnimationPacksMode AnimationPacksMode = AvatarSettingsAnimationPacksMode.PlayerChoice;
        public long ClimbAnimationOverride = 0;

        [Obsolete("Use `ClimbAnimationOverride` instead.")]
        public bool CustomClimbAnimationEnabled;

        [Obsolete("Use `ClimbAnimationOverride` instead.")]
        public long CustomClimbAnimationId;

        [Obsolete("Use `FallAnimationOverride` instead.")]
        public bool CustomFallAnimationEnabled;

        [Obsolete("Use `FallAnimationOverride` instead.")]
        public long CustomFallAnimationId;

        [Obsolete("Use `IdleAltAnimationOverride` instead.")]
        public bool CustomIdleAlt1AnimationEnabled;

        [Obsolete("Use `IdleAltAnimationOverride` instead.")]
        public long CustomIdleAlt1AnimationId;

        [Obsolete]
        public bool CustomIdleAlt2AnimationEnabled;

        [Obsolete]
        public long CustomIdleAlt2AnimationId;

        [Obsolete("Use `IdleAnimationOverride` instead.")]
        public bool CustomIdleAnimationEnabled;

        [Obsolete("Use `IdleAnimationOverride` instead.")]
        public long CustomIdleAnimationId;

        [Obsolete("Use `JumpAnimationOverride` instead.")]
        public bool CustomJumpAnimationEnabled;

        [Obsolete("Use `JumpAnimationOverride` instead.")]
        public long CustomJumpAnimationId;

        [Obsolete("Use `RunAnimationOverride` instead.")]
        public bool CustomRunAnimationEnabled;

        [Obsolete("Use `RunAnimationOverride` instead.")]
        public long CustomRunAnimationId;

        [Obsolete("Use `SwimAnimationOverride` instead.")]
        public bool CustomSwimAnimationEnabled;

        [Obsolete("Use `SwimAnimationOverride` instead.")]
        public long CustomSwimAnimationId;

        [Obsolete("Use `SwimIdleAnimationOverride` instead.")]
        public bool CustomSwimIdleAnimationEnabled;

        [Obsolete("Use `SwimIdleAnimationOverride` instead.")]
        public long CustomSwimIdleAnimationId;

        [Obsolete("Use `WalkAnimationOverride` instead.")]
        public bool CustomWalkAnimationEnabled;

        [Obsolete("Use `WalkAnimationOverride` instead.")]
        public long CustomWalkAnimationId;

        public long FallAnimationOverride = 0;
        public long IdleAltAnimationOverride = 0;
        public long IdleAnimationOverride = 0;
        public long JumpAnimationOverride = 0;
        public long MoodAnimationOverride = 0;
        public long RunAnimationOverride = 0;
        public long SwimAnimationOverride = 0;
        public long SwimIdleAnimationOverride = 0;
        public long WalkAnimationOverride = 0;
    }

    public class AvatarBodyRules : Instance
    {
        [Obsolete("Use `HeadOverride` instead.")]
        public AvatarSettingsAppearanceMode AppearanceMode;

        public GameAvatarType AvatarType = GameAvatarType.R15;
        public AvatarSettingsBuildMode BuildMode = AvatarSettingsBuildMode.PlayerChoice;

        [Obsolete]
        public long CustomBodyBundleId;

        [Obsolete]
        public AvatarSettingsCustomBodyType CustomBodyType;

        [Obsolete("Use `CustomBuildBodyType` instead.")]
        public NumberRange CustomBodyTypeScale;

        public NumberRange CustomBuildBodyType = new NumberRange(0, 1);
        public NumberRange CustomBuildHead = new NumberRange(0.95f, 1);
        public NumberRange CustomBuildHeight = new NumberRange(0.9f, 1.05f);
        public NumberRange CustomBuildProportions = new NumberRange(0, 1);
        public NumberRange CustomBuildWidth = new NumberRange(0.7f, 1);

        [Obsolete]
        public bool CustomEyebrowEnabled;

        [Obsolete]
        public long CustomEyebrowId;

        [Obsolete]
        public bool CustomEyelashEnabled;

        [Obsolete]
        public long CustomEyelashId;

        [Obsolete]
        public bool CustomFaceEnabled;

        [Obsolete]
        public long CustomFaceId;

        [Obsolete("Use `HeadOverride` instead.")]
        public bool CustomHeadEnabled;

        [Obsolete("Use `HeadOverride` instead.")]
        public long CustomHeadId;

        [Obsolete("Use `CustomBuildHead` instead.")]
        public NumberRange CustomHeadScale;

        [Obsolete("Use `CustomWorldHeight` instead.")]
        public NumberRange CustomHeight;

        [Obsolete("Use `CustomBuildHeight` instead.")]
        public NumberRange CustomHeightScale;

        [Obsolete("Use `LeftArmOverride` instead.")]
        public bool CustomLeftArmEnabled;

        [Obsolete("Use `LeftArmOverride` instead.")]
        public long CustomLeftArmId;

        [Obsolete("Use `LeftLegOverride` instead.")]
        public bool CustomLeftLegEnabled;

        [Obsolete("Use `LeftLegOverride` instead.")]
        public long CustomLeftLegId;

        [Obsolete("Use `MoodAnimationOverride` instead.")]
        public bool CustomMoodEnabled;

        [Obsolete("Use `MoodAnimationOverride` instead.")]
        public long CustomMoodId;

        [Obsolete("Use `CustomBuildProportions` instead.")]
        public NumberRange CustomProportionsScale;

        [Obsolete("Use `RightArmOverride` instead.")]
        public bool CustomRightArmEnabled;

        [Obsolete("Use `RightArmOverride` instead.")]
        public long CustomRightArmId;

        [Obsolete("Use `RightLegOverride` instead.")]
        public bool CustomRightLegEnabled;

        [Obsolete("Use `RightLegOverride` instead.")]
        public long CustomRightLegId;

        [Obsolete("Use `TorsoOverride` instead.")]
        public bool CustomTorsoEnabled;

        [Obsolete("Use `TorsoOverride` instead.")]
        public long CustomTorsoId;

        [Obsolete("Use `CustomBuildWidth` instead.")]
        public NumberRange CustomWidthScale;

        public NumberRange CustomWorldHeight = new NumberRange(5.5f);
        public long HeadOverride = 0;

        [Obsolete]
        public bool KeepPlayerHead;

        public long LeftArmOverride = 0;
        public long LeftLegOverride = 0;
        public long RightArmOverride = 0;
        public long RightLegOverride = 0;
        public AvatarSettingsScaleMode ScaleMode = AvatarSettingsScaleMode.PlayerChoice;
        public long TorsoOverride = 0;
    }

    [RbxService]
    public class AvatarChatService : Instance
    {
    }

    public class AvatarClothingRules : Instance
    {
        public long ClassicPantsOverride = 0;
        public long ClassicShirtOverride = 0;
        public long ClassicTShirtOverride = 0;
        public AvatarSettingsClothingMode ClothingMode = AvatarSettingsClothingMode.PlayerChoice;

        [Obsolete("Use `ClassicPantsOverride` instead.")]
        public bool CustomClassicPantsAccessoryEnabled;

        [Obsolete("Use `ClassicPantsOverride` instead.")]
        public long CustomClassicPantsAccessoryId;

        [Obsolete("Use `ClassicShirtOverride` instead.")]
        public bool CustomClassicShirtsAccessoryEnabled;

        [Obsolete("Use `ClassicShirtOverride` instead.")]
        public long CustomClassicShirtsAccessoryId;

        [Obsolete("Use `ClassicTShirtOverride` instead.")]
        public bool CustomClassicTShirtsAccessoryEnabled;

        [Obsolete("Use `ClassicTShirtOverride` instead.")]
        public long CustomClassicTShirtsAccessoryId;

        [Obsolete("Use `TShirtAccessoryOverride` instead.")]
        public AvatarSettingsCustomClothingMode CustomClothingMode;

        [Obsolete("Use `DressSkirtAccessoryOverride` instead.")]
        public bool CustomDressSkirtAccessoryEnabled;

        [Obsolete("Use `DressSkirtAccessoryOverride` instead.")]
        public long CustomDressSkirtAccessoryId;

        [Obsolete("Use `JacketAccessoryOverride` instead.")]
        public bool CustomJacketAccessoryEnabled;

        [Obsolete("Use `JacketAccessoryOverride` instead.")]
        public long CustomJacketAccessoryId;

        [Obsolete("Use `LeftShoeAccessoryOverride` instead.")]
        public bool CustomLeftShoesAccessoryEnabled;

        [Obsolete("Use `LeftShoeAccessoryOverride` instead.")]
        public long CustomLeftShoesAccessoryId;

        [Obsolete("Use `PantsAccessoryOverride` instead.")]
        public bool CustomPantsAccessoryEnabled;

        [Obsolete("Use `PantsAccessoryOverride` instead.")]
        public long CustomPantsAccessoryId;

        [Obsolete("Use `RightShoeAccessoryOverride` instead.")]
        public bool CustomRightShoesAccessoryEnabled;

        [Obsolete("Use `RightShoeAccessoryOverride` instead.")]
        public long CustomRightShoesAccessoryId;

        [Obsolete("Use `ShirtAccessoryOverride` instead.")]
        public bool CustomShirtAccessoryEnabled;

        [Obsolete("Use `ShirtAccessoryOverride` instead.")]
        public long CustomShirtAccessoryId;

        [Obsolete("Use `ShortsAccessoryOverride` instead.")]
        public bool CustomShortsAccessoryEnabled;

        [Obsolete("Use `ShortsAccessoryOverride` instead.")]
        public long CustomShortsAccessoryId;

        [Obsolete("Use `SweaterAccessoryOverride` instead.")]
        public bool CustomSweaterAccessoryEnabled;

        [Obsolete("Use `SweaterAccessoryOverride` instead.")]
        public long CustomSweaterAccessoryId;

        [Obsolete("Use `TShirtAccessoryOverride` instead.")]
        public bool CustomTShirtAccessoryEnabled;

        [Obsolete("Use `TShirtAccessoryOverride` instead.")]
        public long CustomTShirtAccessoryId;

        public long DressSkirtAccessoryOverride = 0;
        public long JacketAccessoryOverride = 0;
        public long LeftShoeAccessoryOverride = 0;
        public Vector3 LimitBounds = Vector3.zero;
        public long PantsAccessoryOverride = 0;
        public long RightShoeAccessoryOverride = 0;
        public long ShirtAccessoryOverride = 0;
        public long ShortsAccessoryOverride = 0;
        public long SweaterAccessoryOverride = 0;
        public long TShirtAccessoryOverride = 0;
    }

    public class AvatarCollisionRules : Instance
    {
        public bool BodyPartsCollidableOnDeath = true;
        public AvatarSettingsCollisionMode CollisionMode = AvatarSettingsCollisionMode.Default;
        public AvatarSettingsHitAndTouchDetectionMode HitAndTouchDetectionMode = AvatarSettingsHitAndTouchDetectionMode.UseParts;

        [Obsolete]
        public AvatarSettingsLegacyCollisionMode LegacyCollisionMode;

        public Vector3 SingleColliderSize = new Vector3(2, 3, 1);
    }

    [RbxService]
    public class AvatarCreationService : Instance
    {
    }

    [RbxService]
    public class AvatarEditorService : Instance
    {
    }

    public class AvatarRules : Instance
    {
        [Obsolete("Use `AvatarType` instead.")]
        public GameAvatarType AvatarType;
    }

    [RbxService]
    public class AvatarSettings : Instance
    {
        public int RulesSchemaVersion;
    }

    [RbxService]
    public class BackendReplicatedStorage : Instance
    {
    }

    [RbxService]
    public class BackendServerScriptService : Instance
    {
    }

    [RbxService]
    public class BackendServerStorage : Instance
    {
    }

    public class Backpack : Instance
    {
    }

    [RbxService]
    public class BadgeService : Instance
    {
    }

    public abstract class BaseCoreGuiConfiguration : Instance
    {
        public bool Enabled;
    }

    public abstract class BaseImportData : Instance
    {
        public string ImportName;
        public bool ShouldImport;
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
        public RolloutState ClipsDescendantsSupportsRotation;

        [Obsolete]
        public bool ResetPlayerGuiOnSpawn = true;

        public RtlTextSupport RtlTextSupport;
        public ScreenOrientation ScreenOrientation = ScreenOrientation.LandscapeSensor;
        public bool ShowDevelopmentGui = true;
        public StyleSheet StudioDefaultStyleSheet;
        public StyleSheet StudioInsertWidgetLayerCollectorAutoLinkStyleSheet;
        public VirtualCursorMode VirtualCursorMode;
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

        public ContentId HSRAssetId
        {
            get => HSRContent;
            set => HSRContent = value;
        }

        public Content HSRContent = Content.None;
        public SharedString HSRData;
        public SharedString HSRMeshIdData;
        public CFrame ImportOrigin = CFrame.identity;
        public Content TemporaryCageMeshContent = Content.None;
    }

    public class WrapDeformer : BaseWrap
    {
    }

    public class WrapLayer : BaseWrap
    {
        public WrapLayerAutoSkin AutoSkin = WrapLayerAutoSkin.Disabled;
        public CFrame BindOffset = CFrame.identity;
        public bool Enabled = true;
        public int Order = 1;

        [Obsolete]
        public float Puffiness = 1;

        public Content ReferenceMeshContent = Content.None;

        public ContentId ReferenceMeshId
        {
            get => ReferenceMeshContent;
            set => ReferenceMeshContent = value;
        }

        public CFrame ReferenceOrigin = CFrame.identity;
        public Content RotateScaleDeformationMap = Content.None;
        public Content ScaleOnlyDeformationMap = Content.None;

        [Obsolete]
        public float ShrinkFactor = 0;

        public float TargetShaping = 0;
        public Content TemporaryReferenceMeshContent = Content.None;
    }

    public class WrapTarget : BaseWrap
    {
        [Obsolete]
        public float Stiffness = 0;
    }

    public class Beam : Instance
    {
        public Attachment Attachment0;
        public Attachment Attachment1;
        public float Brightness = 1;
        public ColorSequence Color = new ColorSequence(1, 1, 1);
        public float CurveSize0 = 0;
        public float CurveSize1 = 0;
        public bool Enabled = true;
        public bool FaceCamera;
        public float LightEmission = 0;
        public float LightInfluence = 0;
        public int Segments = 10;

        public ContentId Texture
        {
            get => TextureContent;
            set => TextureContent = value;
        }

        public Content TextureContent = Content.None;
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

    [Obsolete]
    public abstract class BodyMover : Instance
    {
    }

    [Obsolete("Use `AngularVelocity` instead.")]
    public class BodyAngularVelocity : BodyMover
    {
        public Vector3 AngularVelocity = new Vector3(0, 2, 0);
        public Vector3 MaxTorque = Vector3.one * 4000;
        public float P = 1250;

        [Obsolete("Use `AngularVelocity` instead.")]
        public Vector3 angularvelocity
        {
            get => AngularVelocity;
            set => AngularVelocity = value;
        }

        [Obsolete("Use `MaxTorque` instead.")]
        public Vector3 maxTorque = null;
    }

    [Obsolete("Use `VectorForce` instead.")]
    public class BodyForce : BodyMover
    {
        public Vector3 Force = Vector3.yAxis;

        [Obsolete("Use `Force` instead.")]
        public Vector3 force
        {
            get => Force;
            set => Force = value;
        }
    }

    [Obsolete("Use `AlignOrientation` instead.")]
    public class BodyGyro : BodyMover
    {
        public CFrame CFrame = CFrame.identity;
        public float D = 500;
        public Vector3 MaxTorque = new Vector3(400000, 0, 400000);
        public float P = 3000;

        [Obsolete("Use `CFrame` instead.")]
        public CFrame cframe
        {
            get => CFrame;
            set => CFrame = value;
        }

        [Obsolete("Use `MaxTorque` instead.")]
        public Vector3 maxTorque
        {
            get => MaxTorque;
            set => MaxTorque = value;
        }
    }

    [Obsolete("Use `AlignPosition` instead.")]
    public class BodyPosition : BodyMover
    {
        public float D = 1250;
        public Vector3 MaxForce = Vector3.one * 4000;
        public float P = 10000;
        public Vector3 Position = new Vector3(0, 50, 0);

        [Obsolete("Use `MaxForce` instead.")]
        public Vector3 maxForce = null;

        [Obsolete("Use `Position` instead.")]
        public Vector3 position = null;
    }

    [Obsolete("Use `VectorForce` instead.")]
    public class BodyThrust : BodyMover
    {
        public Vector3 Force = Vector3.yAxis;
        public Vector3 Location = Vector3.zero;

        [Obsolete("Use `Force` instead.")]
        public Vector3 force = null;

        [Obsolete("Use `Location` instead.")]
        public Vector3 location = null;
    }

    [Obsolete("Use `LinearVelocity` instead.")]
    public class BodyVelocity : BodyMover
    {
        public Vector3 MaxForce = Vector3.one * 4000;
        public float P = 1250;
        public Vector3 Velocity = new Vector3(0, 2, 0);

        [Obsolete("Use `MaxForce` instead.")]
        public Vector3 maxForce = null;

        [Obsolete("Use `Velocity` instead.")]
        public Vector3 velocity = null;
    }

    [Obsolete("Use `LineForce` instead.")]
    public class RocketPropulsion : BodyMover
    {
        public float CartoonFactor = 0.7f;
        public float MaxSpeed = 30;
        public float MaxThrust = 4000;
        public Vector3 MaxTorque = new Vector3(400000, 400000, 0);
        public BasePart Target;
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
        public string HeadShape = "";
        public Instance Instance;
    }

    [RbxService]
    public class BranchService : Instance
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
    public class WrapContentProvider : CacheableContentProvider
    {
    }

    [RbxService]
    public class CallingService : Instance
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

    [RbxService]
    public class ChangeHistoryStreamingService : Instance
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
        public Content BaseTextureContent = Content.None;

        public long BaseTextureId
        {
            get => BaseTextureContent.AssetId;
            set => BaseTextureContent = new Content(value);
        }

        public BodyPart BodyPart = BodyPart.Head;
        public Content MeshContent = Content.None;

        public long MeshId
        {
            get => MeshContent.AssetId;
            set => MeshContent = new Content(value);
        }

        public Content OverlayTextureContent = Content.None;

        public long OverlayTextureId
        {
            get => OverlayTextureContent.AssetId;
            set => OverlayTextureContent = new Content(value);
        }
    }

    public abstract class Clothing : CharacterAppearance
    {
        public Color3 Color3 = new Color3(1, 1, 1);
        public Content Outfit1Content = Content.None;
        public Content Outfit2Content = Content.None;
    }

    public class Pants : Clothing
    {
        public ContentId PantsTemplate
        {
            get => PantsTemplateContent;
            set => PantsTemplateContent = value;
        }

        public Content PantsTemplateContent = Content.None;
    }

    public class Shirt : Clothing
    {
        public ContentId ShirtTemplate
        {
            get => ShirtTemplateContent;
            set => ShirtTemplateContent = value;
        }

        public Content ShirtTemplateContent = Content.None;
    }

    public class ShirtGraphic : CharacterAppearance
    {
        public Color3 Color3 = new Color3(1, 1, 1);

        public ContentId Graphic
        {
            get => TextureContent;
            set => TextureContent = value;
        }

        public Content TextureContent = Content.None;
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

    public class ClickDetector : Instance
    {
        public ContentId CursorIcon
        {
            get => CursorIconContent;
            set => CursorIconContent = value;
        }

        public Content CursorIconContent = Content.None;
        public float MaxActivationDistance = 32;
    }

    public class DragDetector : ClickDetector
    {
        public ContentId ActivatedCursorIcon
        {
            get => ActivatedCursorIconContent;
            set => ActivatedCursorIconContent = value;
        }

        public Content ActivatedCursorIconContent = Content.None;
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
        public Instance ReferenceInstance;
        public DragDetectorResponseStyle ResponseStyle = DragDetectorResponseStyle.Physical;
        public float Responsiveness = 10;
        public bool RunLocally;
        public float TrackballRadialPullFactor = 1;
        public float TrackballRollFactor = 1;
        public KeyCode VRSwitchKeyCode = KeyCode.ButtonL2;
    }

    [RbxService]
    public class ClientStorageService : Instance
    {
    }

    [RbxService]
    public class CloudCRUDService : Instance
    {
    }

    [RbxService]
    public class CloudClientService : Instance
    {
        public bool RobloxRealityFilterEnabled;
    }

    [RbxService]
    public class CloudExecutionService : Instance
    {
    }

    [RbxService]
    public class CloudImportService : Instance
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
    public class CommerceService : Instance
    {
    }

    public class CompositeValueCurve : Instance
    {
        public CompositeValueCurveType CurveType = CompositeValueCurveType.NumberRange;
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

    public abstract class Constraint : Instance
    {
        public Attachment Attachment0;
        public Attachment Attachment1;
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
        public bool ApplyAtCenterOfMass;
        public ForceLimitMode ForceLimitMode = ForceLimitMode.Magnitude;
        public ActuatorRelativeTo ForceRelativeTo = ActuatorRelativeTo.World;
        public Vector3 MaxAxesForce = Vector3.one * 10000;
        public float MaxForce = 10000;
        public float MaxVelocity = float.MaxValue;
        public PositionAlignmentMode Mode = PositionAlignmentMode.TwoAttachment;
        public Vector3 Position = Vector3.zero;
        public bool ReactionForceEnabled;
        public float Responsiveness = 10;
        public bool RigidityEnabled;

        public AlignPosition()
        {
            Color = BrickColorId.Medium_stone_grey;
        }
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
        public float AngularDamping = 1;
        public float AngularStrength = 1;
        public bool IsKinematic;
        public float LinearDamping = 1;
        public float LinearStrength = 1;
        public float MaxForce = 10000;
        public float MaxTorque = 10000;
        public CFrame Transform = CFrame.identity;
    }

    public class BallSocketConstraint : Constraint
    {
        public bool LimitsEnabled;

        public float MaxFrictionTorque
        {
            get => MaxFrictionTorqueXml;
            set => MaxFrictionTorqueXml = value;
        }

        public float MaxFrictionTorqueXml;
        public float Radius = 0.15f;
        public float Restitution = 0;
        public bool TwistLimitsEnabled;
        public float TwistLowerAngle = -45;
        public float TwistUpperAngle = 45;
        public float UpperAngle = 45;

        public BallSocketConstraint()
        {
            Color = BrickColorId.New_Yeller;
        }
    }

    public class HingeConstraint : Constraint
    {
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

        public HingeConstraint()
        {
            Color = BrickColorId.New_Yeller;
        }
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
        public ForceLimitMode ForceLimitMode = ForceLimitMode.Magnitude;
        public bool ForceLimitsEnabled = true;
        public Vector3 LineDirection = Vector3.xAxis;
        public float LineVelocity = 0;
        public Vector3 MaxAxesForce = Vector3.one * 1000;
        public float MaxForce = 1000;
        public Vector2 MaxPlanarAxesForce = Vector2.one * 1000;
        public Vector2 PlaneVelocity = Vector2.zero;
        public Vector3 PrimaryTangentAxis = Vector3.xAxis;
        public bool ReactionForceEnabled = true;
        public ActuatorRelativeTo RelativeTo = ActuatorRelativeTo.World;
        public Vector3 SecondaryTangentAxis = Vector3.yAxis;
        public Vector3 VectorVelocity = Vector3.zero;
        public VelocityConstraintMode VelocityConstraintMode = VelocityConstraintMode.Vector;

        public LinearVelocity()
        {
            Color = BrickColorId.Black;
        }
    }

    public class PlaneConstraint : Constraint
    {

        public PlaneConstraint()
        {
            Color = BrickColorId.Medium_stone_grey;
        }
    }

    [Obsolete("Use `PlaneConstraint` instead.")]
    public class Plane : PlaneConstraint
    {
    }

    public class RigidConstraint : Constraint
    {

        public RigidConstraint()
        {
            Color = BrickColorId.Medium_stone_grey;
        }
    }

    public class RodConstraint : Constraint
    {
        public float Length = 5;
        public float LimitAngle0 = 90;
        public float LimitAngle1 = 90;
        public bool LimitsEnabled;
        public float Thickness = 0.1f;

        public RodConstraint()
        {
            Color = BrickColorId.Black;
        }
    }

    public class RopeConstraint : Constraint
    {
        public float Length = 5;
        public float Restitution = 0;
        public float Thickness = 0.1f;
        public bool WinchEnabled;
        public float WinchForce = 10000;
        public float WinchResponsiveness = 45;
        public float WinchSpeed = 2;
        public float WinchTarget = 5;

        public RopeConstraint()
        {
            Color = BrickColorId.Earth_orange;
        }
    }

    public abstract class SlidingBallConstraint : Constraint
    {
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
    }

    public class SpringConstraint : Constraint
    {
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

        public SpringConstraint()
        {
            Color = BrickColorId.Lemon_metalic;
        }
    }

    public class Torque : Constraint
    {
        public ActuatorRelativeTo RelativeTo = ActuatorRelativeTo.Attachment0;
        public Vector3 Torque_ = Vector3.zero;
    }

    public class TorsionSpringConstraint : Constraint
    {
        public float Coils = 8;
        public float Damping = 0.01f;

        [Obsolete("Use `LimitsEnabled` instead.")]
        public bool LimitEnabled;

        public bool LimitsEnabled;
        public float MaxAngle = 45;
        public float MaxTorque = float.MaxValue;
        public float Radius = 0.4f;
        public float Restitution = 0;
        public float Stiffness = 100;

        public TorsionSpringConstraint()
        {
            Color = BrickColorId.Lemon_metalic;
        }
    }

    public class UniversalConstraint : Constraint
    {
        public bool LimitsEnabled;
        public float MaxAngle = 45;
        public float Radius = 0.2f;
        public float Restitution = 0;

        public UniversalConstraint()
        {
            Color = BrickColorId.New_Yeller;
        }
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

    public class ControlState : Instance
    {
        public Player Owner;
        public byte[] StateSchema;
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
        public ControllerBase ActiveController;
        public float BaseMoveSpeed = 16;
        public float BaseTurnSpeed = 8;
        public ControllerSensor ClimbSensor;
        public Vector3 FacingDirection = Vector3.zAxis;
        public ControllerSensor GroundSensor;
        public Vector3 MovingDirection = Vector3.zero;
        public BasePart RootPart;
        public Vector3 UpDirection = Vector3.yAxis;
    }

    [RbxService]
    public class ControllerService : Instance
    {
    }

    [RbxService]
    public class CookiesService : Instance
    {
    }

    [RbxService]
    public class CoreGuiConfiguration : Instance
    {
        public Instance CapturesViewConfiguration;
        public Instance PlayerListConfiguration;
        public Instance SelfViewConfiguration;
    }

    [RbxService]
    public class CorePackages : Instance
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

    public class CustomEvent : Instance
    {
        public float PersistedCurrentValue;
    }

    public class CustomEventReceiver : Instance
    {
        public Instance Source;
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
        public Content MeshContent = Content.None;

        public ContentId MeshId
        {
            get => MeshContent;
            set => MeshContent = value;
        }

        public Content TextureContent = Content.None;

        public ContentId TextureId
        {
            get => TextureContent;
            set => TextureContent = value;
        }
    }

    public class SpecialMesh : FileMesh
    {
        public MeshType MeshType = MeshType.Head;
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
        public int MaxItems = 1000;
    }

    [RbxService]
    public class DebuggerManager : Instance
    {
    }

    public class DebuggerWatch : Instance
    {
        public string Expression;
    }

    [RbxService]
    public class DesignFoundationsService : Instance
    {
    }

    [RbxService]
    public class DeviceDisplayService : Instance
    {
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

    public class DigitsRigDescription : Instance
    {
        public Instance Index1;
        public CFrame Index1TposeAdjustment = CFrame.identity;
        public Instance Index2;
        public CFrame Index2TposeAdjustment = CFrame.identity;
        public Instance Index3;
        public CFrame Index3TposeAdjustment = CFrame.identity;
        public Vector3 IndexRange = Vector3.zero;
        public float IndexSize = 0;
        public Instance Middle1;
        public CFrame Middle1TposeAdjustment = CFrame.identity;
        public Instance Middle2;
        public CFrame Middle2TposeAdjustment = CFrame.identity;
        public Instance Middle3;
        public CFrame Middle3TposeAdjustment = CFrame.identity;
        public Vector3 MiddleRange = Vector3.zero;
        public float MiddleSize = 0;
        public Instance Pinky1;
        public CFrame Pinky1TposeAdjustment = CFrame.identity;
        public Instance Pinky2;
        public CFrame Pinky2TposeAdjustment = CFrame.identity;
        public Instance Pinky3;
        public CFrame Pinky3TposeAdjustment = CFrame.identity;
        public Vector3 PinkyRange = Vector3.zero;
        public float PinkySize = 0;
        public Instance Ring1;
        public CFrame Ring1TposeAdjustment = CFrame.identity;
        public Instance Ring2;
        public CFrame Ring2TposeAdjustment = CFrame.identity;
        public Instance Ring3;
        public CFrame Ring3TposeAdjustment = CFrame.identity;
        public Vector3 RingRange = Vector3.zero;
        public float RingSize = 0;
        public DigitsRigDescriptionSide Side = DigitsRigDescriptionSide.None;
        public Instance Thumb1;
        public CFrame Thumb1TposeAdjustment = CFrame.identity;
        public Instance Thumb2;
        public CFrame Thumb2TposeAdjustment = CFrame.identity;
        public Instance Thumb3;
        public CFrame Thumb3TposeAdjustment = CFrame.identity;
        public Vector3 ThumbRange = Vector3.zero;
        public float ThumbSize = 0;
    }

    public class Dragger : Instance
    {
    }

    [RbxService]
    public class EditableService : Instance
    {
    }

    [RbxService]
    public class EditorSourceService : Instance
    {
    }

    [RbxService]
    public class EncodingService : Instance
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
    public class ExampleV2Service : Instance
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
    public class ExperienceStateCaptureService : Instance
    {
    }

    [RbxService]
    public class ExperienceStateRecordingService : Instance
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
    public class ExternalIdentityService : Instance
    {
    }

    [RbxService]
    public class FaceAnimatorService : Instance
    {
    }

    public class FaceControls : Instance
    {
        public byte[] InternalOverrideFACSData;
    }

    public abstract class FaceInstance : Instance
    {
        public NormalId Face = NormalId.Front;
    }

    public class Decal : FaceInstance
    {
        public bool AutoLocalize = true;
        public Color3 Color3 = new Color3(1, 1, 1);

        public ContentId ColorMap
        {
            get => ColorMapContent;
            set => ColorMapContent = value;
        }

        public Content ColorMapContent = Content.None;
        public Content EmissiveMaskContent = Content.None;
        public float EmissiveStrength = 1;
        public Color3 EmissiveTint = new Color3(1, 1, 1);
        public Content LocalizedTextureContent = Content.None;

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
        public ResamplerMode ResampleMode = ResamplerMode.Default;
        public float Rotation = 0;

        public ContentId RoughnessMap
        {
            get => RoughnessMapContent;
            set => RoughnessMapContent = value;
        }

        public Content RoughnessMapContent = Content.None;

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

        public ContentId TexturePack
        {
            get => TextureContent;
            set => TextureContent = value;
        }

        public string TexturePackMetadata;
        public float Transparency = 0;
        public Vector2 UVOffset = Vector2.zero;
        public Vector2 UVScale = Vector2.one;
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
    public class FacialAnimationStreamingServiceV2 : Instance
    {
        public int ServiceState;
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
    public class FeatureMatchingService : Instance
    {
    }

    public class FeatureMatchingTable : Instance
    {
        public SharedString Data;
    }

    [RbxService]
    public class FeatureRestrictionManager : Instance
    {
    }

    [RbxService]
    public class FileManagerService : Instance
    {
    }

    [RbxService]
    public class FileSyncReplicationService : Instance
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

        [Obsolete("Use `Size` instead.")]
        public float size = 5;

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
        public Color3 IconTint = new Color3();
    }

    public class GeneratedFolder : Folder
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

    [RbxService]
    public class FriendsCallingService : Instance
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

    public abstract class GlobalDataStore : Instance
    {
    }

    [RbxService]
    public class GongService : Instance
    {
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

        [Obsolete("Use `AutoLocalize` instead.")]
        public bool Localize
        {
            get => AutoLocalize;
            set => AutoLocalize = value;
        }

        public LocalizationTable RootLocalizationTable;
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
        public GuiObject NextSelectionDown;
        public GuiObject NextSelectionLeft;
        public GuiObject NextSelectionRight;
        public GuiObject NextSelectionUp;
        public UDim2 Position = new UDim2();
        public float Rotation = 0;
        public bool Selectable;
        public GuiObject SelectionImageObject;
        public int SelectionOrder = 0;
        public InputSink Sink;
        public UDim2 Size = new UDim2();
        public SizeConstraint SizeConstraint = SizeConstraint.RelativeXY;

        [Obsolete]
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
        public FrameStyle Style = FrameStyle.Custom;
    }

    public abstract class GuiButton : GuiObject
    {
        public bool AutoButtonColor = true;
        public HapticEffect HoverHapticEffect;
        public bool Modal;
        public HapticEffect PressHapticEffect;
        public bool Selected;
        public ButtonStyle Style = ButtonStyle.Custom;
    }

    public class ImageButton : GuiButton
    {
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
        public Content LocalizedImageContent = Content.None;

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
        public Font Font
        {
            get => FontUtility.GetLegacyFont(FontFace);
            set => FontUtility.TryGetFontFace(value, out FontFace);
        }

        public FontFace FontFace = FontFace.FromEnum(Enums.Font.Legacy);

        [Obsolete("Use `TextSize` instead.")]
        public FontSize FontSize
        {
            get => FontUtility.GetFontSize(TextSize);
            set => TextSize = FontUtility.GetFontSize(value);
        }

        public float LineHeight = 1;
        public string LocalizationMatchIdentifier;
        public string LocalizationMatchedSourceText;
        public int MaxVisibleGraphemes = -1;
        public string OpenTypeFeatures = "";
        public bool RichText;
        public string Text = "Button";

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

        [Obsolete("Use `TextWrapped` instead.")]
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
    }

    public class ImageLabel : GuiLabel
    {
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
        public Content LocalizedImageContent = Content.None;
        public ResamplerMode ResampleMode = ResamplerMode.Default;
        public ScaleType ScaleType = ScaleType.Stretch;
        public Rect SliceCenter = new Rect();
        public float SliceScale = 1;
        public UDim2 TileSize = new UDim2(1, 0, 1, 0);
    }

    public class TextLabel : GuiLabel
    {
        public Font Font
        {
            get => FontUtility.GetLegacyFont(FontFace);
            set => FontUtility.TryGetFontFace(value, out FontFace);
        }

        public FontFace FontFace = FontFace.FromEnum(Enums.Font.Legacy);

        [Obsolete("Use `TextSize` instead.")]
        public FontSize FontSize
        {
            get => FontUtility.GetFontSize(TextSize);
            set => TextSize = FontUtility.GetFontSize(value);
        }

        public float LineHeight = 1;
        public string LocalizationMatchIdentifier;
        public string LocalizationMatchedSourceText;
        public int MaxVisibleGraphemes = -1;
        public string OpenTypeFeatures = "";
        public bool RichText;
        public string Text = "Label";

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

        [Obsolete("Use `TextWrapped` instead.")]
        public bool TextWrap
        {
            get => TextWrapped;
            set => TextWrapped = value;
        }

        public bool TextWrapped;
        public TextXAlignment TextXAlignment = TextXAlignment.Center;
        public TextYAlignment TextYAlignment = TextYAlignment.Center;
    }

    public class InputActionLabel : GuiObject
    {
        public FontFace FontFace = FontFace.FromEnum(Enums.Font.Legacy);
        public Color3 ImageColor3 = new Color3(1, 1, 1);
        public float ImageTransparency = 0;
        public InputAction InputAction;
        public Content ResolvedImageContent = Content.None;
        public Color3 TextColor3 = Color3.FromRGB(27, 42, 53);
        public float TextSize = 8;
        public float TextTransparency = 0;
        public bool TextWrapped;
        public TextXAlignment TextXAlignment = TextXAlignment.Center;
        public TextYAlignment TextYAlignment = TextYAlignment.Center;
    }

    public class RelativeGui : GuiObject
    {
    }

    public class ScrollingFrame : GuiObject
    {
        public AutomaticSize AutomaticCanvasSize = AutomaticSize.None;

        public ContentId BottomImage
        {
            get => BottomImageContent;
            set => BottomImageContent = value;
        }

        public Content BottomImageContent = Content.None;
        public Vector2 CanvasPosition = Vector2.zero;
        public UDim2 CanvasSize = new UDim2(0, 0, 2, 0);
        public ElasticBehavior ElasticBehavior = ElasticBehavior.WhenScrollable;
        public ScrollBarInset HorizontalScrollBarInset = ScrollBarInset.None;

        public ContentId MidImage
        {
            get => MidImageContent;
            set => MidImageContent = value;
        }

        public Content MidImageContent = Content.None;
        public Color3 ScrollBarImageColor3 = new Color3(1, 1, 1);
        public float ScrollBarImageTransparency = 0;
        public int ScrollBarThickness = 12;
        public ScrollingDirection ScrollingDirection = ScrollingDirection.XY;
        public bool ScrollingEnabled = true;

        public ContentId TopImage
        {
            get => TopImageContent;
            set => TopImageContent = value;
        }

        public Content TopImageContent = Content.None;
        public ScrollBarInset VerticalScrollBarInset = ScrollBarInset.None;
        public VerticalScrollBarPosition VerticalScrollBarPosition = VerticalScrollBarPosition.Right;
    }

    public class TextBox : GuiObject
    {
        public bool ClearTextOnFocus = true;

        public Font Font
        {
            get => FontUtility.GetLegacyFont(FontFace);
            set => FontUtility.TryGetFontFace(value, out FontFace);
        }

        public FontFace FontFace = FontFace.FromEnum(Enums.Font.Legacy);

        [Obsolete("Use `TextSize` instead.")]
        public FontSize FontSize
        {
            get => FontUtility.GetFontSize(TextSize);
            set => TextSize = FontUtility.GetFontSize(value);
        }

        public float LineHeight = 1;
        public string LocalizationMatchIdentifier;
        public string LocalizationMatchedSourceText;
        public int MaxVisibleGraphemes = -1;
        public bool MultiLine;
        public string OpenTypeFeatures = "";
        public Color3 PlaceholderColor3 = Color3.FromRGB(127, 127, 127);
        public string PlaceholderText = "";
        public bool RichText;
        public bool ShowNativeInput = true;
        public string Text = "TextBox";

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

        [Obsolete("Use `TextWrapped` instead.")]
        public bool TextWrap
        {
            get => TextWrapped;
            set => TextWrapped = value;
        }

        public bool TextWrapped;
        public TextXAlignment TextXAlignment = TextXAlignment.Center;
        public TextYAlignment TextYAlignment = TextYAlignment.Center;
    }

    public class TextChannelWindow : GuiObject
    {
        public FontFace FontFace = FontFace.FromEnum(Enums.Font.BuilderSansMedium);
        public TextChannel Target;
        public bool UseDefaultFont = true;
    }

    public class VideoDisplay : GuiObject
    {
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
        public InternalVideoUsage InternalVideoUsage;
        public bool Looped;
        public VideoSampleSize MaximumResolution;
        public bool Playing;
        public float RollOffMaxDistance = 10000;
        public float RollOffMinDistance = 1;
        public RollOffMode RollOffMode = RollOffMode.Inverse;
        public double TimePosition = 0;

        public ContentId Video
        {
            get => VideoContent;
            set => VideoContent = value;
        }

        public Content VideoContent = Content.None;
        public float Volume = 1;
    }

    public class ViewportFrame : GuiObject
    {
        public Color3 Ambient = Color3.FromRGB(200, 200, 200);
        public CFrame CameraCFrame = CFrame.identity;
        public float CameraFieldOfView = 70;
        public Color3 ImageColor3 = new Color3(1, 1, 1);
        public float ImageTransparency = 0;
        public Color3 LightColor = Color3.FromRGB(140, 140, 140);
        public Vector3 LightDirection = Vector3.one * -1;
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
        public float Brightness = 1;
        public bool ClipsDescendants;

        [Obsolete]
        public float DistanceLowerLimit = 0;

        [Obsolete]
        public float DistanceUpperLimit = -1;

        public Vector3 ExtentsOffset = Vector3.zero;
        public Vector3 ExtentsOffsetWorldSpace = Vector3.zero;
        public float LightInfluence = 0;
        public float MaxDistance = float.MaxValue;
        public Instance PlayerToHideFrom;
        public UDim2 Size = new UDim2();
        public Vector2 SizeOffset = Vector2.zero;
        public Vector3 StudsOffset = Vector3.zero;
        public Vector3 StudsOffsetWorldSpace = Vector3.zero;
    }

    public abstract class PluginGui : LayerCollector
    {
        public string Title;
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
        public bool Active = true;
        public Instance Adornee;
        public NormalId Face = NormalId.Front;
    }

    public class AdGui : SurfaceGuiBase
    {
        public AdShape AdShape = AdShape.HorizontalRectangle;
        public bool EnableVideoAds = true;

        public ContentId FallbackImage
        {
            get => FallbackImageContent;
            set => FallbackImageContent = value;
        }

        public Content FallbackImageContent = Content.None;
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
        [Obsolete("Use `Color3` instead.")]
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
        public BasePart From;
        public float StudsBetweenTextures = 4;
        public ContentId Texture = "";
        public Vector2 TextureSize = Vector2.one;
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
        public bool StudioSelectionBox;

        [Obsolete("Use `SurfaceColor3` instead.")]
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
        public CFrame CFrame = CFrame.identity;
        public Vector3 SizeRelativeOffset = Vector3.zero;
        public int ZIndex = -1;
    }

    public class BoxHandleAdornment : HandleAdornment
    {
        public bool DoubleSided;
        public AdornShading Shading = AdornShading.Default;
        public Vector3 Size = Vector3.one;
    }

    public class ConeHandleAdornment : HandleAdornment
    {
        public bool DoubleSided;
        public float Height = 2;
        public bool Hollow;
        public float Radius = 0.5f;
        public AdornShading Shading = AdornShading.Default;
    }

    public class CylinderHandleAdornment : HandleAdornment
    {
        public float Angle = 360;
        public bool DoubleSided;
        public float Height = 1;
        public float InnerRadius = 0;
        public float Radius = 1;
        public AdornShading Shading = AdornShading.Default;
    }

    public class ImageHandleAdornment : HandleAdornment
    {
        public bool DoubleSided;

        public ContentId Image
        {
            get => ImageContent;
            set => ImageContent = value;
        }

        public Content ImageContent = Content.None;
        public Vector2 Size = Vector2.one;

        public ImageHandleAdornment()
        {
            Color3 = Color3.FromRGB(242, 243, 243);
        }
    }

    public class LineHandleAdornment : HandleAdornment
    {
        public float Length = 5;
        public float Thickness = 1;
    }

    public class PyramidHandleAdornment : HandleAdornment
    {
        public bool DoubleSided;
        public float Height = 2;
        public AdornShading Shading = AdornShading.Default;
        public int Sides = 4;
        public float Size = 1;
    }

    public class SphereHandleAdornment : HandleAdornment
    {
        public bool DoubleSided;
        public float Radius = 1;
        public AdornShading Shading = AdornShading.Default;
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
        [Obsolete("Use `SurfaceColor3` instead.")]
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
        public Axes Axes = Axes.X | Axes.Y | Axes.Z;
    }

    public class Handles : HandlesBase
    {
        public Faces Faces = Faces.Right | Faces.Top | Faces.Back | Faces.Left | Faces.Bottom | Faces.Front;
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
        public Vector3 Point = Vector3.zero;
    }

    public class Path2D : GuiBase
    {
        public bool Closed;
        public Color3 Color3 = new Color3();
        public byte[] PropertiesSerialize;
        public float Thickness = 1;
        public float Transparency;
        public bool Visible = true;
        public int ZIndex = 1;
    }

    [RbxService]
    public class GuiService : Instance
    {
        public bool AutoSelectGuiEnabled = true;
        public DisplayScalingMode DisplayScalingMode;
        public bool GuiNavigationEnabled = true;
        public GuiObject SelectedObject;
    }

    [RbxService]
    public class GuidRegistryService : Instance
    {
    }

    public class HapticEffect : Instance
    {
        public bool Looped;
        public Vector3 Position = Vector3.zero;
        public float Radius = 3;
        public HapticEffectType Type = HapticEffectType.UIClick;
        public byte[] WaveformData;
    }

    [RbxService]
    public class HapticService : Instance
    {
    }

    [RbxService]
    public class HarmonyService : Instance
    {
    }

    [RbxService]
    public class HeapProfilerService : Instance
    {
    }

    [RbxService]
    public class HeatmapQueryService : Instance
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

    [RbxService]
    public class HiddenPlayerService : Instance
    {
    }

    public class HiddenSurfaceRemovalAsset : Instance
    {
        public byte[] HSRData;
        public byte[] HSRMeshIdData;
    }

    public class Highlight : Instance
    {
        public Instance Adornee;
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

        [Obsolete("Use `MaxHealth` instead.")]
        public float maxHealth = 100;
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
        public bool StaticFacialAnimation;
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

        public bool UseAvatarSettings;
        public long WalkAnimation = 0;
        public float WidthScale = 1;
    }

    public class HumanoidRigDescription : Instance
    {
        public Instance Chest;
        public Vector3 ChestRangeMax = Vector3.zero;
        public Vector3 ChestRangeMin = Vector3.zero;
        public float ChestSize = 0;
        public CFrame ChestTposeAdjustment = CFrame.identity;
        public Instance HeadBase;
        public Vector3 HeadBaseRangeMax = Vector3.zero;
        public Vector3 HeadBaseRangeMin = Vector3.zero;
        public float HeadBaseSize = 0;
        public CFrame HeadBaseTposeAdjustment = CFrame.identity;
        public Instance LeftAnkle;
        public Vector3 LeftAnkleRangeMax = Vector3.zero;
        public Vector3 LeftAnkleRangeMin = Vector3.zero;
        public float LeftAnkleSize = 0;
        public CFrame LeftAnkleTposeAdjustment = CFrame.identity;
        public Instance LeftClavicle;
        public Vector3 LeftClavicleRangeMax = Vector3.zero;
        public Vector3 LeftClavicleRangeMin = Vector3.zero;
        public float LeftClavicleSize = 0;
        public CFrame LeftClavicleTposeAdjustment = CFrame.identity;
        public Instance LeftElbow;
        public Vector3 LeftElbowRangeMax = Vector3.zero;
        public Vector3 LeftElbowRangeMin = Vector3.zero;
        public float LeftElbowSize = 0;
        public CFrame LeftElbowTposeAdjustment = CFrame.identity;
        public Instance LeftHip;
        public Vector3 LeftHipRangeMax = Vector3.zero;
        public Vector3 LeftHipRangeMin = Vector3.zero;
        public float LeftHipSize = 0;
        public CFrame LeftHipTposeAdjustment = CFrame.identity;
        public Instance LeftKnee;
        public Vector3 LeftKneeRangeMax = Vector3.zero;
        public Vector3 LeftKneeRangeMin = Vector3.zero;
        public float LeftKneeSize = 0;
        public CFrame LeftKneeTposeAdjustment = CFrame.identity;
        public Instance LeftShoulder;
        public Vector3 LeftShoulderRangeMax = Vector3.zero;
        public Vector3 LeftShoulderRangeMin = Vector3.zero;
        public float LeftShoulderSize = 0;
        public CFrame LeftShoulderTposeAdjustment = CFrame.identity;
        public Instance LeftToeBase;
        public Vector3 LeftToeBaseRangeMax = Vector3.zero;
        public Vector3 LeftToeBaseRangeMin = Vector3.zero;
        public float LeftToeBaseSize = 0;
        public CFrame LeftToeBaseTposeAdjustment = CFrame.identity;
        public Instance LeftWrist;
        public Vector3 LeftWristRangeMax = Vector3.zero;
        public Vector3 LeftWristRangeMin = Vector3.zero;
        public float LeftWristSize = 0;
        public CFrame LeftWristTposeAdjustment = CFrame.identity;
        public Instance Neck;
        public Vector3 NeckRangeMax = Vector3.zero;
        public Vector3 NeckRangeMin = Vector3.zero;
        public float NeckSize = 0;
        public CFrame NeckTposeAdjustment = CFrame.identity;
        public CFrame OriginOffset = CFrame.identity;
        public Instance RightAnkle;
        public Vector3 RightAnkleRangeMax = Vector3.zero;
        public Vector3 RightAnkleRangeMin = Vector3.zero;
        public float RightAnkleSize = 0;
        public CFrame RightAnkleTposeAdjustment = CFrame.identity;
        public Instance RightClavicle;
        public Vector3 RightClavicleRangeMax = Vector3.zero;
        public Vector3 RightClavicleRangeMin = Vector3.zero;
        public float RightClavicleSize = 0;
        public CFrame RightClavicleTposeAdjustment = CFrame.identity;
        public Instance RightElbow;
        public Vector3 RightElbowRangeMax = Vector3.zero;
        public Vector3 RightElbowRangeMin = Vector3.zero;
        public float RightElbowSize = 0;
        public CFrame RightElbowTposeAdjustment = CFrame.identity;
        public Instance RightHip;
        public Vector3 RightHipRangeMax = Vector3.zero;
        public Vector3 RightHipRangeMin = Vector3.zero;
        public float RightHipSize = 0;
        public CFrame RightHipTposeAdjustment = CFrame.identity;
        public Instance RightKnee;
        public Vector3 RightKneeRangeMax = Vector3.zero;
        public Vector3 RightKneeRangeMin = Vector3.zero;
        public float RightKneeSize = 0;
        public CFrame RightKneeTposeAdjustment = CFrame.identity;
        public Instance RightShoulder;
        public Vector3 RightShoulderRangeMax = Vector3.zero;
        public Vector3 RightShoulderRangeMin = Vector3.zero;
        public float RightShoulderSize = 0;
        public CFrame RightShoulderTposeAdjustment = CFrame.identity;
        public Instance RightToeBase;
        public Vector3 RightToeBaseRangeMax = Vector3.zero;
        public Vector3 RightToeBaseRangeMin = Vector3.zero;
        public float RightToeBaseSize = 0;
        public CFrame RightToeBaseTposeAdjustment = CFrame.identity;
        public Instance RightWrist;
        public Vector3 RightWristRangeMax = Vector3.zero;
        public Vector3 RightWristRangeMin = Vector3.zero;
        public float RightWristSize = 0;
        public CFrame RightWristTposeAdjustment = CFrame.identity;
        public Instance Root;
        public Vector3 RootRangeMax = Vector3.zero;
        public Vector3 RootRangeMin = Vector3.zero;
        public float RootSize = 0;
        public CFrame RootTposeAdjustment = CFrame.identity;
        public Instance Spine;
        public Vector3 SpineRangeMax = Vector3.zero;
        public Vector3 SpineRangeMin = Vector3.zero;
        public float SpineSize = 0;
        public CFrame SpineTposeAdjustment = CFrame.identity;
        public Instance Waist;
        public Vector3 WaistRangeMax = Vector3.zero;
        public Vector3 WaistRangeMin = Vector3.zero;
        public float WaistSize = 0;
        public CFrame WaistTposeAdjustment = CFrame.identity;
    }

    public class IKControl : Instance
    {
        public Instance ChainRoot;
        public bool Enabled = true;
        public Instance EndEffector;
        public CFrame EndEffectorOffset = CFrame.identity;
        public CFrame Offset = CFrame.identity;
        public Instance Pole;
        public int Priority = 0;
        public float SmoothTime = 0.05f;
        public Instance Target;
        public IKControlType Type = IKControlType.Transform;
        public float Weight = 1;
    }

    [RbxService]
    public class ILegacyStudioBridge : Instance
    {
    }

    [RbxService]
    public class IXPService : Instance
    {
    }

    [RbxService]
    public class ImageScreenCaptureService : Instance
    {
    }

    [RbxService]
    public class IncrementalPatchBuilder : Instance
    {
        public bool AddPathsToBundle;
        public double BuildDebouncePeriod = 0.1;
        public bool HighCompression;
        public bool SerializePatch = true;
        public bool UseFileLevelCompressionInsteadOfChunk;
        public bool ZstdCompression;
    }

    public class InputAction : Instance
    {
        public string DisplayName = "";
        public bool Enabled = true;
        public InputActionType Type = InputActionType.Bool;
    }

    public class InputBinding : Instance
    {
        public KeyCode Backward = KeyCode.None;
        public bool ClampMagnitudeToOne = true;
        public NumberRange Deadzone = new NumberRange(0.1f, 1);
        public Content DisplayImage = Content.None;
        public string DisplayName = "";
        public KeyCode Down = KeyCode.None;
        public KeyCode Forward = KeyCode.None;
        public KeyCode KeyCode = KeyCode.None;
        public KeyCode Left = KeyCode.None;
        public int PointerIndex = 0;
        public float PressedThreshold = 0.5f;
        public KeyCode PrimaryModifier = KeyCode.None;
        public float ReleasedThreshold = 0.2f;
        public float ResponseCurve = 1;
        public KeyCode Right = KeyCode.None;
        public float Scale = 1;
        public KeyCode SecondaryModifier = KeyCode.None;
        public InputBindingType Type = InputBindingType.Automatic;
        public GuiButton UIButton;
        public GuiButton UIModifier;
        public KeyCode Up = KeyCode.None;
        public Vector2 Vector2Scale = Vector2.one;
        public Vector3 Vector3Scale = Vector3.one;
    }

    public class InputContext : Instance
    {
        public bool Enabled = true;
        public int Priority = 1000;
        public bool Sink;
    }

    [RbxService]
    public class InputReplayService : Instance
    {
    }

    [RbxService]
    public class InsertService : Instance
    {
        [Obsolete]
        public bool AllowInsertFreeModels;
    }

    [RbxService]
    public class InstanceExtensionsService : Instance
    {
    }

    [RbxService]
    public class InstanceRegistryService : Instance
    {
    }

    [RbxService]
    public class IntegrityService : Instance
    {
    }

    [RbxService]
    public class IntentService : Instance
    {
    }

    [RbxService]
    public class InternalMessagingService : Instance
    {
    }

    [RbxService]
    public class InternalMessagingServiceVerifier : Instance
    {
    }

    public class InternalSyncItem : Instance
    {
        public bool AutoSync;
        public bool Enabled;
        public string Path;
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
        public BasePart Part0;
        public BasePart Part1;

        [Obsolete("Use `Part1` instead.")]
        public BasePart part1
        {
            get => Part1;
            set => Part1 = value;
        }
    }

    public abstract class DynamicRotate : JointInstance
    {
        public float BaseAngle = 0;
    }

    [Obsolete("Use `HingeConstraint` instead.")]
    public class RotateP : DynamicRotate
    {
    }

    [Obsolete("Use `HingeConstraint` instead.")]
    public class RotateV : DynamicRotate
    {
    }

    [Obsolete("Use `WeldConstraint` instead.")]
    public class Glue : JointInstance
    {
        public Vector3 F0 = Vector3.zero;
        public Vector3 F1 = Vector3.zero;
        public Vector3 F2 = Vector3.zero;
        public Vector3 F3 = Vector3.zero;
    }

    [Obsolete("Use `WeldConstraint` instead.")]
    public abstract class ManualSurfaceJointInstance : JointInstance
    {
    }

    [Obsolete("Use `WeldConstraint` instead.")]
    public class ManualGlue : ManualSurfaceJointInstance
    {
    }

    [Obsolete("Use `WeldConstraint` instead.")]
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

    [Obsolete("Use `HingeConstraint` instead.")]
    public class Rotate : JointInstance
    {
    }

    [Obsolete("Use `WeldConstraint` instead.")]
    public class Snap : JointInstance
    {
    }

    public class VelocityMotor : JointInstance
    {
        public float CurrentAngle = 0;
        public float DesiredAngle = 0;
        public Hole Hole;
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
        public RolloutState ExtendLightRangeTo120;
        public Color3 FogColor = Color3.FromRGB(191, 191, 191);
        public float FogEnd = 100000;
        public float FogStart = 0;
        public float GeographicLatitude = 41.7333f;
        public bool GlobalShadows;
        public LightingStyle LightingStyle = LightingStyle.Soft;
        public Color3 OutdoorAmbient = Color3.FromRGB(127, 127, 127);

        [Obsolete]
        public bool Outlines = true;

        public bool PrioritizeLightingQuality;

        [Obsolete]
        public Color3 ShadowColor = null;

        public float ShadowSoftness = 0.5f;

        [Obsolete("Use `LightingStyle` instead.")]
        public Technology Technology = Technology.Compatibility;

        public string TimeOfDay = "14:00:00";
    }

    [RbxService]
    public class LiveScriptingService : Instance
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

        [Obsolete("Use `SourceLocaleId` instead.")]
        public string DevelopmentLanguage
        {
            get => SourceLocaleId;
            set => SourceLocaleId = value;
        }

        [Obsolete("Use `RootLocalizationTable` instead.")]
        public Instance Root = null;

        public string SourceLocaleId = "en-us";
    }

    [RbxService]
    public class LodDataService : Instance
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
        public string ScriptGuid;
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
    public class LuauExpressionService : Instance
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

    public class MakeupDescription : Instance
    {
        public long AssetId = 0;
        public Instance Instance;
        public MakeupType MakeupType = MakeupType.Face;
        public int Order = 0;
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
    public class MaterialService : Instance
    {
        public string AsphaltName;
        public string BasaltName;
        public string BrickName;
        public string CardboardName;
        public string CarpetName;
        public string CeramicTilesName;
        public string ClayRoofTilesName;
        public string CobblestoneName;
        public string ConcreteName;
        public string CorrodedMetalName;
        public string CrackedLavaName;
        public string DiamondPlateName;
        public string FabricName;
        public string FoilName;
        public string GlacierName;
        public string GraniteName;
        public string GrassName;
        public string GroundName;
        public string IceName;
        public string LeafyGrassName;
        public string LeatherName;
        public string LimestoneName;
        public string MarbleName;
        public string MetalName;
        public string MudName;
        public string PavementName;
        public string PebbleName;
        public string PlasterName;
        public string PlasticName;
        public string RockName;
        public string RoofShinglesName;
        public string RubberName;
        public string SaltName;
        public string SandName;
        public string SandstoneName;
        public string SlateName;
        public string SmoothPlasticName;
        public string SnowName;

        public bool Use2022Materials
        {
            get => Use2022MaterialsXml;
            set => Use2022MaterialsXml = value;
        }

        public bool Use2022MaterialsXml;
        public string WoodName;
        public string WoodPlanksName;
    }

    public class MaterialVariant : Instance
    {
        public AlphaMode AlphaMode = AlphaMode.Opaque;
        public Material BaseMaterial = Material.Plastic;

        public ContentId ColorMap
        {
            get => ColorMapContent;
            set => ColorMapContent = value;
        }

        public Content ColorMapContent = Content.None;
        public PhysicalProperties CustomPhysicalProperties;
        public Content EmissiveMaskContent;
        public float EmissiveStrength = 1;
        public Color3 EmissiveTint = new Color3(1, 1, 1);
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

    [RbxService]
    public class MicroProfilerService : Instance
    {
        public string ContextLabel;
    }

    [RbxService]
    public class ModerationService : Instance
    {
    }

    [RbxService]
    public class MomentsService : Instance
    {
    }

    public abstract class Mouse : Instance
    {
        public ContentId Icon
        {
            get => IconContent;
            set => IconContent = value;
        }

        public Content IconContent = Content.None;
        public Instance TargetFilter;
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

    public abstract class NetworkReplicator : Instance
    {
    }

    public class NoCollisionConstraint : Instance
    {
        public bool Enabled = true;
        public BasePart Part0;
        public BasePart Part1;
    }

    public class Noise : Instance
    {
        public NoiseType NoiseType;
        public int Seed;
    }

    [RbxService]
    public class NotificationService : Instance
    {
    }

    [Obsolete("Use `HttpService` instead.")]
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

        [Obsolete("Use `CollisionGroup` instead.")]
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

        public string MaterialVariant
        {
            get => MaterialVariantSerialized;
            set => MaterialVariantSerialized = value;
        }

        public string MaterialVariantSerialized = "";
        public CFrame PivotOffset = CFrame.identity;

        public Vector3 Position
        {
            get => CFrame.Position;
            set => CFrame = new CFrame(value) * CFrame.Rotation;
        }

        public float Reflectance = 0;

        [Obsolete]
        public float RightParamA = -0.5f;

        [Obsolete]
        public float RightParamB = 0.5f;

        public SurfaceType RightSurface = SurfaceType.Smooth;

        [Obsolete]
        public InputType RightSurfaceInput = InputType.NoInput;

        public int RootPriority = 0;

        [Obsolete("Use `AssemblyAngularVelocity` instead.")]
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

        [Obsolete("Use `AssemblyLinearVelocity` instead.")]
        public Vector3 Velocity = Vector3.zero;

        [Obsolete("Use `BrickColor` instead.")]
        public BrickColor brickColor = null;

        public Vector3 size = new Vector3(4, 1.2f, 2);
    }

    public class CornerWedgePart : BasePart
    {

        public CornerWedgePart()
        {
            size = Vector3.one * 2;
        }
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
        public FormFactor formFactor = FormFactor.Brick;

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
        public BrickColor TeamColor = BrickColorId.Medium_stone_grey;
    }

    public class Seat : Part
    {
        public bool Disabled;
    }

    public class SkateboardPlatform : Part
    {
        public int Steer = 0;
        public bool StickyWheels = true;
        public int Throttle = 0;
    }

    public class SpawnLocation : Part
    {
        public bool AllowTeamChangeOnTouch;
        public int Duration = 10;
        public bool Enabled = true;
        public bool Neutral = true;
        public BrickColor TeamColor = BrickColorId.Medium_stone_grey;
    }

    public class WedgePart : FormFactorPart
    {

        public WedgePart()
        {
            TopSurface = SurfaceType.Smooth;
        }
    }

    public abstract class TriangleMeshPart : BasePart
    {
        public SharedString AeroMeshData;
        public FluidFidelity FluidFidelityInternal;
        public bool InertiaMigrated;
        public SharedString PhysicalConfigData = SharedString.FromBase64("1B2M2Y8AsgTpgAmY7PhCfg==");
        public Vector3 UnscaledCofm;
        public Vector3 UnscaledVolInertiaDiags;
        public Vector3 UnscaledVolInertiaOffDiags;
        public float UnscaledVolume;
    }

    public class MeshPart : TriangleMeshPart
    {
        public bool DoubleSided;

        [Obsolete]
        public bool HasJointOffset;

        public bool HasSkinnedMesh;
        public Vector3 InitialSize;

        [Obsolete]
        public Vector3 JointOffset = Vector3.zero;

        public Content MeshContent = Content.None;
        public byte[] PhysicsData;
        public RenderFidelity RenderFidelity = RenderFidelity.Automatic;
        public Content TextureContent = Content.None;

        public ContentId TextureID
        {
            get => TextureContent;
            set => TextureContent = value;
        }

        public int VertexCount;
    }

    public class PartOperation : TriangleMeshPart
    {
        public ContentId AssetId;
        public byte[] ChildData;
        public SharedString ChildData2;
        public int ComponentIndex;
        public FormFactor FormFactor = FormFactor.Custom;
        public Vector3 InitialSize;
        public byte[] MeshData;
        public SharedString MeshData2;
        public bool OffCentered;
        public byte[] PhysicsData;
        public RenderFidelity RenderFidelity = RenderFidelity.Automatic;
        public float SmoothingAngle = 0;
        public int TriangleCount = 0;
        public bool UsePartColor;
    }

    public class IntersectOperation : PartOperation
    {
    }

    public class NegateOperation : PartOperation
    {
        public NegateOperationHiddenHistory PreviousOperation;

        public NegateOperation()
        {
            Transparency = 0.1f;
        }
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

        public TrussPart()
        {
            BackSurface = SurfaceType.Universal;
            BottomSurface = SurfaceType.Universal;
            FrontSurface = SurfaceType.Universal;
            LeftSurface = SurfaceType.Universal;
            RightSurface = SurfaceType.Universal;
            TopSurface = SurfaceType.Universal;
            size = Vector3.one * 2;
        }
    }

    public class VehicleSeat : BasePart
    {
        public bool Disabled;
        public bool HeadsUpDisplay = true;
        public float MaxSpeed = 25;
        public int Steer = 0;
        public float SteerFloat = 0;
        public int Throttle = 0;
        public float ThrottleFloat = 0;
        public float Torque = 10;
        public float TurnSpeed = 1;

        public VehicleSeat()
        {
            BottomSurface = SurfaceType.Inlet;
            TopSurface = SurfaceType.Studs;
        }
    }

    public class Camera : PVInstance
    {
        public CFrame CFrame = new CFrame(0, 20, 20, 1, 0, 0, 0, 0.70711f, 0.70711f, 0, -0.70711f, 0.70711f);
        public Instance CameraSubject;
        public CameraType CameraType = CameraType.Fixed;

        [Obsolete("Use `CFrame` instead.")]
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
        public OrthographicMode OrthographicMode = OrthographicMode.Vertical;
        public float OrthographicSize = 35;
        public ProjectionType ProjectionType = ProjectionType.Perspective;
        public bool VRTiltAndRollEnabled;
        public float ViewStretch = 1;

        [Obsolete("Use `Focus` instead.")]
        public CFrame focus = null;
    }

    public class ViewportCamera : Camera
    {
    }

    public class Model : PVInstance
    {
        public ModelLevelOfDetail LevelOfDetail = ModelLevelOfDetail.Automatic;
        public CFrame ModelMeshCFrame;
        public SharedString ModelMeshData;
        public Vector3 ModelMeshSize;
        public ModelStreamingMode ModelStreamingMode = ModelStreamingMode.Default;
        public bool NeedsPivotMigration;
        public BasePart PrimaryPart;
        public float ScaleFactor = 1;
        public SharedString SlimHash;
        public CFrame WorldPivotData;
    }

    public class Actor : Model
    {
    }

    public abstract class BackpackItem : Model
    {
        public Content TextureContent = Content.None;

        public ContentId TextureId
        {
            get => TextureContent;
            set => TextureContent = value;
        }
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

    public class ProceduralModel : Model
    {
        public bool Dirty;
        public ModuleScript Generator;
        public Vector3 Size = Vector3.one * 12;
    }

    public abstract class WorldRoot : Model
    {
        public bool AutoSimulate;
        public byte[] CollisionGroupData;
        public Vector3 GravityDirection;
        public float SimulationRate;
        public float Wind;
        public Vector3 WindDirection;
    }

    [RbxService]
    public class Workspace : WorldRoot
    {
        public float AirDensity = 0.0012f;
        public float AirTurbulenceIntensity = 0;
        public bool AllowThirdPartySales;
        public AuthorityMode AuthorityMode;
        public AvatarUnificationMode AvatarUnificationMode;
        public ClientAnimatorThrottlingMode ClientAnimatorThrottling = ClientAnimatorThrottlingMode.Default;
        public Camera CurrentCamera;
        public double DistributedGameTime = 0;
        public RolloutState EnableSLIMAvatars;
        public RolloutState ExpandedTerrain;
        public bool ExplicitAutoJoints = true;
        public bool FallHeightEnabled = true;
        public float FallenPartsDestroyHeight = -500;

        [Obsolete]
        public bool FilteringEnabled = true;

        public FluidForces FluidForces;
        public Vector3 GlobalWind = Vector3.zero;
        public float Gravity = 196.2f;
        public IKControlConstraintSupport IKControlConstraintSupport;
        public RolloutState ImprovedAnimationConstraint;
        public RolloutState ImprovedPhysicsReplication;

        [Obsolete]
        public InterpolationThrottlingMode InterpolationThrottling = InterpolationThrottlingMode.Default;

        public RolloutState LayeredClothingCacheOptimizations;
        public LuauTypeCheckMode LuauTypeCheckMode = LuauTypeCheckMode.Default;
        public RolloutState MapTVRemoteToGamepadKeycodes;
        public MeshPartHeadsAndAccessories MeshPartHeadsAndAccessories;
        public RolloutState MeshStreamingAndImprovedLods;
        public ModelStreamingBehavior ModelStreamingBehavior;
        public RolloutState NextGenerationReplication;
        public PathfindingUseImprovedSearch PathfindingUseImprovedSearch;
        public PhysicsSteppingMethod PhysicsSteppingMethod;
        public PlayerCharacterDestroyBehavior PlayerCharacterDestroyBehavior;
        public RolloutState PlayerScriptsUseInputActionSystem;
        public PredictiveStreamingMode PredictiveStreamingMode;
        public PrimalPhysicsSolver PrimalPhysicsSolver;
        public RejectCharacterDeletions RejectCharacterDeletions;
        public RenderingCacheOptimizationMode RenderingCacheOptimizations;
        public ReplicateInstanceDestroySetting ReplicateInstanceDestroySetting;
        public ReplicationMode ReplicationFrequency = ReplicationMode.Automatic;
        public ReplicationMode ReplicationThroughput = ReplicationMode.Automatic;
        public AnimatorRetargetingMode Retargeting = AnimatorRetargetingMode.Default;
        public SandboxedInstanceMode SandboxedInstanceMode;
        public SignalBehavior SignalBehavior2;
        public StreamOutBehavior StreamOutBehavior;
        public bool StreamingAdaptiveRadius;
        public bool StreamingEnabled;
        public StreamingIntegrityMode StreamingIntegrityMode;
        public int StreamingMinRadius = 64;
        public int StreamingTargetRadius = 1024;
        public bool TerrainWeldsFixed = true;
        public RolloutState TouchEventsUseCollisionGroups;
        public bool TouchesUseCollisionGroups;
        public RolloutState UseFixedSimulation;
        public RolloutState UseInputSink;
        public RolloutState UseNewLuauTypeSolver;
        public RolloutState ValidateEnabledProximityPrompt;
    }

    public class WorldModel : WorldRoot
    {
        public bool UseWorkspaceCollisionGroups;
    }

    public class PackageLink : Instance
    {
        public bool AutoUpdate;
        public string DefaultName;
        public int ModifiedState;
        public Content PackageContent = Content.None;
        public Content PackageContentSerialize = Content.None;
        public byte[] SerializedDefaultAttributes;
        public long VersionIdSerialize;
    }

    [RbxService]
    public class PackageService : Instance
    {
    }

    [RbxService]
    public class Packages : Instance
    {
        public bool IsDehydrated;
        public bool OverridesRecalculated;
        public int ShellPackagesCount;
        public int SkippedInstancesCount;
    }

    public abstract class Pages : Instance
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
        public bool FlipbookBlendFrames = true;
        public NumberRange FlipbookFramerate = new NumberRange(1);
        public string FlipbookIncompatible = "Particle texture must be 1024 by 1024 to use flipbooks.";
        public ParticleFlipbookLayout FlipbookLayout = ParticleFlipbookLayout.None;
        public ParticleFlipbookMode FlipbookMode = ParticleFlipbookMode.Loop;
        public int FlipbookSizeX = 1;
        public int FlipbookSizeY = 1;
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

        public ContentId Texture
        {
            get => TextureContent;
            set => TextureContent = value;
        }

        public Content TextureContent = Content.None;
        public float TimeScale = 1;
        public NumberSequence Transparency = new NumberSequence(0);
        public float VelocityInheritance = 0;

        [Obsolete("Use `SpreadAngle` instead.")]
        public float VelocitySpread
        {
            get => SpreadAngle.X;
            set => SpreadAngle = new Vector2(value, value);
        }

        public bool WindAffectsDrag;
        public float ZOffset = 0;
    }

    public class ParticleEmitter2D : Instance
    {
        public Vector2 Acceleration = Vector2.zero;
        public float Blend = 0;
        public float Brightness = 1;
        public ColorSequence Color = new ColorSequence(1, 1, 1);
        public float Drag = 0;
        public float EmissionAngle = 0;
        public ParticleEmitter2DEmissionMode EmissionMode = ParticleEmitter2DEmissionMode.BoundingBox;
        public Vector2 EmissionOffset = Vector2.zero;
        public Vector2 EmissionSpread = Vector2.zero;
        public bool Enabled = true;
        public bool FlipbookBlendFrames = true;
        public NumberRange FlipbookFramerate = new NumberRange(1);
        public ParticleFlipbookLayout FlipbookLayout = ParticleFlipbookLayout.None;
        public ParticleFlipbookMode FlipbookMode = ParticleFlipbookMode.Loop;
        public int FlipbookSizeX = 1;
        public int FlipbookSizeY = 1;
        public bool FlipbookStartRandom;
        public NumberRange Lifetime = new NumberRange(5, 10);
        public float LightEmission = 0;
        public bool LockedToParent;
        public float Rate = 20;
        public NumberRange RotSpeed = new NumberRange(0);
        public NumberRange Rotation = new NumberRange(0);
        public NumberSequence Size = new NumberSequence(32);
        public NumberRange Speed = new NumberRange(64);
        public float SpreadAngle = 0;
        public NumberSequence Squash = new NumberSequence(0);
        public Content TextureContent = new Content("rbxasset://textures/particles/sparkles_main.dds");
        public float TimeScale = 1;
        public NumberSequence Transparency = new NumberSequence(0);
        public int ZIndex = 1;
    }

    [RbxService]
    public class PartyEmulatorService : Instance
    {
    }

    public class Path3D : Instance
    {
    }

    public class PathfindingLink : Instance
    {
        public Attachment Attachment0;
        public Attachment Attachment1;
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
    public class PermissionsService : Instance
    {
    }

    [RbxService]
    public class PhysicsService : Instance
    {
    }

    [RbxService]
    public class PinShortcutService : Instance
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
    public class PlatformLibraries : Instance
    {
    }

    public class Player : Instance
    {
        public bool AutoJumpEnabled;
        public float CameraMaxZoomDistance;
        public float CameraMinZoomDistance;
        public CameraMode CameraMode;
        public Model Character;

        [Obsolete("Use `CharacterAppearanceId` instead.")]
        public string CharacterAppearance;

        public long CharacterAppearanceId;

        [Obsolete]
        public int DataComplexityLimit;

        public DevCameraOcclusionMode DevCameraOcclusionMode;
        public DevComputerCameraMovementMode DevComputerCameraMode;
        public DevComputerMovementMode DevComputerMovementMode;
        public bool DevEnableMouseLock;
        public DevTouchCameraMovementMode DevTouchCameraMode;
        public DevTouchMovementMode DevTouchMovementMode;
        public float HealthDisplayDistance;
        public int InputLatency;
        public float NameDisplayDistance;
        public bool Neutral;
        public byte[] RawJoinData;
        public Instance ReplicationFocus;
        public SpawnLocation RespawnLocation;
        public Team Team;
        public BrickColor TeamColor;
        public bool TeleportedIn;

        [Obsolete("Use `UserId` instead.")]
        public long userId;
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
        public string EmulatedCountryCode;
        public string EmulatedGameLocale;
        public bool PlayerEmulationEnabled;
        public bool PseudolocalizationEnabled;
        public byte[] SerializedEmulatedPolicyInfo;
        public int TextElongationFactor;
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
        public bool BanningEnabled = true;
        public bool CharacterAutoLoads = true;
        public int MaxPlayersInternal = 16;
        public int PreferredPlayersInternal;
        public float RespawnTime = 5;
        public bool UseStrafingAnimations;
    }

    public class PluginAction : Instance
    {
    }

    public class PluginCapabilities : Instance
    {
        public string Manifest;
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
    public class PointsService : Instance
    {
    }

    [RbxService]
    public class PolicyService : Instance
    {
        public TriStateBoolean IsLuobuServer = TriStateBoolean.Unknown;
        public TriStateBoolean LuobuWhitelisted = TriStateBoolean.Unknown;
    }

    [RbxService]
    public class PopLatencyService : Instance
    {
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
    public class Preloaded : Instance
    {
    }

    [RbxService]
    public class PreloadedRbxmGenerator : Instance
    {
    }

    [RbxService]
    public class ProceduralBehaviorSchedulerService : Instance
    {
    }

    [RbxService]
    public class ProcessInstancePhysicsService : Instance
    {
    }

    [RbxService]
    public class ProjectService : Instance
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
        public float MaxIndicatorDistance = 0;
        public string ObjectText = "";
        public bool RequiresLineOfSight = true;
        public LocalizationTable RootLocalizationTable;
        public ProximityPromptStyle Style = ProximityPromptStyle.Default;
        public Vector2 UIOffset = Vector2.zero;
    }

    [RbxService]
    public class ProximityPromptService : Instance
    {
        public bool Enabled = true;
        public int MaxIndicatorsVisible = 16;
        public int MaxPromptsVisible = 16;
    }

    [RbxService]
    public class PublishService : Instance
    {
    }

    [RbxService]
    public class QueueService : Instance
    {
    }

    [RbxService]
    public class RCCTextureGenerator : Instance
    {
    }

    [RbxService]
    public class RCCTexturePackGenerator : Instance
    {
    }

    public class RTAnimationTracker : Instance
    {
    }

    [RbxService]
    public class RbxAnalyticsService : Instance
    {
    }

    public class RealtimeMedia : Instance
    {
        public bool ForwardInput;
    }

    [RbxService]
    public class RecommendationService : Instance
    {
    }

    [RbxService]
    public class ReflectionService : Instance
    {
    }

    [RbxService]
    public class RemoteCommandService : Instance
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
    public class RequestOrchestratorService : Instance
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
    public class RolloutValidationService : Instance
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
    public class RuntimeContentService : Instance
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
    public class SceneAnalysisService : Instance
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
        public string CoreScriptIdentifier;
        public string ScriptGuid;
    }

    [RbxService]
    public class ScriptDebuggerService : Instance
    {
    }

    [RbxService]
    public class ScriptPinningService : Instance
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
    public class ScriptScannerService : Instance
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
        public Vector3 HitNormal = Vector3.yAxis;
        public float LadderSearchHeight = 6;
        public float LadderSearchOffset = 5;
        public float SearchDistance = 0;
        public Material SensedMaterial = Material.Air;
        public BasePart SensedPart;
        public SensorMode SensorMode = SensorMode.Floor;
    }

    public class FluidForceSensor : SensorBase
    {
    }

    public class PhysicsActivitySensor : SensorBase
    {
        public Vector3 Position;
        public Vector3 Size;
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

    public abstract class ServiceProvider : Instance
    {
    }

    [RbxService]
    public class ServiceVisibilityService : Instance
    {
        public byte[] HiddenServices;
        public byte[] VisibleServices;
    }

    [RbxService]
    public class SessionCheckService : Instance
    {
    }

    [RbxService]
    public class SessionService : Instance
    {
    }

    [RbxService]
    public class SessionTaskService : Instance
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
        public Content MoonTextureContent = Content.None;

        public ContentId MoonTextureId
        {
            get => MoonTextureContent;
            set => MoonTextureContent = value;
        }

        public Content SkyboxBackContent = Content.None;

        public ContentId SkyboxBk
        {
            get => SkyboxBackContent;
            set => SkyboxBackContent = value;
        }

        public ContentId SkyboxDn
        {
            get => SkyboxDownContent;
            set => SkyboxDownContent = value;
        }

        public Content SkyboxDownContent = Content.None;
        public Content SkyboxFrontContent = Content.None;

        public ContentId SkyboxFt
        {
            get => SkyboxFrontContent;
            set => SkyboxFrontContent = value;
        }

        public Content SkyboxLeftContent = Content.None;

        public ContentId SkyboxLf
        {
            get => SkyboxLeftContent;
            set => SkyboxLeftContent = value;
        }

        public Vector3 SkyboxOrientation = Vector3.zero;
        public Content SkyboxRightContent = Content.None;

        public ContentId SkyboxRt
        {
            get => SkyboxRightContent;
            set => SkyboxRightContent = value;
        }

        public ContentId SkyboxUp
        {
            get => SkyboxUpContent;
            set => SkyboxUpContent = value;
        }

        public Content SkyboxUpContent = Content.None;
        public int StarCount = 3000;
        public float SunAngularSize = 21;
        public Content SunTextureContent = Content.None;

        public ContentId SunTextureId
        {
            get => SunTextureContent;
            set => SunTextureContent = value;
        }
    }

    [RbxService]
    public class SlimAnimationReplicationService : Instance
    {
    }

    [RbxService]
    public class SlimDebugSettings : Instance
    {
    }

    [RbxService]
    public class SlimReplicationService : Instance
    {
    }

    [RbxService]
    public class SlimService : Instance
    {
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
    public class SocialService : Instance
    {
    }

    public class Sound : Instance
    {
        public bool AcousticSimulationEnabled = true;
        public Content AudioContent = Content.None;

        [Obsolete("Use `RollOffMinDistance` instead.")]
        public float EmitterSize = 10;

        public NumberRange LoopRegion = new NumberRange(0, 60000);
        public bool Looped;

        [Obsolete("Use `RollOffMaxDistance` instead.")]
        public float MaxDistance
        {
            get => RollOffMaxDistance;
            set => RollOffMaxDistance = value;
        }

        [Obsolete("Use `RollOffMinDistance` instead.")]
        public float MinDistance
        {
            get => RollOffMinDistance;
            set => RollOffMinDistance = value;
        }

        [Obsolete("Use `PlaybackSpeed` instead.")]
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
        public SoundGroup SoundGroup;

        public ContentId SoundId
        {
            get => AudioContent;
            set => AudioContent = value;
        }

        public double TimePosition = 0;
        public float Volume = 0.5f;
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
        public Instance SideChain;
        public float Threshold = -40;
    }

    public class CustomSoundEffect : SoundEffect
    {
    }

    public class ChannelSelectorSoundEffect : CustomSoundEffect
    {
        public int Channel;
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
        public bool AcousticSimulationEnabled;
        public ReverbType AmbientReverb = ReverbType.NoReverb;
        public RolloutState AudioApiByDefault;
        public RolloutState CharacterSoundsUseNewApi = RolloutState.Default;
        public ListenerLocation DefaultListenerLocation;
        public bool DiffractionEnabled = true;
        public float DistanceFactor = 3.33f;
        public float DopplerScale = 1;
        public bool IsNewExpForAudioApiByDefault;
        public CFrame ListenerCFrame = CFrame.identity;
        public Instance ListenerObject;
        public ListenerType ListenerType = ListenerType.Camera;
        public bool OcclusionEnabled = true;
        public bool RespectFilteringEnabled;
        public bool ReverbEnabled = true;
        public float RolloffScale = 1;
        public VolumetricAudio VolumetricAudio;
    }

    [RbxService]
    public class SoundShimService : Instance
    {
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
        public RolloutState AvatarJointUpgrade_SerializedRollout;
        public float CameraMaxZoomDistance = 400;
        public float CameraMinZoomDistance = 0.5f;
        public CameraMode CameraMode = CameraMode.Classic;
        public bool CharacterBreakJointsOnDeath = true;
        public float CharacterJumpHeight = 7.2f;
        public float CharacterJumpPower = 50;
        public float CharacterMaxSlopeAngle = 89;
        public bool CharacterUseJumpPower = true;
        public float CharacterWalkSpeed = 16;
        public bool ClassicDeath = true;
        public bool CreateDefaultPlayerModule = true;
        public DevCameraOcclusionMode DevCameraOcclusionMode = DevCameraOcclusionMode.Zoom;
        public DevComputerCameraMovementMode DevComputerCameraMovementMode = DevComputerCameraMovementMode.UserChoice;
        public DevComputerMovementMode DevComputerMovementMode = DevComputerMovementMode.UserChoice;
        public DevTouchCameraMovementMode DevTouchCameraMovementMode = DevTouchCameraMovementMode.UserChoice;
        public DevTouchMovementMode DevTouchMovementMode = DevTouchMovementMode.UserChoice;
        public LoadDynamicHeads EnableDynamicHeads;
        public bool EnableMouseLockOption = true;
        public GameAvatarType GameSettingsAvatar = GameAvatarType.R15;
        public R15CollisionType GameSettingsR15Collision = R15CollisionType.OuterBox;
        public float HealthDisplayDistance = 100;
        public bool LoadCharacterAppearance = true;
        public LoadCharacterLayeredClothing LoadCharacterLayeredClothing = LoadCharacterLayeredClothing.Default;
        public CharacterControlMode LuaCharacterController = CharacterControlMode.Default;
        public float NameDisplayDistance = 100;
        public Instance PlaceAvatarRules;
        public int PlayerModuleStatus;
        public RolloutState UseImprovedCharacterEvents;
        public bool UserEmotesEnabled = true;
    }

    public abstract class StarterPlayerScripts : Instance
    {
    }

    public class StateMachineDefinition : Instance
    {
        public string NodeId;
    }

    public class StateMachineTransitionDefinition : Instance
    {
        public Instance From;
        public int Priority = 0;
        public Instance To;
        public string TransitionId;
    }

    [RbxService]
    public class Stats : Instance
    {
    }

    public abstract class StatsItem : Instance
    {
    }

    [RbxService]
    public class StudioData : Instance
    {
        public bool EnableScriptCollabByDefaultOnLoad;
    }

    public abstract class StyleBase : Instance
    {
    }

    public class StyleRule : StyleBase
    {
        public int Priority = 0;
        public byte[] PropertiesSerialize;
        public byte[] PropertyTransitionsSerialize;
        public string Selector = "";
    }

    public class StyleSheet : StyleBase
    {
    }

    public class StyleDerive : Instance
    {
        public int Priority = 0;
        public StyleSheet StyleSheet;
    }

    public class StyleLink : Instance
    {
        public StyleSheet StyleSheet;
    }

    public class StyleQuery : Instance
    {
        public byte[] ConditionsSerialize;
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
        public Content EmissiveMaskContent = Content.None;
        public float EmissiveStrength = 1;
        public Color3 EmissiveTint = new Color3(1, 1, 1);

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
        public ResamplerMode ResampleMode = ResamplerMode.Default;

        public ContentId RoughnessMap
        {
            get => RoughnessMapContent;
            set => RoughnessMapContent = value;
        }

        public Content RoughnessMapContent = Content.None;
        public int SurfaceSlot = -1;
        public ContentId TexturePack;
    }

    [RbxService]
    public class SystemThemeService : Instance
    {
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
        public string ReservedServerId = "";
        public string ServerInstanceId = "";
        public bool ShouldReserveServer;
        public string VipServerId = "";
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

    public class TerrainDetail : Instance
    {
        public ContentId ColorMap
        {
            get => ColorMapContent;
            set => ColorMapContent = value;
        }

        public Content ColorMapContent = Content.None;
        public Content EmissiveMaskContent;
        public float EmissiveStrength = 1;
        public Color3 EmissiveTint = new Color3(1, 1, 1);
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
    public class TestCoordinatorService : Instance
    {
    }

    [RbxService]
    public class TestService : Instance
    {
        public bool AutoRuns = true;
        public string Description = "";
        public bool ExecuteWithStudioRun;

        [Obsolete("Use `ThrottlePhysicsToRealtime` instead.")]
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
        public bool AddPlayersOnJoin;
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

    public class ChatInputBarConfiguration : TextChatConfigurations
    {
        public bool AutocompleteEnabled;
        public Color3 BackgroundColor3;
        public double BackgroundTransparency;
        public bool Enabled;
        public FontFace FontFace;
        public KeyCode KeyboardKeyCode;
        public Color3 PlaceholderColor3;
        public TextChannel TargetTextChannel;
        public Color3 TextColor3;
        public long TextSize;
        public Color3 TextStrokeColor3;
        public double TextStrokeTransparency;
    }

    public class ChatWindowConfiguration : TextChatConfigurations
    {
        public Color3 BackgroundColor3;
        public double BackgroundTransparency;
        public bool Enabled;
        public FontFace FontFace;
        public float HeightScale;
        public HorizontalAlignment HorizontalAlignment;
        public TextChannelDisplayMode TextChannelDisplayMode;
        public Color3 TextColor3;
        public long TextSize;
        public Color3 TextStrokeColor3;
        public double TextStrokeTransparency;
        public VerticalAlignment VerticalAlignment;
        public float WidthScale;
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
        public bool IsLegacyChatDisabled;
        public RolloutState PlatformIntegratedChat;
    }

    public class TextDocument : Instance
    {
        public Content TextContent = Content.None;
    }

    public class TextGenerator : Instance
    {
        public int Seed = 0;
        public string SystemPrompt = "";
        public float Temperature = 0.7f;
        public float TopP = 0.9f;
    }

    [RbxService]
    public class TextService : Instance
    {
    }

    [RbxService]
    public class ThirdPartyUserService : Instance
    {
    }

    [RbxService]
    public class ThumbnailGenerator : Instance
    {
        public int GraphicsMode = 0;
    }

    [RbxService]
    public class TimerService : Instance
    {
    }

    [RbxService]
    public class TouchInputService : Instance
    {
    }

    [RbxService]
    public class TraceRouteService : Instance
    {
    }

    public class TrackerStreamAnimation : Instance
    {
    }

    public class Trail : Instance
    {
        public Attachment Attachment0;
        public Attachment Attachment1;
        public float Brightness = 1;
        public ColorSequence Color = new ColorSequence(1, 1, 1);
        public bool Enabled = true;
        public bool FaceCamera;
        public float Lifetime = 2;
        public float LightEmission = 0;
        public float LightInfluence = 0;
        public float MaxLength = 0;
        public float MinLength = 0.1f;

        public ContentId Texture
        {
            get => TextureContent;
            set => TextureContent = value;
        }

        public Content TextureContent = Content.None;
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

    [RbxService]
    public class TweenService : Instance
    {
    }

    [RbxService]
    public class UGCAvatarService : Instance
    {
    }

    [RbxService]
    public class UGCTranscodeService : Instance
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

    public class UIBlur : UIComponent
    {
        public Color3 Color = new Color3(1, 1, 1);
        public bool Enabled = true;
        public UIBlurStrength Strength = UIBlurStrength.Heavy;
        public float Transparency = 0;
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
        public Vector2 MaxSize = Vector2.one * float.MaxValue;
        public Vector2 MinSize = Vector2.zero;
    }

    public class UITextSizeConstraint : UIConstraint
    {
        public int MaxTextSize = 100;
        public int MinTextSize = 1;
    }

    public class UICorner : UIComponent
    {
        public UDim BottomLeftRadius = new UDim(0, 8);
        public UDim BottomRightRadius = new UDim(0, 8);
        public UDim TopLeftRadius = new UDim(0, 8);
        public UDim TopRightRadius = new UDim(0, 8);
    }

    public class UIDragDetector : UIComponent
    {
        public ContentId ActivatedCursorIcon
        {
            get => ActivatedCursorIconContent;
            set => ActivatedCursorIconContent = value;
        }

        public Content ActivatedCursorIconContent = Content.None;
        public UIDragDetectorBoundingBehavior BoundingBehavior = UIDragDetectorBoundingBehavior.Automatic;
        public GuiBase2d BoundingUI;

        public ContentId CursorIcon
        {
            get => CursorIconContent;
            set => CursorIconContent = value;
        }

        public Content CursorIconContent = Content.None;
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
        public GuiObject ReferenceUIInstance;
        public UIDragDetectorResponseStyle ResponseStyle = UIDragDetectorResponseStyle.Offset;
        public bool Selectable = true;
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
        public float Scale = 1;
        public GradientTileMode TileMode = GradientTileMode.Clamp;
        public NumberSequence Transparency = new NumberSequence(0);
        public GradientType Type = GradientType.Linear;
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
        public UIFlexAlignment HorizontalFlex = UIFlexAlignment.None;
        public ItemLineAlignment ItemLineAlignment = ItemLineAlignment.Automatic;
        public UDim Padding = new UDim();
        public UIFlexAlignment VerticalFlex = UIFlexAlignment.None;
        public bool Wraps;

        public UIListLayout()
        {
            FillDirection = FillDirection.Vertical;
        }
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

        public UITableLayout()
        {
            FillDirection = FillDirection.Vertical;
        }
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

    public class UIShadow : UIComponent
    {
        public UDim BlurRadius = new UDim();
        public Color3 Color = new Color3();
        public bool Enabled = true;
        public bool Inset;
        public ApplyShadowMode Mode = ApplyShadowMode.Shape;
        public UDim2 Offset = new UDim2();
        public bool ShowBehindParent = true;
        public UDim2 Spread = new UDim2();
        public float Transparency = 0;
        public int ZIndex = -1;
    }

    public class UIStroke : UIComponent
    {
        public ApplyStrokeMode ApplyStrokeMode = ApplyStrokeMode.Contextual;
        public UDim BorderOffset = new UDim();
        public BorderStrokePosition BorderStrokePosition = BorderStrokePosition.Outer;
        public Color3 Color = new Color3();
        public bool Enabled = true;
        public LineJoinMode LineJoinMode = LineJoinMode.Round;
        public StrokeSizingMode StrokeSizingMode = StrokeSizingMode.FixedSize;
        public float Thickness = 1;
        public float Transparency = 0;
        public int ZIndex = 1;
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

        [Obsolete("Use `TouchControlsEnabled` instead.")]
        public bool ModalEnabled;

        public MouseBehavior MouseBehavior = MouseBehavior.Default;

        public ContentId MouseIcon
        {
            get => MouseIconContent;
            set => MouseIconContent = value;
        }

        public Content MouseIconContent = Content.None;
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
        public Vector3 Value = Vector3.zero;
    }

    public class ValueCurve : Instance
    {
        public byte[] ValuesAndTimes;
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
        public string CameraId;
        public VideoDeviceCaptureQuality CaptureQuality;
    }

    public class VideoPlayer : Instance
    {
        public InternalVideoUsage InternalVideoUsage;
        public bool Looping;
        public VideoSampleSize MaximumResolution;
        public float PlaybackSpeed = 1;
        public double TimePosition = 0;
        public Content VideoContent = Content.None;
        public float Volume = 1;
    }

    [RbxService]
    public class VideoScreenCaptureService : Instance
    {
    }

    [RbxService]
    public class VideoService : Instance
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
        public string Title;
        public string ToolTip;
    }

    public class VisualizationModeCategory : Instance
    {
        public bool Enabled;
        public string Title;
    }

    [RbxService]
    public class VisualizationModeService : Instance
    {
    }

    [RbxService]
    public class VoiceChatService : Instance
    {
        public VoiceChatDistanceAttenuationType DefaultDistanceAttenuation;
        public bool EnableDefaultVoice;
        public RolloutState EnableVoiceVolumeControls;
        public AudioApiRollout UseAudioApi;
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

    [RbxService]
    public class WindowProtocolService : Instance
    {
    }

    public class Wire : Instance
    {
        public Instance SourceInstance;
        public string SourceName = "Output";
        public Instance TargetInstance;
        public string TargetName = "Input";
    }

    [RbxService]
    public class WrapDeformMeshProvider : Instance
    {
    }

    public class WrapTextureTransfer : Instance
    {
        public Content ReferenceCageMeshContent = Content.None;
        public Vector2 UVMaxBound = Vector2.one * float.MinValue;
        public Vector2 UVMinBound = Vector2.one * float.MaxValue;
    }

    public class Logger : RbxObject
    {
    }

    public class LuauExpression : RbxObject
    {
    }

    public class MLSession : RbxObject
    {
    }

    public class ParticipantHandle : RbxObject
    {
    }

    public class TerrainIterateOperation : RbxObject
    {
    }

    public class TerrainModifyOperation : RbxObject
    {
    }

    public class TerrainReadOperation : RbxObject
    {
    }

    public class TerrainWriteOperation : RbxObject
    {
    }

    public class TestCase : RbxObject
    {
    }

    public class TestExecutionContext : RbxObject
    {
    }

    public class TestFailure : RbxObject
    {
    }

    public class TestResult : RbxObject
    {
    }

    public class TestRunResult : RbxObject
    {
    }

    public class TestSuite : RbxObject
    {
    }

    public class VideoSampler : RbxObject
    {
        public Content VideoContent = Content.None;
    }

    public class VoxelBuffer : RbxObject
    {
    }

    public class WebStreamClient : RbxObject
    {
    }
}
