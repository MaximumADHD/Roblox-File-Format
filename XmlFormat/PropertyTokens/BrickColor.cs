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
            bool success = XmlPropertyTokens.ReadPropertyGeneric<int>(prop, PropertyType.BrickColor, token);

            if (success)
            {
                int value = (int)prop.Value;

                try
                {
                    BrickColor brickColor = BrickColor.FromNumber(value);
                    prop.XmlToken = "BrickColor";
                    prop.Value = brickColor;
                }
                catch
                {
                    // Invalid BrickColor Id?
                    success = false;
                }
            }
            
            return success;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            BrickColor value = prop.Value as BrickColor;

            XmlElement brickColor = doc.CreateElement("int");
            brickColor.InnerText = value.Number.ToInvariantString();

            brickColor.SetAttribute("name", prop.Name);
            brickColor.AppendChild(node);
        }
    }
}
