using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Xml;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class EnumToken : IXmlPropertyToken
    {
        public string Token => "token";

        public bool ReadProperty(Property prop, XmlNode token)
        {
            Contract.Requires(prop != null);

            if (XmlPropertyTokens.ReadPropertyGeneric(token, out uint value))
            {
                Instance inst = prop.Instance;
                Type instType = inst?.GetType();

                FieldInfo info = instType.GetField(prop.Name, Property.BindingFlags);

                if (info != null)
                {
                    Type enumType = info.FieldType;
                    string item = value.ToInvariantString();

                    prop.Type = PropertyType.Enum;
                    prop.Value = Enum.Parse(enumType, item);

                    return true;
                }
            }

            return false;
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            Contract.Requires(prop != null && node != null);
            object rawValue = prop.Value;
            
            int signed = (int)rawValue;
            uint value = (uint)signed;

            node.InnerText = value.ToInvariantString();
        }
    }
}
