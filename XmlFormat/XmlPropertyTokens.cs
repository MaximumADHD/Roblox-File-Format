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

        public static bool ReadTokenGeneric<T>(Property prop, PropertyType propType, XmlNode token) where T : struct
        {
            Type resultType = typeof(T);
            TypeConverter converter = TypeDescriptor.GetConverter(resultType);

            if (converter != null)
            {
                object result = converter.ConvertFromString(token.InnerText);
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

        public static float ParseFloat(string value)
        {
            float result;

            if (value == "INF")
                result = float.PositiveInfinity;
            else if (value == "-INF")
                result = float.NegativeInfinity;
            else if (value == "NAN")
                result = float.NaN;
            else
                result = float.Parse(value);

            return result;
        }
    }
}
