using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using RobloxFiles.DataTypes;

namespace RobloxFiles
{
    public enum AttributeType
    {
        Null = 1,
        String,
        Bool,
        Int,
        Float,
        Double,
        Array,
        Dictionary,
        UDim,
        UDim2,
        Ray,
        Faces,
        Axes,
        BrickColor,
        Color3,
        Vector2,
        Vector3,
        Vector2int16,
        Vector3int16,
        CFrame,
        Enum,
        NumberSequence = 23,
        NumberSequenceKeypoint,
        ColorSequence,
        ColorSequenceKeypoint,
        NumberRange,
        Rect,
        PhysicalProperties,
        Region3 = 31,
        Region3int16,
    }

    public class Attribute : IDisposable
    {
        public AttributeType DataType { get; private set; }
        public object Value { get; private set; }

        public override string ToString()
        {
            string type = Enum.GetName(typeof(AttributeType), DataType);
            string value = Value?.ToString() ?? "null";
            return $"[{type}: {value}]";
        }

        internal BinaryReader reader;
        // internal BinaryWriter writer;

        internal int ReadInt() => reader.ReadInt32();
        internal byte readByte() => reader.ReadByte();
        internal bool readBool() => reader.ReadBoolean();
        internal short readShort() => reader.ReadInt16();
        internal float ReadFloat() => reader.ReadSingle();
        internal double ReadDouble() => reader.ReadDouble();
        internal string ReadString() => reader.ReadString(true);

        internal Attribute[] ReadArray()
        {
            int count = ReadInt();
            var result = new Attribute[count];

            for (int i = 0; i < count; i++)
                result[i] = new Attribute(reader);

            return result;
        }

        internal object readEnum()
        {
            string name = ReadString();
            int value = ReadInt();

            try
            {
                Type enumType = Type.GetType($"RobloxFiles.Enums.{name}");
                return Enum.ToObject(enumType, value);
            }
            catch
            {
                if (RobloxFile.LogErrors)
                    Console.Error.WriteLine($"RobloxFile - Got unknown Enum {name} in Attribute.");

                return null;
            }
        }

        private void readData()
        {
            if (reader == null)
                return;

            DataType = (AttributeType)reader.ReadByte();

            switch (DataType)
            {
                //////////////////////////
                case AttributeType.Null:
                    break;
                case AttributeType.String:
                    Value = ReadString();
                    break;
                case AttributeType.Bool:
                    Value = readBool();
                    break;
                case AttributeType.Int:
                    Value = ReadInt();
                    break;
                case AttributeType.Float:
                    Value = ReadFloat();
                    break;
                case AttributeType.Double:
                    Value = ReadDouble();
                    break;
                case AttributeType.Array:
                    Value = ReadArray();
                    break;
                case AttributeType.Dictionary:
                    Value = new Attributes(reader);
                    break;
                case AttributeType.UDim:
                    Value = new UDim(this);
                    break;
                case AttributeType.UDim2:
                    Value = new UDim2(this);
                    break;
                case AttributeType.Ray:
                    Value = new Ray(this);
                    break;
                case AttributeType.Faces:
                    Value = (Faces)ReadInt();
                    break;
                case AttributeType.Axes:
                    Value = (Axes)ReadInt();
                    break;
                case AttributeType.BrickColor:
                    Value = (BrickColor)ReadInt();
                    break;
                case AttributeType.Color3:
                    Value = new Color3(this);
                    break;
                case AttributeType.Vector2:
                    Value = new Vector2(this);
                    break;
                case AttributeType.Vector3:
                    Value = new Vector3(this);
                    break;
                case AttributeType.Vector2int16:
                    Value = new Vector2int16(this);
                    break;
                case AttributeType.Vector3int16:
                    Value = new Vector3int16(this);
                    break;
                case AttributeType.CFrame:
                    Value = new CFrame(this);
                    break;
                case AttributeType.Enum:
                    Value = readEnum();
                    break;
                case AttributeType.NumberSequence:
                    Value = new NumberSequence(this);
                    break;
                case AttributeType.NumberSequenceKeypoint:
                    Value = new NumberSequenceKeypoint(this);
                    break;
                case AttributeType.ColorSequence:
                    Value = new ColorSequence(this);
                    break;
                case AttributeType.ColorSequenceKeypoint:
                    Value = new ColorSequenceKeypoint(this);
                    break;
                case AttributeType.NumberRange:
                    Value = new NumberRange(this);
                    break;
                case AttributeType.Rect:
                    Value = new Rect(this);
                    break;
                case AttributeType.PhysicalProperties:
                    bool custom = readBool();

                    if (custom)
                        Value = new PhysicalProperties(this);

                    break;
                case AttributeType.Region3:
                    Value = new Region3(this);
                    break;
                case AttributeType.Region3int16:
                    Value = new Region3int16(this);
                    break;
                default:
                    throw new InvalidDataException($"Cannot handle AttributeType {DataType}!");
                //////////////////////////
            }

            reader = null;
        }

        public void Dispose()
        {
            reader.Dispose();
        }

        internal Attribute(BinaryReader reader)
        {
            this.reader = reader;
            readData();
        }

        internal Attribute(MemoryStream stream)
        {
            reader = new BinaryReader(stream);
            readData();
        }
    }

    public class Attributes : Dictionary<string, Attribute>
    {
        private void Initialize(BinaryReader reader)
        {
            Stream stream = reader.BaseStream;

            if (stream.Length - stream.Position < 4)
                // Not enough room to read the entry count, possibly empty?
                return;

            int numEntries = reader.ReadInt32();

            for (int i = 0; i < numEntries; i++)
            {
                string key = reader.ReadString(true);
                var attribute = new Attribute(reader);
                Add(key, attribute);
            }
        }

        internal Attributes(BinaryReader reader)
        {
            Initialize(reader);
        }

        internal Attributes(MemoryStream stream)
        {
            using (BinaryReader reader = new BinaryReader(stream))
            {
                Initialize(reader);
            }
        }

        internal byte[] Serialize()
        {
            // TODO
            return Array.Empty<byte>();
        }
    }
}
