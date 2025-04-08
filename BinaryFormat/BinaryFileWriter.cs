using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using RobloxFiles.BinaryFormat.Chunks;
using RobloxFiles.DataTypes;
using RobloxFiles.Enums;

namespace RobloxFiles.BinaryFormat
{
    public class BinaryRobloxFileWriter : BinaryWriter
    {
        public IBinaryFileChunk Chunk { get; private set; }
        public bool WritingChunk { get; private set; }

        public string ChunkType { get; private set; }
        public long ChunkStart { get; private set; }
        
        public readonly BinaryRobloxFile File;

        // Dictionary mapping ClassNames to their INST chunks.
        private readonly Dictionary<string, INST> ClassMap;

        // Instances in parent->child order
        private readonly List<RbxObject> Instances;

        // Instances in child->parent order
        internal List<Instance> PostInstances { get; private set; }

        // Objects picked up from Content properties.
        internal List<RbxObject> Objects { get; private set; }

        public BinaryRobloxFileWriter(BinaryRobloxFile file, Stream workBuffer) : base(workBuffer)
        {
            File = file;

            ChunkStart = 0;
            ChunkType = "";

            Objects = new List<RbxObject>();
            Instances = new List<RbxObject>();
            PostInstances = new List<Instance>();

            ClassMap = new Dictionary<string, INST>();
        }
        
        public static int SizeOf<T>() where T : struct
        {
            int result = 1;
            
            if (typeof(T) != typeof(bool))
                result = Marshal.SizeOf<T>();
                
            return result;
        }

        private static byte[] GetBytes<T>(T value, int bufferSize, IntPtr converter)
        {
            byte[] bytes = new byte[bufferSize];

            Marshal.StructureToPtr(value, converter, true);
            Marshal.Copy(converter, bytes, 0, bufferSize);

            return bytes;
        }

        public static byte[] GetBytes<T>(T value) where T : struct
        {
            int bufferSize = SizeOf<T>();
            IntPtr converter = Marshal.AllocHGlobal(bufferSize);

            var result = GetBytes(value, bufferSize, converter);
            Marshal.FreeHGlobal(converter);

            return result;
        }
        
        // Writes 'count * sizeof(T)' interleaved bytes from a List of T where 
        // each value in the array will be encoded using the provided 'encode' function. 
        public void WriteInterleaved<T>(List<T> values, Func<T, T> encode = null) where T : struct
        {
            int count = values.Count;
            int bufferSize = SizeOf<T>();

            byte[][] blocks = new byte[count][];
            IntPtr converter = Marshal.AllocHGlobal(bufferSize);

            for (int i = 0; i < count; i++)
            {
                T value = values[i];

                if (encode != null)
                    value = encode(value);

                blocks[i] = GetBytes(value, bufferSize, converter);
            }

            for (int layer = bufferSize - 1; layer >= 0; layer--)
            {
                for (int i = 0; i < count; i++)
                {
                    byte value = blocks[i][layer];
                    Write(value);
                }
            }

            Marshal.FreeHGlobal(converter);
        }

        // Rotates the sign bit of the provided int.
        public int RotateInt(int value)
        {
            return (value << 1) ^ (value >> 31);
        }

        // Rotates the sign bit of the provided long.
        public long RotateLong(long value)
        {
            return (value << 1) ^ (value >> 63);
        }

        // Rotates the sign bit of the provided float.
        public float RotateFloat(float value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            uint bits = BitConverter.ToUInt32(buffer, 0);

            bits = (bits << 1) | (bits >> 31);
            buffer = BitConverter.GetBytes(bits);

            return BitConverter.ToSingle(buffer, 0);
        }
        
        // Writes an interleaved list of integers.
        public void WriteInts(List<int> values)
        {
            WriteInterleaved(values, RotateInt);
        }

        // Writes an interleaved list of longs
        public void WriteLongs(List<long> values)
        {
            WriteInterleaved(values, RotateLong);
        }

        // Writes an interleaved list of floats
        public void WriteFloats(List<float> values)
        {
            WriteInterleaved(values, RotateFloat);
        }

        // Accumulatively writes an interleaved array of integers.
        public void WriteObjectIds(List<int> values)
        {
            int numIds = values.Count;
            var instIds = new List<int>(values);

            for (int i = 1; i < numIds; ++i)
                instIds[i] -= values[i - 1];;

            WriteInts(instIds);
        }

        // Writes a string to the buffer with the option to exclude a length prefix.
        public void WriteString(string value, bool raw = false)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(value);
            
            if (!raw)
            {
                int length = buffer.Length;
                Write(length);
            }

            Write(buffer);
        }

        internal void RegisterObject(RbxObject obj)
        {
            int objId = (int)File.NumObjects++;
            string className = obj.ClassName;
            obj.Referent = objId.ToString();

            if (!ClassMap.TryGetValue(className, out INST inst))
            {
                inst = new INST()
                {
                    ClassName = className,
                    ObjectIds = new List<int>(),
                    IsService = false
                };

                if (obj is Instance instance)
                    inst.IsService = instance.IsService;

                ClassMap.Add(className, inst);
            }

            inst.NumObjects++;
            inst.ObjectIds.Add(objId);
        }

        internal void RegisterChildren(Instance root)
        {
            foreach (Instance instance in root.GetChildren())
            {
                if (!instance.Archivable)
                    continue;

                RegisterObject(instance);
                instance.RefreshProperties();
                Instances.Add(instance);

                foreach (var pair in instance.Properties)
                {
                    var prop = pair.Value;

                    if (prop.Type != PropertyType.Content)
                        continue;

                    var content = prop.CastValue<Content>();

                    if (content == null || content.SourceType != ContentSourceType.Object)
                        continue;

                    var obj = content.Object;

                    if (obj == null || obj is Instance)
                        continue;

                    if (Instances.Contains(obj))
                        continue;

                    Instances.Add(obj);
                }

                RegisterChildren(instance);
                PostInstances.Add(instance);
            }
        }

        internal void BuildTables()
        {
            // Register the Instances.
            RegisterChildren(File);

            // Cast them to RbxObject.
            var objects = Instances
                .Cast<RbxObject>()
                .ToList();

            // Register the Objects.
            foreach (var obj in Objects)
            {
                RegisterObject(obj);
                objects.Add(obj);
            }

            // Build the class tables.
            var classNames = ClassMap
                .Select(type => type.Key)
                .ToList();

            classNames.Sort(StringComparer.Ordinal);

            var classes = classNames
                .Select(className => ClassMap[className])
                .ToArray();

            for (int i = 0; i < classes.Length; i++)
            {
                string className = classNames[i];
                INST inst = ClassMap[className];

                inst.ClassIndex = i;
                File.NumClasses++;
            }

            File.Classes = classes;
            File.Objects = objects.ToArray();
        }

        private bool StartWritingChunk(string chunkType)
        {
            if (chunkType.Length != 4)
                throw new Exception("BinaryFileWriter.StartWritingChunk - ChunkType length should be 4!");

            if (!WritingChunk)
            {
                WritingChunk = true;

                ChunkType = chunkType;
                ChunkStart = BaseStream.Position;
                
                return true;
            }

            return false;
        }

        private bool StartWritingChunk(IBinaryFileChunk chunk)
        {
            if (!WritingChunk)
            {
                string chunkType = chunk.GetType().Name;

                StartWritingChunk(chunkType);
                Chunk = chunk;

                return true;
            }

            return false;
        }

        // Compresses the data that was written into a BinaryRobloxFileChunk and writes it.
        private BinaryRobloxFileChunk FinishWritingChunk(bool compress = true)
        {
            if (!WritingChunk)
                throw new Exception($"BinaryRobloxFileWriter: Cannot finish writing a chunk without starting one!");

            // Create the compressed chunk.
            var chunk = new BinaryRobloxFileChunk(this, compress);

            // Clear out the uncompressed data.
            BaseStream.Position = ChunkStart;
            BaseStream.SetLength(ChunkStart);

            // Write the compressed chunk.
            chunk.Handler = Chunk;
            chunk.WriteChunk(this);
            
            // Clean up for the next chunk.
            WritingChunk = false;
            
            ChunkStart = 0;
            ChunkType = "";
            Chunk = null;

            return chunk;
        }

        internal BinaryRobloxFileChunk SaveChunk(IBinaryFileChunk handler, int insertPos = -1)
        {
            StartWritingChunk(handler);
            handler.Save(this);

            var chunk = FinishWritingChunk();

            if (insertPos >= 0)
                File.ChunksImpl.Insert(insertPos, chunk);
            else
                File.ChunksImpl.Add(chunk);

            return chunk;
        }

        internal BinaryRobloxFileChunk WriteChunk(string chunkType, string content, bool compress = false)
        {
            if (chunkType.Length > 4)
                chunkType = chunkType.Substring(0, 4);

            while (chunkType.Length < 4)
                chunkType += '\0';

            StartWritingChunk(chunkType);
            WriteString(content);

            var chunk = FinishWritingChunk(compress);
            File.ChunksImpl.Add(chunk);

            return chunk;
        }
    }
}
