using System;
using System.Collections.Generic;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public class SSTR : IBinaryFileChunk
    {
        public int Version;
        public int NumHashes;

        public Dictionary<string, uint> Lookup = new Dictionary<string, uint>();
        public Dictionary<uint, string> Strings = new Dictionary<uint, string>();

        public void LoadFromReader(BinaryRobloxFileReader reader)
        {
            BinaryRobloxFile file = reader.File;

            Version = reader.ReadInt32();
            NumHashes = reader.ReadInt32();

            for (uint id = 0; id < NumHashes; id++)
            {
                byte[] md5 = reader.ReadBytes(16);

                int length = reader.ReadInt32();
                byte[] data = reader.ReadBytes(length);

                string key = Convert.ToBase64String(md5);
                string value = Convert.ToBase64String(data);

                Lookup.Add(key, id);
                Strings.Add(id, value);
            }

            file.SSTR = this;
        }

        public BinaryRobloxFileChunk SaveAsChunk(BinaryRobloxFileWriter writer)
        {
            writer.StartWritingChunk(this);

            writer.Write(Version);
            writer.Write(NumHashes);

            foreach (var pair in Lookup)
            {
                string key = pair.Key;

                byte[] md5 = Convert.FromBase64String(key);
                writer.Write(md5);

                string value = Strings[pair.Value];
                byte[] buffer = Convert.FromBase64String(value);

                writer.Write(buffer.Length);
                writer.Write(buffer);
            }

            return writer.FinishWritingChunk();
        }
    }
}
