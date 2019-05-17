using System.Collections.Generic;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public class META
    {
        public int NumEntries;
        public Dictionary<string, string> Data = new Dictionary<string, string>();

        public META(BinaryRobloxChunk chunk)
        {
            using (BinaryRobloxReader reader = chunk.GetReader("META"))
            {
                NumEntries = reader.ReadInt32();

                for (int i = 0; i < NumEntries; i++)
                {
                    string key = reader.ReadString();
                    string value = reader.ReadString();
                    Data.Add(key, value);
                }
            }
        }
    }
}
