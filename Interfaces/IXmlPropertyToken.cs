using System.Xml;

namespace RobloxFiles.Tokens
{
    public interface IXmlPropertyToken
    {
        string XmlPropertyToken { get; }

        bool ReadProperty(Property prop, XmlNode node);
        void WriteProperty(Property prop, XmlDocument doc, XmlNode node);
    }
}
