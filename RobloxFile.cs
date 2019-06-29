using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RobloxFiles
{
    /// <summary>
    /// Represents a loaded *.rbxl/*.rbxm Roblox file.
    /// The contents of the RobloxFile are stored as its children.
    /// </summary>
    public abstract class RobloxFile : Instance
    {
        protected abstract void ReadFile(byte[] buffer);
        public abstract void Save(Stream stream);
        
        /// <summary>
        /// Opens a RobloxFile using the provided buffer.
        /// </summary>
        public static RobloxFile Open(byte[] buffer)
        {
            if (buffer.Length > 14)
            {
                string header = Encoding.UTF7.GetString(buffer, 0, 14);
                RobloxFile file = null;

                if (header == BinaryRobloxFile.MagicHeader)
                    file = new BinaryRobloxFile();
                else if (header.StartsWith("<roblox"))
                    file = new XmlRobloxFile();

                if (file != null)
                {
                    file.ReadFile(buffer);
                    return file;
                }
            }

            throw new Exception("Unrecognized header!");
        }
        
        /// <summary>
        /// Opens a Roblox file by reading from a provided Stream.
        /// </summary>
        /// <param name="stream">The stream to read the Roblox file from.</param>
        public static RobloxFile Open(Stream stream)
        {
            byte[] buffer;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                buffer = memoryStream.ToArray();
            }

            return Open(buffer);
        }

        /// <summary>
        /// Opens a Roblox file from a provided file path.
        /// </summary>
        /// <param name="filePath">A path to a Roblox file to be opened.</param>
        public static RobloxFile Open(string filePath)
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            return Open(buffer);
        }

        /// <summary>
        /// Creates and runs a Task to open a Roblox file from a byte sequence that represents the file.
        /// </summary>
        /// <param name="buffer">A byte sequence that represents the file.</param>
        public static Task<RobloxFile> OpenAsync(byte[] buffer)
        {
            return Task.Run(() => Open(buffer));
        }

        /// <summary>
        /// Creates and runs a Task to open a Roblox file using a provided Stream.
        /// </summary>
        /// <param name="stream">The stream to read the Roblox file from.</param>
        public static Task<RobloxFile> OpenAsync(Stream stream)
        {
            return Task.Run(() => Open(stream));
        }

        /// <summary>
        /// Opens a Roblox file from a provided file path.
        /// </summary>
        /// <param name="filePath">A path to a Roblox file to be opened.</param>
        public static Task<RobloxFile> OpenAsync(string filePath)
        {
            return Task.Run(() => Open(filePath));
        }
    }
}
