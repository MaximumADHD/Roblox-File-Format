using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class Vector3int16Token : IXmlPropertyToken
    {
        public string XmlPropertyToken => "Vector3int16";
        private static readonly string[] Coords = new string[3] { "X", "Y", "Z" };

        public bool ReadProperty(Property property, XmlNode token)
        {
            short[] xyz = new short[3];

            for (int i = 0; i < 3; i++)
            {
                string key = Coords[i];

                try
                {
                    var coord = token[key];
                    xyz[i] = short.Parse(coord.InnerText);
                }
                catch
                {
                    return false;
                }
            }

            short x = xyz[0],
                  y = xyz[1],
                  z = xyz[2];

            property.Type = PropertyType.Vector3int16;
            property.Value = new Vector3int16(x, y, z);

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            Vector3int16 value = prop.CastValue<Vector3int16>();

            XmlElement x = doc.CreateElement("X");
            x.InnerText = value.X.ToString();
            node.AppendChild(x);

            XmlElement y = doc.CreateElement("Y");
            y.InnerText = value.Y.ToString();
            node.AppendChild(y);

            XmlElement z = doc.CreateElement("Z");
            z.InnerText = value.Z.ToString();
            node.AppendChild(z);
        }
    }
}
