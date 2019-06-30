using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class FacesToken : IXmlPropertyToken
    {
        public string Token => "Faces";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            uint value;

            if (XmlPropertyTokens.ReadPropertyGeneric(token, out value))
            {
                Faces faces = (Faces)value;
                prop.Value = faces;

                return true;
            }

            return false;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            XmlElement faces = doc.CreateElement("faces");
            node.AppendChild(faces);

            int value = prop.CastValue<int>();
            faces.InnerText = value.ToInvariantString();
        }
    }
}
