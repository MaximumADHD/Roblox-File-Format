using System.Xml;
using RobloxFiles.DataTypes;
using RobloxFiles.XmlFormat;

namespace RobloxFiles.Tokens
{
    public class Color3Token : IXmlPropertyToken, IAttributeToken<Color3>
    {
        public string XmlPropertyToken => "Color3";
        private readonly string[] XmlFields = new string[3] { "R", "G", "B" };

        public AttributeType AttributeType => AttributeType.Color3;
        public Color3 ReadAttribute(RbxAttribute attr) => ReadColor3(attr);
        public void WriteAttribute(RbxAttribute attr, Color3 value) => WriteColor3(attr, value);

        public static Color3 ReadColor3(RbxAttribute attr)
        {
            float r = attr.ReadFloat(),
                  g = attr.ReadFloat(),
                  b = attr.ReadFloat();

            return new Color3(r, g, b);
        }

        public static void WriteColor3(RbxAttribute attr, Color3 value)
        {
            attr.WriteFloat(value.R);
            attr.WriteFloat(value.G);
            attr.WriteFloat(value.B);
        }

        public bool ReadProperty(Property prop, XmlNode token)
        {
            bool success = true;
            float[] fields = new float[XmlFields.Length];

            for (int i = 0; i < fields.Length; i++)
            {
                string key = XmlFields[i];

                try
                {
                    var coord = token[key];
                    string text = coord?.InnerText;

                    if (text == null)
                    {
                        text = "0";
                        success = false;
                    }

                    fields[i] = Formatting.ParseFloat(text);
                }
                catch
                {
                    success = false;
                    break;
                }
            }

            if (success)
            {
                float r = fields[0],
                      g = fields[1],
                      b = fields[2];

                prop.Type = PropertyType.Color3;
                prop.Value = new Color3(r, g, b);
            }
            else
            {
                // Try falling back to the Color3uint8 technique...
                var color3uint8 = XmlPropertyTokens.GetHandler<Color3uint8Token>();
                success = color3uint8.ReadProperty(prop, token);
            }

            return success;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            Color3 color = prop.CastValue<Color3>();
            float[] rgb = new float[3] { color.R, color.G, color.B };

            for (int i = 0; i < 3; i++)
            {
                string field = XmlFields[i];
                float value = rgb[i];

                XmlElement channel = doc.CreateElement(field);
                channel.InnerText = value.ToInvariantString();

                node.AppendChild(channel);
            }
        }
    }
}
