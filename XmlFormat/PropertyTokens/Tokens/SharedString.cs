using System;
using System.Text;
using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class SharedStringToken : IXmlPropertyToken
    {
        public string Token => "SharedString";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string contents = token.InnerText;
            prop.Type = PropertyType.SharedString;
            prop.Value = contents;

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            var BinaryStringToken = XmlPropertyTokens.GetHandler<BinaryStringToken>();
            BinaryStringToken.WriteProperty(prop, doc, node);
        }
    }
}
