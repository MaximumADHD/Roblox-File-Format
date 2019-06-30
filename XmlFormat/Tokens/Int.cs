using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class IntToken : IXmlPropertyToken
    {
        public string Token => "int";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            // BrickColors are represented by ints, see if 
            // we can infer when they should be a BrickColor.

            if (prop.Name.Contains("Color") || prop.Instance.ClassName.Contains("Color"))
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
