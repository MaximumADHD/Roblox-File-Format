using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;

namespace RobloxFiles.XmlFormat
{
    public static class XmlPropertyTokens
    {
        public static IReadOnlyDictionary<string, IXmlPropertyToken> Handlers;

        static XmlPropertyTokens()
        {
            // Initialize the PropertyToken handler singletons.
            Type IXmlPropertyToken = typeof(IXmlPropertyToken);

            var handlerTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type != IXmlPropertyToken)
                .Where(type => IXmlPropertyToken.IsAssignableFrom(type));

            var propTokens = handlerTypes.Select(handlerType => Activator.CreateInstance(handlerType) as IXmlPropertyToken);
            var tokenHandlers = new Dictionary<string, IXmlPropertyToken>();

            foreach (IXmlPropertyToken propToken in propTokens)
            {
                var tokens = propToken.Token.Split(';')
                    .Select(token => token.Trim())
                    .ToList();

                tokens.ForEach(token => tokenHandlers.Add(token, propToken));
            }

            Handlers = tokenHandlers;
        }

        public static bool ReadPropertyGeneric<T>(XmlNode token, out T outValue) where T : struct
        {
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
            catch
            {
                outValue = default(T);
                return false;
            }
        }

        public static bool ReadPropertyGeneric<T>(Property prop, PropertyType propType, XmlNode token) where T : struct
        {
            T result;

            if (ReadPropertyGeneric(token, out result))
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
