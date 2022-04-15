using System;
using System.Xml;

using RobloxFiles.Enums;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class FontToken : IXmlPropertyToken, IAttributeToken<FontFace>
    {
        public string XmlPropertyToken => "Font";
        public AttributeType AttributeType => AttributeType.FontFace;

        public bool ReadProperty(Property prop, XmlNode node)
        {
            try
            {
                var familyNode = node["Family"];
                var family = familyNode.InnerText;

                var weightNode = node["Weight"];
                var weight = (FontWeight)uint.Parse(weightNode.InnerText);

                var styleNode = node["Style"];
                Enum.TryParse(styleNode.InnerText, out FontStyle style);

                prop.Value = new FontFace(family, weight, style);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            FontFace font = prop.CastValue<FontFace>();
            var weight = (uint)font.Weight;

            string family = font.Family;
            string contentType = "null";

            if (family.Length > 0)
                contentType = "url";

            var contentNode = doc.CreateElement(contentType);
            contentNode.InnerText = family;

            var familyNode = doc.CreateElement("Family");
            familyNode.AppendChild(contentNode);
            node.AppendChild(familyNode);

            var weightNode = doc.CreateElement("Weight");
            weightNode.InnerText = $"{weight}";
            node.AppendChild(weightNode);

            var styleNode = doc.CreateElement("Style");
            styleNode.InnerText = $"{font.Style}";
            node.AppendChild(styleNode);
        }

        public FontFace ReadAttribute(RbxAttribute attribute)
        {
            var weight = (FontStyle)attribute.ReadShort();
            var style = (FontWeight)attribute.ReadByte();

            var family = attribute.ReadString();
            _ = attribute.ReadInt(); // Reserved

            return new FontFace(family, style, weight);
        }

        public void WriteAttribute(RbxAttribute attribute, FontFace value)
        {
            var weight = (short)value.Weight;
            var style = (byte)value.Style;

            var family = value.Family;
            var writer = attribute.Writer;

            writer.Write(weight);
            writer.Write(style);

            attribute.WriteString(family);
            attribute.WriteInt(0); // Reserved
        }
    }
}
