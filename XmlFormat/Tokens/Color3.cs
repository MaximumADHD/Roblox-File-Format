using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class Color3Token : IXmlPropertyToken
    {
        public string Token => "Color3";
        private readonly string[] Fields = new string[3] { "R", "G", "B" };

        public bool ReadProperty(Property prop, XmlNode token)
        {
            bool success = true;
            float[] fields = new float[Fields.Length];

            for (int i = 0; i < fields.Length; i++)
            {
                string key = Fields[i];

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
                string field = Fields[i];
                float value = rgb[i];

                XmlElement channel = doc.CreateElement(field);
                channel.InnerText = value.ToInvariantString();

                node.AppendChild(channel);
            }
        }
    }
}
