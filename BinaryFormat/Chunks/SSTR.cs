using System;
using System.Collections.Generic;
using System.Text;

using RobloxFiles.DataTypes;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public class SSTR : IBinaryFileChunk
    {
        private const int FORMAT = 0;

        internal Dictionary<string, uint> Lookup = new Dictionary<string, uint>();
        internal Dictionary<uint, SharedString> Strings = new Dictionary<uint, SharedString>();

        public void Load(BinaryRobloxFileReader reader)
        {
            BinaryRobloxFile file = reader.File;

            int format = reader.ReadInt32();
            int numHashes = reader.ReadInt32();

            if (format != FORMAT)
                throw new Exception($"Unexpected SSTR format: {format} (expected {FORMAT}!)");
            
            for (uint id = 0; id < numHashes; id++)
            {
                byte[] hash = reader.ReadBytes(16);
                string key = Convert.ToBase64String(hash);

                byte[] data = reader.ReadBuffer();
                SharedString value = SharedString.FromBuffer(data);

                Lookup[key] = id;
                Strings[id] = value;
            }

            file.SSTR = this;
        }

        public void Save(BinaryRobloxFileWriter writer)
        {
            writer.Write(FORMAT);
            writer.Write(Lookup.Count);

            foreach (var pair in Lookup)
            {
                string key = pair.Key;

                byte[] hash = Convert.FromBase64String(key);
                writer.Write(hash);

                SharedString value = Strings[pair.Value];
                byte[] buffer = SharedString.Find(value.Key);

                writer.Write(buffer.Length);
                writer.Write(buffer);
            }
        }

        public void WriteInfo(StringBuilder builder)
        {
            builder.AppendLine($"Format:     {FORMAT}");
            builder.AppendLine($"NumStrings: {Lookup.Count}");

            builder.AppendLine($"## Keys");

            foreach (var pair in Lookup)
            {
                string key = pair.Key;
                builder.AppendLine($"- `{key}`");
            }
        }
    }
}
