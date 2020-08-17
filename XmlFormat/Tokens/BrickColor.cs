using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class BrickColorToken : IXmlPropertyToken
    {
        public string Token => "BrickColor";
        // ^ This is a lie: The token is actually int, but that would cause a name collision.
        //   Since BrickColors are written as ints, the IntToken class will try to redirect 
        //   to this handler if it believes that its representing a BrickColor.

        public bool ReadProperty(Property prop, XmlNode token)
        {
            if (XmlPropertyTokens.ReadPropertyGeneric(token, out int value))
            {
                BrickColor brickColor = BrickColor.FromNumber(value);
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
