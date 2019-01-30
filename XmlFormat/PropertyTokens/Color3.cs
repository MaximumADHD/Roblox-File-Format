using System;
using System.Xml;
using Roblox.DataTypes;

namespace Roblox.XmlFormat.PropertyTokens
{
    public class Color3Token : IXmlPropertyToken
    {
        public string Token => "Color3";
        private string[] LegacyFields = new string[3] { "R", "G", "B" };

        public bool ReadToken(Property prop, XmlNode token)
        {
            var color3uint8 = XmlPropertyTokens.GetHandler<Color3uint8Token>();
            bool success = color3uint8.ReadToken(prop, token);

            if (!success)
            {
                // Try the legacy technique.
                float[] fields = new float[LegacyFields.Length];

                for (int i = 0; i < fields.Length; i++)
                {
                    string key = LegacyFields[i];

                    try
                    {
                        var coord = token[key];
                        fields[i] = XmlPropertyTokens.ParseFloat(coord.InnerText);
                    }
                    catch
                    {
                        return false;
                    }
                }

                float r = fields[0],
                      g = fields[1],
                      b = fields[2];

                prop.Type = PropertyType.Color3;
                prop.Value = new Color3(r, g, b);

                success = true;
            }
            
            return success;
        }
    }
}
