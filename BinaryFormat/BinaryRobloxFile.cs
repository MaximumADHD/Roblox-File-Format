using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using RobloxFiles.BinaryFormat;
using RobloxFiles.BinaryFormat.Chunks;
using RobloxFiles.DataTypes;

namespace RobloxFiles
{
    public class BinaryRobloxFile : RobloxFile
    {
        // Header Specific
        public const string MagicHeader = "<roblox!\x89\xff\x0d\x0a\x1a\x0a";

        public ushort Version;
        public uint   NumClasses;
        public uint   NumInstances;
        public long   Reserved;

        // Runtime Specific
        public List<BinaryRobloxFileChunk> Chunks = new List<BinaryRobloxFileChunk>();
        public override string ToString() => GetType().Name;
        
        public Instance[] Instances;
        public INST[] Classes;

        internal META META = null;
        internal SSTR SSTR = null;

        public bool HasMetadata => (META != null);
        public Dictionary<string, string> Metadata => META?.Data;

        public bool HasSharedStrings => (SSTR != null);
        public IReadOnlyDictionary<uint, SharedString> SharedStrings => SSTR?.Strings;

        public BinaryRobloxFile()
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
                NumClasses = reader.ReadUInt32();
                NumInstances = reader.ReadUInt32();
                Reserved = reader.ReadInt64();

                // Begin reading the file chunks.
                bool reading = true;

                Classes = new INST[NumClasses];
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
                                Chunks.Add(chunk);
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
                NumClasses = 0;
                SSTR = null;
                
                // Recursively capture all instances and classes.
                writer.RecordInstances(Children);

                // Apply the recorded instances and classes.
                writer.ApplyClassMap();

                // Write the INST chunks.
                foreach (INST inst in Classes)
                    writer.SaveChunk(inst);

                // Write the PROP chunks.
                foreach (INST inst in Classes)
                {
                    Dictionary<string, PROP> props = PROP.CollectProperties(writer, inst);

                    foreach (string propName in props.Keys)
                    {
                        PROP prop = props[propName];
                        writer.SaveChunk(prop);
                    }
                }

                // Write the PRNT chunk.
                PRNT parents = new PRNT();
                writer.SaveChunk(parents);
                
                // Write the SSTR chunk.
                if (HasSharedStrings)
                {
                    var sharedStrings = SSTR.SaveAsChunk(writer);
                    Chunks.Insert(0, sharedStrings);
                }

                // Write the META chunk.
                if (HasMetadata)
                {
                    var metaChunk = META.SaveAsChunk(writer);
                    Chunks.Insert(0, metaChunk);
                }

                // Write the END_ chunk.
                var endChunk = writer.WriteEndChunk();
                Chunks.Add(endChunk);
            }

            //////////////////////////////////////////////////////////////////////////
            // Write the chunk buffers with the header data
            //////////////////////////////////////////////////////////////////////////

            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                stream.Position = 0;
                stream.SetLength(0);

                writer.Write(MagicHeader
                    .Select(ch => (byte)ch)
                    .ToArray());

                writer.Write(Version);
                writer.Write(NumClasses);
                writer.Write(NumInstances);
                writer.Write(Reserved);

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
