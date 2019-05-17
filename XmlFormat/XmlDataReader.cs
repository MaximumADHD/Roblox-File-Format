using System;
using System.Xml;

namespace RobloxFiles.XmlFormat
{
    public static class XmlDataReader
    {
        private static Func<string, Exception> createErrorHandler(string label)
        {
            var errorHandler = new Func<string, Exception>((message) =>
            {
                string contents = $"XmlDataReader.{label}: {message}";
                return new Exception(contents);
            });

            return errorHandler;
        }

        public static void ReadSharedStrings(XmlNode sharedStrings, XmlRobloxFile file)
        {
            var error = createErrorHandler("ReadSharedStrings");

            if (sharedStrings.Name != "SharedStrings")
                throw error("Provided XmlNode's class should be 'SharedStrings'!");

            foreach (XmlNode sharedString in sharedStrings)
            {
                if (sharedString.Name == "SharedString")
                {
                    XmlNode md5Node = sharedString.Attributes.GetNamedItem("md5");

                    if (md5Node == null)
                        throw error("Got a SharedString without an 'md5' attribute!");

                    string key = md5Node.InnerText;
                    string value = sharedString.InnerText.Replace("\n", "");

                    file.SharedStrings.Add(key, value);
                }
            }
        }

        public static void ReadProperties(Instance instance, XmlNode propsNode)
        {
            var error = createErrorHandler("ReadProperties");

            if (propsNode.Name != "Properties")
                throw error("Provided XmlNode's class should be 'Properties'!");

            foreach (XmlNode propNode in propsNode.ChildNodes)
            {
                string propType = propNode.Name;
                XmlNode propName = propNode.Attributes.GetNamedItem("name");

                if (propName == null)
                    throw error("Got a property node without a 'name' attribute!");

                IXmlPropertyToken tokenHandler = XmlPropertyTokens.GetHandler(propType);

                if (tokenHandler != null)
                {
                    Property prop = new Property();
                    prop.Name = propName.InnerText;
                    prop.Instance = instance;
                    prop.XmlToken = propType;

                    if (!tokenHandler.ReadProperty(prop, propNode))
                        Console.WriteLine("Could not read property: " + prop.GetFullName() + '!');

                    instance.AddProperty(ref prop);
                }
                else
                {
                    Console.WriteLine("No IXmlPropertyToken found for property type: " + propType + '!');
                }
            }
        }

        public static Instance ReadInstance(XmlNode instNode, XmlRobloxFile file)
        {
            var error = createErrorHandler("ReadInstance");

            // Process the instance itself
            if (instNode.Name != "Item")
                throw error("Provided XmlNode's name should be 'Item'!");

            XmlNode classToken = instNode.Attributes.GetNamedItem("class");
            if (classToken == null)
                throw error("Got an Item without a defined 'class' attribute!");

            Instance inst = new Instance(classToken.InnerText);

            // The 'referent' attribute is optional, but should be defined if a Ref property needs to link to this Instance.
            XmlNode refToken = instNode.Attributes.GetNamedItem("referent");

            if (refToken != null && file != null)
            {
                string refId = refToken.InnerText;

                if (file.Instances.ContainsKey(refId))
                    throw error("Got an Item with a duplicate 'referent' attribute!");

                file.Instances.Add(refId, inst);
            }

            // Process the child nodes of this instance.
            foreach (XmlNode childNode in instNode.ChildNodes)
            {
                if (childNode.Name == "Properties")
                {
                    ReadProperties(inst, childNode);
                }
                else if (childNode.Name == "Item")
                {
                    Instance child = ReadInstance(childNode, file);
                    child.Parent = inst;
                }
            }

            return inst;
        }
    }
}
