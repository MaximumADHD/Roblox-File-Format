using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RobloxFiles.BinaryFormat
{
    public class BinaryRobloxFileReader : BinaryReader
    {
        public readonly BinaryRobloxFile File;
        private byte[] lastStringBuffer = Array.Empty<byte>();

        public BinaryRobloxFileReader(BinaryRobloxFile file, Stream stream) : base(stream)
        {
            File = file;
        }

        // Reads 'count * sizeof(T)' interleaved bytes and converts 
        // them into an array of T[count] where each value in the 
        // array has been decoded by the provided 'decode' function.
        public T[] ReadInterleaved<T>(int count, Func<byte[], int, T> decode) where T : struct
        {
            int bufferSize = Marshal.SizeOf<T>();
            byte[] interleaved = ReadBytes(count * bufferSize);

            T[] values = new T[count];

            for (int i = 0; i < count; i++)
            {
                long buffer = 0;

                for (int column = 0; column < bufferSize; column++)
                {
                    long block = interleaved[(column * count) + i];
                    int shift = (bufferSize - column - 1) * 8;
                    buffer |= (block << shift);
                }

                byte[] sequence = BitConverter.GetBytes(buffer);
                values[i] = decode(sequence, 0);
            }

            return values;
        }
        
        // Decodes an int from an interleaved buffer.
        private int DecodeInt(byte[] buffer, int startIndex)
        {
            int value = BitConverter.ToInt32(buffer, startIndex);
            return (value >> 1) ^ (-(value & 1));
        }
        
        // Decodes a float from an interleaved buffer.
        private float DecodeFloat(byte[] buffer, int startIndex)
        {
            uint u = BitConverter.ToUInt32(buffer, startIndex);
            uint i = (u >> 1) | (u << 31);

            byte[] b = BitConverter.GetBytes(i);
            return BitConverter.ToSingle(b, 0);
        }
        
        // Reads an interleaved buffer of integers.
        public int[] ReadInts(int count)
        {
            return ReadInterleaved(count, DecodeInt);
        }
        
        // Reads an interleaved buffer of floats.
        public float[] ReadFloats(int count)
        {
            return ReadInterleaved(count, DecodeFloat);
        }

        // Reads an interleaved buffer of unsigned integers.
        public uint[] ReadUInts(int count)
        {
            return ReadInterleaved(count, BitConverter.ToUInt32);
        }
        
        // Reads and accumulates an interleaved buffer of integers.
        public List<int> ReadInstanceIds(int count)
        {
            int[] values = ReadInts(count);

            for (int i = 1; i < count; ++i)
                values[i] += values[i - 1];

            return values.ToList();
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
