using System;
using RobloxFiles.BinaryFormat.Chunks;

namespace RobloxFiles
{
    public enum PropertyType
    {
        Unknown,
        String,
        Bool,
        Int,
        Float,
        Double,
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
        CFrame,
        Quaternion,
        Enum,
        Ref,
        Vector3int16,
        NumberSequence,
        ColorSequence,
        NumberRange,
        Rect,
        PhysicalProperties,
        Color3uint8,
        Int64,
        SharedString,
    }

    public class Property
    {
        public string Name;
        public Instance Instance;

        public PropertyType Type;
        public object Value;

        public string XmlToken = "";
        private byte[] RawBuffer = null;

        public bool HasRawBuffer
        {
            get
            {
                if (RawBuffer == null && Value != null)
                {
                    // Improvise what the buffer should be if this is a primitive.
                    switch (Type)
                    {
                        case PropertyType.Int:
                            RawBuffer = BitConverter.GetBytes((int)Value);
                            break;
                        case PropertyType.Int64:
                            RawBuffer = BitConverter.GetBytes((long)Value);
                            break;
                        case PropertyType.Bool:
                            RawBuffer = BitConverter.GetBytes((bool)Value);
                            break;
                        case PropertyType.Float:
                            RawBuffer = BitConverter.GetBytes((float)Value);
                            break;
                        case PropertyType.Double:
                            RawBuffer = BitConverter.GetBytes((double)Value);
                            break;
                        case PropertyType.SharedString:
                            RawBuffer = Convert.FromBase64String((string)Value);
                            break;
                    }
                }

                return (RawBuffer != null);
            }
        }

        public Property(string name = "", PropertyType type = PropertyType.Unknown, Instance instance = null)
        {
            Name = name;
            Type = type;

            Instance = instance;
        }

        public Property(Instance instance, PROP property)
        {
            Instance = instance;
            Name = property.Name;
            Type = property.Type;
        }

        public string GetFullName()
        {
            string result = Name;

            if (Instance != null)
                result = Instance.GetFullName() + '.' + result;

            return result;
        }

        public override string ToString()
        {
            string typeName = Enum.GetName(typeof(PropertyType), Type);
            string valueLabel = (Value != null ? Value.ToString() : "null");

            if (Type == PropertyType.String)
                valueLabel = '"' + valueLabel + '"';

            return string.Join(" ", typeName, Name, '=', valueLabel);
        }

        internal void SetRawBuffer(byte[] buffer)
        {
            RawBuffer = buffer;
        }

        public byte[] GetRawBuffer()
        {
            return RawBuffer;
        }
    }
}