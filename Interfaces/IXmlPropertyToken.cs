using System.Xml;

namespace RobloxFiles.Tokens
{
    public interface IXmlPropertyToken
    {
        string XmlPropertyToken { get; }

        bool ReadProperty(Property prop, XmlNode token);
        void WriteProperty(Property prop, XmlDocument doc, XmlNode node);
    }
}
