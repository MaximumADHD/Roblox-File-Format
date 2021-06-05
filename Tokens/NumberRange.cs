using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class NumberRangeToken : IXmlPropertyToken, IAttributeToken<NumberRange>
    {
        public string XmlPropertyToken => "NumberRange";
        public AttributeType AttributeType => AttributeType.NumberRange;

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

        public NumberRange ReadAttribute(RbxAttribute attr)
        {
            float min = attr.ReadFloat();
            float max = attr.ReadFloat();

            return new NumberRange(min, max);
        }

        public void WriteAttribute(RbxAttribute attr, NumberRange value)
        {
            attr.WriteFloat(value.Min);
            attr.WriteFloat(value.Max);
        }
    }
}
