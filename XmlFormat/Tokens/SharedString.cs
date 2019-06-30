using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class SharedStringToken : IXmlPropertyToken
    {
        public string Token => "SharedString";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string md5 = token.InnerText;
            prop.Type = PropertyType.SharedString;
            prop.Value = new SharedString(md5);

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            SharedString value = prop.CastValue<SharedString>();
            node.InnerText = value.MD5_Key;
        }
    }
}
