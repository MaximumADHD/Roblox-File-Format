using System.Xml;

namespace Roblox.XmlFormat.PropertyTokens
{
    public class EnumToken : IXmlPropertyToken
    {
        public string Token => "token";

        public bool ReadToken(Property prop, XmlNode token)
        {
            return XmlPropertyTokens.ReadTokenGeneric<uint>(prop, PropertyType.Enum, token);
        }
    }
}
