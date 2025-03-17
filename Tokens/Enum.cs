using System;
using System.Diagnostics.Contracts;
using System.Xml;

using RobloxFiles.Utility;
using RobloxFiles.XmlFormat;

namespace RobloxFiles.Tokens
{
    public class EnumToken : IXmlPropertyToken, IAttributeToken<Enum>
    {
        public string XmlPropertyToken => "token";
        public AttributeType AttributeType => AttributeType.Enum;

        public bool ReadProperty(Property prop, XmlNode token)
        {
            Contract.Requires(prop != null);

            if (XmlPropertyTokens.ReadPropertyGeneric(token, out uint value))
            {
                RbxObject obj = prop.Object;
                Type instType = obj?.GetType();
                var info = ImplicitMember.Get(instType, prop.Name);

                if (info != null)
                {
                    Type enumType = info.MemberType;
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

        Enum IAttributeToken<Enum>.ReadAttribute(RbxAttribute attribute)
        {
            var enumName = attribute.ReadString();
            var enumValue = attribute.ReadUInt();

            var enumType = Type.GetType($"RobloxFiles.Enums.{enumName}");
            var isValid = enumType?.IsEnum;

            if (isValid ?? false)
            {
                var value = Enum.ToObject(enumType, enumValue);
                return (Enum)value;
            }

            // ... not sure what to do with this.
            return null;
        }

        void IAttributeToken<Enum>.WriteAttribute(RbxAttribute attribute, Enum value)
        {
            var enumType = value?.GetType();
            attribute.WriteString(enumType?.Name ?? "");

            var valueInt = Convert.ToUInt32(value);
            attribute.WriteUInt(valueInt);
        }
    }
}
