using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class Int64Token : IXmlPropertyToken
    {
        public string Token => "int64";

        public bool ReadToken(Property prop, XmlNode token)
        {
            return XmlPropertyTokens.ReadTokenGeneric<long>(prop, PropertyType.Int64, token);
        }
    }
}