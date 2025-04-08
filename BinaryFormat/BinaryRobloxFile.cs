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

        public ushort Version      { get; internal set; }
        public uint   NumClasses   { get; internal set; }
        public uint   NumObjects   { get; internal set; }
        public long   Reserved     { get; internal set; }

        // Runtime Specific
        internal List<BinaryRobloxFileChunk> ChunksImpl = new List<BinaryRobloxFileChunk>();
        public IReadOnlyList<BinaryRobloxFileChunk> Chunks => ChunksImpl;
        public override string ToString() => GetType().Name;
        
        public RbxObject[] Objects { get; internal set; }
        public INST[] Classes       { get; internal set; }

        internal META META;
        internal SSTR SSTR;
        internal SIGN SIGN;

        public bool HasMetadata => (META != null);
        public Dictionary<string, string> Metadata => META?.Data;

        public bool HasSharedStrings => (SSTR != null);
        public IReadOnlyDictionary<uint, SharedString> SharedStrings => SSTR?.Strings;

        public bool HasSignatures => (SIGN != null);
        public IReadOnlyList<RbxSignature> Signatures => SIGN?.Signatures;

        public BinaryRobloxFile()
        {
            Name = "Bin:";
            Referent = "-1";
            ParentLocked = true;
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
                NumObjects = reader.ReadUInt32();
                Reserved = reader.ReadInt64();

                // Begin reading the file chunks.
                bool reading = true;
                Classes = new INST[NumClasses];
                Objects = new RbxObject[NumObjects];

                while (reading)
                {
                    try
                    {
                        var chunk = new BinaryRobloxFileChunk(reader);
                        IBinaryFileChunk handler = null;
                        
                        switch (chunk.ChunkType)
                        {
                            case "INST":
                            {
                                handler = new INST();
                                break;
                            }
                            case "PROP":
                            {
                                handler = new PROP();
                                break;
                            }
                            case "PRNT":
                            {
                                handler = new PRNT();
                                break;
                            }
                            case "META":
                            {
                                handler = new META();
                                break;
                            }
                            case "SSTR":
                            {
                                handler = new SSTR();
                                break;
                            }
                            case "SIGN":
                            {
                                handler = new SIGN();
                                break;
                            }
                            case "END\0":
                            {
                                ChunksImpl.Add(chunk);
                                reading = false;
                                break;
                            }
                            case string unhandled:
                            {
                                LogError($"BinaryRobloxFile - Unhandled chunk-type: {unhandled}!");
                                break;
                            }
                        }

                        if (handler != null)
                        {
                            using (var readBuffer = new MemoryStream(chunk.Data))
                            {
                                using (var dataReader = new BinaryRobloxFileReader(this, readBuffer))
                                {
                                    chunk.Handler = handler;
                                    handler.Load(dataReader);
                                }
                            }
                            
                            ChunksImpl.Add(chunk);
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

            using (var workBuffer = new MemoryStream())
            using (var writer = new BinaryRobloxFileWriter(this, workBuffer))
            {
                // Clear the existing data.
                Referent = "-1";
                ChunksImpl.Clear();

                NumObjects = 0;
                NumClasses = 0;
                SSTR = null;

                // Build the Object/Class tables.
                writer.BuildTables();

                // Write the INST chunks.
                foreach (INST inst in Classes)
                    writer.SaveChunk(inst);

                // Write the PROP chunks.
                foreach (INST inst in Classes)
                {
                    var props = PROP.CollectProperties(writer, inst);

                    foreach (string propName in props.Keys)
                    {
                        PROP prop = props[propName];
                        writer.SaveChunk(prop);
                    }
                }

                // Write the PRNT chunk.
                var parents = new PRNT();
                writer.SaveChunk(parents);

                // Write the SSTR chunk.
                if (HasSharedStrings)
                    writer.SaveChunk(SSTR, 0);

                // Write the META chunk.
                if (HasMetadata)
                    writer.SaveChunk(META, 0);

                // Write the SIGN chunk.
                if (HasSignatures)
                    writer.SaveChunk(SIGN);

                // Write the END chunk.
                writer.WriteChunk("END", "</roblox>");
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
                writer.Write(NumObjects);
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
