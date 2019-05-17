using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class BoolToken : IXmlPropertyToken
    {
        public string Token => "bool";

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
