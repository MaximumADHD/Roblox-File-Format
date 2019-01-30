using System;
using System.Xml;

namespace Roblox.XmlFormat.PropertyTokens
{
    public class ContentToken : IXmlPropertyToken
    {
        public string Token => "Content";

        public bool ReadToken(Property prop, XmlNode token)
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
    }
}
