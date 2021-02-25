using System.Xml;
using RobloxFiles.XmlFormat;

namespace RobloxFiles.Tokens
{
    public class Int64Token : IXmlPropertyToken
    {
        public string XmlPropertyToken => "int64";

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