using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Roblox.BinaryFormat.Chunks;

namespace Roblox.BinaryFormat
{
    public class RobloxBinaryFile : RobloxFile
    {
        public const string FileSignature = "<roblox!\x89\xff\x0d\x0a\x1a\x0a";
        public readonly List<RobloxBinaryChunk> BinaryChunks = new List<RobloxBinaryChunk>();

        public readonly PRNT ParentIds;
        public readonly META Metadata;

        public readonly Dictionary<int, INST> INSTs = new Dictionary<int, INST>();
        public readonly List<PROP> PROPs = new List<PROP>();

        public readonly RobloxInstance[] Instances;

        public readonly ushort Version;
        public readonly uint NumTypes;
        public readonly uint NumInstances;
        public readonly long Reserved;

        public RobloxBinaryFile(byte[] contents)
        {
            using (MemoryStream file = new MemoryStream(contents))
            using (RobloxBinaryReader reader = new RobloxBinaryReader(file))
            {
                byte[] binSignature = reader.ReadBytes(14);
                string signature = Encoding.UTF7.GetString(binSignature);

                if (signature != FileSignature)
                    throw new InvalidDataException("Signature does not match RobloxBinaryFile.FileSignature!");

                Version = reader.ReadUInt16();
                NumTypes = reader.ReadUInt32();
                NumInstances = reader.ReadUInt32();
                Reserved = reader.ReadInt64();

                // Begin reading the file chunks.
                bool reading = true;
                Instances = new RobloxInstance[NumInstances];
                BinaryChunks = new List<RobloxBinaryChunk>();

                while (reading)
                {
                    try
                    {
                        RobloxBinaryChunk chunk = new RobloxBinaryChunk(reader);
                        BinaryChunks.Add(chunk);

                        switch (chunk.ChunkType)
                        {
                            case "INST":
                                INST inst = new INST(chunk);
                                INSTs.Add(inst.TypeIndex, inst);
                                break;
                            case "PROP":
                                PROP prop = new PROP(chunk);
                                PROPs.Add(prop);
                                break;
                            case "PRNT":
                                PRNT prnt = new PRNT(chunk);
                                ParentIds = prnt;
                                break;
                            case "META":
                                META meta = new META(chunk);
                                Metadata = meta;
                                break;
                            case "END\0":
                                reading = false;
                                break;
                            default:
                                BinaryChunks.Remove(chunk);
                                break;
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("Unexpected end of file!");
                    }
                }

                foreach (INST chunk in INSTs.Values)
                {
                    foreach (int id in chunk.InstanceIds)
                    {
                        RobloxInstance inst = new RobloxInstance();
                        inst.ClassName = chunk.TypeName;
                        Instances[id] = inst;
                    }
                }

                foreach (PROP prop in PROPs)
                {
                    INST chunk = INSTs[prop.Index];
                    prop.ReadPropertyValues(chunk, Instances);
                }

                for (int i = 0; i < ParentIds.NumRelations; i++)
                {
                    int childId = ParentIds.ChildrenIds[i];
                    int parentId = ParentIds.ParentIds[i];

                    RobloxInstance child = Instances[childId];

                    if (parentId >= 0)
                    {
                        var parent = Instances[parentId];
                        child.Parent = parent;
                    }
                    else
                    {
                        Trunk.Add(child);
                    }
                }
            }
        }
    }
}
