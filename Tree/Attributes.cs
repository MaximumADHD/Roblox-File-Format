using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RobloxFiles
{
    // This enum defines existing attributes
    // Commented out values are known types
    // which are unsupported at this time.

    public enum AttributeType
    {
     // Null = 1,
        String = 2,
        Bool = 3,
        Int = 4,
        Float = 5,
        Double = 6,
     // Array = 7,
     // Dictionary = 8,
        UDim = 9,
        UDim2 = 10,
     // Ray = 11,
     // Faces = 12,
     // Axes = 13
        BrickColor = 14,
        Color3 = 15,
        Vector2 = 16,
        Vector3 = 17,
     // Vector2int16 = 18,
     // Vector3int16 = 19,
        CFrame = 20,
        Enum = 21,
        NumberSequence = 23,
     // NumberSequenceKeypoint = 24,
        ColorSequence = 25,
     // ColorSequenceKeypoint = 26,
        NumberRange = 27,
        Rect = 28,
     // PhysicalProperties = 29
     // Region3 = 31,
     // Region3int16 = 32,
        FontFace = 33
    }

    public class RbxAttribute : IDisposable
    {
        private static readonly IReadOnlyDictionary<AttributeType, Tokenizer> AttributeSupport;
        private static readonly IReadOnlyDictionary<Type, AttributeType> SupportedTypes;

        public AttributeType DataType { get; private set; }
        public object Value { get; private set; }

        private struct Tokenizer
        {
            public readonly Type Support;
            public readonly object Token;

            public readonly MethodInfo Reader;
            public readonly MethodInfo Writer;

            public Tokenizer(Type tokenType, Type support)
            {
                Support = support;
                Token = Activator.CreateInstance(tokenType);

                Reader = support.GetMethod("ReadAttribute");
                Writer = support.GetMethod("WriteAttribute");
            }

            public object ReadAttribute(RbxAttribute attr)
            {
                var args = new object[1] { attr };
                return Reader.Invoke(Token, args);
            }

            public void WriteAttribute(RbxAttribute attr, object value)
            {
                var args = new object[2] { attr, value };
                Writer.Invoke(Token, args);
            }
        }

        static RbxAttribute()
        {
            var attributeSupport = new Dictionary<AttributeType, Tokenizer>();
            var supportedTypes = new Dictionary<Type, AttributeType>();
            var assembly = Assembly.GetExecutingAssembly();

            var handlerTypes =
                from type in assembly.GetTypes()
                    let typeInfo = type.GetTypeInfo()
                    let support = typeInfo.GetInterface("IAttributeToken`1")
                where (support != null)
                    select new Tokenizer(typeInfo, support);
            
            foreach (var tokenizer in handlerTypes)
            {
                var token = tokenizer.Token;
                var support = tokenizer.Support;
                
                var genericType = support.GenericTypeArguments.FirstOrDefault();
                var getAttributeType = support.GetMethod("get_AttributeType");
                var attributeType = (AttributeType)getAttributeType.Invoke(token, null);

                attributeSupport.Add(attributeType, tokenizer);
                supportedTypes.Add(genericType, attributeType);
            }

            AttributeSupport = attributeSupport;
            SupportedTypes = supportedTypes;
        }

        /// <summary>
        /// Returns true if the provided type is supported by attributes.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool SupportsType(Type type)
        {
            return SupportedTypes.ContainsKey(type);
        }

        /// <summary>
        /// Returns true if the provided type is supported by attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool SupportsType<T>()
        {
            Type type = typeof(T);
            return SupportsType(type);
        }

        public override string ToString()
        {
            string value = Value?.ToString() ?? "null";
            return $"[{DataType}: {value}]";
        }

        internal BinaryReader Reader;
        internal BinaryWriter Writer;

        internal int ReadInt() => Reader.ReadInt32();
        internal byte ReadByte() => Reader.ReadByte();
        internal uint ReadUInt() => Reader.ReadUInt32();
        internal bool ReadBool() => Reader.ReadBoolean();
        internal short ReadShort() => Reader.ReadInt16();
        internal float ReadFloat() => Reader.ReadSingle();
        internal double ReadDouble() => Reader.ReadDouble();
        internal string ReadString() => Reader.ReadString(true);

        internal void WriteInt(int value) => Writer.Write(value);
        internal void WriteByte(byte value) => Writer.Write(value);
        internal void WriteUInt(uint value) => Writer.Write(value);
        internal void WriteBool(bool value) => Writer.Write(value);
        internal void WriteFloat(float value) => Writer.Write(value);
        internal void WriteDouble(double value) => Writer.Write(value);

        internal void WriteString(string value)
        {
            byte[] utf8 = Encoding.UTF8.GetBytes(value);
            Writer.Write(utf8.Length);
            Writer.Write(utf8);
        }

        internal void Read()
        {
            if (Reader == null)
                return;

            var dataType = Reader.ReadByte();
            DataType = (AttributeType)dataType;

            var tokenizer = AttributeSupport[DataType];
            Value = tokenizer.ReadAttribute(this);

            Reader = null;
        }

        public void Dispose()
        {
            Reader?.Dispose();
        }

        internal void Write(BinaryWriter writer)
        {
            var tokenizer = AttributeSupport[DataType];
            Writer = writer;

            writer.Write((byte)DataType);
            tokenizer.WriteAttribute(this, Value);

            Writer = null;
        }

        internal RbxAttribute(BinaryReader reader)
        {
            Reader = reader;
            Read();
        }

        internal RbxAttribute(MemoryStream stream)
        {
            Reader = new BinaryReader(stream);
            Read();
        }

        internal RbxAttribute(object value)
        {
            Type type = value.GetType();

            if (SupportedTypes.TryGetValue(type, out AttributeType dataType))
            {
                DataType = dataType;
                Value = value;
            }
        }
    }

    public class RbxAttributes : SortedDictionary<string, RbxAttribute>
    {
        internal void Load(byte[] buffer)
        {
            Clear();

            if (buffer == null || buffer.Length < 4)
                // Not enough room to read the entry count, possibly empty?
                return;

            using (var input = new MemoryStream(buffer))
            using (var reader = new BinaryReader(input))
            {
                int numEntries = reader.ReadInt32();

                for (int i = 0; i < numEntries; i++)
                {
                    string key = reader.ReadString(true);
                    var attribute = new RbxAttribute(reader);
                    Add(key, attribute);
                }
            }
        }

        internal byte[] Save()
        {
            if (Count == 0)
                return Array.Empty<byte>();

            using (var output = new MemoryStream())
            using (var writer = new BinaryWriter(output))
            {
                writer.Write(Count);

                foreach (string key in Keys)
                {
                    var attribute = this[key];
                    attribute.Writer = writer;

                    attribute.WriteString(key);
                    attribute.Write(writer);
                }

                return output.ToArray();
            }
        }
    }
}
