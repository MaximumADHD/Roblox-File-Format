using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class CFrameToken : IXmlPropertyToken
    {
        public string Token => "CoordinateFrame; CFrame";
        private static string[] Coords = new string[12] { "X", "Y", "Z", "R00", "R01", "R02", "R10", "R11", "R12", "R20", "R21", "R22"};

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
            CFrame cf = prop.CastValue<CFrame>();
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
    }
}
