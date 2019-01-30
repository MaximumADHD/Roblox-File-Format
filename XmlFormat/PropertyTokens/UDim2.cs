using System.Xml;
using Roblox.DataTypes;

namespace Roblox.XmlFormat.PropertyTokens
{
    public class UDim2Token : IXmlPropertyToken
    {
        public string Token => "UDim2";

        public bool ReadToken(Property property, XmlNode token)
        {
            UDim? xDim = UDimToken.ReadUDim(token, "X");
            UDim? yDim = UDimToken.ReadUDim(token, "Y");

            if (xDim != null && yDim != null)
            {
                property.Type = PropertyType.UDim2;
                property.Value = new UDim2(xDim.Value, yDim.Value);

                return true;
            }

            return false;
        }
    }
}
