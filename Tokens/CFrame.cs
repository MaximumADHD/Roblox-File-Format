using System;
using System.Runtime.Remoting.Messaging;
using System.Xml;
using RobloxFiles.DataTypes;
using RobloxFiles.Enums;

namespace RobloxFiles.Tokens
{
    public class CFrameToken : IXmlPropertyToken, IAttributeToken<CFrame>
    {
        public string XmlPropertyToken => "CoordinateFrame; CFrame";
        public AttributeType AttributeType => AttributeType.CFrame;

        private static readonly string[] Coords = new string[12] 
        {
            "X",   "Y",   "Z", 
            "R00", "R01", "R02",
            "R10", "R11", "R12",
            "R20", "R21", "R22"
        };

        public static CFrame ReadCFrame(XmlNode token)
        {
            float[] components = new float[12];

            for (int i = 0; i < 12; i++)
            {
                string key = Coords[i];

                try
                {
                    var coord = token[key];
                    components[i] = Formatting.ParseFloat(coord.InnerText);
                }
                catch
                {
                    return null;
                }
            }

            return new CFrame(components);
        }

        public static void WriteCFrame(CFrame cf, XmlDocument doc, XmlNode node)
        {
            float[] components = cf.GetComponents();

            for (int i = 0; i < 12; i++)
            {
                string coordName = Coords[i];
                float coordValue = components[i];

                XmlElement coord = doc.CreateElement(coordName);
                coord.InnerText = coordValue.ToInvariantString();

                node.AppendChild(coord);
            }
        }

        public bool ReadProperty(Property prop, XmlNode token)
        {
            CFrame result = ReadCFrame(token);
            bool success = (result != null);

            if (success)
            {
                prop.Type = PropertyType.CFrame;
                prop.Value = result;
            }

            return success;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            CFrame value = prop.Value as CFrame;
            WriteCFrame(value, doc, node);
        }

        public CFrame ReadAttribute(RbxAttribute attribute)
        {
            float x = attribute.ReadFloat(),
                  y = attribute.ReadFloat(),
                  z = attribute.ReadFloat();

            byte orientId = attribute.ReadByte();
            var pos = new Vector3(x, y, z);

            if (orientId > 0)
            {
                return CFrame.FromOrientId(orientId - 1) + pos;
            }
            else
            {
                float[] matrix = new float[12];

                for (int i = 3; i < 12; i++)
                    matrix[i] = attribute.ReadFloat();

                return new CFrame(matrix) + pos;
            }
        }

        public void WriteAttribute(RbxAttribute attribute, CFrame value)
        {
            Vector3 pos = value.Position;
            Vector3Token.WriteVector3(attribute, pos);

            int orientId = value.GetOrientId();
            attribute.WriteByte((byte)(orientId + 1));

            if (orientId == -1)
            {
                float[] components = value.GetComponents();

                for (int i = 3; i < 12; i++)
                {
                    float component = components[i];
                    attribute.WriteFloat(component);
                }
            }
        }
    }
}
