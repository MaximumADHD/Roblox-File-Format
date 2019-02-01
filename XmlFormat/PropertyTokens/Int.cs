using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class IntToken : IXmlPropertyToken
    {
        public string Token => "int";

        public bool ReadToken(Property prop, XmlNode token)
        {
            // BrickColors are represented by ints, see if 
            // we can infer when they should be a BrickColor.

            if (prop.Name.Contains("Color") || prop.Instance.ClassName.Contains("Color"))
            {
                var brickColorToken = XmlPropertyTokens.GetHandler<BrickColorToken>();
                return brickColorToken.ReadToken(prop, token);
            }
            else
            {
                return XmlPropertyTokens.ReadTokenGeneric<int>(prop, PropertyType.Int, token);
            }
        }
    }
}
