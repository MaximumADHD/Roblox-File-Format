using System.Xml;
using RobloxFiles.XmlFormat;

namespace RobloxFiles.Tokens
{
    public class BoolToken : IXmlPropertyToken, IAttributeToken<bool>
    {
        public string XmlPropertyToken => "bool";
        public AttributeType AttributeType => AttributeType.Bool;

        public bool ReadAttribute(RbxAttribute attr) => attr.ReadBool();
        public void WriteAttribute(RbxAttribute attr, bool value) => attr.WriteBool(value);

        public bool ReadProperty(Property prop, XmlNode token)
        {
            return XmlPropertyTokens.ReadPropertyGeneric<bool>(prop, PropertyType.Bool, token);
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            string boolString = prop.Value
                .ToString()
                .ToLower();

            node.InnerText = boolString;
        }
    }
}
