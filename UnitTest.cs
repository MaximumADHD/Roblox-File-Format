using System.Diagnostics;

namespace Roblox
{
    // This is a placeholder.

    internal class UnitTest
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                RobloxFile file = new RobloxFile(args[0]);
                Debugger.Break();
            }
        }
    }
}