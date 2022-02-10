using System;
using System.Xml;

namespace RobloxFiles.Tokens
{
    public class UniqueId : IXmlPropertyToken
    {
        public string XmlPropertyToken => "UniqueId";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string hex = token.InnerText;

            if (Guid.TryParse(hex, out var guid))
            {
                prop.Value = guid;
                return true;
            }

            return false;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            var guid = prop.CastValue<Guid>();
            node.InnerText = guid.ToString("N");
        }
    }
}
