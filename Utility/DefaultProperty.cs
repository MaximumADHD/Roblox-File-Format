using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RobloxFiles.Utility
{
    public static class DefaultProperty
    {
        private static readonly Dictionary<string, Instance> ClassMap;
        private static readonly HashSet<Instance> Refreshed = new HashSet<Instance>();

        static DefaultProperty()
        {
            var Instance = typeof(Instance);
            var assembly = Assembly.GetExecutingAssembly();

            var classes = assembly.GetTypes()
                .Where(type => !type.IsAbstract && Instance.IsAssignableFrom(type))
                .Select(type => Activator.CreateInstance(type))
                .Cast<Instance>();

            ClassMap = classes.ToDictionary(inst => inst.ClassName);
        }

        public static object Get(string className, string propName)
        {
            if (!ClassMap.ContainsKey(className))
                return null;

            Instance inst = ClassMap[className];

            if (!Refreshed.Contains(inst))
            {
                inst.RefreshProperties();
                Refreshed.Add(inst);
            }

            var props = inst.Properties;

            if (!props.ContainsKey(propName))
                return null;

            var prop = props[propName];
            return prop.Value;
        }

        public static object Get(Instance inst, string propName)
        {
            return Get(inst.ClassName, propName);
        }

        public static object Get(Instance inst, Property prop)
        {
            return Get(inst.ClassName, prop.Name);
        }

        public static object Get(string className, Property prop)
        {
            return Get(className, prop.Name);
        }
    }
}
