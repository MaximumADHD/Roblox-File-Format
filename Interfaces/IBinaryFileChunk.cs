using System.IO;
using System.Text;

namespace RobloxFiles.BinaryFormat
{
    public interface IBinaryFileChunk
    {
        void Load(BinaryRobloxFileReader reader);
        void Save(BinaryRobloxFileWriter writer);
        void WriteInfo(StringBuilder builder);
    }
}
