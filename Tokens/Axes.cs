using System.Xml;

using RobloxFiles.DataTypes;
using RobloxFiles.XmlFormat;

namespace RobloxFiles.Tokens
{
    public class AxesToken : IXmlPropertyToken
    {
        public string XmlPropertyToken => "Axes";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            if (XmlPropertyTokens.ReadPropertyGeneric(token, out uint value))
            {
                Axes axes = (Axes)value;
                prop.Value = axes;

                return true;
            }

            return false;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            XmlElement axes = doc.CreateElement("axes");
            node.AppendChild(axes);

            int value = prop.CastValue<int>();
            axes.InnerText = value.ToInvariantString();
        }
    }
}
