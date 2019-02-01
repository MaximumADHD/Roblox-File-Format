using System;
using RobloxFiles.Enums;

namespace RobloxFiles.DataTypes
{
    [Flags]
    public enum Axes
    {
        X = 1 << Axis.X,
        Y = 1 << Axis.Y,
        Z = 1 << Axis.Z,
    }
}
