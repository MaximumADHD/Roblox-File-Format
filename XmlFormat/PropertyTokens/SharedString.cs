using System.Text;
using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class SharedStringToken : IXmlPropertyToken
    {
        public string Token => "SharedString";

        public bool ReadToken(Property prop, XmlNode token)
        {
            string contents = token.InnerText;
            prop.Type = PropertyType.SharedString;
            prop.Value = contents;

            return true;
        }
    }
}
