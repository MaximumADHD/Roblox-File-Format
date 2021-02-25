using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class RayToken : IXmlPropertyToken
    {
        public string XmlPropertyToken => "Ray";
        private static readonly string[] Fields = new string[2] { "origin", "direction" };

        public bool ReadProperty(Property prop, XmlNode token)
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

                Vector3 origin = read[0],
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

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            Ray ray = prop.CastValue<Ray>();

            XmlElement origin = doc.CreateElement("origin");
            XmlElement direction = doc.CreateElement("direction");

            Vector3Token.WriteVector3(doc, origin, ray.Origin);
            Vector3Token.WriteVector3(doc, direction, ray.Direction);

            node.AppendChild(origin);
            node.AppendChild(direction);
        }
    }
}
