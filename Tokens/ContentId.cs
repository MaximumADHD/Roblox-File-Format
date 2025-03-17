using System;
using System.Xml;

using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class ContentIdToken : IXmlPropertyToken
    {
        // This is a lie, the token is "Content". A name collision between Content and ContentId.
        // The Content token will redirect here appropriately as needed.
        public string XmlPropertyToken => "ContentId";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string data = token.InnerText;
            prop.Value = new ContentId(data);
            prop.Type = PropertyType.String;

            if (token.HasChildNodes)
            {
                XmlNode childNode = token.FirstChild;
                string contentType = childNode.Name;

                if (contentType.StartsWith("binary") || contentType == "hash")
                {
                    try
                    {
                        // Roblox technically doesn't support this anymore, but load it anyway :P
                        byte[] buffer = Convert.FromBase64String(data);
                        prop.RawBuffer = buffer;
                    }
                    catch
                    {
                        RobloxFile.LogError($"ContentToken: Got illegal base64 string: {data}");
                    }
                }
            }

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            string content = prop.CastValue<ContentId>();
            string type = "null";

            if (prop.HasRawBuffer)
                type = "binary";
            else if (content.Length > 0)
                type = "url";

            XmlElement contentType = doc.CreateElement(type);

            if (type == "binary")
            {
                XmlCDataSection cdata = doc.CreateCDataSection(content);
                contentType.AppendChild(cdata);
            }
            else
            {
                contentType.InnerText = content;
            }

            XmlElement contentId = doc.CreateElement("Content");
            contentId.SetAttribute("name", prop.Name);
            contentId.AppendChild(contentType);
            contentId.AppendChild(node);
        }
    }
}