using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class UDim2Token : IXmlPropertyToken, IAttributeToken<UDim2>
    {
        public string XmlPropertyToken => "UDim2";
        public AttributeType AttributeType => AttributeType.UDim2;

        public UDim2 ReadAttribute(RbxAttribute attr)
        {
            UDim x = UDimToken.ReadUDim(attr);
            UDim y = UDimToken.ReadUDim(attr);

            return new UDim2(x, y);
        }

        public void WriteAttribute(RbxAttribute attr, UDim2 value)
        {
            UDimToken.WriteUDim(attr, value.X);
            UDimToken.WriteUDim(attr, value.Y);
        }

        public bool ReadProperty(Property property, XmlNode token)
        {
            UDim xUDim = UDimToken.ReadUDim(token, "X");
            UDim yUDim = UDimToken.ReadUDim(token, "Y");

            if (xUDim != null && yUDim != null)
            {
                property.Type = PropertyType.UDim2;
                property.Value = new UDim2(xUDim, yUDim);

                return true;
            }

            return false;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            UDim2 value = prop.CastValue<UDim2>();

            UDim xUDim = value.X;
            UDimToken.WriteUDim(doc, node, xUDim, "X");

            UDim yUDim = value.Y;
            UDimToken.WriteUDim(doc, node, yUDim, "Y");
        }
    }
}
