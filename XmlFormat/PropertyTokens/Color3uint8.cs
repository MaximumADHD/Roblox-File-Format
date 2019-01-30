using System;
using System.Xml;
using Roblox.DataTypes;

namespace Roblox.XmlFormat.PropertyTokens
{
    public class Color3uint8Token : IXmlPropertyToken
    {
        public string Token => "Color3uint8";

        public bool ReadToken(Property prop, XmlNode token)
        {
            bool success = XmlPropertyTokens.ReadTokenGeneric<uint>(prop, PropertyType.Color3, token);

            if (success)
            {
                uint value = (uint)prop.Value;

                uint r = (value >> 16) & 0xFF;
                uint g = (value >> 8) & 0xFF;
                uint b = value & 0xFF;

                prop.Value = Color3.fromRGB(r, g, b);
            }
            
            return success;
        }
    }
}
