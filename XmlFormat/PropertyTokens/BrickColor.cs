using System.Xml;
using Roblox.DataTypes;

namespace Roblox.XmlFormat.PropertyTokens
{
    public class BrickColorToken : IXmlPropertyToken
    {
        public string Token => "BrickColor";
        // ^ This is a lie: The token is actually int, but that would cause a name collision.
        //   Since BrickColors are written as ints, the IntToken class will try to redirect 
        //   to this handler if it believes that its representing a BrickColor.

        public bool ReadToken(Property prop, XmlNode token)
        {
            bool success = XmlPropertyTokens.ReadTokenGeneric<int>(prop, PropertyType.BrickColor, token);

            if (success)
            {
                int value = (int)prop.Value;
                try
                {
                    BrickColor brickColor = BrickColor.FromNumber(value);
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
    }
}
