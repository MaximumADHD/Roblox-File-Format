using System;
using System.Linq;

using System.Net;
using System.IO;
using RobloxFileFormat.Update.Properties;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;

using Microsoft.Win32;

namespace RobloxFileFormat.Update
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var outDir = Directory.GetCurrentDirectory();
            var info = new DirectoryInfo(outDir);
            var found = false;

            while (info.Exists)
            {
                if (info.Name == "Roblox-File-Format")
                {
                    outDir = Path.Combine(info.FullName, "Generated");
                    found = true;
                    break;
                }

                info = info.Parent;
            }

            if (!found)
                return;

            const string fileName = "Null.rbxlx";
            File.WriteAllBytes(fileName, Resources.DummyPlaceFile);

            var hkcu = Registry.CurrentUser;
            var studioReg = hkcu.OpenSubKey(@"Software\Roblox\RobloxStudio");
            var contentFolder = studioReg.GetValue("ContentFolder") as string;

            if (contentFolder == null)
            {
                Console.WriteLine("Could not find Roblox Studio!");
                Environment.Exit(1);
            }

            var dirInfo = new DirectoryInfo(contentFolder);
            var studioPath = Path.Combine(dirInfo.Parent.FullName, "RobloxStudioBeta.exe");

            var process = Process.Start(new ProcessStartInfo()
            {
                FileName = studioPath,
                Arguments = fileName
            });

            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:20326/");
            listener.Start();

            while (listener.IsListening)
            {
                var context = await listener.GetContextAsync();
                var request = context.Request;

                var action = request.RawUrl
                    .ToLowerInvariant()
                    .Substring(1);

                Console.WriteLine($"Received request: {action}");

                if (action == "exit")
                {
                    process.Kill();
                    listener.Close();

                    Console.WriteLine("Done! Press any key to continue...");
                    Console.ReadKey();

                    Environment.Exit(0);
                }

                var input = request.InputStream;
                string filePath = null;

                if (action == "write-classes")
                    filePath = Path.Combine(outDir, "Classes.cs");
                else if (action == "write-enums")
                    filePath = Path.Combine(outDir, "Enums.cs");

                if (filePath != null)
                {
                    using (var reader = new StreamReader(input))
                    {
                        var body = reader.ReadToEnd();
                        File.WriteAllText(filePath, body);
                        Console.WriteLine($"Wrote {filePath}");
                    }
                }

                var response = context.Response;
                response.StatusCode = 200;
                response.Close();
            }
        }
    }
}
