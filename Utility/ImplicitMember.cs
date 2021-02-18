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
        
        private ImplicitMember(FieldInfo field) { member = field; }
        private ImplicitMember(PropertyInfo prop) { member = prop; }

        public static ImplicitMember Get(Type type, string name)
        {
            var field = type
                .GetFields(flags)
                .Where(f => f.Name == name)
                .FirstOrDefault();

            if (field != null)
                return new ImplicitMember(field);

            var prop = type
                .GetProperties(flags)
                .Where(p => p.Name == name)
                .FirstOrDefault();

            if (prop != null)
                return new ImplicitMember(prop);

            return null;
        }

        public Type MemberType
        {
            get
            {
                Type result = null;

                if (member is FieldInfo field)
                    result = field.FieldType;
                else if (member is PropertyInfo prop)
                    result = prop.PropertyType;

                return result;
            }
        }

        public object GetValue(object obj)
        {
            if (member is FieldInfo field)
                return field.GetValue(obj);
            else if (member is PropertyInfo prop)
                return prop.GetValue(obj);
            
            return null;
        }

        public void SetValue(object obj, object value)
        {
            if (member is FieldInfo field)
                field.SetValue(obj, value);
            else if (member is PropertyInfo prop)
                prop.SetValue(obj, value);

            RobloxFile.LogError("Unknown field in ImplicitMember.SetValue");
        }
    }
}
