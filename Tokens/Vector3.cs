using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class Vector3Token : IXmlPropertyToken, IAttributeToken<Vector3>
    {
        public string XmlPropertyToken => "Vector3";
        private static readonly string[] XmlCoords = new string[3] { "X", "Y", "Z" };

        public AttributeType AttributeType => AttributeType.Vector3;
        public Vector3 ReadAttribute(RbxAttribute attr) => ReadVector3(attr);
        public void WriteAttribute(RbxAttribute attr, Vector3 value) => WriteVector3(attr, value);

        public static Vector3 ReadVector3(XmlNode token)
        {
            float[] xyz = new float[3];

            for (int i = 0; i < 3; i++)
            {
                string key = XmlCoords[i];

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

        public static Vector3 ReadVector3(RbxAttribute attr)
        {
            float x = attr.ReadFloat(),
                  y = attr.ReadFloat(),
                  z = attr.ReadFloat();

            return new Vector3(x, y, z);
        }

        public static void WriteVector3(RbxAttribute attr, Vector3 value)
        {
            attr.WriteFloat(value.X);
            attr.WriteFloat(value.Y);
            attr.WriteFloat(value.Z);
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
