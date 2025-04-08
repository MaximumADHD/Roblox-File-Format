using System;

namespace RobloxFiles
{
    /// <summary>
    /// Indicates an enum that was removed by Roblox without any enum name taking the place of its original value.
    /// This has only ever happened in a few specific narrow cases and is considered bad practice.
    /// </summary>
    public class LostEnumValue : Attribute
    {
        public int MapTo { get; set; }
    }
}
