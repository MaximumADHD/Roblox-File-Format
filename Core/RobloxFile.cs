using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Roblox.BinaryFormat;
using Roblox.XmlFormat;

namespace Roblox
{
    /// <summary>
    /// Interface which represents a RobloxFile implementation.
    /// </summary>
    public interface IRobloxFile
    {
        IReadOnlyList<Instance> Trunk { get; }
        void Initialize(byte[] buffer);
    }

    /// <summary>
    /// Represents a loaded *.rbxl/*.rbxm Roblox file.
    /// All of the surface-level Instances are stored in the RobloxFile's Trunk property.
    /// </summary>
    public class RobloxFile : IRobloxFile
    {
        public bool Initialized { get; private set; }
        public IRobloxFile InnerFile { get; private set; }

        public IReadOnlyList<Instance> Trunk => InnerFile.Trunk;

        public void Initialize(byte[] buffer)
        {
            if (!Initialized)
            {
                if (buffer.Length > 14)
                {
                    string header = Encoding.UTF7.GetString(buffer, 0, 14);
                    IRobloxFile file = null;

                    if (header == RobloxBinaryFile.MagicHeader)
                        file = new RobloxBinaryFile();
                    else if (header.StartsWith("<roblox"))
                        file = new RobloxXmlFile();

                    if (file != null)
                    {
                        file.Initialize(buffer);
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
            Initialize(buffer);
        }

        public RobloxFile(Stream stream)
        {
            byte[] buffer;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                buffer = memoryStream.ToArray();
            }

            Initialize(buffer);
        }

        public RobloxFile(string filePath)
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            Initialize(buffer);
        }
    }
}
