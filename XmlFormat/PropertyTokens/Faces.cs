using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class FacesToken : IXmlPropertyToken
    {
        public string Token => "Faces";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            bool success = XmlPropertyTokens.ReadPropertyGeneric<uint>(prop, PropertyType.Faces, token);

            if (success)
            {
                uint value = (uint)prop.Value;
                try
                {
                    Faces faces = (Faces)value;
                    prop.Value = faces;
                }
                catch
                {
                    success = false;
                }
            }

            return success;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            XmlElement faces = doc.CreateElement("faces");
            node.AppendChild(faces);

            int value = (int)prop.Value;
            faces.InnerText = value.ToInvariantString();
        }
    }
}
