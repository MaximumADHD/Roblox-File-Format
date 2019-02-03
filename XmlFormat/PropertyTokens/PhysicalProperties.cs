using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class PhysicalPropertiesToken : IXmlPropertyToken
    {
        public string Token => "PhysicalProperties";

        private Func<string, T> createReader<T>(Func<string, T> parse, XmlNode token) where T : struct
        {
            return new Func<string, T>(key =>
            {
                XmlElement node = token[key];
                return parse(node.InnerText);
            });
        }

        public bool ReadToken(Property prop, XmlNode token)
        {
            var readBool = createReader(bool.Parse, token);
            var readFloat = createReader(XmlPropertyTokens.ParseFloat, token);

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
    }
}
