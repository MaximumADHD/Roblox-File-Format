using System.Xml;
using RobloxFiles.DataTypes;
using RobloxFiles.XmlFormat;

namespace RobloxFiles.Tokens
{
    public class BrickColorToken : IXmlPropertyToken, IAttributeToken<BrickColor>
    {
        // This is a lie: The token is actually int, but that would cause a name collision.
        // Since BrickColors are written as ints, the IntToken class will try to redirect 
        // to this handler if it believes that its representing a BrickColor.
        public string XmlPropertyToken => "BrickColor";
        public AttributeType AttributeType => AttributeType.BrickColor;

        public BrickColor ReadAttribute(RbxAttribute attr) => (BrickColorId)attr.ReadInt();
        public void WriteAttribute(RbxAttribute attr, BrickColor value) => attr.WriteInt(value.Number);
        
        public bool ReadProperty(Property prop, XmlNode token)
        {
            if (XmlPropertyTokens.ReadPropertyGeneric(token, out int value))
            {
                BrickColor brickColor = (BrickColorId)value;
                prop.XmlToken = "BrickColor";
                prop.Value = brickColor;

                return true;
            }
            
            return false;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            BrickColor value = prop.CastValue<BrickColor>();

            XmlElement brickColor = doc.CreateElement("int");
            brickColor.InnerText = value.Number.ToInvariantString();

            brickColor.SetAttribute("name", prop.Name);
            brickColor.AppendChild(node);
        }
    }
}
