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
            prop.Type = PropertyType.OptionalCFrame;

            if (first?.Name == "CFrame")
                prop.Value = CFrameToken.ReadCFrame(first);

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            CFrame value = prop.CastValue<CFrame>();

            if (value != null)
            {
                XmlElement cfNode = doc.CreateElement("CFrame");
                CFrameToken.WriteCFrame(prop, doc, cfNode);
                node.AppendChild(cfNode);
            }
        }
    }
}
