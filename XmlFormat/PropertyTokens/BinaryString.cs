using System;
using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class BinaryStringToken : IXmlPropertyToken
    {
        public string Token => "BinaryString";

        public bool ReadToken(Property prop, XmlNode token)
        {
            // BinaryStrings are encoded in base64
            string base64 = token.InnerText;
            prop.Type = PropertyType.String;
            prop.Value = base64;

            byte[] buffer = Convert.FromBase64String(base64);
            prop.SetRawBuffer(buffer);
            
            return true;
        }
    }
}
