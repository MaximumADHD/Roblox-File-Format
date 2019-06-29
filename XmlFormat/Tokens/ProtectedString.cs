using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class ProtectedStringToken : IXmlPropertyToken
    {
        public string Token => "ProtectedString";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            ProtectedString contents = token.InnerText;
            prop.Type = PropertyType.String;
            prop.Value = contents;

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            string value = prop.CastValue<ProtectedString>();

            if (value.Contains("\r") || value.Contains("\n"))
            {
                XmlCDataSection cdata = doc.CreateCDataSection(value);
                node.AppendChild(cdata);
            }
            else
            {
                node.InnerText = value;
            }
        }
    }
}
