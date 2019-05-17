using System;
using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class ContentToken : IXmlPropertyToken
    {
        public string Token => "Content";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string content = token.InnerText;
            prop.Type = PropertyType.String;
            prop.Value = content;

            if (token.HasChildNodes)
            {
                XmlNode childNode = token.FirstChild;
                string contentType = childNode.Name;

                if (contentType.StartsWith("binary") || contentType == "hash")
                {
                    // Roblox technically doesn't support this anymore, but load it anyway :P
                    byte[] buffer = Convert.FromBase64String(content);
                    prop.SetRawBuffer(buffer);
                }
            }

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            string content = prop.Value.ToString();
            string type = "null";

            if (prop.HasRawBuffer)
                type = "binary";
            else if (content.Length > 0)
                type = "url";

            XmlElement contentType = doc.CreateElement(type);
            contentType.InnerText = content;

            node.AppendChild(contentType);
        }
    }
}
