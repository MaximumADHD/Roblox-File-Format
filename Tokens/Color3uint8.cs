using System.Xml;
using RobloxFiles.DataTypes;
using RobloxFiles.XmlFormat;
using System.Diagnostics.Contracts;

namespace RobloxFiles.Tokens
{
    public class Color3uint8Token : IXmlPropertyToken
    {
        public string XmlPropertyToken => "Color3uint8";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            if (XmlPropertyTokens.ReadPropertyGeneric(token, out uint value))
            {
                uint r = (value >> 16) & 0xFF;
                uint g = (value >> 8) & 0xFF;
                uint b = value & 0xFF;

                Color3uint8 result = Color3.FromRGB(r, g, b);
                prop.Value = result;

                return true;
            }
            
            return false;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            Color3uint8 color = prop?.CastValue<Color3uint8>();
            Contract.Requires(node != null);


            uint r = color.R,
                 g = color.G,
                 b = color.B;

            uint rgb = (255u << 24) | (r << 16) | (g << 8) | b;
            node.InnerText = rgb.ToInvariantString();
        }
    }
}
