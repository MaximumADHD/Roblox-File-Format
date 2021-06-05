using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class RectToken : IXmlPropertyToken, IAttributeToken<Rect>
    {
        public string XmlPropertyToken => "Rect2D";
        public AttributeType AttributeType => AttributeType.Rect;
        private static readonly string[] XmlFields = new string[2] { "min", "max" };
        
        public bool ReadProperty(Property prop, XmlNode token)
        {
            try
            {
                Vector2[] read = new Vector2[XmlFields.Length];

                for (int i = 0; i < read.Length; i++)
                {
                    string field = XmlFields[i];
                    var fieldToken = token[field];
                    read[i] = Vector2Token.ReadVector2(fieldToken);
                }

                Vector2 min = read[0],
                        max = read[1];

                Rect rect = new Rect(min, max);
                prop.Type = PropertyType.Rect;
                prop.Value = rect;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            Rect rect = prop.CastValue<Rect>();

            XmlElement min = doc.CreateElement("min");
            Vector2Token.WriteVector2(doc, min, rect.Min);
            node.AppendChild(min);

            XmlElement max = doc.CreateElement("max");
            Vector2Token.WriteVector2(doc, max, rect.Max);
            node.AppendChild(max);
        }

        public Rect ReadAttribute(RbxAttribute attr)
        {
            Vector2 min = Vector2Token.ReadVector2(attr);
            Vector2 max = Vector2Token.ReadVector2(attr);

            return new Rect(min, max);
        }

        public void WriteAttribute(RbxAttribute attr, Rect value)
        {
            Vector2Token.WriteVector2(attr, value.Min);
            Vector2Token.WriteVector2(attr, value.Max);
        }
    }
}
