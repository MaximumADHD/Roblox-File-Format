using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class NumberSequenceToken : IXmlPropertyToken
    {
        public string Token => "NumberSequence";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string contents = token.InnerText.Trim();
            string[] buffer = contents.Split(' ');

            int length = buffer.Length;
            bool valid = (length % 3 == 0);

            if (valid)
            {
                try
                {
                    NumberSequenceKeypoint[] keypoints = new NumberSequenceKeypoint[length / 3];

                    for (int i = 0; i < length; i += 3)
                    {
                        float Time     = Formatting.ParseFloat(buffer[  i  ]);
                        float Value    = Formatting.ParseFloat(buffer[i + 1]);
                        float Envelope = Formatting.ParseFloat(buffer[i + 2]);

                        keypoints[i / 3] = new NumberSequenceKeypoint(Time, Value, Envelope);
                    }

                    prop.Type = PropertyType.NumberSequence;
                    prop.Value = new NumberSequence(keypoints);
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
            NumberSequence value = prop.CastValue<NumberSequence>();
            node.InnerText = value.ToString() + ' ';
        }
    }
}
