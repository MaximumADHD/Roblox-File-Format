using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class Vector2Token : IXmlPropertyToken, IAttributeToken<Vector2>
    {
        public string XmlPropertyToken => "Vector2";
        private static readonly string[] XmlCoords = new string[2] { "X", "Y" };

        public AttributeType AttributeType => AttributeType.Vector2;
        public Vector2 ReadAttribute(RbxAttribute attr) => ReadVector2(attr);
        public void WriteAttribute(RbxAttribute attr, Vector2 value) => WriteVector2(attr, value);

        public static Vector2 ReadVector2(XmlNode token)
        {
            float[] xy = new float[2];

            for (int i = 0; i < 2; i++)
            {
                string key = XmlCoords[i];

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

        public static Vector2 ReadVector2(RbxAttribute attr)
        {
            float x = attr.ReadFloat(),
                  y = attr.ReadFloat();

            return new Vector2(x, y);
        }

        public static void WriteVector2(RbxAttribute attr, Vector2 value)
        {
            attr.WriteFloat(value.X);
            attr.WriteFloat(value.Y);
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
