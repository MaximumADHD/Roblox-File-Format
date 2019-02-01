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
                float scale = XmlPropertyTokens.ParseFloat(scaleToken.InnerText);

                XmlElement offsetToken = token[prefix + 'O'];
                int offset = int.Parse(offsetToken.InnerText);

                return new UDim(scale, offset);
            }
            catch
            {
                return null;
            }
        }

        public bool ReadToken(Property property, XmlNode token)
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
    }
}
