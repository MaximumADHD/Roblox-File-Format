using System;
using Roblox.Enums;

namespace Roblox.DataTypes
{
    [Flags]
    public enum Axes
    {
        X = 1 << Axis.X,
        Y = 1 << Axis.Y,
        Z = 1 << Axis.Z,
    }
}
