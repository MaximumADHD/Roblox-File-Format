using System.Xml;

namespace Roblox.XmlFormat.PropertyTokens
{
    public class FloatToken : IXmlPropertyToken
    {
        public string Token => "float";

        public bool ReadToken(Property prop, XmlNode token)
        {
            try
            {
                float value = XmlPropertyTokens.ParseFloat(token.InnerText);
                prop.Type = PropertyType.Float;
                prop.Value = value;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}