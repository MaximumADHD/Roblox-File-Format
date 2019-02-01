using System.Xml;
using Roblox.DataTypes;

namespace Roblox.XmlFormat.PropertyTokens
{
    public class Vector2Token : IXmlPropertyToken
    {
        public string Token => "Vector2";
        private static string[] Coords = new string[2] { "X", "Y" };

        public static Vector2? ReadVector2(XmlNode token)
        {
            float[] xy = new float[2];

            for (int i = 0; i < 2; i++)
            {
                string key = Coords[i];

                try
                {
                    var coord = token[key];
                    string text = coord.InnerText;
                    xy[i] = XmlPropertyTokens.ParseFloat(text);
                }
                catch
                {
                    return null;
                }
            }

            return new Vector2(xy);
        }

        public bool ReadToken(Property property, XmlNode token)
        {
            Vector2? result = ReadVector2(token);
            bool success = result.HasValue;

            if (success)
            {
                property.Type = PropertyType.Vector2;
                property.Value = result.Value;
            }

            return success;
        }
    }
}
