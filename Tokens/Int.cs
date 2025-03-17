using System.Xml;
using RobloxFiles.XmlFormat;

namespace RobloxFiles.Tokens
{
    public class IntToken : IXmlPropertyToken
    {
        public string XmlPropertyToken => "int";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            var obj = prop.Object;
            var type = obj.GetType();
            var field = type.GetField(prop.Name);

            if (field != null && field.FieldType.Name == "BrickColor")
            {
                var brickColorToken = XmlPropertyTokens.GetHandler<BrickColorToken>();
                return brickColorToken.ReadProperty(prop, token);
            }
            else
            {
                return XmlPropertyTokens.ReadPropertyGeneric<int>(prop, PropertyType.Int, token);
            }
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            int value = prop.CastValue<int>();
            node.InnerText = value.ToInvariantString();
        }
    }
}
