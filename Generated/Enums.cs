// Auto-generated list of Roblox enums.
// Updated as of 0.458.1.415373

namespace RobloxFiles.Enums
{
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
        Core = 1000
    }

    public enum AspectType
    {
        FitWithinMaxSize,
        ScaleWithParentSize
    }

    public enum AutomaticSize
    {
        None,
        X,
        Y,
        XY
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
        Ubuntu
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

    public enum HumanoidRigType
    {
        R6,
        R15
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

    public enum LevelOfDetailSetting
    {
        Low,
        Medium,
        High
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

    public enum MeshPartHeads
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

    public enum PartType
    {
        Ball,
        Block,
        Cylinder
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

    public enum StreamingPauseMode
    {
        Default,
        Disabled,
        ClientPhysicsPause
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

    public enum ZIndexBehavior
    {
        Global,
        Sibling
    }
}
