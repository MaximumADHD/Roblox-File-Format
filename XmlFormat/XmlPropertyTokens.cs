using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;
using System.Linq;
using System.Xml;

using RobloxFiles.Tokens;

namespace RobloxFiles.XmlFormat
{
    public static class XmlPropertyTokens
    {
        private static readonly Dictionary<string, IXmlPropertyToken> Handlers = new Dictionary<string, IXmlPropertyToken>();

        static XmlPropertyTokens()
        {
            // Initialize the PropertyToken handler singletons.
            Type IXmlPropertyToken = typeof(IXmlPropertyToken);
            var assembly = Assembly.GetExecutingAssembly();

            var handlerTypes = assembly.GetTypes()
                .Where(type => IXmlPropertyToken.IsAssignableFrom(type))
                .Where(type => type != IXmlPropertyToken);

            var propTokens = handlerTypes
                .Select(handlerType => Activator.CreateInstance(handlerType))
                .Cast<IXmlPropertyToken>();

            foreach (IXmlPropertyToken propToken in propTokens)
            {
                var tokens = propToken.XmlPropertyToken.Split(';')
                    .Select(token => token.Trim())
                    .ToList();

                tokens.ForEach(token => Handlers.Add(token, propToken));
            }
        }

        public static bool ReadPropertyGeneric<T>(XmlNode token, out T outValue) where T : struct
        {
            if (token == null)
            {
                var name = nameof(token);
                throw new ArgumentNullException(name);
            }
            
            try
            {
                string value = token.InnerText;
                Type type = typeof(T);

                object result = null;

                if (type == typeof(int))
                    result = Formatting.ParseInt(value);
                else if (type == typeof(float))
                    result = Formatting.ParseFloat(value);
                else if (type == typeof(double))
                    result = Formatting.ParseDouble(value);

                if (result == null)
                {
                    Type resultType = typeof(T);
                    var converter = TypeDescriptor.GetConverter(resultType);
                    result = converter.ConvertFromString(token.InnerText);
                }

                outValue = (T)result;
                return true;
            }
            catch (NotSupportedException)
            {
                outValue = default;
                return false;
            }
        }

        public static bool ReadPropertyGeneric<T>(Property prop, PropertyType propType, XmlNode token) where T : struct
        {
            if (prop == null)
            {
                var name = nameof(prop);
                throw new ArgumentNullException(name);
            }

            if (ReadPropertyGeneric(token, out T result))
            {
                prop.Type = propType;
                prop.Value = result;

                return true;
            }

            return false;
        }

        public static IXmlPropertyToken GetHandler(string tokenName)
        {
            IXmlPropertyToken result = null;

            if (Handlers.ContainsKey(tokenName))
                result = Handlers[tokenName];

            return result;
        }

        public static T GetHandler<T>() where T : IXmlPropertyToken
        {
            IXmlPropertyToken result = Handlers.Values
                .Where(token => token is T)
                .First();

            return (T)result;
        }
    }
}
