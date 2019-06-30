using System;
using System.Text;
using System.Xml;

using RobloxFiles.DataTypes;
using RobloxFiles.XmlFormat.PropertyTokens;

namespace RobloxFiles.XmlFormat
{
    public static class XmlRobloxFileWriter
    {
        public static readonly XmlWriterSettings Settings = new XmlWriterSettings()
        {
            Indent = true,
            IndentChars = "\t",
            NewLineChars = "\r\n",
            Encoding = Encoding.UTF8,
            OmitXmlDeclaration = true
        };

        public static string CreateReferent()
        {
            Guid referentGuid = Guid.NewGuid();

            string referent = "RBX" + referentGuid
                .ToString()
                .ToUpper();

            return referent.Replace("-", "");
        }

        private static string GetEnumName<T>(T item) where T : struct
        {
            return Enum.GetName(typeof(T), item);
        }

        internal static void RecordInstances(XmlRobloxFile file, Instance inst)
        {
            foreach (Instance child in inst.GetChildren())
                RecordInstances(file, child);

            if (inst.Referent == null || inst.Referent.Length < 35)
                inst.Referent = CreateReferent();

            file.Instances.Add(inst.Referent, inst);
        }

        public static XmlNode WriteProperty(Property prop, XmlDocument doc, XmlRobloxFile file)
        {
            string propType = prop.XmlToken;

            if (prop.XmlToken.Length == 0)
            {
                propType = GetEnumName(prop.Type);

                switch (prop.Type)
                {
                    case PropertyType.CFrame:
                    case PropertyType.Quaternion:
                        propType = "CoordinateFrame";
                        break;
                    case PropertyType.Enum:
                        propType = "token";
                        break;
                    case PropertyType.Rect:
                        propType = "Rect2D";
                        break;
                    case PropertyType.Int:
                    case PropertyType.Bool:
                    case PropertyType.Float:
                    case PropertyType.Int64:
                    case PropertyType.Double:
                        propType = propType.ToLower();
                        break;
                    case PropertyType.String:
                        propType = (prop.HasRawBuffer ? "BinaryString" : "string");
                        break;
                }
            }
            
            IXmlPropertyToken handler = XmlPropertyTokens.GetHandler(propType);

            if (handler == null)
            {
                Console.WriteLine("XmlDataWriter.WriteProperty: No token handler found for property type: {0}", propType);
                return null;
            }

            XmlElement propElement = doc.CreateElement(propType);
            propElement.SetAttribute("name", prop.Name);

            XmlNode propNode = propElement;
            handler.WriteProperty(prop, doc, propNode);

            if (propNode.ParentNode != null)
            {
                XmlNode newNode = propNode.ParentNode;
                newNode.RemoveChild(propNode);
                propNode = newNode;
            }

            if (prop.Type == PropertyType.SharedString)
            {
                SharedString value = prop.CastValue<SharedString>();
                file.SharedStrings.Add(value.MD5_Key);
            }

            return propNode;
        }

        public static XmlNode WriteInstance(Instance instance, XmlDocument doc, XmlRobloxFile file)
        {
            if (!instance.Archivable)
                return null;

            XmlElement instNode = doc.CreateElement("Item");
            instNode.SetAttribute("class", instance.ClassName);
            instNode.SetAttribute("referent", instance.Referent);

            XmlElement propsNode = doc.CreateElement("Properties");
            instNode.AppendChild(propsNode);

            var props = instance.RefreshProperties();
            
            foreach (string propName in props.Keys)
            {
                Property prop = props[propName];
                XmlNode propNode = WriteProperty(prop, doc, file);
                propsNode.AppendChild(propNode);
            }

            foreach (Instance child in instance.GetChildren())
            {
                if (child.Archivable)
                {
                    XmlNode childNode = WriteInstance(child, doc, file);
                    instNode.AppendChild(childNode);
                }
            }

            return instNode;
        }

        public static XmlNode WriteSharedStrings(XmlDocument doc, XmlRobloxFile file)
        {
            XmlElement sharedStrings = doc.CreateElement("SharedStrings");

            var binaryWriter = XmlPropertyTokens.GetHandler<BinaryStringToken>();
            var binaryBuffer = new Property("SharedString", PropertyType.String);

            foreach (string md5 in file.SharedStrings)
            {
                XmlElement sharedString = doc.CreateElement("SharedString");
                sharedString.SetAttribute("md5", md5);

                binaryBuffer.RawBuffer = SharedString.FindRecord(md5);
                binaryWriter.WriteProperty(binaryBuffer, doc, sharedString);

                sharedStrings.AppendChild(sharedString);
            }

            return sharedStrings;
        }
    }
}
