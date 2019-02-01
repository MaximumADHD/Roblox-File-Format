using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class NumberRangeToken : IXmlPropertyToken
    {
        public string Token => "NumberRange";

        public bool ReadToken(Property prop, XmlNode token)
        {
            string contents = token.InnerText.Trim();
            string[] buffer = contents.Split(' ');
            bool valid = (buffer.Length == 2);

            if (valid)
            {
                try
                {
                    float min = float.Parse(buffer[0]);
                    float max = float.Parse(buffer[1]);

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
    }
}
