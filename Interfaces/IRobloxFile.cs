using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxFiles
{
    /// <summary>
    /// Interface which represents a RobloxFile implementation.
    /// </summary>
    public interface IRobloxFile
    {
        Instance Contents { get; }

        void ReadFile(byte[] buffer);
        void WriteFile(Stream stream);
    }
}
