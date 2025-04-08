using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;

using RobloxFiles.DataTypes;
using RobloxFiles.Utility;
using RobloxFiles.Tokens;

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
            var referentGuid = Guid
                .NewGuid()
                .ToString();

            string referent = "RBX" + referentGuid
                .ToUpper(CultureInfo.InvariantCulture)
                .Replace("-", "");

            return referent;
        }

        private static string GetEnumName<T>(T item) where T : struct
        {
            return Enum.GetName(typeof(T), item);
        }

        internal static void RecordInstances(XmlRobloxFile file, Instance inst)
        {
            inst.Referent = "RBX" + file.RefCounter++;

            foreach (Instance child in inst.GetChildren())
                RecordInstances(file, child);

            file.Instances.Add(inst.Referent, inst);
        }

        public static XmlNode WriteProperty(Property prop, XmlDocument doc, XmlRobloxFile file)
        {
            if (prop.Name == "Archivable")
                return null;

            string propType = prop.XmlToken;

            if (propType == null)
                propType = "";

            if (propType.Length == 0)
            {
                propType = GetEnumName(prop.Type);

                switch (prop.Type)
                {
                    case PropertyType.Ref:
                    {
                        propType = "Ref";
                        break;
                    }
                    case PropertyType.CFrame:
                    case PropertyType.Quaternion:
                    {
                        propType = "CoordinateFrame";
                        break;
                    }
                    case PropertyType.Enum:
                    {
                        propType = "token";
                        break;
                    }
                    case PropertyType.Rect:
                    {
                        propType = "Rect2D";
                        break;
                    }
                    case PropertyType.Int:
                    case PropertyType.Bool:
                    case PropertyType.Float:
                    case PropertyType.Int64:
                    case PropertyType.Double:
                    {
                        propType = propType.ToLower(CultureInfo.InvariantCulture);
                        break;
                    }
                    case PropertyType.String:
                    {
                        if (prop.Value is ContentId)
                            propType = "Content";
                        else if (prop.Value is ProtectedString)
                            propType = "ProtectedString";
                        else if (prop.Value is byte[])
                            propType = "BinaryString";
                        else
                            propType = "string";

                        break;
                    }
                }
            }

            if (prop.Type == PropertyType.Ref)
                propType = "Ref";
            
            IXmlPropertyToken handler = XmlPropertyTokens.GetHandler(propType);

            if (handler == null)
            {
                RobloxFile.LogError($"XmlRobloxFileWriter.WriteProperty: No token handler found for property type: {propType}");
                return null;
            }

            if (prop.Type == PropertyType.SharedString)
            {
                SharedString str = prop.CastValue<SharedString>();

                if (str == null)
                {
                    byte[] value = prop.CastValue<byte[]>();
                    str = SharedString.FromBuffer(value);
                }
                
                if (str.ComputedKey == null)
                {
                    var newShared = SharedString.FromBuffer(str.SharedValue);
                    str.Key = newShared.ComputedKey;
                }

                file.SharedStrings.Add(str.Key);
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

            var orderedKeys = props
                .OrderBy(pair => pair.Key)
                .Select(pair => pair.Key);
            
            foreach (string propName in orderedKeys)
            {
                Property prop = props[propName];
                bool isDefault = false;

                object a = DefaultProperty.Get(instance, prop);
                object b = prop.Value;

                if (a is double d0 && b is double d1)
                    isDefault = d0.FuzzyEquals(d1);
                else if (a is float f0 && b is float f1)
                    isDefault = f0.FuzzyEquals(f1);
                else if (b != null)
                    isDefault = b.Equals(a);
                else if (a == b)
                    isDefault = true;
                
                if (!isDefault || propName == "Name")
                {
                    XmlNode propNode = WriteProperty(prop, doc, file);

                    if (propNode == null)
                        continue;

                    propsNode.AppendChild(propNode);
                }
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
            Contract.Requires(doc != null && file != null);
            XmlElement sharedStrings = doc.CreateElement("SharedStrings");

            var binaryWriter = XmlPropertyTokens.GetHandler<BinaryStringToken>();
            var binaryBuffer = new Property("SharedString", PropertyType.String);

            foreach (string key in file.SharedStrings)
            {
                XmlElement sharedString = doc.CreateElement("SharedString");
                sharedString.SetAttribute("md5", key);

                binaryBuffer.RawBuffer = SharedString.Find(key);
                binaryWriter.WriteProperty(binaryBuffer, doc, sharedString);

                sharedStrings.AppendChild(sharedString);
            }

            return sharedStrings;
        }
    }
}
