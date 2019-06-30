using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class Int64Token : IXmlPropertyToken
    {
        public string Token => "int64";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            return XmlPropertyTokens.ReadPropertyGeneric<long>(prop, PropertyType.Int64, token);
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            long value = prop.CastValue<long>();
            node.InnerText = value.ToString();
        }
    }
}