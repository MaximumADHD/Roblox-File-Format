using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class RayToken : IXmlPropertyToken
    {
        public string Token => "Ray";
        private static string[] Fields = new string[2] { "origin", "direction" };

        public bool ReadToken(Property prop, XmlNode token)
        {
            Vector3[] read = new Vector3[Fields.Length];

            for (int i = 0; i < read.Length; i++)
            {
                string field = Fields[i];
                try
                {
                    var fieldToken = token[field];
                    Vector3? vector3 = Vector3Token.ReadVector3(fieldToken);
                    read[i] = vector3.Value;
                }
                catch
                {
                    return false;
                }
            }

            Vector3 origin    = read[0],
                    direction = read[1];

            Ray ray = new Ray(origin, direction);
            prop.Type = PropertyType.Ray;
            prop.Value = ray;

            return true;
        }
    }
}
