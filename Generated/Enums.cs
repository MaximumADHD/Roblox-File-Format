// Auto-generated list of Roblox enums.
// Updated as of 0.589.0.5890596

namespace RobloxFiles.Enums
{
    public enum AccessModifierType
    {
        Allow,
        Deny
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
        Eyelash
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

    public enum AdShape
    {
        HorizontalRectangle = 1
    }

    public enum AdornCullingMode
    {
        Automatic,
        Never
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
        Action2,
        Action3,
        Action4,
        Core = 1000
    }

    public enum AnimatorRetargetingMode
    {
        Default,
        Disabled,
        Enabled
    }

    public enum ApplyStrokeMode
    {
        Contextual,
        Border
    }

    public enum AspectType
    {
        FitWithinMaxSize,
        ScaleWithParentSize
    }

    public enum AudioSubType
    {
        Music = 1,
        SoundEffect
    }

    public enum AutomaticSize
    {
        None,
        X,
        Y,
        XY
    }

    public enum AvatarJointUpgrade
    {
        Default,
        Enabled,
        Disabled
    }

    public enum AvatarUnificationMode
    {
        Default,
        Disabled,
        Enabled
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

    public enum BorderMode
    {
        Outline,
        Middle,
        Inset
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

    public enum ChatVersion
    {
        LegacyChatService,
        TextChatService
    }

    public enum ClientAnimatorThrottlingMode
    {
        Default,
        Disabled,
        Enabled
    }

    public enum DeathStyle
    {
        Default,
        ClassicBreakApart,
        NonGraphic,
        Scriptable
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
        BestForDevice
    }

    public enum DragDetectorResponseStyle
    {
        Geometric,
        Physical,
        Custom
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

    public enum ExplosionType
    {
        NoCraters,
        Craters
    }

    public enum FieldOfViewMode
    {
        Vertical,
        Diagonal,
        MaxAxis
    }

    public enum FillDirection
    {
        Horizontal,
        Vertical
    }

    public enum FluidForces
    {
        Default,
        Experimental
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
        Unknown = 100
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

    public enum FontStyle
    {
        Normal,
        Italic
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
        Heavy = 900
    }

    public enum ForceLimitMode
    {
        Magnitude,
        PerAxis
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

    public enum GameAvatarType
    {
        R6,
        R15,
        PlayerChoice
    }

    public enum HandlesStyle
    {
        Resize,
        Movement
    }

    public enum HighlightDepthMode
    {
        AlwaysOnTop,
        Occluded
    }

    public enum HorizontalAlignment
    {
        Center,
        Left,
        Right
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

    public enum HumanoidOnlySetCollisionsOnStateChange
    {
        Default,
        Disabled,
        Enabled
    }

    public enum HumanoidRigType
    {
        R6,
        R15
    }

    public enum HumanoidStateMachineMode
    {
        Default,
        Legacy,
        NoStateMachine,
        LuaStateMachine
    }

    public enum IKControlConstraintSupport
    {
        Default,
        Disabled,
        Enabled
    }

    public enum IKControlType
    {
        Transform,
        Position,
        Rotation,
        LookAt
    }

    public enum InOut
    {
        Edge,
        Inset,
        Center
    }

    public enum InputType
    {
        NoInput,
        Constant = 12,
        Sin
    }

    public enum InterpolationThrottlingMode
    {
        Default,
        Disabled,
        Enabled
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

    public enum LeftRight
    {
        Left,
        Center,
        Right
    }

    public enum LineJoinMode
    {
        Round,
        Bevel,
        Miter
    }

    public enum LoadCharacterLayeredClothing
    {
        Default,
        Disabled,
        Enabled
    }

    public enum LoadDynamicHeads
    {
        Default,
        Disabled,
        Enabled
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
        Rubber
    }

    public enum MaterialPattern
    {
        Regular,
        Organic
    }

    public enum MeshPartHeadsAndAccessories
    {
        Default,
        Disabled,
        Enabled
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

    public enum ModelLevelOfDetail
    {
        Automatic,
        StreamingMesh,
        Disabled
    }

    public enum ModelStreamingBehavior
    {
        Default,
        Legacy,
        Improved
    }

    public enum ModelStreamingMode
    {
        Default,
        Atomic,
        Persistent,
        PersistentPerPlayer,
        Nonatomic
    }

    public enum MouseBehavior
    {
        Default,
        LockCenter,
        LockCurrentPosition
    }

    public enum NameOcclusion
    {
        NoOcclusion,
        EnemyOcclusion,
        OccludeAll
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

    public enum OrientationAlignmentMode
    {
        OneAttachment,
        TwoAttachment
    }

    public enum PartType
    {
        Ball,
        Block,
        Cylinder,
        Wedge,
        CornerWedge
    }

    public enum ParticleEmitterShape
    {
        Box,
        Sphere,
        Cylinder,
        Disc
    }

    public enum ParticleEmitterShapeInOut
    {
        Outward,
        Inward,
        InAndOut
    }

    public enum ParticleEmitterShapeStyle
    {
        Volume,
        Surface
    }

    public enum ParticleFlipbookLayout
    {
        None,
        Grid2x2,
        Grid4x4,
        Grid8x8
    }

    public enum ParticleFlipbookMode
    {
        Loop,
        OneShot,
        PingPong,
        Random
    }

    public enum ParticleOrientation
    {
        FacingCamera,
        FacingCameraWorldUp,
        VelocityParallel,
        VelocityPerpendicular
    }

    public enum PhysicsSteppingMethod
    {
        Default,
        Fixed,
        Adaptive
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

    public enum PositionAlignmentMode
    {
        OneAttachment,
        TwoAttachment
    }

    public enum ProximityPromptExclusivity
    {
        OnePerButton,
        OneGlobally,
        AlwaysShow
    }

    public enum ProximityPromptStyle
    {
        Default,
        Custom
    }

    public enum R15CollisionType
    {
        OuterBox,
        InnerBox
    }

    public enum RejectCharacterDeletions
    {
        Default,
        Disabled,
        Enabled
    }

    public enum RenderFidelity
    {
        Automatic,
        Precise,
        Performance
    }

    public enum RenderingTestComparisonMethod
    {
        psnr,
        diff
    }

    public enum ReplicateInstanceDestroySetting
    {
        Default,
        Disabled,
        Enabled
    }

    public enum ResamplerMode
    {
        Default,
        Pixelated
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

    public enum RollOffMode
    {
        Inverse,
        Linear,
        LinearSquare,
        InverseTapered
    }

    public enum RotationOrder
    {
        XYZ,
        XZY,
        YZX,
        YXZ,
        ZXY,
        ZYX
    }

    public enum RtlTextSupport
    {
        Default,
        Disabled,
        Enabled
    }

    public enum RunContext
    {
        Legacy,
        Server,
        Client,
        Plugin
    }

    public enum SafeAreaCompatibility
    {
        None,
        FullscreenExtension
    }

    public enum ScaleType
    {
        Stretch,
        Slice,
        Tile,
        Fit,
        Crop
    }

    public enum ScreenInsets
    {
        None,
        DeviceSafeInsets,
        CoreUISafeInsets
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

    public enum SelectionBehavior
    {
        Escape,
        Stop
    }

    public enum SensorMode
    {
        Floor,
        Ladder
    }

    public enum SensorUpdateType
    {
        OnRead,
        Manual
    }

    public enum ServiceVisibility
    {
        Always,
        Off,
        WithChildren
    }

    public enum SignalBehavior
    {
        Default,
        Immediate,
        Deferred,
        AncestryDeferred
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

    public enum StartCorner
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    public enum StreamOutBehavior
    {
        Default,
        LowMemory,
        Opportunistic
    }

    public enum StreamingIntegrityMode
    {
        Default,
        Disabled,
        MinimumRadiusPause,
        PauseOutsideLoadedArea
    }

    public enum Style
    {
        AlternatingSupports,
        BridgeStyleSupports,
        NoSupports
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
        Other
    }

    public enum TerrainFace
    {
        Top,
        Side,
        Bottom
    }

    public enum TextDirection
    {
        Auto,
        LeftToRight,
        RightToLeft
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

    public enum TopBottom
    {
        Top,
        Center,
        Bottom
    }

    public enum TriStateBoolean
    {
        Unknown,
        True,
        False
    }

    public enum VelocityConstraintMode
    {
        Line,
        Plane,
        Vector
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

    public enum VirtualCursorMode
    {
        Default,
        Disabled,
        Enabled
    }

    public enum VolumetricAudio
    {
        Disabled,
        Automatic,
        Enabled
    }

    public enum WrapLayerAutoSkin
    {
        Disabled,
        EnabledPreserve,
        EnabledOverride
    }

    public enum ZIndexBehavior
    {
        Global,
        Sibling
    }
}
