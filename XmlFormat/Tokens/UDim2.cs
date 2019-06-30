using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class UDim2Token : IXmlPropertyToken
    {
        public string Token => "UDim2";

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
