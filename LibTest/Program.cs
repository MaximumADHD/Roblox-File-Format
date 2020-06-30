using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

using RobloxFiles.DataTypes;

namespace RobloxFiles
{
    // If the solution is built as an exe, this class is
    // used to drive some basic testing of the library.

    internal static class Program
    {
        const string pattern = "\\d+$";

        static void CountAssets(string path)
        {
            Console.WriteLine("Opening file...");
            RobloxFile target = RobloxFile.Open(path);

            var workspace = target.FindFirstChildOfClass<Workspace>();
            var assets = new HashSet<string>();

            foreach (Instance inst in workspace.GetDescendants())
            {
                var instPath = inst.GetFullName();
                var props = inst.Properties;

                foreach (var prop in props)
                {
                    var propName = prop.Key;
                    var content = prop.Value.CastValue<Content>();

                    if (content != null)
                    {
                        string url = content.Url.Trim();

                        var id = Regex
                            .Match(url, pattern)?
                            .Value;

                        if (id != null && id.Length > 5)
                            url = "rbxassetid://" + id;

                        if (url.Length > 0 && !assets.Contains(url))
                        {
                            Console.WriteLine($"[{url}] at {instPath}.{propName}");
                            assets.Add(url);
                        }
                    }
                }
            }

            Console.WriteLine("Done! Press any key to continue...");
            Console.Read();
        }

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string path = args[0];
                CountAssets(path);
            }
            else
            {
                RobloxFile bin = RobloxFile.Open(@"LibTest\Binary.rbxl");
                RobloxFile xml = RobloxFile.Open(@"LibTest\Xml.rbxlx");

                Console.WriteLine("Files opened! Pausing execution for debugger analysis...");
                Debugger.Break();

                using (FileStream binStream = File.OpenWrite(@"LibTest\Binary_SaveTest.rbxl"))
                    bin.Save(binStream);

                using (FileStream xmlStream = File.OpenWrite(@"LibTest\Xml_SaveTest.rbxlx"))
                    xml.Save(xmlStream);

                Console.WriteLine("Files saved! Pausing execution for debugger analysis...");
                Debugger.Break();
            }
        }
    }
}
