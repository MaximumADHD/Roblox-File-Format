using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using RobloxFiles.BinaryFormat.Chunks;

namespace RobloxFiles.BinaryFormat
{
    public class BinaryRobloxFile : IRobloxFile
    {
        // Header Specific
        public const string MagicHeader = "<roblox!\x89\xff\x0d\x0a\x1a\x0a";

        public ushort Version;
        public uint   NumTypes;
        public uint   NumInstances;
        public byte[] Reserved;

        // IRobloxFile
        internal readonly Instance BinContents = new Instance("Folder", "BinaryRobloxFile");
        public Instance Contents => BinContents;

        // Runtime Specific
        public List<BinaryRobloxChunk> Chunks = new List<BinaryRobloxChunk>();
        public override string ToString() => GetType().Name;
        
        public Instance[] Instances;
        public INST[] Types;

        public Dictionary<string, string> Metadata;
        public Dictionary<uint, string> SharedStrings;
        
        public void ReadFile(byte[] contents)
        {
            using (MemoryStream file = new MemoryStream(contents))
            using (BinaryRobloxReader reader = new BinaryRobloxReader(file))
            {
                // Verify the signature of the file.
                byte[] binSignature = reader.ReadBytes(14);
                string signature = Encoding.UTF7.GetString(binSignature);

                if (signature != MagicHeader)
                    throw new InvalidDataException("Provided file's signature does not match BinaryRobloxFile.MagicHeader!");

                // Read header data.
                Version = reader.ReadUInt16();
                NumTypes = reader.ReadUInt32();
                NumInstances = reader.ReadUInt32();
                Reserved = reader.ReadBytes(8);

                // Begin reading the file chunks.
                bool reading = true;

                Types = new INST[NumTypes];
                Instances = new Instance[NumInstances];
                
                while (reading)
                {
                    try
                    {
                        BinaryRobloxChunk chunk = new BinaryRobloxChunk(reader);
                        Chunks.Add(chunk);

                        switch (chunk.ChunkType)
                        {
                            case "INST":
                                INST type = new INST(chunk);
                                type.Allocate(this);
                                break;
                            case "PROP":
                                PROP prop = new PROP(chunk);
                                prop.ReadProperties(this);
                                break;
                            case "PRNT":
                                PRNT hierarchy = new PRNT(chunk);
                                hierarchy.Assemble(this);
                                break;
                            case "META":
                                META meta = new META(chunk);
                                Metadata = meta.Data;
                                break;
                            case "SSTR":
                                SSTR shared = new SSTR(chunk);
                                SharedStrings = shared.Strings;
                                break;
                            case "END\0":
                                reading = false;
                                break;
                            default:
                                Console.WriteLine("Unhandled chunk type: {0}!", chunk.ChunkType);
                                Chunks.Remove(chunk);
                                break;
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("Unexpected end of file!");
                    }
                }
            }
        }
    }
}