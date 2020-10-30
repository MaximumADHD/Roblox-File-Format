using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using RobloxFiles.DataTypes;

namespace RobloxFiles.UnitTest
{
    static class Program
    {
        const string pattern = "\\d+$";

        static void PrintTreeImpl(Instance inst, int stack = 0)
        {
            string padding = "";
            string extension = "";

            for (int i = 0; i < stack; i++)
                padding += '\t';

            switch (inst.ClassName)
            {
                case "Script":
                    extension = ".server.lua";
                    break;
                case "LocalScript":
                    extension = ".client.lua";
                    break;
                case "ModuleScript":
                    extension = ".lua";
                    break;
                default: break;
            }

            Console.WriteLine($"{padding}{inst.Name}{extension}");

            var children = inst
                .GetChildren()
                .ToList();

            children.ForEach(child => PrintTreeImpl(child, stack + 1));
        }

        static void PrintTree(string path)
        {
            Console.WriteLine("Opening file...");
            RobloxFile target = RobloxFile.Open(path);

            foreach (Instance child in target.GetChildren())
                PrintTreeImpl(child);

            Debugger.Break();
        }

        static void CountAssets(string path)
        {
            Console.WriteLine("Opening file...");
            RobloxFile target = RobloxFile.Open(path);

            var workspace = target.FindFirstChildOfClass<Workspace>();
            var assets = new HashSet<string>();

            if (workspace == null)
            {
                Console.WriteLine("No workspace found!");
                Debugger.Break();

                return;
            }

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
            RobloxFile.LogErrors = true;

            if (args.Length > 0)
            {
                string path = args[0];
                PrintTree(path);
            }
            else
            {
                RobloxFile bin = RobloxFile.Open(@"Files\Binary.rbxl");
                RobloxFile xml = RobloxFile.Open(@"Files\Xml.rbxlx");

                Console.WriteLine("Files opened! Pausing execution for debugger analysis...");
                Debugger.Break();

                bin.Save(@"Files\Binary_SaveTest.rbxl");
                xml.Save(@"Files\Xml_SaveTest.rbxlx");
                
                Console.WriteLine("Files saved! Pausing execution for debugger analysis...");
                Debugger.Break();
            }
        }
    }
}
