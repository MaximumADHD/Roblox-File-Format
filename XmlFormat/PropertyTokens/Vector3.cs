using System.Xml;
using Roblox.DataTypes;

namespace Roblox.XmlFormat.PropertyTokens
{
    public class Vector3Token : IXmlPropertyToken
    {
        public string Token => "Vector3";
        private static string[] Coords = new string[3] { "X", "Y", "Z" };

        public static Vector3? ReadVector3(XmlNode token)
        {
            float[] xyz = new float[3];

            for (int i = 0; i < 3; i++)
            {
                string key = Coords[i];

                try
                {
                    var coord = token[key];
                    xyz[i] = XmlPropertyTokens.ParseFloat(coord.InnerText);
                }
                catch
                {
                    return null;
                }
            }

            return new Vector3(xyz);
        }

        public bool ReadToken(Property property, XmlNode token)
        {
            Vector3? result = ReadVector3(token);
            bool success = (result != null);

            if (success)
            {
                property.Type = PropertyType.Vector3;
                property.Value = result;
            }

            return success;
        }
    }
}
