using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class SharedStringToken : IXmlPropertyToken
    {
        public string XmlPropertyToken => "SharedString";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string key = token.InnerText;
            prop.Type = PropertyType.SharedString;
            prop.Value = new SharedString(key);

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            if (prop.Value is SharedString value)
            {
                string key = value.Key;

                if (value.ComputedKey == null)
                {
                    var newShared = SharedString.FromBuffer(value.SharedValue);
                    key = newShared.ComputedKey;
                }

                node.InnerText = key;
            }
        }
    }
}
