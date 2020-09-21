using System;
using System.Xml;

using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class ContentToken : IXmlPropertyToken
    {
        public string Token => "Content";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string data = token.InnerText;
            prop.Value = new Content(data);
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
                        if (!RobloxFile.LogErrors)
                            return true;

                        Console.Error.WriteLine("ContentToken: Got illegal base64 string: {0}", data);
                    }
                }
            }

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            string content = prop.CastValue<Content>();
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
            
            node.AppendChild(contentType);
        }
    }
}
