using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RobloxFiles
{
    /// <summary>
    /// Represents a loaded Roblox place/model file.
    /// RobloxFile is an Instance and its children are the contents of the file.
    /// </summary>
    public abstract class RobloxFile : Instance
    {
        public static bool LogErrors = false;

        protected abstract void ReadFile(byte[] buffer);

        /// <summary>
        /// Saves this RobloxFile to the provided stream.
        /// </summary>
        /// <param name="stream">The stream to save to.</param>
        public abstract void Save(Stream stream);

        /// <summary>
        /// Opens a RobloxFile using the provided buffer.
        /// </summary>
        /// <returns>The opened RobloxFile.</returns>
        public static RobloxFile Open(byte[] buffer)
        {
            if (buffer.Length > 14)
            {
                string header = Encoding.ASCII.GetString(buffer, 0, 8);
                RobloxFile file = null;

                if (header == "<roblox!")
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
        /// <returns>The opened RobloxFile.</returns>
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
        /// <returns>The opened RobloxFile.</returns>
        public static RobloxFile Open(string filePath)
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            return Open(buffer);
        }

        /// <summary>
        /// Creates and runs a Task to open a Roblox file from a byte sequence that represents the file.
        /// </summary>
        /// <param name="buffer">A byte sequence that represents the file.</param>
        /// <returns>A task which will complete once the file is opened with the resulting RobloxFile.</returns>
        public static Task<RobloxFile> OpenAsync(byte[] buffer)
        {
            return Task.Run(() => Open(buffer));
        }

        /// <summary>
        /// Creates and runs a Task to open a Roblox file using a provided Stream.
        /// </summary>
        /// <param name="stream">The stream to read the Roblox file from.</param>
        /// <returns>A task which will complete once the file is opened with the resulting RobloxFile.</returns>
        public static Task<RobloxFile> OpenAsync(Stream stream)
        {
            return Task.Run(() => Open(stream));
        }

        /// <summary>
        /// Opens a Roblox file from a provided file path.
        /// </summary>
        /// <param name="filePath">A path to a Roblox file to be opened.</param>
        /// <returns>A task which will complete once the file is opened with the resulting RobloxFile.</returns>
        public static Task<RobloxFile> OpenAsync(string filePath)
        {
            return Task.Run(() => Open(filePath));
        }

        /// <summary>
        /// Saves this RobloxFile to the provided file path.
        /// </summary>
        /// <param name="filePath">A path to where the file should be saved.</param>
        public void Save(string filePath)
        {
            using (FileStream stream = File.OpenWrite(filePath))
            {
                Save(stream);
            }
        }

        /// <summary>
        /// Asynchronously saves this RobloxFile to the provided stream.
        /// </summary>
        /// <param name="stream">The stream to save to.</param>
        /// <returns>A task which will complete upon the save's completion.</returns>
        public Task SaveAsync(Stream stream)
        {
            return Task.Run(() => Save(stream));
        }

        /// <summary>
        /// Asynchronously saves this RobloxFile to the provided file path.
        /// </summary>
        /// <param name="filePath">A path to where the file should be saved.</param>
        /// <returns>A task which will complete upon the save's completion.</returns>
        public Task SaveAsync(string filePath)
        {
            return Task.Run(() => Save(filePath));
        }

        /// <summary>
        /// Logs an error that occurred while opening a RobloxFile if logs are enabled.
        /// </summary>
        /// <param name="message"></param>
        internal static void LogError(string message)
        {
            if (!LogErrors)
                return;

            Console.Error.WriteLine(message);
        }
    }
}
