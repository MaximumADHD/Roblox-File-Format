using System;
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
                var bytes = guid.ToByteArray();
                var random = BitConverter.ToUInt64(bytes, 0);

                var time = BitConverter.ToUInt32(bytes, 8);
                var index = BitConverter.ToUInt32(bytes, 12);

                prop.Value = new UniqueId(time, index, random);
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
