using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class RefToken : IXmlPropertyToken
    {
        public string Token => "Ref";

        public bool ReadToken(Property prop, XmlNode token)
        {
            string refId = token.InnerText;
            prop.Type = PropertyType.Ref;
            prop.Value = refId;

            return true;
        }
    }
}
