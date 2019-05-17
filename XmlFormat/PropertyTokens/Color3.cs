using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class Color3Token : IXmlPropertyToken
    {
        public string Token => "Color3";
        private string[] Fields = new string[3] { "R", "G", "B" };

        public bool ReadToken(Property prop, XmlNode token)
        {
            bool success = true;
            float[] fields = new float[Fields.Length];

            for (int i = 0; i < fields.Length; i++)
            {
                string key = Fields[i];

                try
                {
                    var coord = token[key];
                    fields[i] = XmlPropertyTokens.ParseFloat(coord.InnerText);
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
                success = color3uint8.ReadToken(prop, token);
            }

            return success;
        }
    }
}
