using System;
using System.Collections.Generic;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Tokens
{
    public class PhysicalPropertiesToken : IXmlPropertyToken
    {
        public string XmlPropertyToken => "PhysicalProperties";

        private static Func<string, T> CreateReader<T>(Func<string, T> parse, XmlNode token) where T : struct
        {
            return new Func<string, T>(key =>
            {
                XmlElement node = token[key];
                return parse(node.InnerText);
            });
        }

        public bool ReadProperty(Property prop, XmlNode token)
        {
            var readBool = CreateReader(bool.Parse, token);
            var readFloat = CreateReader(Formatting.ParseFloat, token);

            try
            {
                bool custom = readBool("CustomPhysics");
                prop.Type = PropertyType.PhysicalProperties;

                if (custom)
                {
                    prop.Value = new PhysicalProperties
                    (
                        readFloat("Density"),
                        readFloat("Friction"),
                        readFloat("Elasticity"),
                        readFloat("FrictionWeight"),
                        readFloat("ElasticityWeight")
                    );
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            bool hasCustomPhysics = (prop.Value != null);

            XmlElement customPhysics = doc.CreateElement("CustomPhysics");
            customPhysics.InnerText = hasCustomPhysics
                .ToString()
                .ToLower();

            node.AppendChild(customPhysics);

            if (hasCustomPhysics)
            {
                var customProps = prop.CastValue<PhysicalProperties>();
                
                var data = new Dictionary<string, float>()
                {
                    { "Density", customProps.Density },
                    { "Friction", customProps.Friction },
                    { "Elasticity", customProps.Elasticity },
                    { "FrictionWeight", customProps.FrictionWeight },
                    { "ElasticityWeight", customProps.ElasticityWeight }
                };

                foreach (string elementType in data.Keys)
                {
                    float value = data[elementType];

                    XmlElement element = doc.CreateElement(elementType);
                    element.InnerText = value.ToInvariantString();

                    node.AppendChild(element);
                }
            }
        }
    }
}
