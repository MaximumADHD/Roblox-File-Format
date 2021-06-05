using System.Xml;

namespace RobloxFiles.Tokens
{
    public class StringToken : IXmlPropertyToken, IAttributeToken<string>
    {
        public string XmlPropertyToken => "string";
        public AttributeType AttributeType => AttributeType.String;

        public string ReadAttribute(RbxAttribute attr) => attr.ReadString();
        public void WriteAttribute(RbxAttribute attr, string value) => attr.WriteString(value);

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
