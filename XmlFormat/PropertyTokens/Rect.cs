using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class RectToken : IXmlPropertyToken
    {
        public string Token => "Rect2D";
        private static string[] Fields = new string[2] { "min", "max" };

        public bool ReadToken(Property prop, XmlNode token)
        {
            Vector2[] read = new Vector2[Fields.Length];

            for (int i = 0; i < read.Length; i++)
            {
                string field = Fields[i];
                try
                {
                    var fieldToken = token[field];
                    Vector2? vector2 = Vector2Token.ReadVector2(fieldToken);
                    read[i] = vector2.Value;
                }
                catch
                {
                    return false;
                }
            }

            Vector2 min = read[0],
                    max = read[1];

            Rect rect = new Rect(min, max);
            prop.Type = PropertyType.Rect;
            prop.Value = rect;

            return true;
        }
    }
}
