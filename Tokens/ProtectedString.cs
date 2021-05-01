using System.Text;
using System.Xml;

using RobloxFiles.DataTypes;
using RobloxFiles.XmlFormat;

namespace RobloxFiles.Tokens
{
    public class ProtectedStringToken : IXmlPropertyToken
    {
        public string XmlPropertyToken => "ProtectedString";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            ProtectedString contents = token.InnerText;
            prop.Type = PropertyType.String;
            prop.Value = contents.ToString();

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            ProtectedString value = prop.CastValue<ProtectedString>();

            if (value.IsCompiled)
            {
                var binary = XmlPropertyTokens.GetHandler<BinaryStringToken>();
                binary.WriteProperty(prop, doc, node);
            }
            else
            {
                string contents = Encoding.UTF8.GetString(value.RawBuffer);

                if (contents.Contains("\r") || contents.Contains("\n"))
                {
                    XmlCDataSection cdata = doc.CreateCDataSection(contents);
                    node.AppendChild(cdata);
                }
                else
                {
                    node.InnerText = contents;
                }
            }
        }
    }
}
