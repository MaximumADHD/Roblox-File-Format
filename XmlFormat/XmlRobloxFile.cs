using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Text;
using System.Xml;

using RobloxFiles.DataTypes;
using RobloxFiles.XmlFormat;

namespace RobloxFiles
{
    public class XmlRobloxFile : RobloxFile
    {
        public readonly XmlDocument XmlDocument = new XmlDocument();

        internal Dictionary<string, Instance> Instances = new Dictionary<string, Instance>();
        internal HashSet<string> SharedStrings = new HashSet<string>();

        private Dictionary<string, string> RawMetadata = new Dictionary<string, string>();
        public Dictionary<string, string> Metadata => RawMetadata;

        public XmlRobloxFile()
        {
            Name = "XmlRobloxFile";
            ParentLocked = true;
            Referent = "null";
        }
        
        protected override void ReadFile(byte[] buffer)
        {
            try
            {
                string xml = Encoding.UTF8.GetString(buffer);
                XmlDocument.LoadXml(xml);
            }
            catch
            {
                throw new Exception("XmlRobloxFile: Could not read provided buffer as XML!");
            }

            XmlNode roblox = XmlDocument.FirstChild;
            
            if (roblox != null && roblox.Name == "roblox")
            {
                // Verify the version we are using.
                XmlNode version = roblox.Attributes.GetNamedItem("version");
                int schemaVersion;

                if (version == null || !int.TryParse(version.Value, out schemaVersion))
                    throw new Exception("XmlRobloxFile: No version number defined!");
                else if (schemaVersion < 4)
                    throw new Exception("XmlRobloxFile: Provided version must be at least 4!");

                // Process the instances.
                foreach (XmlNode child in roblox.ChildNodes)
                {
                    if (child.Name == "Item")
                    {
                        Instance item = XmlRobloxFileReader.ReadInstance(child, this);
                        item.Parent = this;
                    }
                    else if (child.Name == "SharedStrings")
                    {
                        XmlRobloxFileReader.ReadSharedStrings(child, this);
                    }
                    else if (child.Name == "Meta")
                    {
                        XmlRobloxFileReader.ReadMetadata(child, this);
                    }
                }

                // Query the properties.
                var allProps = Instances.Values
                    .SelectMany(inst => inst.Properties)
                    .Select(pair => pair.Value);

                // Resolve referent properties.
                var refProps = allProps.Where(prop => prop.Type == PropertyType.Ref);
                  
                foreach (Property refProp in refProps)
                {
                    string refId = refProp.XmlToken;
                    refProp.XmlToken = "Ref";

                    if (Instances.ContainsKey(refId))
                    {
                        Instance refInst = Instances[refId];
                        refProp.Value = refInst;
                    }
                    else if (refId != "null")
                    {
                        string name = refProp.GetFullName();
                        Console.WriteLine("XmlRobloxFile: Could not resolve reference for {0}", name);
                        refProp.Value = null;
                    }
                }

                // Record shared strings.
                var sharedProps = allProps.Where(prop => prop.Type == PropertyType.SharedString);

                foreach (Property sharedProp in sharedProps)
                {
                    SharedString shared = sharedProp.CastValue<SharedString>();
                    SharedStrings.Add(shared.Key);
                }
            }
            else
            {
                throw new Exception("XmlRobloxFile: No 'roblox' element found!");
            }
        }

        public override void Save(Stream stream)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement roblox = doc.CreateElement("roblox");
            roblox.SetAttribute("version", "4");
            doc.AppendChild(roblox);

            Instances.Clear();
            SharedStrings.Clear();

            // First, append the metadata
            foreach (string key in Metadata.Keys)
            {
                string value = Metadata[key];

                XmlElement meta = doc.CreateElement("Meta");
                meta.SetAttribute("name", key);
                meta.InnerText = value;
                
                roblox.AppendChild(meta);
            }

            Instance[] children = GetChildren();

            // Record all of the instances.
            foreach (Instance inst in children)
                XmlRobloxFileWriter.RecordInstances(this, inst);

            // Now append them into the document.
            foreach (Instance inst in children)
            {
                if (inst.Archivable)
                {
                    XmlNode instNode = XmlRobloxFileWriter.WriteInstance(inst, doc, this);
                    roblox.AppendChild(instNode);
                }
            }

            // Append the shared strings.
            if (SharedStrings.Count > 0)
            {
                XmlNode sharedStrings = XmlRobloxFileWriter.WriteSharedStrings(doc, this);
                roblox.AppendChild(sharedStrings);
            }

            // Write the XML file.
            using (StringWriter buffer = new StringWriter())
            {
                XmlWriterSettings settings = XmlRobloxFileWriter.Settings;
                
                using (XmlWriter xmlWriter = XmlWriter.Create(buffer, settings))
                    doc.WriteContentTo(xmlWriter);

                string result = buffer.ToString()
                    .Replace("<![CDATA[]]>", "");
                
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    byte[] data = Encoding.UTF8.GetBytes(result);
                    stream.SetLength(0);
                    writer.Write(data);
                }
            }
        }
    }
}