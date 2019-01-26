using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

using Roblox.DataTypes;

namespace Roblox.BinaryFormat
{
    public class RobloxBinaryReader : BinaryReader
    {
        public RobloxBinaryReader(Stream stream) : base(stream) { }

        public T[] ReadInterwovenValues<T>(int count, Func<byte[], int, T> decode) where T : struct
        {
            int bufferSize = Marshal.SizeOf<T>();

            byte[] interwoven = ReadBytes(count * bufferSize);
            T[] values = new T[count];

            for (int i = 0; i < count; i++)
            {
                long unwind = 0;

                for (int weave = 0; weave < bufferSize; weave++)
                {
                    long splice = interwoven[(weave * count) + i];
                    int strand = (bufferSize - weave - 1) * 8;
                    unwind |= (splice << strand);
                }

                byte[] buffer = BitConverter.GetBytes(unwind);
                values[i] = decode(buffer, 0);
            }

            return values;
        }

        public int[] ReadInts(int count)
        {
            return ReadInterwovenValues(count, (buffer, start) =>
            {
                int value = BitConverter.ToInt32(buffer, start);
                return (value >> 1) ^ (-(value & 1));
            });
        }

        public float[] ReadFloats(int count)
        {
            return ReadInterwovenValues(count, (buffer, start) =>
            {
                uint u = BitConverter.ToUInt32(buffer, start);
                uint i = (u >> 1) | (u << 31);

                byte[] b = BitConverter.GetBytes(i);
                return BitConverter.ToSingle(b, 0);
            });
        }

        public int[] ReadInstanceIds(int count)
        {
            int[] values = ReadInts(count);

            for (int i = 1; i < count; ++i)
                values[i] += values[i - 1];

            return values;
        }

        public override string ReadString()
        {
            int length = ReadInt32();
            byte[] buffer = ReadBytes(length);
            return Encoding.UTF8.GetString(buffer);
        }
    }
}
