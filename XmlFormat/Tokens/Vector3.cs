using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class Vector3Token : IXmlPropertyToken
    {
        public string Token => "Vector3";
        private static string[] Coords = new string[3] { "X", "Y", "Z" };

        public static Vector3 ReadVector3(XmlNode token)
        {
            float[] xyz = new float[3];

            for (int i = 0; i < 3; i++)
            {
                string key = Coords[i];

                try
                {
                    var coord = token[key];
                    xyz[i] = Formatting.ParseFloat(coord.InnerText);
                }
                catch
                {
                    return null;
                }
            }

            return new Vector3(xyz);
        }

        public static void WriteVector3(XmlDocument doc, XmlNode node, Vector3 value)
        {
            XmlElement x = doc.CreateElement("X");
            x.InnerText = value.X.ToInvariantString();
            node.AppendChild(x);

            XmlElement y = doc.CreateElement("Y");
            y.InnerText = value.Y.ToInvariantString();
            node.AppendChild(y);

            XmlElement z = doc.CreateElement("Z");
            z.InnerText = value.Z.ToInvariantString();
            node.AppendChild(z);
        }

        public bool ReadProperty(Property property, XmlNode token)
        {
            Vector3 result = ReadVector3(token);
            bool success = (result != null);

            if (success)
            {
                property.Type = PropertyType.Vector3;
                property.Value = result;
            }

            return success;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            Vector3 value = prop.CastValue<Vector3>();
            WriteVector3(doc, node, value);
        }
    }
}
