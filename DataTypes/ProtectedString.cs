using System;
using System.Text;

namespace RobloxFiles.DataTypes
{
    /// <summary>
    /// ProtectedString is a type used by the Source property of scripts.
    /// If constructed as an array of bytes, it's assumed to be compiled byte-code.
    /// </summary>
    public class ProtectedString
    {
        public readonly bool IsCompiled;
        public readonly byte[] RawBuffer;

        public override string ToString()
        {
            if (IsCompiled)
                return $"byte[{RawBuffer.Length}]";

            return Encoding.UTF8.GetString(RawBuffer);
        }

        public ProtectedString(string value)
        {
            IsCompiled = false;
            RawBuffer = Encoding.UTF8.GetBytes(value);
        }

        public ProtectedString(byte[] compiled)
        {
            // This'll break in the future if Luau ever has more than 32 VM versions.
            // Feels pretty unlikely this'll happen anytime soon, if ever.

            IsCompiled = true;

            if (compiled.Length > 0)
                if (compiled[0] >= 32)
                    IsCompiled = false;

            RawBuffer = compiled;
        }

        public static implicit operator string(ProtectedString protectedString)
        {
            return Encoding.UTF8.GetString(protectedString.RawBuffer);
        }

        public static implicit operator ProtectedString(string value)
        {
            return new ProtectedString(value);
        }

        public static implicit operator byte[](ProtectedString protectedString)
        {
            return protectedString.RawBuffer;
        }

        public static implicit operator ProtectedString(byte[] value)
        {
            return new ProtectedString(value);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ProtectedString other))
                return false;

            var otherBuffer = other.RawBuffer;

            if (RawBuffer.Length != otherBuffer.Length)
                return false;

            for (int i = 0; i < RawBuffer.Length; i++)
                if (RawBuffer[i] != otherBuffer[i])
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            var str = Convert.ToBase64String(RawBuffer);
            return str.GetHashCode();
        }
    }
}
