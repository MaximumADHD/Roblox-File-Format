using System.Xml;
using RobloxFiles.XmlFormat;

namespace RobloxFiles.Tokens
{
    public class FloatToken : IXmlPropertyToken, IAttributeToken<float>
    {
        public string XmlPropertyToken => "float";
        public AttributeType AttributeType => AttributeType.Float;

        public float ReadAttribute(RbxAttribute attr) => attr.ReadFloat();
        public void WriteAttribute(RbxAttribute attr, float value) => attr.WriteFloat(value);

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