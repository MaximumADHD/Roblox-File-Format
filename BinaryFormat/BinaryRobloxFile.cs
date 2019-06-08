using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using RobloxFiles.BinaryFormat.Chunks;

namespace RobloxFiles.BinaryFormat
{
    public class BinaryRobloxFile : RobloxFile
    {
        // Header Specific
        public const string MagicHeader = "<roblox!\x89\xff\x0d\x0a\x1a\x0a";

        public ushort Version;
        public uint   NumTypes;
        public uint   NumInstances;
        public long   Reserved;

        // Runtime Specific
        public List<BinaryRobloxFileChunk> Chunks = new List<BinaryRobloxFileChunk>();
        public override string ToString() => GetType().Name;
        
        public Instance[] Instances;
        public INST[] Types;

        internal META META = null;
        internal SSTR SSTR = null;

        public bool HasMetadata => (META != null);
        public Dictionary<string, string> Metadata => META?.Data;

        public bool HasSharedStrings => (SSTR != null);
        public Dictionary<uint, string> SharedStrings => SSTR?.Strings;

        internal BinaryRobloxFile()
        {
            Name = "BinaryRobloxFile";
            ParentLocked = true;
            Referent = "-1";
        }
        
        protected override void ReadFile(byte[] contents)
        {
            using (MemoryStream file = new MemoryStream(contents))
            using (BinaryRobloxFileReader reader = new BinaryRobloxFileReader(this, file))
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
                Reserved = reader.ReadInt64();

                // Begin reading the file chunks.
                bool reading = true;

                Types = new INST[NumTypes];
                Instances = new Instance[NumInstances];

                while (reading)
                {
                    try
                    {
                        BinaryRobloxFileChunk chunk = new BinaryRobloxFileChunk(reader);
                        string chunkType = chunk.ChunkType;

                        IBinaryFileChunk handler = null;
                        
                        switch (chunkType)
                        {
                            case "INST":
                                handler = new INST();
                                break;
                            case "PROP":
                                handler = new PROP();
                                break;
                            case "PRNT":
                                handler = new PRNT();
                                break;
                            case "META":
                                handler = new META();
                                break;
                            case "SSTR":
                                handler = new SSTR();
                                break;
                            case "END\0":
                                reading = false;
                                break;
                            default:
                                Console.WriteLine("BinaryRobloxFile - Unhandled chunk-type: {0}!", chunkType);
                                break;
                        }

                        if (handler != null)
                        {
                            using (BinaryRobloxFileReader dataReader = chunk.GetDataReader(this))
                                handler.LoadFromReader(dataReader);

                            chunk.Handler = handler;
                            Chunks.Add(chunk);
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("Unexpected end of file!");
                    }
                }
            }
        }

        public override void Save(Stream stream)
        {
            //////////////////////////////////////////////////////////////////////////
            // Generate the chunk data.
            //////////////////////////////////////////////////////////////////////////

            using (var writer = new BinaryRobloxFileWriter(this))
            {
                // Clear the existing data.
                Referent = "-1";
                Chunks.Clear();
                
                NumInstances = 0;
                NumTypes = 0;

                if (HasSharedStrings)
                {
                    SSTR.NumHashes = 0;
                    SSTR.Lookup.Clear();
                    SSTR.Strings.Clear();
                }

                // Write the META chunk.
                if (HasMetadata)
                {
                    var metaChunk = META.SaveAsChunk(writer);
                    Chunks.Add(metaChunk);
                }

                // Record all instances and types.
                writer.RecordInstances(Children);

                // Apply the type values.
                INST.ApplyTypeMap(writer);

                // Write the INST chunks.
                foreach (INST type in Types)
                {
                    var instChunk = type.SaveAsChunk(writer);
                    Chunks.Add(instChunk);
                }

                // Write the PROP chunks.
                foreach (INST type in Types)
                {
                    Dictionary<string, PROP> props = PROP.CollectProperties(writer, type);

                    foreach (string propName in props.Keys)
                    {
                        PROP prop = props[propName];

                        var chunk = prop.SaveAsChunk(writer);
                        Chunks.Add(chunk);
                    }
                }

                // Write the PRNT chunk.
                PRNT parents = new PRNT();

                var parentChunk = parents.SaveAsChunk(writer);
                Chunks.Add(parentChunk);

                // Write the SSTR chunk.
                if (HasSharedStrings)
                {
                    var sharedStrings = SSTR.SaveAsChunk(writer);
                    Chunks.Insert(0, sharedStrings);
                }

                // Write the END_ chunk.
                writer.StartWritingChunk("END\0");
                writer.WriteString("</roblox>", true);

                var endChunk = writer.FinishWritingChunk(false);
                Chunks.Add(endChunk);
            }

            //////////////////////////////////////////////////////////////////////////
            // Write the chunks with the header & footer data
            //////////////////////////////////////////////////////////////////////////

            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                stream.Position = 0;
                stream.SetLength(0);

                byte[] magicHeader = MagicHeader
                    .Select(ch => (byte)ch)
                    .ToArray();

                writer.Write(magicHeader);

                writer.Write(Version);
                writer.Write(NumTypes);
                writer.Write(NumInstances);

                // Write the 8 reserved-bytes.
                writer.Write(0L);

                // Write all of the chunks.
                foreach (BinaryRobloxFileChunk chunk in Chunks)
                {
                    if (chunk.HasWriteBuffer)
                    {
                        byte[] writeBuffer = chunk.WriteBuffer;
                        writer.Write(writeBuffer);
                    }
                }
            }
        }
    }
}
