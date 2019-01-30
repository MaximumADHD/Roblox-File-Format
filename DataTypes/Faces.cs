using System;
using Roblox.Enums;

namespace Roblox.DataTypes
{
    [Flags]
    public enum Faces
    {
        Right  = 1 << NormalId.Right,
        Top    = 1 << NormalId.Top,
        Back   = 1 << NormalId.Back,
        Left   = 1 << NormalId.Left,
        Bottom = 1 << NormalId.Bottom,
        Front  = 1 << NormalId.Front,
    }
}
