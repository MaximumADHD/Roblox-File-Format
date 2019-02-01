using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class NumberSequenceToken : IXmlPropertyToken
    {
        public string Token => "NumberSequence";

        public bool ReadToken(Property prop, XmlNode token)
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
                        float Time     = float.Parse(buffer[  i  ]);
                        float Value    = float.Parse(buffer[i + 1]);
                        float Envelope = float.Parse(buffer[i + 2]);

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
    }
}
