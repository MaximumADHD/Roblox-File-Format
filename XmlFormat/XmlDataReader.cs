using System;
using System.Collections.Generic;
using System.Xml;

namespace RobloxFiles.XmlFormat
{
    public static class XmlDataReader
    {
        public static void ReadProperties(Instance instance, XmlNode propsNode)
        {
            if (propsNode.Name != "Properties")
                throw new Exception("XmlDataReader.ReadProperties: Provided XmlNode's class should be 'Properties'!");

            foreach (XmlNode propNode in propsNode.ChildNodes)
            {
                string propType = propNode.Name;
                XmlNode propName = propNode.Attributes.GetNamedItem("name");

                if (propName == null)
                    throw new Exception("XmlDataReader.ReadProperties: Got a property node without a 'name' attribute!");

                IXmlPropertyToken tokenHandler = XmlPropertyTokens.GetHandler(propType);

                if (tokenHandler != null)
                {
                    Property prop = new Property();
                    prop.Name = propName.InnerText;
                    prop.Instance = instance;

                    if (!tokenHandler.ReadToken(prop, propNode))
                        Console.WriteLine("XmlDataReader.ReadProperties:  Could not read property: " + prop.GetFullName() + '!');

                    instance.AddProperty(ref prop);
                }
                else
                {
                    Console.WriteLine("XmlDataReader.ReadProperties: No IXmlPropertyToken found for property type: " + propType + '!');
                }
            }
        }

        public static Instance ReadInstance(XmlNode instNode, XmlRobloxFile file = null)
        {
            // Process the instance itself
            if (instNode.Name != "Item")
                throw new Exception("XmlDataReader.ReadInstance: Provided XmlNode's name should be 'Item'!");

            XmlNode classToken = instNode.Attributes.GetNamedItem("class");
            if (classToken == null)
                throw new Exception("XmlDataReader.ReadInstance: Got an Item without a defined 'class' attribute!");

            Instance inst = new Instance(classToken.InnerText);

            // The 'referent' attribute is optional, but should be defined if a Ref property needs to link to this Instance.
            XmlNode refToken = instNode.Attributes.GetNamedItem("referent");

            if (refToken != null && file != null)
            {
                string refId = refToken.InnerText;

                if (file.Instances.ContainsKey(refId))
                    throw new Exception("XmlDataReader.ReadInstance: Got an Item with a duplicate 'referent' attribute!");

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
