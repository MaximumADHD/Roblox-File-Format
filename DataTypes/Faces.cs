using System;
using Roblox.Enums;

namespace Roblox.DataTypes
{
    [Flags]
    public enum Faces
    {
        Right  = 0 << NormalId.Right,
        Top    = 0 << NormalId.Top,
        Back   = 0 << NormalId.Back,
        Left   = 0 << NormalId.Left,
        Bottom = 0 << NormalId.Bottom,
        Front  = 0 << NormalId.Front,
    }
}
