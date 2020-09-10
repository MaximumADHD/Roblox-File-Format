using System.Collections.Generic;
using System.Text;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public class META : IBinaryFileChunk
    {
        public Dictionary<string, string> Data = new Dictionary<string, string>();

        public void Load(BinaryRobloxFileReader reader)
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

        public void Save(BinaryRobloxFileWriter writer)
        {
            writer.Write(Data.Count);

            foreach (var pair in Data)
            {
                writer.WriteString(pair.Key);
                writer.WriteString(pair.Value);
            }
        }

        public void WriteInfo(StringBuilder builder)
        {
            builder.AppendLine($"- NumEntries: {Data.Count}");

            foreach (var pair in Data)
            {
                string key   = pair.Key,
                       value = pair.Value;

                builder.AppendLine($"  - {key}: {value}");
            }
        }
    }
}
