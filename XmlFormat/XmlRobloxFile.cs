using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Xml;

namespace RobloxFiles.XmlFormat
{
    public class XmlRobloxFile : IRobloxFile
    {
        // IRobloxFile
        internal readonly Instance XmlContents = new Instance("Folder", "XmlRobloxFile");
        public Instance Contents => XmlContents;

        // Runtime Specific
        public readonly XmlDocument Root = new XmlDocument();
        public Dictionary<string, Instance> Instances = new Dictionary<string, Instance>();
        public Dictionary<string, string> SharedStrings = new Dictionary<string, string>();
        
        public void ReadFile(byte[] buffer)
        {
            try
            {
                string xml = Encoding.UTF8.GetString(buffer);
                Root.LoadXml(xml);
            }
            catch
            {
                throw new Exception("XmlRobloxFile: Could not read provided buffer as XML!");
            }

            XmlNode roblox = Root.FirstChild;

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
                        Instance item = XmlDataReader.ReadInstance(child, this);
                        item.Parent = XmlContents;
                    }
                    else if (child.Name == "SharedStrings")
                    {
                        XmlDataReader.ReadSharedStrings(child, this);
                    }
                }

                // Query the properties.
                var props = Instances.Values
                    .SelectMany(inst => inst.Properties)
                    .Select(pair => pair.Value);

                // Resolve referent properties.
                var refProps = props.Where(prop => prop.Type == PropertyType.Ref);
                  
                foreach (Property refProp in refProps)
                {
                    string refId = refProp.Value as string;

                    if (Instances.ContainsKey(refId))
                    {
                        Instance refInst = Instances[refId];
                        refProp.Value = refInst;
                    }
                    else if (refId != "null")
                    {
                        string name = refProp.GetFullName();
                        Console.WriteLine("XmlRobloxFile: Could not resolve reference for {0}", name);
                    }
                }

                // Resolve shared strings.
                var sharedProps = props.Where(prop => prop.Type == PropertyType.SharedString);

                foreach (Property sharedProp in sharedProps)
                {
                    string md5 = sharedProp.Value as string;

                    if (SharedStrings.ContainsKey(md5))
                    {
                        string value = SharedStrings[md5];
                        sharedProp.Value = value;

                        byte[] data = Convert.FromBase64String(value);
                        sharedProp.SetRawBuffer(data);

                        continue;
                    }

                    string name = sharedProp.GetFullName();
                    Console.WriteLine("XmlRobloxFile: Could not resolve shared string for {0}", name);
                }
            }
            else
            {
                throw new Exception("XmlRobloxFile: No 'roblox' tag found!");
            }
        }
    }
}