using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class UDimToken : IXmlPropertyToken
    {
        public string Token => "UDim";

        public static UDim ReadUDim(XmlNode token, string prefix = "")
        {
            try
            {
                XmlElement scaleToken = token[prefix + 'S'];
                float scale = Formatting.ParseFloat(scaleToken.InnerText);

                XmlElement offsetToken = token[prefix + 'O'];
                int offset = int.Parse(offsetToken.InnerText);

                return new UDim(scale, offset);
            }
            catch
            {
                return null;
            }
        }

        public static void WriteUDim(XmlDocument doc, XmlNode node, UDim value, string prefix = "")
        {
            XmlElement scale = doc.CreateElement(prefix + 'S');
            scale.InnerText = value.Scale.ToInvariantString();
            node.AppendChild(scale);

            XmlElement offset = doc.CreateElement(prefix + 'O');
            offset.InnerText = value.Offset.ToInvariantString();
            node.AppendChild(offset);
        }

        public bool ReadProperty(Property property, XmlNode token)
        {
            UDim result = ReadUDim(token);
            bool success = (result != null);

            if (success)
            {
                property.Type = PropertyType.UDim;
                property.Value = result;
            }

            return success;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            UDim value = prop.CastValue<UDim>();
            WriteUDim(doc, node, value);
        }
    }
}
