using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Roblox.BinaryFormat
{
    public class RobloxBinaryReader : BinaryReader
    {
        public RobloxBinaryReader(Stream stream) : base(stream) { }
        private byte[] lastStringBuffer = new byte[0] { };

        public T[] ReadInterlaced<T>(int count, Func<byte[], int, T> decode) where T : struct
        {
            int bytesPerBlock = Marshal.SizeOf<T>();
            byte[] interlaced = ReadBytes(count * bytesPerBlock);

            T[] values = new T[count];

            for (int i = 0; i < count; i++)
            {
                long block = 0;

                for (int pack = 0; pack < bytesPerBlock; pack++)
                {
                    long bits = interlaced[(pack * count) + i];
                    int shift = (bytesPerBlock - pack - 1) * 8;
                    block |= (bits << shift);
                }

                byte[] buffer = BitConverter.GetBytes(block);
                values[i] = decode(buffer, 0);
            }

            return values;
        }

        private int ReadInterlacedInt(byte[] buffer, int startIndex)
        {
            int value = BitConverter.ToInt32(buffer, startIndex);
            return (value >> 1) ^ (-(value & 1));
        }

        private float ReadInterlacedFloat(byte[] buffer, int startIndex)
        {
            uint u = BitConverter.ToUInt32(buffer, startIndex);
            uint i = (u >> 1) | (u << 31);

            byte[] b = BitConverter.GetBytes(i);
            return BitConverter.ToSingle(b, 0);
        }

        public int[] ReadInts(int count)
        {
            return ReadInterlaced(count, ReadInterlacedInt);
        }

        public float[] ReadFloats(int count)
        {
            return ReadInterlaced(count, ReadInterlacedFloat);
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

            lastStringBuffer = buffer;
            return Encoding.UTF8.GetString(buffer);
        }

        public float ReadFloat()
        {
            return ReadSingle();
        }

        public byte[] GetLastStringBuffer()
        {
            return lastStringBuffer;
        }
    }
}