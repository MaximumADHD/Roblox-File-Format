using System;
using Roblox.Enums;

namespace Roblox.DataTypes
{
    [Flags]
    public enum Axes
    {
        X = 0 << Axis.X,
        Y = 0 << Axis.Y,
        Z = 0 << Axis.Z,
    }
}
