using System.Text;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class ProtectedStringToken : IXmlPropertyToken
    {
        public string Token => "ProtectedString";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            ProtectedString contents = token.InnerText;
            prop.Type = PropertyType.ProtectedString;
            prop.Value = contents;

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
