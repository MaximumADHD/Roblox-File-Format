using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class Vector3int16Token : IXmlPropertyToken
    {
        public string Token => "Vector3int16";
        private static string[] Coords = new string[3] { "X", "Y", "Z" };

        public bool ReadToken(Property property, XmlNode token)
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
    }
}
