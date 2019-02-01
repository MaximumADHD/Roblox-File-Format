using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class DoubleToken : IXmlPropertyToken
    {
        public string Token => "double";

        public bool ReadToken(Property prop, XmlNode token)
        {
            return XmlPropertyTokens.ReadTokenGeneric<double>(prop, PropertyType.Double, token);
        }
    }
}
