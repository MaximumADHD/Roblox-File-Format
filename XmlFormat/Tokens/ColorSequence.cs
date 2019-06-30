using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class ColorSequenceToken : IXmlPropertyToken
    {
        public string Token => "ColorSequence";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string contents = token.InnerText.Trim();
            string[] buffer = contents.Split(' ');

            int length = buffer.Length;
            bool valid = (length % 5 == 0);

            if (valid)
            {
                try
                {
                    ColorSequenceKeypoint[] keypoints = new ColorSequenceKeypoint[length / 5];

                    for (int i = 0; i < length; i += 5)
                    {
                        float Time = Formatting.ParseFloat(buffer[i]);

                        float R = Formatting.ParseFloat(buffer[i + 1]);
                        float G = Formatting.ParseFloat(buffer[i + 2]);
                        float B = Formatting.ParseFloat(buffer[i + 3]);

                        Color3 Value = new Color3(R, G, B);
                        keypoints[i / 5] = new ColorSequenceKeypoint(Time, Value);
                    }

                    prop.Type = PropertyType.ColorSequence;
                    prop.Value = new ColorSequence(keypoints);
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
            ColorSequence value = prop.CastValue<ColorSequence>();
            node.InnerText = value.ToString() + ' ';
        }
    }
}
