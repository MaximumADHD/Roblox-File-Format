using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Roblox.BinaryFormat.Chunks;

namespace Roblox.BinaryFormat
{
    public class RobloxBinaryFile : IRobloxFile
    {
        // Header Specific
        public const string MagicHeader = "<roblox!\x89\xff\x0d\x0a\x1a\x0a";

        public ushort Version;
        public uint   NumTypes;
        public uint   NumInstances;
        public byte[] Reserved;

        // IRobloxFile
        public List<Instance> BinaryTrunk = new List<Instance>();
        public IReadOnlyList<Instance> Trunk => BinaryTrunk.AsReadOnly();

        // Runtime Specific
        public List<RobloxBinaryChunk> Chunks = new List<RobloxBinaryChunk>();
        public override string ToString() => GetType().Name;
        
        public Instance[] Instances;
        public META Metadata;
        public INST[] Types;
        
        public void Initialize(byte[] contents)
        {
            using (MemoryStream file = new MemoryStream(contents))
            using (RobloxBinaryReader reader = new RobloxBinaryReader(file))
            {
                // Verify the signature of the file.
                byte[] binSignature = reader.ReadBytes(14);
                string signature = Encoding.UTF7.GetString(binSignature);

                if (signature != MagicHeader)
                    throw new InvalidDataException("Provided file's signature does not match RobloxBinaryFile.MagicHeader!");

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
                        RobloxBinaryChunk chunk = new RobloxBinaryChunk(reader);
                        Chunks.Add(chunk);

                        switch (chunk.ChunkType)
                        {
                            case "INST":
                                INST type = new INST(chunk);
                                type.Allocate(this);
                                break;
                            case "PROP":
                                PROP.ReadProperties(this, chunk);
                                break;
                            case "PRNT":
                                PRNT prnt = new PRNT(chunk);
                                prnt.Assemble(this);
                                break;
                            case "META":
                                Metadata = new META(chunk);
                                break;
                            case "END\0":
                                reading = false;
                                break;
                            default:
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
