using K4os.Compression.LZ4;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using ZstdSharp;

namespace RobloxFiles.BinaryFormat
{
    /// <summary>
    /// BinaryRobloxFileChunk represents a generic LZ4-compressed chunk
    /// of data in Roblox's Binary File Format.
    /// </summary>
    public class BinaryRobloxFileChunk
    {
        public readonly string ChunkType;
        public readonly int Reserved;

        public readonly int CompressedSize;
        public readonly int Size;

        public readonly byte[] CompressedData;
        public readonly byte[] Data;

        public bool HasCompressedData => (CompressedSize > 0);
        public IBinaryFileChunk Handler { get; internal set; }

        public bool HasWriteBuffer { get; private set; }
        public byte[] WriteBuffer { get; private set; }

        public override string ToString()
        {
            string chunkType = ChunkType.Replace('\0', ' ');
            return $"'{chunkType}' Chunk ({Size} bytes) [{Handler?.ToString()}]";
        }

        public BinaryRobloxFileChunk(BinaryRobloxFileReader reader)
        {
            byte[] rawChunkType = reader.ReadBytes(4);
            ChunkType = Encoding.ASCII.GetString(rawChunkType);

            CompressedSize = reader.ReadInt32();
            Size = reader.ReadInt32();
            Reserved = reader.ReadInt32();

            if (HasCompressedData)
            {
                CompressedData = reader.ReadBytes(CompressedSize);
                Data = new byte[Size];

                using (var compStream = new MemoryStream(CompressedData))
                {
                    Stream decompStream = null;

                    if (CompressedData[0] == 0x78 || CompressedData[0] == 0x58)
                    {
                        // Probably zlib
                        decompStream = new DeflateStream(compStream, CompressionMode.Decompress);
                    }
                    else if (BitConverter.ToString(CompressedData, 1, 3) == "B5-2F-FD")
                    {
                        // Probably zstd
                        decompStream = new DecompressionStream(compStream);
                    }
                    else
                    {
                        // Probably LZ4
                        var decomp = new byte[Size];
                        
                        LZ4Codec.Decode(
                            CompressedData, 0, CompressedSize,
                            decomp, 0, Size
                        );
                        
                        decompStream = new MemoryStream(decomp);
                    }

                    if (decompStream == null)
                        throw new Exception("Unsupported compression scheme!");

                    decompStream.Read(Data, 0, Size);
                    decompStream.Dispose();
                }
            }
            else
            {
                Data = reader.ReadBytes(Size);
            }
        }

        public BinaryRobloxFileChunk(BinaryRobloxFileWriter writer, bool compress = true)
        {
            if (!writer.WritingChunk)
                throw new Exception("BinaryRobloxFileChunk: Supplied writer must have WritingChunk set to true.");

            Stream stream = writer.BaseStream;

            using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, true))
            {
                long length = (stream.Position - writer.ChunkStart);
                stream.Position = writer.ChunkStart;

                Size = (int)length;
                Data = reader.ReadBytes(Size);
            }

            CompressedData = new byte[LZ4Codec.MaximumOutputSize(Size)];
            int encoded = LZ4Codec.Encode(Data, 0, Size, CompressedData, 0, CompressedData.Length);
            Array.Resize(ref CompressedData, encoded);
            CompressedSize = CompressedData.Length;

            if (!compress || CompressedSize > Size)
            {
                CompressedSize = 0;
                CompressedData = Array.Empty<byte>();
            }

            ChunkType = writer.ChunkType;
            Reserved = 0;
        }

        public void WriteChunk(BinaryRobloxFileWriter writer)
        {
            // Record where we are when we start writing.
            var stream = writer.BaseStream;
            long startPos = stream.Position;

            // Write the chunk's data.
            writer.WriteString(ChunkType, true);

            writer.Write(CompressedSize);
            writer.Write(Size);

            writer.Write(Reserved);

            if (CompressedSize > 0)
                writer.Write(CompressedData);
            else
                writer.Write(Data);

            // Capture the data we wrote into a byte[] array.
            long endPos = stream.Position;
            int length = (int)(endPos - startPos);

            using (MemoryStream buffer = new MemoryStream())
            {
                stream.Position = startPos;
                stream.CopyTo(buffer, length);

                WriteBuffer = buffer.ToArray();
                HasWriteBuffer = true;
            }
        }
    }
}
