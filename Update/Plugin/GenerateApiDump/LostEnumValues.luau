type LostEnumValues = {
    [string]: {
        [string]: number
    }
}

return {
    BinType = {
        Slingshot = 5,
        Rocket = 6,
        Laser = 7,
    },

    InputType = {
        LeftTread = 1,
        RightTread = 2,
        Steer = 3,
        Throttle = 4,
        UpDown = 6,
        Action1 = 7,
        Action2 = 8,
        Action3 = 9,
        Action4 = 10,
        Action5 = 11,
    },

    SurfaceType = {
        Unjoinable = 9,
    },
} :: LostEnumValues
