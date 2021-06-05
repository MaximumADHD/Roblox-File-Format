using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class UDimToken : IXmlPropertyToken, IAttributeToken<UDim>
    {
        public string XmlPropertyToken => "UDim";
        public AttributeType AttributeType => AttributeType.UDim;
        
        public UDim ReadAttribute(RbxAttribute attr) => ReadUDim(attr);
        public void WriteAttribute(RbxAttribute attr, UDim value) => WriteUDim(attr, value);
        
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

        public static UDim ReadUDim(RbxAttribute attr)
        {
            float scale = attr.ReadFloat();
            int offset = attr.ReadInt();

            return new UDim(scale, offset);
        }

        public static void WriteUDim(RbxAttribute attr, UDim value)
        {
            float scale = value.Scale;
            attr.WriteFloat(scale);

            int offset = value.Offset;
            attr.WriteInt(offset);
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
