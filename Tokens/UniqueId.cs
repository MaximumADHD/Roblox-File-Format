using System;
using System.Linq;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class UniqueIdToken : IXmlPropertyToken
    {
        public string XmlPropertyToken => "UniqueId";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string hex = token.InnerText;

            if (Guid.TryParse(hex, out var guid))
            {
                var bytes = new byte[16];

                for (int i = 0; i < 16; i++)
                {
                    var hexChar = hex.Substring(i * 2, 2);
                    bytes[15 - i] = Convert.ToByte(hexChar, 16);
                }

                var rand = BitConverter.ToInt64(bytes, 8);
                var time = BitConverter.ToUInt32(bytes, 4);
                var index = BitConverter.ToUInt32(bytes, 0);

                var uniqueId = new UniqueId(rand, time, index);
                prop.Value = uniqueId;

                return true;
            }

            return false;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            var uniqueId = prop.CastValue<UniqueId>();

            var random = BitConverter.GetBytes(uniqueId.Random);
            var time = BitConverter.GetBytes(uniqueId.Time);
            var index = BitConverter.GetBytes(uniqueId.Index);

            var bytes = new byte[16];
            random.CopyTo(bytes, 0);
            time.CopyTo(bytes, 8);
            index.CopyTo(bytes, 12);

            var guid = new Guid(bytes);
            node.InnerText = guid.ToString("N");
        }
    }
}
