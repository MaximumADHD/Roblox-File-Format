using System;
using System.Linq;
using System.Reflection;

namespace RobloxFiles.Utility
{
    // This is a lazy helper class to disambiguate between FieldInfo and PropertyInfo
    internal class ImplicitMember
    {
        private const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase;
        
        private readonly object member;
        private readonly string inputName;
        
        private ImplicitMember(FieldInfo field, string name) 
        { 
            member = field;
            inputName = name;
        }
        private ImplicitMember(PropertyInfo prop, string name)
        {
            member = prop;
            inputName = name;
        }

        public static ImplicitMember Get(Type type, string name)
        {
            var field = type
                .GetFields(flags)
                .Where(f => f.Name == name)
                .FirstOrDefault();

            if (field != null)
                return new ImplicitMember(field, name);

            var prop = type
                .GetProperties(flags)
                .Where(p => p.Name == name)
                .FirstOrDefault();

            if (prop != null)
                return new ImplicitMember(prop, name);

            return null;
        }

        public Type MemberType
        {
            get
            {
                switch (member)
                {
                    case PropertyInfo prop:  return prop.PropertyType;
                    case FieldInfo field:    return field.FieldType;
                    
                    default:                 return null;
                }
            }
        }

        public object GetValue(object obj)
        {
            object result = null;

            switch (member)
            {
                case FieldInfo field:
                {
                    result = field.GetValue(obj);
                    break;
                }
                case PropertyInfo prop:
                {
                    result = prop.GetValue(obj);
                    break;
                }
            }

            return result;
        }

        public void SetValue(object obj, object value)
        {
            switch (member)
            {
                case FieldInfo field:
                {
                    field.SetValue(obj, value);
                    return;
                }
                case PropertyInfo prop:
                {
                    prop.SetValue(obj, value);
                    return;
                }
            }
            
            RobloxFile.LogError($"Unknown field '{inputName}' in ImplicitMember.SetValue");
        }
    }
}
