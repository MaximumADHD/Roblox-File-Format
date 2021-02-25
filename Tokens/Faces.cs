using System.Diagnostics.Contracts;
using System.Xml;

using RobloxFiles.DataTypes;
using RobloxFiles.XmlFormat;

namespace RobloxFiles.Tokens
{
    public class FacesToken : IXmlPropertyToken
    {
        public string XmlPropertyToken => "Faces";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            Contract.Requires(prop != null);

            if (XmlPropertyTokens.ReadPropertyGeneric(token, out uint value))
            {
                Faces faces = (Faces)value;
                prop.Value = faces;

                return true;
            }

            return false;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            Contract.Requires(prop != null && doc != null && node != null);

            XmlElement faces = doc.CreateElement("faces");
            node.AppendChild(faces);

            int value = prop.CastValue<int>();
            faces.InnerText = value.ToInvariantString();
        }
    }
}
