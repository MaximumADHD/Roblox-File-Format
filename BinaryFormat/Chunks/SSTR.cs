using System;
using System.Collections.Generic;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public class SSTR
    {
        public int Version;
        public int NumHashes;

        public Dictionary<string, uint> Lookup = new Dictionary<string, uint>();
        public Dictionary<uint, string> Strings = new Dictionary<uint, string>();

        public SSTR(BinaryRobloxFileChunk chunk)
        {
            using (BinaryRobloxFileReader reader = chunk.GetDataReader())
            {
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
            }
        }
    }
}
