using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class OptionalCFrameToken : IXmlPropertyToken
    {
        public string XmlPropertyToken => "OptionalCoordinateFrame";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            XmlNode first = token.FirstChild;
            CFrame value = null;

            if (first?.Name == "CFrame")
                value = CFrameToken.ReadCFrame(first);
                
            prop.Value = new Optional<CFrame>(value);
            prop.Type = PropertyType.OptionalCFrame;
            
            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            if (prop.Value is Optional<CFrame> optional)
            {
                if (optional.HasValue)
                {
                    CFrame value = optional.Value;
                    XmlElement cfNode = doc.CreateElement("CFrame");

                    CFrameToken.WriteCFrame(value, doc, cfNode);
                    node.AppendChild(cfNode);
                }
            }
        }
    }
}
