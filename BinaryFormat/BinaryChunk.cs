using System;
using System.IO;
using System.Text;
using LZ4;

namespace Roblox.BinaryFormat
{
    public class RobloxBinaryChunk
    {
        public readonly string ChunkType;

        public readonly int CompressedSize;
        public readonly byte[] CompressedData;

        public readonly int Size;
        public readonly byte[] Reserved;
        public readonly byte[] Data;

        public bool HasCompressedData => (CompressedSize > 0);

        public override string ToString()
        {
            return ChunkType + " Chunk [" + Size + " bytes]";
        }

        public RobloxBinaryReader GetReader(string chunkType)
        {
            if (ChunkType == chunkType)
            {
                MemoryStream buffer = new MemoryStream(Data);
                return new RobloxBinaryReader(buffer);
            }

            throw new Exception("Expected " + chunkType + " ChunkType from the input RobloxBinaryChunk");
        }

        public RobloxBinaryChunk(RobloxBinaryReader reader)
        {
            byte[] bChunkType = reader.ReadBytes(4);
            ChunkType = Encoding.ASCII.GetString(bChunkType);

            CompressedSize = reader.ReadInt32();
            Size = reader.ReadInt32();
            Reserved = reader.ReadBytes(4);

            if (HasCompressedData)
            {
                CompressedData = reader.ReadBytes(CompressedSize);
                Data = LZ4Codec.Decode(CompressedData, 0, CompressedSize, Size);
            }
            else
            {
                Data = reader.ReadBytes(Size);
            }
        }
    }
}
