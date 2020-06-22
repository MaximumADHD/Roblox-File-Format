using System;
using System.Diagnostics;

namespace RobloxFiles
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            RobloxFile bin = RobloxFile.Open(@"LibTest\Binary.rbxl");
            Debugger.Break();

            RobloxFile xml = RobloxFile.Open(@"LibTest\Xml.rbxlx");
            Debugger.Break();
        }
    }
}
