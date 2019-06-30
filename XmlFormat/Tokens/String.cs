using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class StringToken : IXmlPropertyToken
    {
        public string Token => "string";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string contents = token.InnerText;
            prop.Type = PropertyType.String;
            prop.Value = contents;

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            string value = prop.Value.ToInvariantString();

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
