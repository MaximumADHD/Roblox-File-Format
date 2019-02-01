using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class UDim2Token : IXmlPropertyToken
    {
        public string Token => "UDim2";

        public bool ReadToken(Property property, XmlNode token)
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
    }
}
