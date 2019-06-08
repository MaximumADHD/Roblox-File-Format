using System.Collections.Generic;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public class META : IBinaryFileChunk
    {
        public Dictionary<string, string> Data = new Dictionary<string, string>();

        public void LoadFromReader(BinaryRobloxFileReader reader)
        {
            BinaryRobloxFile file = reader.File;
            int numEntries = reader.ReadInt32();

            for (int i = 0; i < numEntries; i++)
            {
                string key = reader.ReadString();
                string value = reader.ReadString();
                Data.Add(key, value);
            }

            file.META = this;
        }

        public BinaryRobloxFileChunk SaveAsChunk(BinaryRobloxFileWriter writer)
        {
            writer.StartWritingChunk(this);
            writer.Write(Data.Count);

            foreach (var kvPair in Data)
            {
                writer.WriteString(kvPair.Key);
                writer.WriteString(kvPair.Value);
            }

            return writer.FinishWritingChunk();
        }
    }
}
