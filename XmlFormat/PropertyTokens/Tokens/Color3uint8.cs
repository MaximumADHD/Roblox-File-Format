using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class Color3uint8Token : IXmlPropertyToken
    {
        public string Token => "Color3uint8";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            bool success = XmlPropertyTokens.ReadPropertyGeneric<uint>(prop, PropertyType.Color3, token);

            if (success)
            {
                uint value = (uint)prop.Value;

                uint r = (value >> 16) & 0xFF;
                uint g = (value >> 8) & 0xFF;
                uint b = value & 0xFF;

                prop.Value = Color3.FromRGB(r, g, b);
            }
            
            return success;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            Color3 color = prop.Value as Color3;

            uint r = (uint)(color.R * 256);
            uint g = (uint)(color.G * 256);
            uint b = (uint)(color.B * 256);

            uint rgb = (255u << 24) | (r << 16) | (g << 8) | b;
            node.InnerText = rgb.ToString();
        }
    }
}
