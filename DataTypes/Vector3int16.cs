using System;

namespace RobloxFiles.DataTypes
{
    public class Vector3int16
    {
        public readonly short X, Y, Z;
        public override string ToString() => $"{X}, {Y}, {Z}";

        public Vector3int16() : this(0, 0, 0)
        {
        }

        public Vector3int16(short x = 0, short y = 0, short z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3int16(int x = 0, int y = 0, int z = 0)
        {
            X = (short)x;
            Y = (short)y;
            Z = (short)z;
        }

        private delegate Vector3int16 Operator(Vector3int16 a, Vector3int16 b);
        
        private static Vector3int16 upcastShortOp(Vector3int16 vec, short num, Operator upcast)
        {
            Vector3int16 numVec = new Vector3int16(num, num, num);
            return upcast(vec, numVec);
        }

        private static Vector3int16 upcastShortOp(short num, Vector3int16 vec, Operator upcast)
        {
            Vector3int16 numVec = new Vector3int16(num, num, num);
            return upcast(numVec, vec);
        }

        private static readonly Operator add = new Operator((a, b) => new Vector3int16(a.X + b.X, a.Y + b.Y, a.Z + b.Z));
        private static readonly Operator sub = new Operator((a, b) => new Vector3int16(a.X - b.X, a.Y - b.Y, a.Z - b.Z));
        private static readonly Operator mul = new Operator((a, b) => new Vector3int16(a.X * b.X, a.Y * b.Y, a.Z * b.Z));
        private static readonly Operator div = new Operator((a, b) =>
        {
            if (b.X == 0 || b.Y == 0 || b.Z == 0)
                throw new DivideByZeroException();

            return new Vector3int16(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        });

        public static Vector3int16 operator +(Vector3int16 a, Vector3int16 b) => add(a, b);
        public static Vector3int16 operator +(Vector3int16 v, short n)        => upcastShortOp(v, n, add);
        public static Vector3int16 operator +(short n, Vector3int16 v)        => upcastShortOp(n, v, add);

        public static Vector3int16 operator -(Vector3int16 a, Vector3int16 b) => sub(a, b);
        public static Vector3int16 operator -(Vector3int16 v, short n)        => upcastShortOp(v, n, sub);
        public static Vector3int16 operator -(short n, Vector3int16 v)        => upcastShortOp(n, v, sub);

        public static Vector3int16 operator *(Vector3int16 a, Vector3int16 b) => mul(a, b);
        public static Vector3int16 operator *(Vector3int16 v, short n)        => upcastShortOp(v, n, mul);
        public static Vector3int16 operator *(short n, Vector3int16 v)        => upcastShortOp(n, v, mul);

        public static Vector3int16 operator /(Vector3int16 a, Vector3int16 b) => div(a, b);
        public static Vector3int16 operator /(Vector3int16 v, short n)        => upcastShortOp(v, n, div);
        public static Vector3int16 operator /(short n, Vector3int16 v)        => upcastShortOp(n, v, div);

        public override int GetHashCode()
        {
            int hash = X.GetHashCode()
                     ^ Y.GetHashCode()
                     ^ Z.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector3int16 other))
                return false;

            if (!X.Equals(other.X))
                return false;

            if (!Y.Equals(other.Y))
                return false;

            if (!Z.Equals(other.Z))
                return false;

            return true;
        }
    }
}
