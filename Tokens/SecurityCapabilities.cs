using System.Xml;

namespace RobloxFiles.Tokens
{
    public class SecurityCapabilitiesToken : IXmlPropertyToken
    {
        public string XmlPropertyToken => "SecurityCapabilities";

        public bool ReadProperty(Property prop, XmlNode node)
        {
            if (ulong.TryParse(node.InnerText, out var value))
            {
                prop.Value = (SecurityCapabilities)value;
                return true;
            }

            return false;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            var value = prop.CastValue<ulong>();
            node.InnerText = value.ToString();
        }
    }
}
