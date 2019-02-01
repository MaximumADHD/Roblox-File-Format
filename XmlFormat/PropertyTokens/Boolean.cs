using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class BoolToken : IXmlPropertyToken
    {
        public string Token => "bool";

        public bool ReadToken(Property prop, XmlNode token)
        {
            return XmlPropertyTokens.ReadTokenGeneric<bool>(prop, PropertyType.Bool, token);
        }
    }
}
