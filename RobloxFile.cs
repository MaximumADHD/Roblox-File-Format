using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using RobloxFiles.BinaryFormat;
using RobloxFiles.XmlFormat;

namespace RobloxFiles
{
    /// <summary>
    /// Represents a loaded *.rbxl/*.rbxm Roblox file.
    /// All of the surface-level Instances are stored in the RobloxFile's 'Contents' property.
    /// </summary>
    public class RobloxFile : IRobloxFile
    {
        /// <summary>
        /// Indicates if this RobloxFile has loaded data already.
        /// </summary>
        public bool Initialized { get; private set; }

        /// <summary>
        /// A reference to the inner IRobloxFile implementation that this RobloxFile opened with.<para/>
        /// It can be a BinaryRobloxFile, or an XmlRobloxFile.
        /// </summary>
        public IRobloxFile InnerFile { get; private set; }

        /// <summary>
        /// A reference to a Folder Instance that stores all of the contents that were loaded.
        /// </summary>
        public Instance Contents => InnerFile.Contents;

        /// <summary>
        /// Initializes the RobloxFile from the provided buffer, if it hasn't been Initialized yet.
        /// </summary>
        /// <param name="buffer"></param>
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

        /// <summary>
        /// Creates a RobloxFile from a provided byte sequence that represents the file.
        /// </summary>
        /// <param name="buffer"></param>
        private RobloxFile(byte[] buffer)
        {
            ReadFile(buffer);
        }

        /// <summary>
        /// Opens a Roblox file from a byte sequence that represents the file.
        /// </summary>
        /// <param name="buffer">A byte sequence that represents the file.</param>
        public static RobloxFile Open(byte[] buffer)
        {
            return new RobloxFile(buffer);
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

        /// <summary>
        /// Allows you to access a child/descendant of this file's contents, and/or one of its properties.<para/>
        /// The provided string should be a period-separated (.) path to what you wish to access.<para/>
        /// This will throw an exception if any part of the path cannot be found.<para/>
        /// 
        /// ~ Examples ~<para/>
        ///     var terrain = robloxFile["Workspace.Terrain"] as Instance;<para/>
        ///     var currentCamera = robloxFile["Workspace.CurrentCamera"] as Property;<para/>
        /// 
        /// </summary>
        public object this[string accessor] => Contents[accessor];
    }
}
