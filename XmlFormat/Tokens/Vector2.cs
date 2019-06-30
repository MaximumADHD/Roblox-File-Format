using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class Vector2Token : IXmlPropertyToken
    {
        public string Token => "Vector2";
        private static string[] Coords = new string[2] { "X", "Y" };

        public static Vector2 ReadVector2(XmlNode token)
        {
            float[] xy = new float[2];

            for (int i = 0; i < 2; i++)
            {
                string key = Coords[i];

                try
                {
                    var coord = token[key];
                    string text = coord.InnerText;
                    xy[i] = Formatting.ParseFloat(text);
                }
                catch
                {
                    return null;
                }
            }

            return new Vector2(xy);
        }

        public static void WriteVector2(XmlDocument doc, XmlNode node, Vector2 value)
        {
            XmlElement x = doc.CreateElement("X");
            x.InnerText = value.X.ToInvariantString();
            node.AppendChild(x);

            XmlElement y = doc.CreateElement("Y");
            y.InnerText = value.Y.ToInvariantString();
            node.AppendChild(y);
        }

        public bool ReadProperty(Property property, XmlNode token)
        {
            Vector2 result = ReadVector2(token);
            bool success = (result != null);

            if (success)
            {
                property.Type = PropertyType.Vector2;
                property.Value = result;
            }

            return success;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            Vector2 value = prop.CastValue<Vector2>();
            WriteVector2(doc, node, value);
        }
    }
}
