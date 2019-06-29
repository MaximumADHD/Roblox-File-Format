using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class NumberRangeToken : IXmlPropertyToken
    {
        public string Token => "NumberRange";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string contents = token.InnerText.Trim();
            string[] buffer = contents.Split(' ');
            bool valid = (buffer.Length == 2);

            if (valid)
            {
                try
                {
                    float min = Formatting.ParseFloat(buffer[0]);
                    float max = Formatting.ParseFloat(buffer[1]);

                    prop.Type = PropertyType.NumberRange;
                    prop.Value = new NumberRange(min, max);
                }
                catch
                {
                    valid = false;
                }
            }

            return valid;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            NumberRange value = prop.CastValue<NumberRange>();
            node.InnerText = value.ToString() + ' ';
        }
    }
}
