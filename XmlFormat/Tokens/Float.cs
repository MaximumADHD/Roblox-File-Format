using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class FloatToken : IXmlPropertyToken
    {
        public string Token => "float";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            return XmlPropertyTokens.ReadPropertyGeneric<float>(prop, PropertyType.Float, token);
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            float value = prop.CastValue<float>();
            node.InnerText = value.ToInvariantString();
        }
    }
}