using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class SharedStringToken : IXmlPropertyToken
    {
        public string Token => "SharedString";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string key = token.InnerText;
            prop.Type = PropertyType.SharedString;
            prop.Value = new SharedString(key);

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            var value = prop.Value as SharedString;

            if (value != null)
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
