using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class DoubleToken : IXmlPropertyToken
    {
        public string Token => "double";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            return XmlPropertyTokens.ReadPropertyGeneric<double>(prop, PropertyType.Double, token);
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            double value = prop.CastValue<double>();
            node.InnerText = value.ToInvariantString();
        }
    }
}
