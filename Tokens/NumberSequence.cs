using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class NumberSequenceToken : IXmlPropertyToken, IAttributeToken<NumberSequence>
    {
        public string XmlPropertyToken => "NumberSequence";
        public AttributeType AttributeType => AttributeType.NumberSequence;

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

        public NumberSequence ReadAttribute(RbxAttribute attr)
        {
            int numKeys = attr.ReadInt();
            var keypoints = new NumberSequenceKeypoint[numKeys];

            for (int i = 0; i < numKeys; i++)
            {
                float envelope = attr.ReadInt(),
                      time = attr.ReadFloat(),
                      value = attr.ReadFloat();

                keypoints[i] = new NumberSequenceKeypoint(time, value, envelope);
            }

            return new NumberSequence(keypoints);
        }

        public void WriteAttribute(RbxAttribute attr, NumberSequence value)
        {
            attr.WriteInt(value.Keypoints.Length);

            foreach (var keypoint in value.Keypoints)
            {
                attr.WriteFloat(keypoint.Envelope);
                attr.WriteFloat(keypoint.Time);
                attr.WriteFloat(keypoint.Value);
            }
        }
    }
}
