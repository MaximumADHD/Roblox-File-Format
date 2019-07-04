using System;
using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class BinaryStringToken : IXmlPropertyToken
    {
        public string Token => "BinaryString";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            // BinaryStrings are encoded in base64
            string base64 = token.InnerText.Replace("\n", "");
            byte[] buffer = Convert.FromBase64String(base64);

            prop.Value = buffer;
            prop.RawBuffer = buffer;
            prop.Type = PropertyType.String;
            
            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            byte[] data = prop.RawBuffer;
            string value = Convert.ToBase64String(data);
            
            if (value.Length > 72)
            {
                string buffer = "";

                while (value.Length > 72)
                {
                    string chunk = value.Substring(0, 72);
                    value = value.Substring(72);
                    buffer += chunk + '\n';
                }
                
                value = buffer + value;
            }
            
            XmlCDataSection cdata = doc.CreateCDataSection(value);
            node.AppendChild(cdata);
        }
    }
}
