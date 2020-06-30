// Auto-generated list of Roblox enums.
// Updated as of 0.438.0.407270

namespace RobloxFiles.Enums
{
    public enum ABTestLoadingStatus
    {
        None,
        Pending,
        Initialized,
        Error,
        TimedOut,
        ShutOff
    }

    public enum ActionType
    {
        Nothing,
        Pause,
        Lose,
        Draw,
        Win
    }

    public enum ActuatorRelativeTo
    {
        Attachment0,
        Attachment1,
        World
    }

    public enum ActuatorType
    {
        None,
        Motor,
        Servo
    }

    public enum AlignType
    {
        Parallel,
        Perpendicular
    }

    public enum AlphaMode
    {
        Overlay,
        Transparency
    }

    public enum AnimationPriority
    {
        Idle,
        Movement,
        Action,
        Core = 1000
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
        AvatarEditorPageLoaded
    }

    public enum AspectType
    {
        FitWithinMaxSize,
        ScaleWithParentSize
    }

    public enum AssetFetchStatus
    {
        Success,
        Failure
    }

    public enum AssetType
    {
        Image = 1,
        TeeShirt,
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
        Video
    }

    public enum AutoIndentRule
    {
        Off,
        Absolute,
        Relative
    }

    public enum AvatarContextMenuOption
    {
        Friend,
        Chat,
        Emote,
        InspectMenu
    }

    public enum AvatarJointPositionType
    {
        Fixed,
        ArtistIntent
    }

    public enum Axis
    {
        X,
        Y,
        Z
    }

    public enum BinType
    {
        Script,
        GameTool,
        Grab,
        Clone,
        Hammer
    }

    public enum BodyPart
    {
        Head,
        Torso,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg
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
        Unknown = 17
    }

    public enum BorderMode
    {
        Outline,
        Middle,
        Inset
    }

    public enum BreakReason
    {
        Other,
        Error,
        SpecialBreakpoint,
        UserBreakpoint
    }

    public enum BulkMoveMode
    {
        FireAllEvents,
        FireCFrameChanged
    }

    public enum Button
    {
        Dismount = 8,
        Jump = 32
    }

    public enum ButtonStyle
    {
        Custom,
        RobloxButtonDefault,
        RobloxButton,
        RobloxRoundButton,
        RobloxRoundDefaultButton,
        RobloxRoundDropdownButton
    }

    public enum CameraMode
    {
        Classic,
        LockFirstPerson
    }

    public enum CameraPanMode
    {
        Classic,
        EdgeBump
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
        Orbital
    }

    public enum CellBlock
    {
        Solid,
        VerticalWedge,
        CornerWedge,
        InverseCornerWedge,
        HorizontalWedge
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
        Water
    }

    public enum CellOrientation
    {
        NegZ,
        X,
        Z,
        NegX
    }

    public enum CenterDialogType
    {
        UnsolicitedDialog = 1,
        PlayerInitiatedDialog,
        ModalDialog,
        QuitDialog
    }

    public enum ChatCallbackType
    {
        OnCreatingChatWindow = 1,
        OnClientSendingMessage,
        OnClientFormattingMessage,
        OnServerReceivingMessage = 17
    }

    public enum ChatColor
    {
        Blue,
        Green,
        Red,
        White
    }

    public enum ChatMode
    {
        Menu,
        TextAndMenu
    }

    public enum ChatPrivacyMode
    {
        AllUsers,
        NoOne,
        Friends
    }

    public enum ChatStyle
    {
        Classic,
        Bubble,
        ClassicAndBubble
    }

    public enum CollisionFidelity
    {
        Default,
        Hull,
        Box,
        PreciseConvexDecomposition
    }

    public enum ComputerCameraMovementMode
    {
        Default,
        Classic,
        Follow,
        Orbital,
        CameraToggle
    }

    public enum ComputerMovementMode
    {
        Default,
        KeyboardMouse,
        ClickToMove
    }

    public enum ConnectionError
    {
        OK,
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
        PlacelaunchCustomMessage = 610,
        PlacelaunchOtherError,
        TeleportErrors = 768,
        TeleportFailure,
        TeleportGameNotFound,
        TeleportGameEnded,
        TeleportGameFull,
        TeleportUnauthorized,
        TeleportFlooded,
        TeleportIsTeleporting
    }

    public enum ConnectionState
    {
        Connected,
        Disconnected
    }

    public enum ContextActionPriority
    {
        Low = 1000,
        Default = 2000,
        Medium = 2000,
        High = 3000
    }

    public enum ContextActionResult
    {
        Sink,
        Pass
    }

    public enum ControlMode
    {
        Classic,
        MouseLockSwitch
    }

    public enum CoreGuiType
    {
        PlayerList,
        Health,
        Backpack,
        Chat,
        All,
        EmotesMenu
    }

    public enum CreatorType
    {
        User,
        Group
    }

    public enum CurrencyType
    {
        Default,
        Robux,
        Tix
    }

    public enum CustomCameraMode
    {
        Default,
        Classic,
        Follow
    }

    public enum DataStoreRequestType
    {
        GetAsync,
        SetIncrementAsync,
        UpdateAsync,
        GetSortedAsync,
        SetIncrementSortedAsync,
        OnUpdate
    }

    public enum DevCameraOcclusionMode
    {
        Zoom,
        Invisicam
    }

    public enum DevComputerCameraMovementMode
    {
        UserChoice,
        Classic,
        Follow,
        Orbital,
        CameraToggle
    }

    public enum DevComputerMovementMode
    {
        UserChoice,
        KeyboardMouse,
        ClickToMove,
        Scriptable
    }

    public enum DevTouchCameraMovementMode
    {
        UserChoice,
        Classic,
        Follow,
        Orbital
    }

    public enum DevTouchMovementMode
    {
        UserChoice,
        Thumbstick,
        DPad,
        Thumbpad,
        ClickToMove,
        Scriptable,
        DynamicThumbstick
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
        GraphicsMeshParts,
        GraphicsParticles,
        GraphicsParts,
        GraphicsSpatialHash,
        GraphicsTerrain,
        GraphicsTexture,
        GraphicsTextureCharacter,
        Sounds,
        StreamingSounds,
        TerrainVoxels,
        Gui = 20,
        Animation,
        Navigation
    }

    public enum DeviceType
    {
        Unknown,
        Desktop,
        Tablet,
        Phone
    }

    public enum DialogBehaviorType
    {
        SinglePlayer,
        MultiplePlayers
    }

    public enum DialogPurpose
    {
        Quest,
        Help,
        Shop
    }

    public enum DialogTone
    {
        Neutral,
        Friendly,
        Enemy
    }

    public enum DominantAxis
    {
        Width,
        Height
    }

    public enum DraftStatusCode
    {
        OK,
        DraftOutdated,
        ScriptRemoved,
        DraftCommitted
    }

    public enum EasingDirection
    {
        In,
        Out,
        InOut
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
        Cubic
    }

    public enum ElasticBehavior
    {
        WhenScrollable,
        Always,
        Never
    }

    public enum EnviromentalPhysicsThrottle
    {
        DefaultAuto,
        Disabled,
        Always,
        Skip2,
        Skip4,
        Skip8,
        Skip16
    }

    public enum ExplosionType
    {
        NoCraters,
        Craters
    }

    public enum FillDirection
    {
        Horizontal,
        Vertical
    }

    public enum FilterResult
    {
        Accepted,
        Rejected
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
        GothamSemibold,
        GothamBold,
        GothamBlack
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
        Size96
    }

    public enum FormFactor
    {
        Symmetric,
        Brick,
        Plate,
        Custom
    }

    public enum FrameStyle
    {
        Custom,
        ChatBlue,
        RobloxSquare,
        RobloxRound,
        ChatGreen,
        ChatRed,
        DropShadow
    }

    public enum FramerateManagerMode
    {
        Automatic,
        On,
        Off
    }

    public enum FriendRequestEvent
    {
        Issue,
        Revoke,
        Accept,
        Deny
    }

    public enum FriendStatus
    {
        Unknown,
        NotFriend,
        Friend,
        FriendRequestSent,
        FriendRequestReceived
    }

    public enum FunctionalTestResult
    {
        Passed,
        Warning,
        Error
    }

    public enum GameAvatarType
    {
        R6,
        R15,
        PlayerChoice
    }

    public enum GearGenreSetting
    {
        AllGenres,
        MatchingGenreOnly
    }

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
        Transport
    }

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
        Tutorial
    }

    public enum GraphicsMode
    {
        Automatic = 1,
        Direct3D11,
        Direct3D9,
        OpenGL,
        Metal,
        Vulkan,
        NoGraphics
    }

    public enum HandlesStyle
    {
        Resize,
        Movement
    }

    public enum HorizontalAlignment
    {
        Center,
        Left,
        Right
    }

    public enum HoverAnimateSpeed
    {
        VerySlow,
        Slow,
        Medium,
        Fast,
        VeryFast
    }

    public enum HttpCachePolicy
    {
        None,
        Full,
        DataOnly,
        Default,
        InternalRedirectRefresh
    }

    public enum HttpContentType
    {
        ApplicationJson,
        ApplicationXml,
        ApplicationUrlEncoded,
        TextPlain,
        TextXml
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
        Unknown
    }

    public enum HttpRequestType
    {
        Default,
        MarketplaceService = 2,
        Players = 7,
        Chat = 15,
        Avatar,
        Analytics = 22,
        Localization = 24
    }

    public enum HumanoidCollisionType
    {
        OuterBox,
        InnerBox
    }

    public enum HumanoidDisplayDistanceType
    {
        Viewer,
        Subject,
        None
    }

    public enum HumanoidHealthDisplayType
    {
        DisplayWhenDamaged,
        AlwaysOn,
        AlwaysOff
    }

    public enum HumanoidRigType
    {
        R6,
        R15
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
        None = 18
    }

    public enum IKCollisionsMode
    {
        NoCollisions,
        OtherMechanismsAnchored,
        IncludeContactedMechanisms
    }

    public enum InOut
    {
        Edge,
        Inset,
        Center
    }

    public enum InfoType
    {
        Asset,
        Product,
        GamePass,
        Subscription,
        Bundle
    }

    public enum InitialDockState
    {
        Top,
        Bottom,
        Left,
        Right,
        Float
    }

    public enum InlineAlignment
    {
        Bottom,
        Center,
        Top
    }

    public enum InputType
    {
        NoInput,
        Constant = 12,
        Sin
    }

    public enum JointCreationMode
    {
        All,
        Surface,
        None
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
        World0 = 160,
        World1,
        World2,
        World3,
        World4,
        World5,
        World6,
        World7,
        World8,
        World9,
        World10,
        World11,
        World12,
        World13,
        World14,
        World15,
        World16,
        World17,
        World18,
        World19,
        World20,
        World21,
        World22,
        World23,
        World24,
        World25,
        World26,
        World27,
        World28,
        World29,
        World30,
        World31,
        World32,
        World33,
        World34,
        World35,
        World36,
        World37,
        World38,
        World39,
        World40,
        World41,
        World42,
        World43,
        World44,
        World45,
        World46,
        World47,
        World48,
        World49,
        World50,
        World51,
        World52,
        World53,
        World54,
        World55,
        World56,
        World57,
        World58,
        World59,
        World60,
        World61,
        World62,
        World63,
        World64,
        World65,
        World66,
        World67,
        World68,
        World69,
        World70,
        World71,
        World72,
        World73,
        World74,
        World75,
        World76,
        World77,
        World78,
        World79,
        World80,
        World81,
        World82,
        World83,
        World84,
        World85,
        World86,
        World87,
        World88,
        World89,
        World90,
        World91,
        World92,
        World93,
        World94,
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
        Thumbstick2
    }

    public enum KeywordFilterType
    {
        Include,
        Exclude
    }

    public enum Language
    {
        Default
    }

    public enum LanguagePreference
    {
        SystemDefault,
        English,
        SimplifiedChinese,
        Korean
    }

    public enum LeftRight
    {
        Left,
        Center,
        Right
    }

    public enum LevelOfDetailSetting
    {
        Low,
        Medium,
        High
    }

    public enum Limb
    {
        Head,
        Torso,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg,
        Unknown
    }

    public enum ListDisplayMode
    {
        Horizontal,
        Vertical
    }

    public enum ListenerType
    {
        Camera,
        CFrame,
        ObjectPosition,
        ObjectCFrame
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
        Water = 2048
    }

    public enum MembershipType
    {
        None,
        BuildersClub,
        TurboBuildersClub,
        OutrageousBuildersClub,
        Premium
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
        Prism,
        Pyramid,
        ParallelRamp,
        RightAngleRamp,
        CornerWedge
    }

    public enum MessageType
    {
        MessageOutput,
        MessageInfo,
        MessageWarning,
        MessageError
    }

    public enum ModifierKey
    {
        Shift,
        Ctrl,
        Alt,
        Meta
    }

    public enum MouseBehavior
    {
        Default,
        LockCenter,
        LockCurrentPosition
    }

    public enum MoveState
    {
        Stopped,
        Coasting,
        Pushing,
        Stopping,
        AirFree
    }

    public enum NameOcclusion
    {
        NoOcclusion,
        EnemyOcclusion,
        OccludeAll
    }

    public enum NetworkOwnership
    {
        Automatic,
        Manual,
        OnContact
    }

    public enum NormalId
    {
        Right,
        Top,
        Back,
        Left,
        Bottom,
        Front
    }

    public enum OutputLayoutMode
    {
        Horizontal,
        Vertical
    }

    public enum OverrideMouseIconBehavior
    {
        None,
        ForceShow,
        ForceHide
    }

    public enum PacketPriority
    {
        IMMEDIATE_PRIORITY,
        HIGH_PRIORITY,
        MEDIUM_PRIORITY,
        LOW_PRIORITY
    }

    public enum PartType
    {
        Ball,
        Block,
        Cylinder
    }

    public enum PathStatus
    {
        Success,
        ClosestNoPath,
        ClosestOutOfRange,
        FailStartNotEmpty,
        FailFinishNotEmpty,
        NoPath
    }

    public enum PathWaypointAction
    {
        Walk,
        Jump
    }

    public enum PermissionLevelShown
    {
        Game,
        RobloxGame,
        RobloxScript,
        Studio,
        Roblox
    }

    public enum PhysicsSimulationRate
    {
        Fixed240Hz,
        Fixed120Hz,
        Fixed60Hz
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
        None
    }

    public enum PlaybackState
    {
        Begin,
        Delayed,
        Playing,
        Paused,
        Completed,
        Cancelled
    }

    public enum PlayerActions
    {
        CharacterForward,
        CharacterBackward,
        CharacterLeft,
        CharacterRight,
        CharacterJump
    }

    public enum PlayerChatType
    {
        All,
        Team,
        Whisper
    }

    public enum PoseEasingDirection
    {
        In,
        Out,
        InOut
    }

    public enum PoseEasingStyle
    {
        Linear,
        Constant,
        Elastic,
        Cubic,
        Bounce
    }

    public enum PrivilegeType
    {
        Banned,
        Visitor = 10,
        Member = 128,
        Admin = 240,
        Owner = 255
    }

    public enum ProductPurchaseDecision
    {
        NotProcessedYet,
        PurchaseGranted
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
        Level21
    }

    public enum R15CollisionType
    {
        OuterBox,
        InnerBox
    }

    public enum RaycastFilterType
    {
        Blacklist,
        Whitelist
    }

    public enum RenderFidelity
    {
        Automatic,
        Precise
    }

    public enum RenderPriority
    {
        First,
        Input = 100,
        Camera = 200,
        Character = 300,
        Last = 2000
    }

    public enum RenderingTestComparisonMethod
    {
        psnr,
        diff
    }

    public enum ReturnKeyType
    {
        Default,
        Done,
        Go,
        Next,
        Search,
        Send
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
        UnderWater
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
        None
    }

    public enum RollOffMode
    {
        Inverse,
        Linear,
        LinearSquare,
        InverseTapered
    }

    public enum RotationType
    {
        MovementRelative,
        CameraRelative
    }

    public enum RuntimeUndoBehavior
    {
        Aggregate,
        Snapshot,
        Hybrid
    }

    public enum SaveFilter
    {
        SaveWorld,
        SaveGame,
        SaveAll
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
        QualityLevel10
    }

    public enum ScaleType
    {
        Stretch,
        Slice,
        Tile,
        Fit,
        Crop
    }

    public enum ScreenOrientation
    {
        LandscapeLeft,
        LandscapeRight,
        LandscapeSensor,
        Portrait,
        Sensor
    }

    public enum ScrollBarInset
    {
        None,
        ScrollBar,
        Always
    }

    public enum ScrollingDirection
    {
        X = 1,
        Y,
        XY = 4
    }

    public enum ServerAudioBehavior
    {
        Enabled,
        Muted,
        OnlineGame
    }

    public enum SizeConstraint
    {
        RelativeXY,
        RelativeXX,
        RelativeYY
    }

    public enum SortOrder
    {
        Name,
        Custom,
        LayoutOrder
    }

    public enum SoundType
    {
        NoSound,
        Boing,
        Bomb,
        Break,
        Click,
        Clock,
        Slingshot,
        Page,
        Ping,
        Snap,
        Splat,
        Step,
        StepOn,
        Swoosh,
        Victory
    }

    public enum SpecialKey
    {
        Insert,
        Home,
        End,
        PageUp,
        PageDown,
        ChatHotkey
    }

    public enum StartCorner
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    public enum Status
    {
        Poison,
        Confusion
    }

    public enum StreamingPauseMode
    {
        Default,
        Disabled,
        ClientPhysicsPause
    }

    public enum StudioDataModelType
    {
        Edit,
        PlayClient = 2,
        PlayServer,
        RobloxPlugin,
        UserPlugin,
        None
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
        ScriptPreprocessor,
        ScriptKeyword,
        ScriptBuiltInFunction,
        ScriptWarning,
        ScriptError,
        ScriptWhitespace,
        ScriptRuler,
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
        InfoBarWarningText
    }

    public enum StudioStyleGuideModifier
    {
        Default,
        Selected,
        Pressed,
        Disabled,
        Hover
    }

    public enum Style
    {
        AlternatingSupports,
        BridgeStyleSupports,
        NoSupports
    }

    public enum SurfaceConstraint
    {
        None,
        Hinge,
        SteppingMotor,
        Motor
    }

    public enum SurfaceGuiSizingMode
    {
        FixedSize,
        PixelsPerStud
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
        SmoothNoOutlines = 10
    }

    public enum SwipeDirection
    {
        Right,
        Left,
        Up,
        Down,
        None
    }

    public enum TableMajorAxis
    {
        RowMajor,
        ColumnMajor
    }

    public enum Technology
    {
        Legacy,
        Voxel,
        Compatibility,
        ShadowMap,
        Future
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
        IsTeleporting
    }

    public enum TeleportState
    {
        RequestedFromServer,
        Started,
        WaitingForServer,
        Failed,
        InProgress
    }

    public enum TeleportType
    {
        ToPlace,
        ToInstance,
        ToReservedServer
    }

    public enum TextFilterContext
    {
        PublicChat = 1,
        PrivateChat
    }

    public enum TextInputType
    {
        Default,
        NoSuggestions,
        Number,
        Email,
        Phone,
        Password
    }

    public enum TextTruncate
    {
        None,
        AtEnd
    }

    public enum TextXAlignment
    {
        Left,
        Right,
        Center
    }

    public enum TextYAlignment
    {
        Top,
        Center,
        Bottom
    }

    public enum TextureMode
    {
        Stretch,
        Wrap,
        Static
    }

    public enum TextureQueryType
    {
        NonHumanoid,
        NonHumanoidOrphaned,
        Humanoid,
        HumanoidOrphaned
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
        PerCore4
    }

    public enum ThrottlingPriority
    {
        Default,
        ElevatedOnServer,
        Extreme
    }

    public enum ThumbnailSize
    {
        Size48x48,
        Size180x180,
        Size420x420,
        Size60x60,
        Size100x100,
        Size150x150,
        Size352x352
    }

    public enum ThumbnailType
    {
        HeadShot,
        AvatarBust,
        AvatarThumbnail
    }

    public enum TickCountSampleMethod
    {
        Fast,
        Benchmark,
        Precise
    }

    public enum TopBottom
    {
        Top,
        Center,
        Bottom
    }

    public enum TouchCameraMovementMode
    {
        Default,
        Classic,
        Follow,
        Orbital
    }

    public enum TouchMovementMode
    {
        Default,
        Thumbstick,
        DPad,
        Thumbpad,
        ClickToMove,
        DynamicThumbstick
    }

    public enum TweenStatus
    {
        Canceled,
        Completed
    }

    public enum UITheme
    {
        Light,
        Dark
    }

    public enum UiMessageType
    {
        UiMessageError,
        UiMessageInfo
    }

    public enum UploadSetting
    {
        Never,
        Ask,
        Always
    }

    public enum UserCFrame
    {
        Head,
        LeftHand,
        RightHand
    }

    public enum UserInputState
    {
        Begin,
        Change,
        End,
        Cancel,
        None
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
        None
    }

    public enum VRTouchpad
    {
        Left,
        Right
    }

    public enum VRTouchpadMode
    {
        Touch,
        VirtualThumbstick,
        ABXY
    }

    public enum VerticalAlignment
    {
        Center,
        Top,
        Bottom
    }

    public enum VerticalScrollBarPosition
    {
        Right,
        Left
    }

    public enum VibrationMotor
    {
        Large,
        Small,
        LeftTrigger,
        RightTrigger,
        LeftHand,
        RightHand
    }

    public enum VideoQualitySettings
    {
        LowResolution,
        MediumResolution,
        HighResolution
    }

    public enum VirtualInputMode
    {
        None,
        Recording,
        Playing
    }

    public enum WaterDirection
    {
        NegX,
        X,
        NegY,
        Y,
        NegZ,
        Z
    }

    public enum WaterForce
    {
        None,
        Small,
        Medium,
        Strong,
        Max
    }

    public enum ZIndexBehavior
    {
        Global,
        Sibling
    }
}
