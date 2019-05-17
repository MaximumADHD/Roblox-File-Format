using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class EnumToken : IXmlPropertyToken
    {
        public string Token => "token";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            return XmlPropertyTokens.ReadPropertyGeneric<uint>(prop, PropertyType.Enum, token);
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            node.InnerText = prop.Value.ToString();
        }
    }
}
