using System.Text;
using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class StringToken : IXmlPropertyToken
    {
        public string Token => "string; ProtectedString";

        public bool ReadToken(Property prop, XmlNode token)
        {
            string contents = token.InnerText;
            prop.Type = PropertyType.String;
            prop.Value = contents;

            byte[] buffer = Encoding.UTF8.GetBytes(contents);
            prop.SetRawBuffer(buffer);

            return true;
        }
    }
}
