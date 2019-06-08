using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class RefToken : IXmlPropertyToken
    {
        public string Token => "Ref";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            string refId = token.InnerText;
            prop.Type = PropertyType.Ref;
            prop.Value = refId;

            return true;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            string result = "null";

            if (prop.Value != null && prop.Value.ToString() != "null")
            {
                Instance inst = prop.Value as Instance;
                result = inst.Referent;
            }

            node.InnerText = result;
        }
    }
}
