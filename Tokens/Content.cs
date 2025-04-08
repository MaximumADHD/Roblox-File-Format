using System;
using System.Xml;

using RobloxFiles.Enums;
using RobloxFiles.DataTypes;
using RobloxFiles.XmlFormat;
using Newtonsoft.Json.Linq;

namespace RobloxFiles.Tokens
{
    public class ContentToken : IXmlPropertyToken
    {
        public string XmlPropertyToken => "Content";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            var obj = prop.Object;
            var objType = obj.GetType();
            var objField = objType.GetField(prop.Name);

            if (objField != null && objField.FieldType.Name == "ContentId")
            {
                var contentIdToken = XmlPropertyTokens.GetHandler<ContentIdToken>();
                return contentIdToken.ReadProperty(prop, token);
            }
            else
            {
                XmlNode childNode = token.FirstChild;
                string contentType = childNode.Name;

                if (contentType == "uri")
                    prop.Value = new Content(token.InnerText);
                else if (contentType == "Ref")
                    prop.Value = new Content(prop.File, token.InnerText);
                else
                    prop.Value = Content.None;

                prop.Type = PropertyType.Content;
                return true;
            }
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            var obj = prop.Object;
            var objType = obj.GetType();
            var objField = objType.GetField(prop.Name);

            if (objField != null && objField.FieldType.Name == "ContentId")
            {
                var contentIdToken = XmlPropertyTokens.GetHandler<ContentIdToken>();
                contentIdToken.WriteProperty(prop, doc, node);
            }
            else
            {
                var content = prop.CastValue<Content>();
                string type = "null";

                if (content.SourceType == ContentSourceType.None)
                    type = "null";
                else if (content.SourceType == ContentSourceType.Uri)
                    type = "uri";
                else if (content.SourceType == ContentSourceType.Object)
                    type = "Ref";

                XmlElement contentType = doc.CreateElement(type);

                if (content.SourceType == ContentSourceType.Uri)
                    contentType.InnerText = content.Uri;
                else if (content.SourceType == ContentSourceType.Object)
                    contentType.InnerText = content.Object.Referent;

                node.AppendChild(contentType);
            }
        }
    }
}
