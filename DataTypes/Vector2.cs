#pragma warning disable IDE1006 // Naming Styles
using System;

namespace RobloxFiles.DataTypes
{

    public class Vector2
    {
        public readonly float X, Y;
        public override string ToString() => $"{X}, {Y}";

        public Vector2(float x = 0, float y = 0)
        {
            X = x;
            Y = y;
        }

        public Vector2(params float[] coords)
        {
            X = coords.Length > 0 ? coords[0] : 0;
            Y = coords.Length > 1 ? coords[1] : 0;
        }
        
        public float Magnitude => (float)Math.Sqrt(X*X + Y*Y);
        public Vector2 Unit => this / Magnitude;

        private delegate Vector2 Operator(Vector2 a, Vector2 b);

        private static Vector2 UpcastFloatOp(Vector2 vec, float num, Operator upcast)
        {
            var numVec = new Vector2(num, num);
            return upcast(vec, numVec);
        }

        private static Vector2 UpcastFloatOp(float num, Vector2 vec, Operator upcast)
        {
            var numVec = new Vector2(num, num);
            return upcast(numVec, vec);
        }

        private static readonly Operator add = new Operator((a, b) => new Vector2(a.X + b.X, a.Y + b.Y));
        private static readonly Operator sub = new Operator((a, b) => new Vector2(a.X - b.X, a.Y - b.Y));
        private static readonly Operator mul = new Operator((a, b) => new Vector2(a.X * b.X, a.Y * b.Y));
        private static readonly Operator div = new Operator((a, b) => new Vector2(a.X / b.X, a.Y / b.Y));

        public static Vector2 operator +(Vector2 a, Vector2 b) => add(a, b);
        public static Vector2 operator +(Vector2 v, float n) => UpcastFloatOp(v, n, add);
        public static Vector2 operator +(float n, Vector2 v) => UpcastFloatOp(n, v, add);

        public static Vector2 operator -(Vector2 a, Vector2 b) => sub(a, b);
        public static Vector2 operator -(Vector2 v, float n) => UpcastFloatOp(v, n, sub);
        public static Vector2 operator -(float n, Vector2 v) => UpcastFloatOp(n, v, sub);

        public static Vector2 operator *(Vector2 a, Vector2 b) => mul(a, b);
        public static Vector2 operator *(Vector2 v, float n) => UpcastFloatOp(v, n, mul);
        public static Vector2 operator *(float n, Vector2 v) => UpcastFloatOp(n, v, mul);

        public static Vector2 operator /(Vector2 a, Vector2 b) => div(a, b);
        public static Vector2 operator /(Vector2 v, float n) => UpcastFloatOp(v, n, div);
        public static Vector2 operator /(float n, Vector2 v) => UpcastFloatOp(n, v, div);

        public static Vector2 operator -(Vector2 v) => new Vector2(-v.X, -v.Y);

        public static Vector2 zero => new Vector2(0, 0);
        public static Vector2 one  => new Vector2(1, 1);

        public static Vector2 xAxis => new Vector2(1, 0);
        public static Vector2 yAxis => new Vector2(0, 1);

        public float Dot(Vector2 other) => (X * other.X) + (Y * other.Y);
        public Vector2 Cross(Vector2 other) => new Vector2(X * other.Y, Y * other.X);
        
        public Vector2 Lerp(Vector2 other, float t)
        {
            return this + (other - this) * t;
        }

        public override int GetHashCode()
        {
            int hash = X.GetHashCode()
                     ^ Y.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2 other))
                return false;

            if (!X.Equals(other.X))
                return false;

            if (!Y.Equals(other.Y))
                return false;

            return true;
        }
    }
}