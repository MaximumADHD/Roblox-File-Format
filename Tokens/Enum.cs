using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Xml;

using RobloxFiles.XmlFormat;

namespace RobloxFiles.Tokens
{
    public class EnumToken : IXmlPropertyToken
    {
        public string XmlPropertyToken => "token";

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
            
            if (!(rawValue is uint value))
            {
                Type type = rawValue.GetType();

                if (type.IsEnum)
                {
                    var signed = (int)rawValue;
                    value = (uint)signed;
                }
                else
                {
                    value = 0;
                    RobloxFile.LogError($"Raw value for enum property {prop} could not be casted to uint!");
                }
            }

            node.InnerText = value.ToInvariantString();
        }
    }
}
