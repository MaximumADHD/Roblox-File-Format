// Auto-generated list of Roblox enums.
// Updated as of 0.676.0.6760531
using System;

namespace RobloxFiles.Enums
{
    public enum AccessModifierType
    {
        Allow,
        Deny,
    }

    public enum AccessoryType
    {
        Unknown,
        Hat,
        Hair,
        Face,
        Neck,
        Shoulder,
        Front,
        Back,
        Waist,
        TShirt,
        Shirt,
        Pants,
        Jacket,
        Sweater,
        Shorts,
        LeftShoe,
        RightShoe,
        DressSkirt,
        Eyebrow,
        Eyelash,

        [Obsolete]
        TeeShirt = TShirt,
    }

    public enum ActionOnAutoResumeSync
    {
        DontResume,
        KeepStudio,
        KeepLocal,
    }

    public enum ActionOnStopSync
    {
        AlwaysAsk,
        KeepLocalFiles,
        DeleteLocalFiles,
    }

    public enum ActionType
    {
        Nothing,
        Pause,
        Lose,
        Draw,
        Win,
    }

    public enum ActuatorRelativeTo
    {
        Attachment0,
        Attachment1,
        World,
    }

    public enum ActuatorType
    {
        None,
        Motor,
        Servo,
    }

    public enum AdAvailabilityResult
    {
        IsAvailable = 1,
        DeviceIneligible,
        ExperienceIneligible,
        InternalError,
        NoFill,
        PlayerIneligible,
        PublisherIneligible,
    }

    public enum AdEventType
    {
        [Obsolete]
        VideoLoaded,

        [Obsolete]
        VideoRemoved,

        [Obsolete]
        UserCompletedVideo,

        RewardedAdLoaded,
        RewardedAdGrant,
        RewardedAdUnloaded,
    }

    public enum AdFormat
    {
        RewardedVideo,
    }

    public enum AdShape
    {
        HorizontalRectangle = 1,
    }

    public enum AdTeleportMethod
    {
        Undefined,
        PortalForward,
        InGameMenuBackButton,
        UIBackButton,
    }

    public enum AdUIEventType
    {
        AdLabelClicked,
        VolumeButtonClicked,
        FullscreenButtonClicked,
        PlayButtonClicked,
        PauseButtonClicked,
        CloseButtonClicked,
        WhyThisAdClicked,
        PlayEventTriggered,
        PauseEventTriggered,
    }

    public enum AdUIType
    {
        None,
        Image,
        Video,
    }

    public enum AdUnitStatus
    {
        Inactive,
        Active,
    }

    public enum AdornCullingMode
    {
        Automatic,
        Never,
    }

    public enum AlignType
    {
        [Obsolete]
        Parallel,

        [Obsolete]
        Perpendicular,

        PrimaryAxisParallel,
        PrimaryAxisPerpendicular,
        PrimaryAxisLookAt,
        AllAxes,
    }

    public enum AlphaMode
    {
        Overlay,
        Transparency,
        TintMask,
    }

    public enum AnalyticsCustomFieldKeys
    {
        CustomField01,
        CustomField02,
        CustomField03,
    }

    public enum AnalyticsEconomyAction
    {
        Default,
        Acquire,
        Spend,
    }

    public enum AnalyticsEconomyFlowType
    {
        Sink,
        Source,
    }

    public enum AnalyticsEconomyTransactionType
    {
        IAP,
        Shop,
        Gameplay,
        ContextualPurchase,
        TimedReward,
        Onboarding,
    }

    public enum AnalyticsLogLevel
    {
        Trace,
        Debug,
        Information,
        Warning,
        Error,
        Fatal,
    }

    public enum AnalyticsProgressionStatus
    {
        Default,
        Begin,
        Complete,
        Abandon,
        Fail,
    }

    public enum AnalyticsProgressionType
    {
        Custom,
        Start,
        Fail,
        Complete,
    }

    public enum AnimationClipFromVideoStatus
    {
        Initializing,
        Pending,
        Processing,
        ErrorGeneric = 4,
        Success = 6,
        ErrorVideoTooLong,
        ErrorNoPersonDetected,
        ErrorVideoUnstable,
        Timeout,
        Cancelled,
        ErrorMultiplePeople,
        ErrorUploadingVideo = 2001,
    }

    public enum AnimationPriority
    {
        Idle,
        Movement,
        Action,
        Action2,
        Action3,
        Action4,
        Core = 1000,
    }

    public enum AnimatorRetargetingMode
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum AnnotationEditingMode
    {
        None,
        PlacingNew,
        WritingNew,
    }

    public enum AnnotationRequestStatus
    {
        Success,
        Loading,
        ErrorInternalFailure,
        ErrorNotFound,
        ErrorModerated,
    }

    public enum AnnotationRequestType
    {
        Unknown,
        Create,
        Resolve,
        Delete,
        Edit,
    }

    public enum AppLifecycleManagerState
    {
        Detached,
        Active,
        Inactive,
        Hidden,
    }

    public enum AppShellActionType
    {
        None,
        OpenApp,
        TapChatTab,
        TapConversationEntry,
        TapAvatarTab,
        ReadConversation,
        TapGamePageTab,
        TapHomePageTab,
        GamePageLoaded,
        HomePageLoaded,
        AvatarEditorPageLoaded,
    }

    public enum AppShellFeature
    {
        None,
        Chat,
        AvatarEditor,
        GamePage,
        HomePage,
        More,
        Landing,
    }

    public enum AppUpdateStatus
    {
        Unknown,
        NotSupported,
        Failed,
        NotAvailable,
        Available,
        AvailableBoundChannel,
    }

    public enum ApplyStrokeMode
    {
        Contextual,
        Border,
    }

    public enum AspectType
    {
        FitWithinMaxSize,
        ScaleWithParentSize,
    }

    public enum AssetCreatorType
    {
        User,
        Group,
    }

    public enum AssetFetchStatus
    {
        Success,
        Failure,
        None,
        Loading,
        TimedOut,
    }

    public enum AssetType
    {
        Image = 1,
        TShirt,
        Audio,
        Mesh,
        Lua,
        Hat = 8,
        Place,
        Model,
        Shirt,
        Pants,
        Decal,
        Head = 17,
        Face,
        Gear,
        Badge = 21,
        Animation = 24,
        Torso = 27,
        RightArm,
        LeftArm,
        LeftLeg,
        RightLeg,
        Package,
        GamePass = 34,
        Plugin = 38,
        MeshPart = 40,
        HairAccessory,
        FaceAccessory,
        NeckAccessory,
        ShoulderAccessory,
        FrontAccessory,
        BackAccessory,
        WaistAccessory,
        ClimbAnimation,
        DeathAnimation,
        FallAnimation,
        IdleAnimation,
        JumpAnimation,
        RunAnimation,
        SwimAnimation,
        WalkAnimation,
        PoseAnimation,
        EarAccessory,
        EyeAccessory,
        EmoteAnimation = 61,
        Video,
        TShirtAccessory = 64,
        ShirtAccessory,
        PantsAccessory,
        JacketAccessory,
        SweaterAccessory,
        ShortsAccessory,
        LeftShoeAccessory,
        RightShoeAccessory,
        DressSkirtAccessory,
        FontFamily,
        EyebrowAccessory = 76,
        EyelashAccessory,
        MoodAnimation,
        DynamicHead,

        [Obsolete]
        TeeShirt = TShirt,

        [Obsolete]
        TeeShirtAccessory = TShirtAccessory,
    }

    public enum AssetTypeVerification
    {
        Default = 1,
        ClientOnly,
        Always,
    }

    public enum AudioApiRollout
    {
        Disabled,
        Automatic,
        Enabled,
    }

    [Obsolete]
    public enum AudioCaptureMode
    {
    }

    public enum AudioChannelLayout
    {
        Mono,
        Stereo,
        Quad,
        Surround_5,
        Surround_5_1,
        Surround_7_1,
        Surround_7_1_4,
    }

    public enum AudioFilterType
    {
        Peak,
        LowShelf,
        HighShelf,
        Lowpass12dB,
        Lowpass24dB,
        Lowpass48dB,
        Highpass12dB,
        Highpass24dB,
        Highpass48dB,
        Bandpass,
        Notch,
        Lowpass6dB,
    }

    public enum AudioSimulationFidelity
    {
        None,
        Automatic,
    }

    public enum AudioSubType
    {
        Music = 1,
        SoundEffect,
    }

    public enum AudioWindowSize
    {
        Small,
        Medium,
        Large,
    }

    public enum AutoIndentRule
    {
        Off,
        Absolute,
        Relative,
    }

    public enum AutomaticSize
    {
        None,
        X,
        Y,
        XY,
    }

    public enum AvatarAssetType
    {
        TShirt = 2,
        Hat = 8,
        Shirt = 11,
        Pants,
        Head = 17,
        Face,
        Gear,
        Torso = 27,
        RightArm,
        LeftArm,
        LeftLeg,
        RightLeg,
        HairAccessory = 41,
        FaceAccessory,
        NeckAccessory,
        ShoulderAccessory,
        FrontAccessory,
        BackAccessory,
        WaistAccessory,
        ClimbAnimation,
        FallAnimation = 50,
        IdleAnimation,
        JumpAnimation,
        RunAnimation,
        SwimAnimation,
        WalkAnimation,
        EmoteAnimation = 61,
        TShirtAccessory = 64,
        ShirtAccessory,
        PantsAccessory,
        JacketAccessory,
        SweaterAccessory,
        ShortsAccessory,
        LeftShoeAccessory,
        RightShoeAccessory,
        DressSkirtAccessory,
        EyebrowAccessory = 76,
        EyelashAccessory,
        MoodAnimation,
        DynamicHead,

        [Obsolete]
        TeeShirtAccessory = TShirtAccessory,
    }

    public enum AvatarChatServiceFeature
    {
        None,
        UniverseAudio,
        UniverseVideo,
        PlaceAudio = 4,
        PlaceVideo = 8,
        UserAudioEligible = 16,
        UserAudio = 32,
        UserVideoEligible = 64,
        UserVideo = 128,
        UserBanned = 256,
        UserVerifiedForVoice = 512,
    }

    public enum AvatarContextMenuOption
    {
        Friend,
        Chat,
        Emote,
        InspectMenu,
    }

    public enum AvatarGenerationError
    {
        None,
        Unknown,
        DownloadFailed,
        Canceled,
        Offensive,
        Timeout,
        JobNotFound,
    }

    public enum AvatarItemType
    {
        Asset = 1,
        Bundle,
    }

    public enum AvatarPromptResult
    {
        Success = 1,
        PermissionDenied,
        Failed,
    }

    public enum AvatarSettingsAccessoryLimitMethod
    {
        Scale,
        Remove,
    }

    public enum AvatarSettingsAccessoryMode
    {
        PlayerChoice,
        CustomLimit,
    }

    public enum AvatarSettingsAnimationClipsMode
    {
        PlayerChoice,
        CustomClips,
    }

    public enum AvatarSettingsAnimationPacksMode
    {
        PlayerChoice,
        StandardR15,
        StandardR6,
    }

    public enum AvatarSettingsAppearanceMode
    {
        PlayerChoice,
        CustomParts,
        CustomBody,
    }

    public enum AvatarSettingsBuildMode
    {
        PlayerChoice,
        CustomBuild,
    }

    public enum AvatarSettingsClothingMode
    {
        PlayerChoice,
        CustomLimit,
    }

    public enum AvatarSettingsCollisionMode
    {
        Default,
        SingleCollider,
        Legacy,
    }

    public enum AvatarSettingsCustomAccessoryMode
    {
        PlayerChoice,
        CustomAccessories,
    }

    public enum AvatarSettingsCustomBodyType
    {
        AvatarReference,
        BundleId,
    }

    public enum AvatarSettingsCustomClothingMode
    {
        PlayerChoice,
        CustomClothing,
    }

    public enum AvatarSettingsHitAndTouchDetectionMode
    {
        UseParts,
        UseCollider,
    }

    public enum AvatarSettingsJumpMode
    {
        JumpHeight,
        JumpPower,
    }

    public enum AvatarSettingsLegacyCollisionMode
    {
        R6Colliders,
        InnerBoxColliders,
    }

    public enum AvatarSettingsScaleMode
    {
        PlayerChoice,
        CustomScale,
    }

    public enum AvatarThumbnailCustomizationType
    {
        Closeup = 1,
        FullBody,
    }

    public enum AvatarUnificationMode
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum Axis
    {
        X,
        Y,
        Z,

        [Obsolete]
        Back = Z,

        [Obsolete]
        Bottom = Y,

        [Obsolete]
        Front = Z,

        [Obsolete]
        Left = X,

        [Obsolete]
        Right = X,

        [Obsolete]
        Top = Y,
    }

    public enum BenefitType
    {
        DeveloperProduct,
        AvatarAsset,
        AvatarBundle,
    }

    public enum BinType
    {
        Script,
        GameTool,
        Grab,
        Clone,
        Hammer,

        [Obsolete]
        [LostEnumValue(MapTo = 7)]
        _Laser = Script,

        [Obsolete]
        [LostEnumValue(MapTo = 6)]
        _Rocket = Script,

        [Obsolete]
        [LostEnumValue(MapTo = 5)]
        _Slingshot = Script,
    }

    public enum BodyPart
    {
        Head,
        Torso,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg,
    }

    public enum BodyPartR15
    {
        Head,
        UpperTorso,
        LowerTorso,
        LeftFoot,
        LeftLowerLeg,
        LeftUpperLeg,
        RightFoot,
        RightLowerLeg,
        RightUpperLeg,
        LeftHand,
        LeftLowerArm,
        LeftUpperArm,
        RightHand,
        RightLowerArm,
        RightUpperArm,
        RootPart,
        Unknown = 17,
    }

    public enum BorderMode
    {
        Outline,
        Middle,
        Inset,
    }

    public enum BreakReason
    {
        Other,
        Error,
        SpecialBreakpoint,
        UserBreakpoint,
    }

    public enum BreakpointRemoveReason
    {
        Requested,
        ScriptChanged,
        ScriptRemoved,
    }

    public enum BulkMoveMode
    {
        FireAllEvents,
        FireCFrameChanged,
    }

    public enum BundleType
    {
        BodyParts = 1,
        Animations,
        Shoes,
        DynamicHead,
        DynamicHeadAvatar,
    }

    public enum Button
    {
        Dismount = 8,
        Jump = 32,
    }

    public enum ButtonStyle
    {
        Custom,
        RobloxButtonDefault,
        RobloxButton,
        RobloxRoundButton,
        RobloxRoundDefaultButton,
        RobloxRoundDropdownButton,
    }

    public enum CageType
    {
        Inner,
        Outer,
    }

    public enum CameraMode
    {
        Classic,
        LockFirstPerson,
    }

    public enum CameraPanMode
    {
        Classic,
        EdgeBump,
    }

    public enum CameraSpeedAdjustBinding
    {
        None,
        RmbScroll,
        AltScroll,
    }

    public enum CameraType
    {
        Fixed,
        Attach,
        Watch,
        Track,
        Follow,
        Custom,
        Scriptable,
        Orbital,
    }

    public enum CaptureType
    {
        Screenshot,
        Video,
    }

    public enum CatalogCategoryFilter
    {
        None = 1,
        Featured,
        Collectibles,
        CommunityCreations,
        Premium,
        Recommended,
    }

    public enum CatalogSortAggregation
    {
        Past12Hours = 1,
        PastDay,
        Past3Days,
        PastWeek,
        PastMonth,
        AllTime,
    }

    public enum CatalogSortType
    {
        Relevance = 1,
        PriceHighToLow,
        PriceLowToHigh,
        MostFavorited = 5,
        RecentlyCreated,
        Bestselling,

        [Obsolete]
        RecentlyUpdated = RecentlyCreated,
    }

    public enum CellBlock
    {
        Solid,
        VerticalWedge,
        CornerWedge,
        InverseCornerWedge,
        HorizontalWedge,
    }

    public enum CellMaterial
    {
        Empty,
        Grass,
        Sand,
        Brick,
        Granite,
        Asphalt,
        Iron,
        Aluminum,
        Gold,
        WoodPlank,
        WoodLog,
        Gravel,
        CinderBlock,
        MossyStone,
        Cement,
        RedPlastic,
        BluePlastic,
        Water,
    }

    public enum CellOrientation
    {
        NegZ,
        X,
        Z,
        NegX,
    }

    public enum CenterDialogType
    {
        UnsolicitedDialog = 1,
        PlayerInitiatedDialog,
        ModalDialog,
        QuitDialog,
    }

    public enum CharacterControlMode
    {
        Default,
        Legacy,
        NoCharacterController,
        LuaCharacterController,
    }

    public enum ChatCallbackType
    {
        OnCreatingChatWindow = 1,
        OnClientSendingMessage,
        OnClientFormattingMessage,
        OnServerReceivingMessage = 17,
    }

    public enum ChatColor
    {
        Blue,
        Green,
        Red,
        White,
    }

    public enum ChatMode
    {
        Menu,
        TextAndMenu,
    }

    public enum ChatPrivacyMode
    {
        AllUsers,
        NoOne,
        Friends,
    }

    public enum ChatRestrictionStatus
    {
        Unknown,
        NotRestricted,
        Restricted,
    }

    public enum ChatStyle
    {
        Classic,
        Bubble,
        ClassicAndBubble,
    }

    public enum ChatVersion
    {
        LegacyChatService,
        TextChatService,
    }

    public enum ClientAnimatorThrottlingMode
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum CloseReason
    {
        Unknown,
        RobloxMaintenance,
        DeveloperShutdown,
        DeveloperUpdate,
        ServerEmpty,
        OutOfMemory,
    }

    public enum CollaboratorStatus
    {
        None,
        Editing3D,
        Scripting,
        PrivateScripting,
    }

    public enum CollisionFidelity
    {
        Default,
        Hull,
        Box,
        PreciseConvexDecomposition,
    }

    public enum CommandPermission
    {
        Plugin,
        LocalUser,
    }

    public enum CompileTarget
    {
        Client,
        CoreScript,
        Studio,
        CoreScriptRaw,
    }

    public enum CompletionAcceptanceBehavior
    {
        Insert,
        Replace,
        ReplaceOnEnterInsertOnTab,
        InsertOnEnterReplaceOnTab,
    }

    public enum CompletionItemKind
    {
        Text = 1,
        Method,
        Function,
        Constructor,
        Field,
        Variable,
        Class,
        Interface,
        Module,
        Property,
        Unit,
        Value,
        Enum,
        Keyword,
        Snippet,
        Color,
        File,
        Reference,
        Folder,
        EnumMember,
        Constant,
        Struct,
        Event,
        Operator,
        TypeParameter,
    }

    public enum CompletionItemTag
    {
        Deprecated = 1,
        IncorrectIndexType,
        PluginPermissions,
        CommandLinePermissions,
        RobloxPermissions,
        AddParens,
        PutCursorInParens,
        TypeCorrect,
        ClientServerBoundaryViolation,
        Invalidated,
        PutCursorBeforeEnd,
    }

    public enum CompletionTriggerKind
    {
        Invoked = 1,
        TriggerCharacter,
        TriggerForIncompleteCompletions,
    }

    public enum ComputerCameraMovementMode
    {
        Default,
        Classic,
        Follow,
        Orbital,
        CameraToggle,
    }

    public enum ComputerMovementMode
    {
        Default,
        KeyboardMouse,
        ClickToMove,
    }

    public enum ConfigSnapshotErrorState
    {
        None,
        LoadFailed,
    }

    public enum ConnectionError
    {
        OK,
        Unknown,
        DisconnectErrors = 256,
        DisconnectBadhash,
        DisconnectSecurityKeyMismatch,
        DisconnectProtocolMismatch,
        DisconnectReceivePacketError,
        DisconnectReceivePacketStreamError,
        DisconnectSendPacketError,
        DisconnectIllegalTeleport,
        DisconnectDuplicatePlayer,
        DisconnectDuplicateTicket,
        DisconnectTimeout,
        DisconnectLuaKick,
        DisconnectOnRemoteSysStats,
        DisconnectHashTimeout,
        DisconnectCloudEditKick,
        DisconnectPlayerless,
        DisconnectNewSecurityKeyMismatch,
        DisconnectEvicted,
        DisconnectDevMaintenance,
        DisconnectRobloxMaintenance,
        DisconnectRejoin,
        DisconnectConnectionLost,
        DisconnectIdle,
        DisconnectRaknetErrors,
        DisconnectWrongVersion,
        DisconnectBySecurityPolicy,
        DisconnectBlockedIP,
        DisconnectClientFailure = 284,
        DisconnectClientRequest,
        DisconnectPrivateServerKickout,
        DisconnectModeratedGame,
        ServerShutdown,
        ReplicatorTimeout = 290,
        PlayerRemoved,
        DisconnectOutOfMemoryKeepPlayingLeave,
        DisconnectRomarkEndOfTest,
        DisconnectCollaboratorPermissionRevoked,
        DisconnectCollaboratorUnderage,
        NetworkInternal,
        NetworkSend,
        NetworkTimeout,
        NetworkMisbehavior,
        NetworkSecurity,
        ReplacementReady,
        ServerEmpty,
        PhantomFreeze,
        AndroidAnticheatKick,
        AndroidEmulatorKick,
        PlacelaunchErrors = 512,
        PlacelaunchDisabled = 515,
        PlacelaunchError,
        PlacelaunchGameEnded,
        PlacelaunchGameFull,
        PlacelaunchUserLeft = 522,
        PlacelaunchRestricted,
        PlacelaunchUnauthorized,
        PlacelaunchFlooded,
        PlacelaunchHashExpired,
        PlacelaunchHashException,
        PlacelaunchPartyCannotFit,
        PlacelaunchHttpError,
        PlacelaunchUserPrivacyUnauthorized = 533,
        PlacelaunchCreatorBan = 600,
        PlacelaunchCustomMessage = 610,
        PlacelaunchOtherError,
        TeleportErrors = 768,
        TeleportFailure,
        TeleportGameNotFound,
        TeleportGameEnded,
        TeleportGameFull,
        TeleportUnauthorized,
        TeleportFlooded,
        TeleportIsTeleporting,
    }

    public enum ConnectionState
    {
        Connected,
        Disconnected,
    }

    public enum ContentSourceType
    {
        None,
        Uri,
        Object,
    }

    public enum ContextActionPriority
    {
        Low = 1000,
        Medium = 2000,
        High = 3000,

        [Obsolete]
        Default = Medium,
    }

    public enum ContextActionResult
    {
        Sink,
        Pass,
    }

    public enum ControlMode
    {
        Classic,
        MouseLockSwitch,

        [Obsolete]
        Mouse_Lock_Switch = MouseLockSwitch,
    }

    public enum CoreGuiType
    {
        PlayerList,
        Health,
        Backpack,
        Chat,
        All,
        EmotesMenu,
        SelfView,
        Captures,
    }

    public enum CreateAssetResult
    {
        Success = 1,
        PermissionDenied,
        UploadFailed,
        Unknown,
    }

    public enum CreateOutfitFailure
    {
        InvalidName = 1,
        OutfitLimitReached,
        Other,
    }

    public enum CreatorType
    {
        User,
        Group,
    }

    public enum CreatorTypeFilter
    {
        User,
        Group,
        All,
    }

    public enum CurrencyType
    {
        Default,
        Robux,
        Tix,
    }

    public enum CustomCameraMode
    {
        Default,
        Classic,
        Follow,
    }

    public enum DataStoreRequestType
    {
        GetAsync,
        SetIncrementAsync,
        UpdateAsync,
        GetSortedAsync,
        SetIncrementSortedAsync,
        OnUpdate,
        ListAsync,
        GetVersionAsync,
        RemoveVersionAsync,
    }

    public enum DebuggerEndReason
    {
        ClientRequest,
        Timeout,
        InvalidHost,
        Disconnected,
        ServerShutdown,
        ServerProtocolMismatch,
        ConfigurationFailed,
        RpcError,
    }

    public enum DebuggerExceptionBreakMode
    {
        Never,
        Always,
        Unhandled,
    }

    public enum DebuggerFrameType
    {
        C,
        Lua,
    }

    public enum DebuggerPauseReason
    {
        Unknown,
        Requested,
        Breakpoint,
        Exception,
        SingleStep,
        Entrypoint,
    }

    public enum DebuggerStatus
    {
        Success,
        Timeout,
        ConnectionLost,
        InvalidResponse,
        InternalError,
        InvalidState,
        RpcError,
        InvalidArgument,
        ConnectionClosed,
    }

    public enum DevCameraOcclusionMode
    {
        Zoom,
        Invisicam,
    }

    public enum DevComputerCameraMovementMode
    {
        UserChoice,
        Classic,
        Follow,
        Orbital,
        CameraToggle,
    }

    public enum DevComputerMovementMode
    {
        UserChoice,
        KeyboardMouse,
        ClickToMove,
        Scriptable,
    }

    public enum DevTouchCameraMovementMode
    {
        UserChoice,
        Classic,
        Follow,
        Orbital,
    }

    public enum DevTouchMovementMode
    {
        UserChoice,
        Thumbstick,
        DPad,
        Thumbpad,
        ClickToMove,
        Scriptable,
        DynamicThumbstick,
    }

    public enum DeveloperMemoryTag
    {
        Internal,
        HttpCache,
        Instances,
        Signals,
        LuaHeap,
        Script,
        PhysicsCollision,
        PhysicsParts,
        GraphicsSolidModels,
        GraphicsMeshParts = 10,
        GraphicsParticles,
        GraphicsParts,
        GraphicsSpatialHash,
        GraphicsTerrain,
        GraphicsTexture,
        GraphicsTextureCharacter,
        Sounds,
        StreamingSounds,
        TerrainVoxels,
        Gui = 21,
        Animation,
        Navigation,
        GeometryCSG,
        GraphicsSlimModels,
    }

    public enum DeviceFeatureType
    {
        DeviceCapture,
    }

    public enum DeviceForm
    {
        Console,
        Phone,
        Tablet,
        Desktop,
        VR,
    }

    public enum DeviceLevel
    {
        Low,
        Medium,
        High,
    }

    public enum DeviceType
    {
        Unknown,
        Desktop,
        Tablet,
        Phone,
    }

    public enum DialogBehaviorType
    {
        SinglePlayer,
        MultiplePlayers,
    }

    public enum DialogPurpose
    {
        Quest,
        Help,
        Shop,
    }

    public enum DialogTone
    {
        Neutral,
        Friendly,
        Enemy,
    }

    public enum DominantAxis
    {
        Width,
        Height,
    }

    public enum DraftStatusCode
    {
        OK,
        DraftOutdated,
        ScriptRemoved,
        DraftCommitted,
    }

    public enum DragDetectorDragStyle
    {
        TranslateLine,
        TranslatePlane,
        TranslatePlaneOrLine,
        TranslateLineOrPlane,
        TranslateViewPlane,
        RotateAxis,
        RotateTrackball,
        Scriptable,
        BestForDevice,
    }

    public enum DragDetectorPermissionPolicy
    {
        Nobody,
        Everybody,
        Scriptable,
    }

    public enum DragDetectorResponseStyle
    {
        Geometric,
        Physical,
        Custom,
    }

    public enum DraggerCoordinateSpace
    {
        Object,
        World,
    }

    public enum DraggerMovementMode
    {
        Geometric,
        Physical,
    }

    public enum DraggingScrollBar
    {
        None,
        Horizontal,
        Vertical,
    }

    public enum EasingDirection
    {
        In,
        Out,
        InOut,
    }

    public enum EasingStyle
    {
        Linear,
        Sine,
        Back,
        Quad,
        Quart,
        Quint,
        Bounce,
        Elastic,
        Exponential,
        Circular,
        Cubic,
    }

    public enum EditableStatus
    {
        Unknown,
        Allowed,
        Disallowed,
    }

    public enum ElasticBehavior
    {
        WhenScrollable,
        Always,
        Never,
    }

    public enum EnviromentalPhysicsThrottle
    {
        DefaultAuto,
        Disabled,
        Always,
        Skip2,
        Skip4,
        Skip8,
        Skip16,
    }

    public enum ExperienceAuthScope
    {
        DefaultScope,
        CreatorAssetsCreate,
    }

    public enum ExplosionType
    {
        NoCraters,
        Craters,

        [Obsolete]
        CratersAndDebris = Craters,
    }

    public enum FACSDataLod
    {
        LOD0,
        LOD1,
        LODCount,
    }

    public enum FacialAgeEstimationResultType
    {
        Complete,
        Cancel,
        Error,
    }

    public enum FacialAnimationStreamingState
    {
        None,
        Audio,
        Video,
        Place = 4,
        Server = 8,
    }

    public enum FacsActionUnit
    {
        ChinRaiserUpperLip,
        ChinRaiser,
        FlatPucker,
        Funneler,
        LowerLipSuck,
        LipPresser,
        LipsTogether,
        MouthLeft,
        MouthRight,
        Pucker,
        UpperLipSuck,
        LeftCheekPuff,
        LeftDimpler,
        LeftLipCornerDown,
        LeftLowerLipDepressor,
        LeftLipCornerPuller,
        LeftLipStretcher,
        LeftUpperLipRaiser,
        RightCheekPuff,
        RightDimpler,
        RightLipCornerDown,
        RightLowerLipDepressor,
        RightLipCornerPuller,
        RightLipStretcher,
        RightUpperLipRaiser,
        JawDrop,
        JawLeft,
        JawRight,
        Corrugator,
        LeftBrowLowerer,
        LeftOuterBrowRaiser,
        LeftNoseWrinkler,
        LeftInnerBrowRaiser,
        RightBrowLowerer,
        RightOuterBrowRaiser,
        RightInnerBrowRaiser,
        RightNoseWrinkler,
        EyesLookDown,
        EyesLookLeft,
        EyesLookUp,
        EyesLookRight,
        LeftCheekRaiser,
        LeftEyeUpperLidRaiser,
        LeftEyeClosed,
        RightCheekRaiser,
        RightEyeUpperLidRaiser,
        RightEyeClosed,
        TongueDown,
        TongueOut,
        TongueUp,
    }

    public enum FeedRankingScoreType
    {
        Content,
        Final,
        GameJoin,
        Interaction,
        Sharing,
    }

    public enum FieldOfViewMode
    {
        Vertical,
        Diagonal,
        MaxAxis,
    }

    public enum FillDirection
    {
        Horizontal,
        Vertical,
    }

    public enum FilterErrorType
    {
        BackslashNotEscapingAnything,
        BadBespokeFilter,
        BadName,
        IncompleteOr,
        IncompleteParenthesis,
        InvalidDoubleStar,
        InvalidTilde,
        PropertyBadOperator,
        PropertyDoesNotExist,
        PropertyInvalidField,
        PropertyInvalidValue,
        PropertyUnsupportedFields,
        PropertyUnsupportedProperty,
        UnexpectedNameIndex,
        UnexpectedToken,
        UnfinishedBinaryOperator,
        UnfinishedQuote,
        UnknownBespokeFilter,
        WildcardInProperty,
    }

    public enum FilterResult
    {
        Accepted,
        Rejected,
    }

    public enum FinishRecordingOperation
    {
        Cancel,
        Commit,
        Append,
    }

    public enum FluidFidelity
    {
        Automatic,
        UseCollisionGeometry,
        UsePreciseGeometry,
    }

    public enum FluidForces
    {
        Default,
        Experimental,
    }

    public enum Font
    {
        Legacy,
        Arial,
        ArialBold,
        SourceSans,
        SourceSansBold,
        SourceSansLight,
        SourceSansItalic,
        Bodoni,
        Garamond,
        Cartoon,
        Code,
        Highway,
        SciFi,
        Arcade,
        Fantasy,
        Antique,
        SourceSansSemibold,
        Gotham,
        GothamMedium,
        GothamBold,
        GothamBlack,
        AmaticSC,
        Bangers,
        Creepster,
        DenkOne,
        Fondamento,
        FredokaOne,
        GrenzeGotisch,
        IndieFlower,
        JosefinSans,
        Jura,
        Kalam,
        LuckiestGuy,
        Merriweather,
        Michroma,
        Nunito,
        Oswald,
        PatrickHand,
        PermanentMarker,
        Roboto,
        RobotoCondensed,
        RobotoMono,
        Sarpanch,
        SpecialElite,
        TitilliumWeb,
        Ubuntu,
        BuilderSans,
        BuilderSansMedium,
        BuilderSansBold,
        BuilderSansExtraBold,
        Arimo,
        ArimoBold,
        Unknown = 100,

        [Obsolete]
        GothamSemibold = GothamMedium,

        [Obsolete]
        Montserrat = Gotham,

        [Obsolete]
        MontserratBlack = GothamBlack,

        [Obsolete]
        MontserratBold = GothamBold,

        [Obsolete]
        MontserratMedium = GothamMedium,
    }

    public enum FontSize
    {
        Size8,
        Size9,
        Size10,
        Size11,
        Size12,
        Size14,
        Size18,
        Size24,
        Size36,
        Size48,
        Size28,
        Size32,
        Size42,
        Size60,
        Size96,
    }

    public enum FontStyle
    {
        Normal,
        Italic,
    }

    public enum FontWeight
    {
        Thin = 100,
        ExtraLight = 200,
        Light = 300,
        Regular = 400,
        Medium = 500,
        SemiBold = 600,
        Bold = 700,
        ExtraBold = 800,
        Heavy = 900,
    }

    public enum ForceLimitMode
    {
        Magnitude,
        PerAxis,
    }

    public enum FormFactor
    {
        Symmetric,
        Brick,
        Plate,
        Custom,

        [Obsolete]
        Block = Brick,
    }

    public enum FrameStyle
    {
        Custom,
        ChatBlue,
        RobloxSquare,
        RobloxRound,
        ChatGreen,
        ChatRed,
        DropShadow,
    }

    public enum FramerateManagerMode
    {
        Automatic,
        On,
        Off,
    }

    public enum FriendRequestEvent
    {
        Issue,
        Revoke,
        Accept,
        Deny,
    }

    public enum FriendStatus
    {
        Unknown,
        NotFriend,
        Friend,
        FriendRequestSent,
        FriendRequestReceived,
    }

    public enum FunctionalTestResult
    {
        Passed,
        Warning,
        Error,
    }

    public enum GameAvatarType
    {
        R6,
        R15,
        PlayerChoice,
    }

    public enum GamepadType
    {
        Unknown,
        PS4,
        PS5,
        XboxOne,
    }

    [Obsolete]
    public enum GearGenreSetting
    {
        AllGenres,
        MatchingGenreOnly,
    }

    [Obsolete]
    public enum GearType
    {
        MeleeWeapons,
        RangedWeapons,
        Explosives,
        PowerUps,
        NavigationEnhancers,
        MusicalInstruments,
        SocialItems,
        BuildingTools,
        Transport,
    }

    [Obsolete]
    public enum Genre
    {
        All,
        TownAndCity,
        Fantasy,
        SciFi,
        Ninja,
        Scary,
        Pirate,
        Adventure,
        Sports,
        Funny,
        WildWest,
        War,
        SkatePark,
        Tutorial,
    }

    public enum GraphicsMode
    {
        Automatic = 1,
        Direct3D11,
        OpenGL = 4,
        Metal,
        Vulkan,
        NoGraphics = 9,
    }

    public enum GraphicsOptimizationMode
    {
        Performance,
        Balanced,
        Quality,
    }

    public enum GuiState
    {
        Idle,
        Hover,
        Press,
        NonInteractable,
    }

    public enum GuiType
    {
        Core,
        Custom,
        PlayerNameplates,
        CustomBillboards,
        CoreBillboards,
    }

    public enum HandRigDescriptionSide
    {
        None,
        Left,
        Right,
    }

    public enum HandlesStyle
    {
        Resize,
        Movement,
    }

    public enum HapticEffectType
    {
        Custom,
        UIHover,
        UIClick,
        UINotification,
        GameplayExplosion,
        GameplayCollision,
    }

    public enum HighlightDepthMode
    {
        AlwaysOnTop,
        Occluded,
    }

    public enum HorizontalAlignment
    {
        Center,
        Left,
        Right,
    }

    public enum HoverAnimateSpeed
    {
        VerySlow,
        Slow,
        Medium,
        Fast,
        VeryFast,
    }

    public enum HttpCachePolicy
    {
        None,
        Full,
        DataOnly,
        Default,
        InternalRedirectRefresh,
    }

    public enum HttpCompression
    {
        None,
        Gzip,
    }

    public enum HttpContentType
    {
        ApplicationJson,
        ApplicationXml,
        ApplicationUrlEncoded,
        TextPlain,
        TextXml,
    }

    public enum HttpError
    {
        OK,
        InvalidUrl,
        DnsResolve,
        ConnectFail,
        OutOfMemory,
        TimedOut,
        TooManyRedirects,
        InvalidRedirect,
        NetFail,
        Aborted,
        SslConnectFail,
        SslVerificationFail,
        Unknown,
        ConnectionClosed,
        ServerProtocolError,
    }

    public enum HttpRequestType
    {
        Default,
        MarketplaceService = 2,
        Players = 7,
        Chat = 15,
        Avatar,
        Analytics = 23,
        Localization = 25,
    }

    public enum HumanoidCollisionType
    {
        OuterBox,
        InnerBox,
    }

    public enum HumanoidDisplayDistanceType
    {
        Viewer,
        Subject,
        None,
    }

    public enum HumanoidHealthDisplayType
    {
        DisplayWhenDamaged,
        AlwaysOn,
        AlwaysOff,
    }

    public enum HumanoidRigType
    {
        R6,
        R15,
    }

    public enum HumanoidStateType
    {
        FallingDown,
        Ragdoll,
        GettingUp,
        Jumping,
        Swimming,
        Freefall,
        Flying,
        Landed,
        Running,
        RunningNoPhysics = 10,
        StrafingNoPhysics,
        Climbing,
        Seated,
        PlatformStanding,
        Dead,
        Physics,
        None = 18,
    }

    public enum IKCollisionsMode
    {
        NoCollisions,
        OtherMechanismsAnchored,
        IncludeContactedMechanisms,
    }

    public enum IKControlConstraintSupport
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum IKControlType
    {
        Transform,
        Position,
        Rotation,
        LookAt,
    }

    public enum IXPLoadingStatus
    {
        None,
        Pending,
        Initialized,
        ErrorInvalidUser,
        ErrorConnection,
        ErrorJsonParse,
        ErrorTimedOut,
    }

    public enum ImageAlphaType
    {
        Default = 1,
        LockCanvasAlpha,
        LockCanvasColor,
    }

    public enum ImageCombineType
    {
        BlendSourceOver = 1,
        Overwrite,
        Add,
        Multiply,
        AlphaBlend,
    }

    public enum InOut
    {
        Edge,
        Inset,
        Center,
    }

    public enum InfoType
    {
        Asset,
        Product,
        GamePass,
        Subscription,
        Bundle,
    }

    public enum InitialDockState
    {
        Top,
        Bottom,
        Left,
        Right,
        Float,
    }

    public enum InputActionType
    {
        Bool,
        Direction1D,
        Direction2D,
    }

    public enum InputType
    {
        NoInput,
        Constant = 12,
        Sin,

        [Obsolete]
        [LostEnumValue(MapTo = 7)]
        _Action1 = NoInput,

        [Obsolete]
        [LostEnumValue(MapTo = 8)]
        _Action2 = NoInput,

        [Obsolete]
        [LostEnumValue(MapTo = 9)]
        _Action3 = NoInput,

        [Obsolete]
        [LostEnumValue(MapTo = 10)]
        _Action4 = NoInput,

        [Obsolete]
        [LostEnumValue(MapTo = 11)]
        _Action5 = NoInput,

        [Obsolete]
        [LostEnumValue(MapTo = 1)]
        _LeftTread = NoInput,

        [Obsolete]
        [LostEnumValue(MapTo = 2)]
        _RightTread = NoInput,

        [Obsolete]
        [LostEnumValue(MapTo = 3)]
        _Steer = NoInput,

        [Obsolete]
        Throtle = NoInput,

        [Obsolete]
        [LostEnumValue(MapTo = 4)]
        _Throttle = NoInput,

        [Obsolete]
        [LostEnumValue(MapTo = 6)]
        _UpDown = NoInput,
    }

    public enum IntermediateMeshGenerationResult
    {
        HighQualityMesh,
    }

    public enum InterpolationThrottlingMode
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum InviteState
    {
        Placed,
        Accepted,
        Declined,
        Missed,
    }

    public enum ItemLineAlignment
    {
        Automatic,
        Start,
        Center,
        End,
        Stretch,
    }

    public enum JoinSource
    {
        CreatedItemAttribution = 1,
    }

    public enum JointCreationMode
    {
        All,
        Surface,
        None,
    }

    public enum KeyCode
    {
        Unknown,
        Backspace = 8,
        Tab,
        Clear = 12,
        Return,
        Pause = 19,
        Escape = 27,
        Space = 32,
        QuotedDouble = 34,
        Hash,
        Dollar,
        Percent,
        Ampersand,
        Quote,
        LeftParenthesis,
        RightParenthesis,
        Asterisk,
        Plus,
        Comma,
        Minus,
        Period,
        Slash,
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Colon,
        Semicolon,
        LessThan,
        Equals,
        GreaterThan,
        Question,
        At,
        LeftBracket = 91,
        BackSlash,
        RightBracket,
        Caret,
        Underscore,
        Backquote,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        LeftCurly,
        Pipe,
        RightCurly,
        Tilde,
        Delete,

        [Obsolete]
        World0 = 160,

        [Obsolete]
        World1,

        [Obsolete]
        World2,

        [Obsolete]
        World3,

        [Obsolete]
        World4,

        [Obsolete]
        World5,

        [Obsolete]
        World6,

        [Obsolete]
        World7,

        [Obsolete]
        World8,

        [Obsolete]
        World9,

        [Obsolete]
        World10,

        [Obsolete]
        World11,

        [Obsolete]
        World12,

        [Obsolete]
        World13,

        [Obsolete]
        World14,

        [Obsolete]
        World15,

        [Obsolete]
        World16,

        [Obsolete]
        World17,

        [Obsolete]
        World18,

        [Obsolete]
        World19,

        [Obsolete]
        World20,

        [Obsolete]
        World21,

        [Obsolete]
        World22,

        [Obsolete]
        World23,

        [Obsolete]
        World24,

        [Obsolete]
        World25,

        [Obsolete]
        World26,

        [Obsolete]
        World27,

        [Obsolete]
        World28,

        [Obsolete]
        World29,

        [Obsolete]
        World30,

        [Obsolete]
        World31,

        [Obsolete]
        World32,

        [Obsolete]
        World33,

        [Obsolete]
        World34,

        [Obsolete]
        World35,

        [Obsolete]
        World36,

        [Obsolete]
        World37,

        [Obsolete]
        World38,

        [Obsolete]
        World39,

        [Obsolete]
        World40,

        [Obsolete]
        World41,

        [Obsolete]
        World42,

        [Obsolete]
        World43,

        [Obsolete]
        World44,

        [Obsolete]
        World45,

        [Obsolete]
        World46,

        [Obsolete]
        World47,

        [Obsolete]
        World48,

        [Obsolete]
        World49,

        [Obsolete]
        World50,

        [Obsolete]
        World51,

        [Obsolete]
        World52,

        [Obsolete]
        World53,

        [Obsolete]
        World54,

        [Obsolete]
        World55,

        [Obsolete]
        World56,

        [Obsolete]
        World57,

        [Obsolete]
        World58,

        [Obsolete]
        World59,

        [Obsolete]
        World60,

        [Obsolete]
        World61,

        [Obsolete]
        World62,

        [Obsolete]
        World63,

        [Obsolete]
        World64,

        [Obsolete]
        World65,

        [Obsolete]
        World66,

        [Obsolete]
        World67,

        [Obsolete]
        World68,

        [Obsolete]
        World69,

        [Obsolete]
        World70,

        [Obsolete]
        World71,

        [Obsolete]
        World72,

        [Obsolete]
        World73,

        [Obsolete]
        World74,

        [Obsolete]
        World75,

        [Obsolete]
        World76,

        [Obsolete]
        World77,

        [Obsolete]
        World78,

        [Obsolete]
        World79,

        [Obsolete]
        World80,

        [Obsolete]
        World81,

        [Obsolete]
        World82,

        [Obsolete]
        World83,

        [Obsolete]
        World84,

        [Obsolete]
        World85,

        [Obsolete]
        World86,

        [Obsolete]
        World87,

        [Obsolete]
        World88,

        [Obsolete]
        World89,

        [Obsolete]
        World90,

        [Obsolete]
        World91,

        [Obsolete]
        World92,

        [Obsolete]
        World93,

        [Obsolete]
        World94,

        [Obsolete]
        World95,

        KeypadZero,
        KeypadOne,
        KeypadTwo,
        KeypadThree,
        KeypadFour,
        KeypadFive,
        KeypadSix,
        KeypadSeven,
        KeypadEight,
        KeypadNine,
        KeypadPeriod,
        KeypadDivide,
        KeypadMultiply,
        KeypadMinus,
        KeypadPlus,
        KeypadEnter,
        KeypadEquals,
        Up,
        Down,
        Right,
        Left,
        Insert,
        Home,
        End,
        PageUp,
        PageDown,
        F1,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        F11,
        F12,
        F13,
        F14,
        F15,
        NumLock = 300,
        CapsLock,
        ScrollLock,
        RightShift,
        LeftShift,
        RightControl,
        LeftControl,
        RightAlt,
        LeftAlt,
        RightMeta,
        LeftMeta,
        LeftSuper,
        RightSuper,
        Mode,
        Compose,
        Help,
        Print,
        SysReq,
        Break,
        Menu,
        Power,
        Euro,
        Undo,
        ButtonX = 1000,
        ButtonY,
        ButtonA,
        ButtonB,
        ButtonR1,
        ButtonL1,
        ButtonR2,
        ButtonL2,
        ButtonR3,
        ButtonL3,
        ButtonStart,
        ButtonSelect,
        DPadLeft,
        DPadRight,
        DPadUp,
        DPadDown,
        Thumbstick1,
        Thumbstick2,
        MouseLeftButton,
        MouseRightButton,
        MouseMiddleButton,

        [Obsolete]
        MouseBackButton,

        [Obsolete]
        MouseNoButton,

        [Obsolete]
        MouseX,

        [Obsolete]
        MouseY,
    }

    public enum KeyInterpolationMode
    {
        Constant,
        Linear,
        Cubic,
    }

    public enum KeywordFilterType
    {
        Include,
        Exclude,
    }

    public enum Language
    {
        Default,
    }

    public enum LeftRight
    {
        Left,
        Center,
        Right,
    }

    public enum LexemeType
    {
        Eof,
        Name,
        QuotedString,
        Number,
        And,
        Or,
        Equal,
        TildeEqual,
        GreaterThan,
        GreaterThanEqual,
        LessThan,
        LessThanEqual,
        Colon,
        Dot,
        LeftParenthesis,
        RightParenthesis,
        Star,
        DoubleStar,
        ReservedSpecial,
    }

    public enum LightingStyle
    {
        Realistic,
        Soft,
    }

    public enum Limb
    {
        Head,
        Torso,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg,
        Unknown,
    }

    public enum LineJoinMode
    {
        Round,
        Bevel,
        Miter,
    }

    public enum ListDisplayMode
    {
        Horizontal,
        Vertical,
    }

    public enum ListenerLocation
    {
        Default,
        None,
        Character,
        Camera,
    }

    public enum ListenerType
    {
        Camera,
        CFrame,
        ObjectPosition,
        ObjectCFrame,
    }

    public enum LiveEditingAtomicUpdateResponse
    {
        Success,
        FailureGuidNotFound,
        FailureHashMismatch,
        FailureOperationIllegal,
    }

    public enum LiveEditingBroadcastMessageType
    {
        Normal,
        Warning,
        Error,
    }

    public enum LoadCharacterLayeredClothing
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum LoadDynamicHeads
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum LocationType
    {
        Character,
        Camera,
        ObjectPosition,
    }

    public enum MarketplaceBulkPurchasePromptStatus
    {
        Completed = 1,
        Aborted,
        Error,
    }

    public enum MarketplaceItemPurchaseStatus
    {
        Success = 1,
        SystemError,
        AlreadyOwned,
        InsufficientRobux,
        QuantityLimitExceeded,
        QuotaExceeded,
        NotForSale,
        NotAvailableForPurchaser,
        PriceMismatch,
        SoldOut,
        PurchaserIsSeller,
        InsufficientMembership,
        PlaceInvalid,
    }

    public enum MarketplaceProductType
    {
        AvatarAsset = 1,
        AvatarBundle,
    }

    public enum MarkupKind
    {
        PlainText,
        Markdown,
    }

    public enum MatchmakingType
    {
        Default = 1,
        XboxOnly,
        PlayStationOnly,
    }

    public enum Material
    {
        Plastic = 256,
        SmoothPlastic = 272,
        Neon = 288,
        Wood = 512,
        WoodPlanks = 528,
        Marble = 784,
        Basalt = 788,
        Slate = 800,
        CrackedLava = 804,
        Concrete = 816,
        Limestone = 820,
        Granite = 832,
        Pavement = 836,
        Brick = 848,
        Pebble = 864,
        Cobblestone = 880,
        Rock = 896,
        Sandstone = 912,
        CorrodedMetal = 1040,
        DiamondPlate = 1056,
        Foil = 1072,
        Metal = 1088,
        Grass = 1280,
        LeafyGrass = 1284,
        Sand = 1296,
        Fabric = 1312,
        Snow = 1328,
        Mud = 1344,
        Ground = 1360,
        Asphalt = 1376,
        Salt = 1392,
        Ice = 1536,
        Glacier = 1552,
        Glass = 1568,
        ForceField = 1584,
        Air = 1792,
        Water = 2048,
        Cardboard = 2304,
        Carpet,
        CeramicTiles,
        ClayRoofTiles,
        RoofShingles,
        Leather,
        Plaster,
        Rubber,

        [Obsolete]
        Aluminum = Foil,

        [Obsolete]
        Corroded_Metal = CorrodedMetal,
    }

    public enum MaterialPattern
    {
        Regular,
        Organic,
    }

    public enum MembershipType
    {
        None,
        BuildersClub,
        TurboBuildersClub,
        OutrageousBuildersClub,
        Premium,
    }

    public enum MeshPartDetailLevel
    {
        DistanceBased,
        Level00,
        Level01,
        Level02,
        Level03,
        Level04,
    }

    public enum MeshPartHeadsAndAccessories
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum MeshScaleUnit
    {
        Stud,
        Meter,
        CM,
        MM,
        Foot,
        Inch,
    }

    public enum MeshType
    {
        Head,
        Torso,
        Wedge,
        Sphere,
        Cylinder,
        FileMesh,
        Brick,

        [Obsolete]
        Prism,

        [Obsolete]
        Pyramid,

        [Obsolete]
        ParallelRamp,

        [Obsolete]
        RightAngleRamp,

        [Obsolete]
        CornerWedge,
    }

    public enum MessageType
    {
        MessageOutput,
        MessageInfo,
        MessageWarning,
        MessageError,
    }

    public enum ModelLevelOfDetail
    {
        Automatic,
        StreamingMesh,
        Disabled,
    }

    public enum ModelStreamingBehavior
    {
        Default,
        Legacy,
        Improved,
    }

    public enum ModelStreamingMode
    {
        Default,
        Atomic,
        Persistent,
        PersistentPerPlayer,
        Nonatomic,
    }

    public enum ModerationStatus
    {
        ReviewedApproved = 1,
        ReviewedRejected,
        NotReviewed,
        NotApplicable,
        Invalid,
    }

    public enum ModifierKey
    {
        Shift,
        Ctrl,
        Alt,
        Meta,
    }

    public enum MouseBehavior
    {
        Default,
        LockCenter,
        LockCurrentPosition,
    }

    public enum MoveState
    {
        Stopped,
        Coasting,
        Pushing,
        Stopping,
        AirFree,
    }

    public enum MoverConstraintRootBehaviorMode
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum MuteState
    {
        Unmuted,
        Muted,
    }

    public enum NameOcclusion
    {
        NoOcclusion,
        EnemyOcclusion,
        OccludeAll,
    }

    public enum NegateOperationHiddenHistory
    {
        None,
        NegatedUnion,
        NegatedIntersection,
    }

    public enum NetworkOwnership
    {
        Automatic,
        Manual,
        OnContact,
    }

    public enum NetworkStatus
    {
        Unknown,
        Connected,
        Disconnected,
    }

    public enum NoiseType
    {
        SimplexGabor,
    }

    public enum NormalId
    {
        Right,
        Top,
        Back,
        Left,
        Bottom,
        Front,
    }

    public enum NotificationButtonType
    {
        Primary,
        Secondary,
    }

    public enum OperationType
    {
        Null,
        Union,
        Subtraction,
        Intersection,
        Primitive,
    }

    public enum OrientationAlignmentMode
    {
        OneAttachment,
        TwoAttachment,
    }

    public enum OutfitSource
    {
        All = 1,
        Created,
        Purchased,
    }

    public enum OutfitType
    {
        All = 1,
        Avatar,
        DynamicHead,
    }

    public enum OutputLayoutMode
    {
        Horizontal,
        Vertical,
    }

    public enum OverrideMouseIconBehavior
    {
        None,
        ForceShow,
        ForceHide,
    }

    public enum PackagePermission
    {
        None,
        NoAccess,
        Revoked,
        UseView,
        Edit,
        Own,
    }

    public enum PartType
    {
        Ball,
        Block,
        Cylinder,
        Wedge,
        CornerWedge,
    }

    public enum ParticleEmitterShape
    {
        Box,
        Sphere,
        Cylinder,
        Disc,
    }

    public enum ParticleEmitterShapeInOut
    {
        Outward,
        Inward,
        InAndOut,
    }

    public enum ParticleEmitterShapeStyle
    {
        Volume,
        Surface,
    }

    public enum ParticleFlipbookLayout
    {
        None,
        Grid2x2,
        Grid4x4,
        Grid8x8,
    }

    public enum ParticleFlipbookMode
    {
        Loop,
        OneShot,
        PingPong,
        Random,
    }

    public enum ParticleFlipbookTextureCompatible
    {
        NotCompatible,
        Compatible,
        Unknown,
    }

    public enum ParticleOrientation
    {
        FacingCamera,
        FacingCameraWorldUp,
        VelocityParallel,
        VelocityPerpendicular,
    }

    public enum PathStatus
    {
        Success,

        [Obsolete]
        ClosestNoPath,

        [Obsolete]
        ClosestOutOfRange,

        [Obsolete]
        FailStartNotEmpty,

        [Obsolete]
        FailFinishNotEmpty,

        NoPath,
    }

    public enum PathWaypointAction
    {
        Walk,
        Jump,
        Custom,
    }

    public enum PathfindingUseImprovedSearch
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum PermissionLevelShown
    {
        Game,
        RobloxGame,
        RobloxScript,
        Studio,
        Roblox,
    }

    public enum PhysicsSimulationRate
    {
        Fixed240Hz,
        Fixed120Hz,
        Fixed60Hz,
    }

    public enum PhysicsSteppingMethod
    {
        Default,
        Fixed,
        Adaptive,
    }

    public enum Platform
    {
        Windows,
        OSX,
        IOS,
        Android,
        XBoxOne,
        PS4,
        PS3,
        XBox360,
        WiiU,
        NX,
        Ouya,
        AndroidTV,
        Chromecast,
        Linux,
        SteamOS,
        WebOS,
        DOS,
        BeOS,
        UWP,
        PS5,
        MetaOS,
        None,
    }

    public enum PlaybackState
    {
        Begin,
        Delayed,
        Playing,
        Paused,
        Completed,
        Cancelled,
    }

    public enum PlayerActions
    {
        CharacterForward,
        CharacterBackward,
        CharacterLeft,
        CharacterRight,
        CharacterJump,
    }

    public enum PlayerCharacterDestroyBehavior
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum PlayerChatType
    {
        All,
        Team,
        Whisper,
    }

    public enum PlayerDataErrorState
    {
        LoadFailed,
        FlushFailed,
        ReleaseFailed,
        None,
    }

    public enum PlayerDataLoadFailureBehavior
    {
        Failure,
        FallbackToDefault,
        Kick,
    }

    public enum PoseEasingDirection
    {
        In,
        Out,
        InOut,
    }

    public enum PoseEasingStyle
    {
        Linear,
        Constant,
        Elastic,
        Cubic,
        Bounce,
        CubicV2,
    }

    public enum PositionAlignmentMode
    {
        OneAttachment,
        TwoAttachment,
    }

    public enum PreferredInput
    {
        KeyboardAndMouse,
        Gamepad,
        Touch,
    }

    public enum PreferredTextSize
    {
        Medium = 1,
        Large,
        Larger,
        Largest,
    }

    public enum PrimalPhysicsSolver
    {
        Default,
        Experimental,
        Disabled,
    }

    public enum PrimitiveType
    {
        Null,
        Ball,
        Cylinder,
        Block,
        Wedge,
        CornerWedge,
    }

    [Obsolete]
    public enum PrivilegeType
    {
        Banned,
        Visitor = 10,
        Member = 128,
        Admin = 240,
        Owner = 255,
    }

    public enum ProductLocationRestriction
    {
        AvatarShop,
        AllowedGames,
        AllGames,
    }

    public enum ProductPurchaseChannel
    {
        InExperience = 1,
        ExperienceDetailsPage,
        AdReward,
        CommerceProduct,
    }

    public enum ProductPurchaseDecision
    {
        NotProcessedYet,
        PurchaseGranted,
    }

    public enum PromptCreateAssetResult
    {
        Success = 1,
        PermissionDenied,
        Timeout,
        UploadFailed,
        NoUserInput,
        UnknownFailure,
    }

    public enum PromptCreateAvatarResult
    {
        Success = 1,
        PermissionDenied,
        Timeout,
        UploadFailed,
        NoUserInput,
        InvalidHumanoidDescription,
        UGCValidationFailed,
        ModeratedName,
        MaxOutfits,
        PurchaseFailure,
        UnknownFailure,
        TokenInvalid,
    }

    public enum PromptPublishAssetResult
    {
        Success = 1,
        PermissionDenied,
        Timeout,
        UploadFailed,
        NoUserInput,
        UnknownFailure,
    }

    public enum PropertyStatus
    {
        Ok,
        Warning,
        Error,
    }

    public enum ProximityPromptExclusivity
    {
        OnePerButton,
        OneGlobally,
        AlwaysShow,
    }

    public enum ProximityPromptInputType
    {
        Keyboard,
        Gamepad,
        Touch,
    }

    public enum ProximityPromptStyle
    {
        Default,
        Custom,
    }

    public enum QualityLevel
    {
        Automatic,
        Level01,
        Level02,
        Level03,
        Level04,
        Level05,
        Level06,
        Level07,
        Level08,
        Level09,
        Level10,
        Level11,
        Level12,
        Level13,
        Level14,
        Level15,
        Level16,
        Level17,
        Level18,
        Level19,
        Level20,
        Level21,

        [Obsolete]
        Level_10 = Level10,

        [Obsolete]
        Level_11 = Level11,

        [Obsolete]
        Level_12 = Level12,

        [Obsolete]
        Level_13 = Level13,

        [Obsolete]
        Level_14 = Level14,

        [Obsolete]
        Level_15 = Level15,

        [Obsolete]
        Level_16 = Level16,

        [Obsolete]
        Level_17 = Level17,

        [Obsolete]
        Level_18 = Level18,

        [Obsolete]
        Level_19 = Level19,

        [Obsolete]
        Level_20 = Level20,

        [Obsolete]
        Level_21 = Level21,

        [Obsolete]
        Level__1 = Level01,

        [Obsolete]
        Level__2 = Level02,

        [Obsolete]
        Level__3 = Level03,

        [Obsolete]
        Level__4 = Level04,

        [Obsolete]
        Level__5 = Level05,

        [Obsolete]
        Level__6 = Level06,

        [Obsolete]
        Level__7 = Level07,

        [Obsolete]
        Level__8 = Level08,

        [Obsolete]
        Level__9 = Level09,
    }

    public enum R15CollisionType
    {
        OuterBox,
        InnerBox,
    }

    public enum RaycastFilterType
    {
        Exclude,
        Include,

        [Obsolete]
        Blacklist = Exclude,

        [Obsolete]
        Whitelist = Include,
    }

    public enum RejectCharacterDeletions
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum RenderFidelity
    {
        Automatic,
        Precise,
        Performance,
    }

    public enum RenderPriority
    {
        First,
        Input = 100,
        Camera = 200,
        Character = 300,
        Last = 2000,
    }

    public enum RenderingCacheOptimizationMode
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum RenderingTestComparisonMethod
    {
        psnr,
        diff,
    }

    public enum ReplicateInstanceDestroySetting
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum ResamplerMode
    {
        Default,
        Pixelated,
    }

    public enum ReservedHighlightId
    {
        Standard,
        Active = 131072,
        Hover = 262144,
        Selection = 524288,
    }

    public enum RestPose
    {
        Default,
        RotationsReset,
        Custom,
    }

    public enum ReturnKeyType
    {
        Default,
        Done,
        Go,
        Next,
        Search,
        Send,
    }

    public enum ReverbType
    {
        NoReverb,
        GenericReverb,
        PaddedCell,
        Room,
        Bathroom,
        LivingRoom,
        StoneRoom,
        Auditorium,
        ConcertHall,
        Cave,
        Arena,
        Hangar,
        CarpettedHallway,
        Hallway,
        StoneCorridor,
        Alley,
        Forest,
        City,
        Mountains,
        Quarry,
        Plain,
        ParkingLot,
        SewerPipe,
        UnderWater,
    }

    public enum RibbonTool
    {
        Select,
        Scale,
        Rotate,
        Move,
        Transform,
        ColorPicker,
        MaterialPicker,
        Group,
        Ungroup,
        None,
        PivotEditor,
    }

    public enum RigScale
    {
        Default,
        Rthro,
        RthroNarrow,
    }

    public enum RigType
    {
        R15,
        Custom,
        None,
    }

    public enum RollOffMode
    {
        Inverse,
        Linear,
        LinearSquare,
        InverseTapered,
    }

    public enum RolloutState
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum RotationOrder
    {
        XYZ,
        XZY,
        YZX,
        YXZ,
        ZXY,
        ZYX,
    }

    public enum RotationType
    {
        MovementRelative,
        CameraRelative,
    }

    public enum RtlTextSupport
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum RunContext
    {
        Legacy,
        Server,
        Client,
        Plugin,
    }

    public enum RunState
    {
        Stopped,
        Running,
        Paused,
    }

    public enum RuntimeUndoBehavior
    {
        Aggregate,
        Snapshot,
        Hybrid,
    }

    public enum SafeAreaCompatibility
    {
        None,
        FullscreenExtension,
    }

    public enum SalesTypeFilter
    {
        All = 1,
        Collectibles,
        Premium,
    }

    public enum SandboxedInstanceMode
    {
        Default,
        Experimental,
    }

    public enum SaveAvatarThumbnailCustomizationFailure
    {
        BadThumbnailType = 1,
        BadYRotDeg,
        BadFieldOfViewDeg,
        BadDistanceScale,
        Other,
        Throttled,
    }

    [Obsolete]
    public enum SaveFilter
    {
        SaveWorld,
        SaveGame,
        SaveAll,
    }

    public enum SavedQualitySetting
    {
        Automatic,
        QualityLevel1,
        QualityLevel2,
        QualityLevel3,
        QualityLevel4,
        QualityLevel5,
        QualityLevel6,
        QualityLevel7,
        QualityLevel8,
        QualityLevel9,
        QualityLevel10,
    }

    public enum ScaleType
    {
        Stretch,
        Slice,
        Tile,
        Fit,
        Crop,
    }

    public enum ScopeCheckResult
    {
        ConsentAccepted,
        InvalidScopes,
        Timeout,
        NoUserInput,
        BackendError,
        UnexpectedError,
        InvalidArgument,
        ConsentDenied,
    }

    public enum ScreenInsets
    {
        None,
        DeviceSafeInsets,
        CoreUISafeInsets,
        TopbarSafeInsets,
    }

    public enum ScreenOrientation
    {
        LandscapeLeft,
        LandscapeRight,
        LandscapeSensor,
        Portrait,
        Sensor,
    }

    public enum ScrollBarInset
    {
        None,
        ScrollBar,
        Always,
    }

    public enum ScrollingDirection
    {
        X = 1,
        Y,
        XY = 4,
    }

    public enum SecurityCapability
    {
        RunClientScript,
        RunServerScript,
        AccessOutsideWrite,
        AssetRequire,
        LoadString,
        ScriptGlobals,
        CreateInstances,
        Basic,
        Audio,
        DataStore,
        Network,
        Physics,
        UI,
        CSG,
        Chat,
        Animation,
        Avatar,
        Input,
        Environment,
        RemoteEvent,
        LegacySound,
        Players,
        CapabilityControl,
    }

    public enum SelectionBehavior
    {
        Escape,
        Stop,
    }

    public enum SelectionRenderMode
    {
        Outlines,
        BoundingBoxes,
        Both,
    }

    public enum SelfViewPosition
    {
        LastPosition,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
    }

    public enum SensorMode
    {
        Floor,
        Ladder,
    }

    public enum SensorUpdateType
    {
        OnRead,
        Manual,
    }

    public enum ServerLiveEditingMode
    {
        Uninitialized,
        Enabled,
        Disabled,
    }

    public enum ServiceVisibility
    {
        Always,
        Off,
        WithChildren,
    }

    public enum Severity
    {
        Error = 1,
        Warning,
        Information,
        Hint,
    }

    public enum ShowAdResult
    {
        ShowCompleted = 1,
        AdNotReady,
        AdAlreadyShowing,
        InternalError,
        ShowInterrupted,
        InsufficientMemory,
    }

    public enum SignalBehavior
    {
        Default,
        Immediate,
        Deferred,
        AncestryDeferred,
    }

    public enum SizeConstraint
    {
        RelativeXY,
        RelativeXX,
        RelativeYY,
    }

    public enum SolverConvergenceMetricType
    {
        IterationBased,
        AlgorithmAgnostic,
    }

    public enum SolverConvergenceVisualizationMode
    {
        Disabled,
        PerIsland,
        PerEdge,
    }

    public enum SortDirection
    {
        Ascending,
        Descending,
    }

    public enum SortOrder
    {
        Name,

        [Obsolete]
        Custom,

        LayoutOrder,
    }

    public enum SpecialKey
    {
        Insert,
        Home,
        End,
        PageUp,
        PageDown,
        ChatHotkey,
    }

    public enum StartCorner
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
    }

    [Obsolete]
    public enum StateObjectFieldType
    {
        Boolean,
        CFrame,
        Color3,
        Float,
        Instance,
        Random,
        Vector2,
        Vector3,
        INVALID,
    }

    [Obsolete]
    public enum Status
    {
        Poison,
        Confusion,
    }

    public enum StreamOutBehavior
    {
        Default,
        LowMemory,
        Opportunistic,
    }

    public enum StreamingIntegrityMode
    {
        Default,
        Disabled,
        MinimumRadiusPause,
        PauseOutsideLoadedArea,
    }

    [Obsolete]
    public enum StreamingPauseMode
    {
        Default,
        Disabled,
        ClientPhysicsPause,
    }

    public enum StudioCloseMode
    {
        None,
        CloseStudio,
        CloseDoc,
        LogOut,
    }

    public enum StudioDataModelType
    {
        Edit,
        PlayClient,
        PlayServer,
        Standalone,
        None,
    }

    public enum StudioPlaceUpdateFailureReason
    {
        Other,
        TeamCreateConflict,
    }

    public enum StudioScriptEditorColorCategories
    {
        Default,
        Operator,
        Number,
        String,
        Comment,
        Keyword,
        Builtin,
        Method,
        Property,
        Nil,
        Bool,
        Function,
        Local,
        Self,
        LuauKeyword,
        FunctionName,
        TODO,
        Background,
        SelectionText,
        SelectionBackground,
        FindSelectionBackground,
        MatchingWordBackground,
        Warning,
        Error,
        Info,
        Hint,
        Whitespace,
        ActiveLine,
        DebuggerCurrentLine,
        DebuggerErrorLine,
        Ruler,
        Bracket,
        Type,
        MenuPrimaryText,
        MenuSecondaryText,
        MenuSelectedText,
        MenuBackground,
        MenuSelectedBackground,
        MenuScrollbarBackground,
        MenuScrollbarHandle,
        MenuBorder,
        DocViewCodeBackground,
        AICOOverlayText,
        AICOOverlayButtonBackground,
        AICOOverlayButtonBackgroundHover,
        AICOOverlayButtonBackgroundPressed,
        IndentationRuler,
    }

    public enum StudioScriptEditorColorPresets
    {
        RobloxDefault,
        Extra1,
        Extra2,
        Custom,
    }

    public enum StudioStyleGuideColor
    {
        MainBackground,
        Titlebar,
        Dropdown,
        Tooltip,
        Notification,
        ScrollBar,
        ScrollBarBackground,
        TabBar,
        Tab,
        FilterButtonDefault,
        FilterButtonHover,
        FilterButtonChecked,
        FilterButtonAccent,
        FilterButtonBorder,
        FilterButtonBorderAlt,
        RibbonTab,
        RibbonTabTopBar,
        Button,
        MainButton,
        RibbonButton,
        ViewPortBackground,
        InputFieldBackground,
        Item,
        TableItem,
        CategoryItem,
        GameSettingsTableItem,
        GameSettingsTooltip,
        EmulatorBar,
        EmulatorDropDown,
        ColorPickerFrame,
        CurrentMarker,
        Border,
        DropShadow,
        Shadow,
        Light,
        Dark,
        Mid,
        MainText,
        SubText,
        TitlebarText,
        BrightText,
        DimmedText,
        LinkText,
        WarningText,
        ErrorText,
        InfoText,
        SensitiveText,
        ScriptSideWidget,
        ScriptBackground,
        ScriptText,
        ScriptSelectionText,
        ScriptSelectionBackground,
        ScriptFindSelectionBackground,
        ScriptMatchingWordSelectionBackground,
        ScriptOperator,
        ScriptNumber,
        ScriptString,
        ScriptComment,
        ScriptKeyword,
        ScriptBuiltInFunction,
        ScriptWarning,
        ScriptError,
        ScriptInformation,
        ScriptHint,
        ScriptWhitespace,
        ScriptRuler,
        DocViewCodeBackground,
        DebuggerCurrentLine,
        DebuggerErrorLine,
        DiffFilePathText,
        DiffTextHunkInfo,
        DiffTextNoChange,
        DiffTextAddition,
        DiffTextDeletion,
        DiffTextSeparatorBackground,
        DiffTextNoChangeBackground,
        DiffTextAdditionBackground,
        DiffTextDeletionBackground,
        DiffLineNum,
        DiffLineNumSeparatorBackground,
        DiffLineNumNoChangeBackground,
        DiffLineNumAdditionBackground,
        DiffLineNumDeletionBackground,
        DiffFilePathBackground,
        DiffFilePathBorder,
        ChatIncomingBgColor,
        ChatIncomingTextColor,
        ChatOutgoingBgColor,
        ChatOutgoingTextColor,
        ChatModeratedMessageColor,
        Separator,
        ButtonBorder,
        ButtonText,
        InputFieldBorder,
        CheckedFieldBackground,
        CheckedFieldBorder,
        CheckedFieldIndicator,
        HeaderSection,
        Midlight,
        StatusBar,
        DialogButton,
        DialogButtonText,
        DialogButtonBorder,
        DialogMainButton,
        DialogMainButtonText,
        InfoBarWarningBackground,
        InfoBarWarningText,
        ScriptEditorCurrentLine,
        ScriptMethod,
        ScriptProperty,
        ScriptNil,
        ScriptBool,
        ScriptFunction,
        ScriptLocal,
        ScriptSelf,
        ScriptLuauKeyword,
        ScriptFunctionName,
        ScriptTodo,
        ScriptBracket,
        AttributeCog,
        AICOOverlayText = 128,
        AICOOverlayButtonBackground,
        AICOOverlayButtonBackgroundHover,
        AICOOverlayButtonBackgroundPressed,
        OnboardingCover,
        OnboardingHighlight,
        OnboardingShadow,
        BreakpointMarker = 136,
        DiffLineNumHover,
        DiffLineNumSeparatorBackgroundHover,
    }

    public enum StudioStyleGuideModifier
    {
        Default,
        Selected,
        Pressed,
        Disabled,
        Hover,
    }

    public enum Style
    {
        AlternatingSupports,
        BridgeStyleSupports,
        NoSupports,

        [Obsolete]
        Alternating_Supports = AlternatingSupports,

        [Obsolete]
        Bridge_Style_Supports = BridgeStyleSupports,

        [Obsolete]
        No_Supports = NoSupports,
    }

    public enum SubscriptionExpirationReason
    {
        ProductInactive,
        ProductDeleted,
        SubscriberCancelled,
        SubscriberRefunded,
        Lapsed,
    }

    public enum SubscriptionPaymentStatus
    {
        Paid,
        Refunded,
    }

    public enum SubscriptionPeriod
    {
        Month,
    }

    public enum SubscriptionState
    {
        NeverSubscribed,
        SubscribedWillRenew,
        SubscribedWillNotRenew,
        SubscribedRenewalPaymentPending,
        Expired,
    }

    public enum SurfaceConstraint
    {
        None,
        Hinge,
        SteppingMotor,
        Motor,
    }

    public enum SurfaceGuiShape
    {
        Flat,
        CurvedHorizontally,
    }

    public enum SurfaceGuiSizingMode
    {
        FixedSize,
        PixelsPerStud,
    }

    public enum SurfaceType
    {
        Smooth,
        Glue,
        Weld,
        Studs,
        Inlet,
        Universal,
        Hinge,
        Motor,
        SteppingMotor,
        SmoothNoOutlines = 10,

        [Obsolete]
        Bumps = Glue,

        [Obsolete]
        Spawn = Smooth,

        [Obsolete]
        [LostEnumValue(MapTo = 9)]
        _Unjoinable = Smooth,
    }

    public enum SwipeDirection
    {
        Right,
        Left,
        Up,
        Down,
        None,
    }

    public enum SystemThemeValue
    {
        error,
        light,
        dark,
        systemLight,
        systemDark,
    }

    public enum TableMajorAxis
    {
        RowMajor,
        ColumnMajor,
    }

    public enum TeamCreateErrorState
    {
        PlaceSizeTooLarge,
        PlaceSizeApproachingLimit,
        NoError,
    }

    public enum Technology
    {
        [Obsolete]
        Legacy,

        Voxel,
        Compatibility,
        ShadowMap,
        Future,

        [Obsolete]
        Unified,
    }

    public enum TeleportMethod
    {
        TeleportToSpawnByName,
        TeleportToPlaceInstance,
        TeleportToPrivateServer,
        TeleportPartyAsync,
        TeleportToVIPServer,
        TeleportToInstanceBack,
        TeleportUnknown,
    }

    public enum TeleportResult
    {
        Success,
        Failure,
        GameNotFound,
        GameEnded,
        GameFull,
        Unauthorized,
        Flooded,
        IsTeleporting,
    }

    public enum TeleportState
    {
        RequestedFromServer,
        Started,
        WaitingForServer,
        Failed,
        InProgress,
    }

    public enum TeleportType
    {
        ToPlace,
        ToInstance,
        ToReservedServer,
        ToVIPServer,
        ToInstanceBack,
    }

    public enum TerrainAcquisitionMethod
    {
        None,
        Legacy,
        Template,
        Generate,
        Import,
        Convert,
        EditAddTool,
        EditSeaLevelTool,
        EditReplaceTool,
        RegionFillTool,
        RegionPasteTool,
        Other,
    }

    public enum TerrainFace
    {
        Top,
        Side,
        Bottom,
    }

    public enum TextChatMessageStatus
    {
        Unknown = 1,
        Success,
        Sending,
        TextFilterFailed,
        Floodchecked,
        InvalidPrivacySettings,
        InvalidTextChannelPermissions,
        MessageTooLong,
        ModerationTimeout,
    }

    public enum TextDirection
    {
        Auto,
        LeftToRight,
        RightToLeft,
    }

    public enum TextFilterContext
    {
        PublicChat = 1,
        PrivateChat,
    }

    public enum TextInputType
    {
        Default,
        NoSuggestions,
        Number,
        Email,
        Phone,
        Password,
        PasswordShown,
        Username,
        OneTimePassword,
    }

    public enum TextTruncate
    {
        None,
        AtEnd,
        SplitWord,
    }

    public enum TextXAlignment
    {
        Left,
        Right,
        Center,
    }

    public enum TextYAlignment
    {
        Top,
        Center,
        Bottom,
    }

    public enum TextureMode
    {
        Stretch,
        Wrap,
        Static,
    }

    public enum TextureQueryType
    {
        NonHumanoid,
        NonHumanoidOrphaned,
        Humanoid,
        HumanoidOrphaned,
    }

    public enum ThreadPoolConfig
    {
        Auto,
        Threads1,
        Threads2,
        Threads3,
        Threads4,
        Threads8 = 8,
        Threads16 = 16,
        PerCore1 = 101,
        PerCore2,
        PerCore3,
        PerCore4,

        [Obsolete]
        PartialThread = Auto,
    }

    public enum ThrottlingPriority
    {
        Default,
        ElevatedOnServer,
        Extreme,
    }

    public enum ThumbnailSize
    {
        Size48x48,
        Size180x180,
        Size420x420,
        Size60x60,
        Size100x100,
        Size150x150,
        Size352x352,
    }

    public enum ThumbnailType
    {
        HeadShot,
        AvatarBust,
        AvatarThumbnail,
    }

    public enum TickCountSampleMethod
    {
        Fast,
        Benchmark,
        Precise,
    }

    public enum TonemapperPreset
    {
        Default,
        Retro,
    }

    public enum TopBottom
    {
        Top,
        Center,
        Bottom,
    }

    public enum TouchCameraMovementMode
    {
        Default,
        Classic,
        Follow,
        Orbital,
    }

    public enum TouchMovementMode
    {
        Default,
        Thumbstick,
        DPad,
        Thumbpad,
        ClickToMove,
        DynamicThumbstick,
    }

    public enum TrackerError
    {
        Ok,
        NoService,
        InitFailed,
        NoVideo,
        VideoError,
        VideoNoPermission,
        VideoUnsupported,
        NoAudio,
        AudioError,
        AudioNoPermission,
        UnsupportedDevice,
    }

    public enum TrackerExtrapolationFlagMode
    {
        ForceDisabled,
        ExtrapolateFacsAndPose,
        ExtrapolateFacsOnly,
        Auto,
    }

    public enum TrackerFaceTrackingStatus
    {
        FaceTrackingSuccess,
        FaceTrackingNoFaceFound,
        FaceTrackingUnknown,
        FaceTrackingLost,
        FaceTrackingHasTrackingError,
        FaceTrackingIsOccluded,
        FaceTrackingUninitialized,
    }

    public enum TrackerLodFlagMode
    {
        ForceFalse,
        ForceTrue,
        Auto,
    }

    public enum TrackerLodValueMode
    {
        Force0,
        Force1,
        Auto,
    }

    public enum TrackerMode
    {
        None,
        Audio,
        Video,
        AudioVideo,
    }

    public enum TrackerPromptEvent
    {
        LODCameraRecommendDisable,
    }

    public enum TrackerType
    {
        None,
        Face,
        UpperBody,
    }

    public enum TriStateBoolean
    {
        Unknown,
        True,
        False,
    }

    public enum TweenStatus
    {
        Canceled,
        Completed,
    }

    public enum UICaptureMode
    {
        All,
        None,
    }

    public enum UIDragDetectorBoundingBehavior
    {
        Automatic,
        EntireObject,
        HitPoint,
    }

    public enum UIDragDetectorDragRelativity
    {
        Absolute,
        Relative,
    }

    public enum UIDragDetectorDragSpace
    {
        Parent,
        LayerCollector,
        Reference,
    }

    public enum UIDragDetectorDragStyle
    {
        TranslatePlane,
        TranslateLine,
        Rotate,
        Scriptable,
    }

    public enum UIDragDetectorResponseStyle
    {
        Offset,
        Scale,
        CustomOffset,
        CustomScale,
    }

    public enum UIDragSpeedAxisMapping
    {
        XY,
        XX,
        YY,
    }

    public enum UIFlexAlignment
    {
        None,
        Fill,
        SpaceAround,
        SpaceBetween,
        SpaceEvenly,
    }

    public enum UIFlexMode
    {
        None,
        Grow,
        Shrink,
        Fill,
        Custom,
    }

    [Obsolete]
    public enum UITheme
    {
        Light,
        Dark,
    }

    public enum UiMessageType
    {
        UiMessageError,
        UiMessageInfo,
    }

    public enum UsageContext
    {
        Default,
        Preview,
    }

    public enum UserCFrame
    {
        Head,
        LeftHand,
        RightHand,
        Floor,
    }

    public enum UserInputState
    {
        Begin,
        Change,
        End,
        Cancel,
        None,
    }

    public enum UserInputType
    {
        MouseButton1,
        MouseButton2,
        MouseButton3,
        MouseWheel,
        MouseMovement,
        Touch = 7,
        Keyboard,
        Focus,
        Accelerometer,
        Gyro,
        Gamepad1,
        Gamepad2,
        Gamepad3,
        Gamepad4,
        Gamepad5,
        Gamepad6,
        Gamepad7,
        Gamepad8,
        TextInput,
        InputMethod,
        None,
    }

    public enum VRComfortSetting
    {
        Comfort,
        Normal,
        Expert,
        Custom,
    }

    public enum VRControllerModelMode
    {
        Disabled,
        Transparent,
    }

    public enum VRDeviceType
    {
        Unknown,
        OculusRift,
        HTCVive,
        ValveIndex,
        OculusQuest,
    }

    public enum VRLaserPointerMode
    {
        Disabled,
        Pointer,
        DualPointer,
    }

    public enum VRSafetyBubbleMode
    {
        NoOne,
        OnlyFriends,
        Anyone,
    }

    public enum VRScaling
    {
        World,
        Off,
    }

    public enum VRSessionState
    {
        Undefined,
        Idle,
        Visible,
        Focused,
        Stopping,
    }

    public enum VRTouchpad
    {
        Left,
        Right,
    }

    public enum VRTouchpadMode
    {
        Touch,
        VirtualThumbstick,
        ABXY,
    }

    public enum VelocityConstraintMode
    {
        Line,
        Plane,
        Vector,
    }

    public enum VerticalAlignment
    {
        Center,
        Top,
        Bottom,
    }

    public enum VerticalScrollBarPosition
    {
        Right,
        Left,
    }

    public enum VibrationMotor
    {
        Large,
        Small,
        LeftTrigger,
        RightTrigger,
        LeftHand,
        RightHand,
    }

    public enum VideoCaptureResult
    {
        Success,
        OtherError,
        ScreenSizeChanged,
        TimeLimitReached,
    }

    public enum VideoCaptureStartedResult
    {
        Success,
        OtherError,
        CapturingAlready,
        NoDeviceSupport,
        NoSpaceOnDevice,
    }

    public enum VideoDeviceCaptureQuality
    {
        Default,
        Low,
        Medium,
        High,
    }

    public enum VideoError
    {
        Ok,
        Eof,
        EAgain,
        BadParameter,
        AllocFailed,
        CodecInitFailed,
        CodecCloseFailed,
        DecodeFailed,
        ParsingFailed,
        Unsupported,
        Generic,
        DownloadFailed,
        StreamNotFound,
        EncodeFailed,
        CreateFailed,
        NoPermission,
        NoService,
        ReleaseFailed,
        Unknown,
    }

    public enum ViewMode
    {
        None,
        GeometryComplexity,
        Transparent,
        Decal,
    }

    public enum VirtualCursorMode
    {
        Default,
        Disabled,
        Enabled,
    }

    public enum VirtualInputMode
    {
        None,
        Recording,
        Playing,
    }

    public enum VoiceChatDistanceAttenuationType
    {
        Inverse,
        Legacy,
    }

    public enum VoiceChatState
    {
        Idle,
        Joining,
        JoiningRetry,
        Joined,
        Leaving,
        Ended,
        Failed,
    }

    public enum VoiceControlPath
    {
        Publish,
        Subscribe,
        Join,
    }

    public enum VolumetricAudio
    {
        Disabled,
        Automatic,
        Enabled,
    }

    public enum WaterDirection
    {
        NegX,
        X,
        NegY,
        Y,
        NegZ,
        Z,
    }

    public enum WaterForce
    {
        None,
        Small,
        Medium,
        Strong,
        Max,
    }

    public enum WebSocketState
    {
        Connecting,
        Open,
        Closing,
        Closed,
    }

    public enum WeldConstraintPreserve
    {
        All,
        None,
        Touching,
    }

    public enum WhisperChatPrivacyMode
    {
        AllUsers,
        NoOne,
    }

    public enum WrapLayerAutoSkin
    {
        Disabled,
        EnabledPreserve,
        EnabledOverride,
    }

    public enum WrapLayerDebugMode
    {
        None,
        BoundCage,
        LayerCage,
        BoundCageAndLinks,
        Reference,
        Rbf,
        OuterCage,
        ReferenceMeshAfterMorph,
        HSROuterDetail,
        HSROuter,
        HSRInner,
        HSRInnerReverse,
        LayerCageFittedToBase,
        LayerCageFittedToPrev,
        PreWrapDeformerOuterCage,
    }

    public enum WrapTargetDebugMode
    {
        None,
        TargetCageOriginal,
        TargetCageCompressed,
        TargetCageInterface,
        TargetLayerCageOriginal,
        TargetLayerCageCompressed,
        TargetLayerInterface,
        Rbf,
        OuterCageDetail,
        PreWrapDeformerCage,
    }

    public enum ZIndexBehavior
    {
        Global,
        Sibling,
    }
}
