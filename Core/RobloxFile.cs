using System;
using System.IO;
using System.Text;

using RobloxFiles.BinaryFormat;
using RobloxFiles.XmlFormat;

namespace RobloxFiles
{
    /// <summary>
    /// Interface which represents a RobloxFile implementation.
    /// </summary>
    public interface IRobloxFile
    {
        Instance Contents { get; }
        void ReadFile(byte[] buffer);
    }

    /// <summary>
    /// Represents a loaded *.rbxl/*.rbxm Roblox file.
    /// All of the surface-level Instances are stored in the RobloxFile's Trunk property.
    /// </summary>
    public class RobloxFile : IRobloxFile
    {
        public bool Initialized { get; private set; }
        public IRobloxFile InnerFile { get; private set; }

        public Instance Contents => InnerFile.Contents;

        public void ReadFile(byte[] buffer)
        {
            if (!Initialized)
            {
                if (buffer.Length > 14)
                {
                    string header = Encoding.UTF7.GetString(buffer, 0, 14);
                    IRobloxFile file = null;

                    if (header == BinaryRobloxFile.MagicHeader)
                        file = new BinaryRobloxFile();
                    else if (header.StartsWith("<roblox"))
                        file = new XmlRobloxFile();

                    if (file != null)
                    {
                        file.ReadFile(buffer);
                        InnerFile = file;

                        Initialized = true;
                        return;
                    }
                }

                throw new Exception("Unrecognized header!");
            }
        }

        public RobloxFile(byte[] buffer)
        {
            ReadFile(buffer);
        }

        public RobloxFile(Stream stream)
        {
            byte[] buffer;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                buffer = memoryStream.ToArray();
            }

            ReadFile(buffer);
        }

        public RobloxFile(string filePath)
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            ReadFile(buffer);
        }

        /// <summary>
        /// Treats the provided string as if you were indexing a specific child or descendant of the `RobloxFile.Contents` folder.<para/>
        /// The provided string can either be:<para/>
        /// - The name of a child that is parented to RobloxFile.Contents (  Example: RobloxFile["Workspace"]  )<para/>
        /// - A period (.) separated path to a descendant of RobloxFile.Contents (  Example: RobloxFile["Workspace.Terrain"]  )<para/>
        /// This will throw an exception if any instance in the traversal is not found.
        /// </summary>
        public Instance this[string accessor] => Contents[accessor];
    }
}
