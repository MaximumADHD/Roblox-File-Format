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
            try
            {
                Vector3[] read = new Vector3[Fields.Length];

                for (int i = 0; i < read.Length; i++)
                {
                    string field = Fields[i];
                    var fieldToken = token[field];
                    read[i] = Vector3Token.ReadVector3(fieldToken);
                }

                Vector3 origin    = read[0],
                        direction = read[1];

                Ray ray = new Ray(origin, direction);
                prop.Type = PropertyType.Ray;
                prop.Value = ray;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
