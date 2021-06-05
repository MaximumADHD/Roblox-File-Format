using System;

namespace RobloxFiles.DataTypes
{
    public class Vector2int16
    {
        public readonly short X, Y;
        public override string ToString() => $"{X}, {Y}";

        public Vector2int16(short x = 0, short y = 0)
        {
            X = x;
            Y = y;
        }

        public Vector2int16(int x = 0, int y = 0)
        {
            X = (short)x;
            Y = (short)y;
        }

        private delegate Vector2int16 Operator(Vector2int16 a, Vector2int16 b);
        
        private static Vector2int16 upcastShortOp(Vector2int16 vec, short num, Operator upcast)
        {
            Vector2int16 numVec = new Vector2int16(num, num);
            return upcast(vec, numVec);
        }

        private static Vector2int16 upcastShortOp(short num, Vector2int16 vec, Operator upcast)
        {
            Vector2int16 numVec = new Vector2int16(num, num);
            return upcast(numVec, vec);
        }

        private static readonly Operator add = new Operator((a, b) => new Vector2int16(a.X + b.X, a.Y + b.Y));
        private static readonly Operator sub = new Operator((a, b) => new Vector2int16(a.X - b.X, a.Y - b.Y));
        private static readonly Operator mul = new Operator((a, b) => new Vector2int16(a.X * b.X, a.Y * b.Y));
        private static readonly Operator div = new Operator((a, b) =>
        {
            if (b.X == 0 || b.Y == 0)
                throw new DivideByZeroException();

            return new Vector2int16(a.X / b.X, a.Y / b.Y);
        });

        public static Vector2int16 operator +(Vector2int16 a, Vector2int16 b) => add(a, b);
        public static Vector2int16 operator +(Vector2int16 v, short n)        => upcastShortOp(v, n, add);
        public static Vector2int16 operator +(short n, Vector2int16 v)        => upcastShortOp(n, v, add);

        public static Vector2int16 operator -(Vector2int16 a, Vector2int16 b) => sub(a, b);
        public static Vector2int16 operator -(Vector2int16 v, short n)        => upcastShortOp(v, n, sub);
        public static Vector2int16 operator -(short n, Vector2int16 v)        => upcastShortOp(n, v, sub);

        public static Vector2int16 operator *(Vector2int16 a, Vector2int16 b) => mul(a, b);
        public static Vector2int16 operator *(Vector2int16 v, short n)        => upcastShortOp(v, n, mul);
        public static Vector2int16 operator *(short n, Vector2int16 v)        => upcastShortOp(n, v, mul);

        public static Vector2int16 operator /(Vector2int16 a, Vector2int16 b) => div(a, b);
        public static Vector2int16 operator /(Vector2int16 v, short n)        => upcastShortOp(v, n, div);
        public static Vector2int16 operator /(short n, Vector2int16 v)        => upcastShortOp(n, v, div);

        public override int GetHashCode()
        {
            int hash = X.GetHashCode()
                     ^ Y.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2int16 other))
                return false;

            if (!X.Equals(other.X))
                return false;

            if (!Y.Equals(other.Y))
                return false;

            return true;
        }
    }
}
