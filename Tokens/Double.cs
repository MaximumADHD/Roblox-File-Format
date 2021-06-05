using System.Xml;
using RobloxFiles.XmlFormat;

namespace RobloxFiles.Tokens
{
    public class DoubleToken : IXmlPropertyToken, IAttributeToken<double>
    {
        public string XmlPropertyToken => "double";
        public AttributeType AttributeType => AttributeType.Double;

        public double ReadAttribute(RbxAttribute attr) => attr.ReadDouble();
        public void WriteAttribute(RbxAttribute attr, double value) => attr.WriteDouble(value);

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
