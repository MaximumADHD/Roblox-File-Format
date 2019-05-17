using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;

using RobloxFiles;

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

        public static bool ReadPropertyGeneric<T>(Property prop, PropertyType propType, XmlNode token) where T : struct
        {
            try
            {
                string value = token.InnerText;

                if (typeof(T) == typeof(int))
                    prop.Value = Formatting.ParseInt(value);
                else if (typeof(T) == typeof(float))
                    prop.Value = Formatting.ParseFloat(value);
                else if (typeof(T) == typeof(double))
                    prop.Value = Formatting.ParseDouble(value);

                if (prop.Value == null)
                {
                    Type resultType = typeof(T);
                    TypeConverter converter = TypeDescriptor.GetConverter(resultType);

                    object result = converter.ConvertFromString(token.InnerText);
                    prop.Value = result;
                }

                prop.Type = propType;
                
                return true;
            }
            catch
            {
                return false;
            }
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
