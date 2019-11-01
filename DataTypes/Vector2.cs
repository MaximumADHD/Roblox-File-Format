using System;

namespace RobloxFiles.DataTypes
{
    public class Vector2
    {
        public readonly float X, Y;
        public override string ToString() => $"{X}, {Y}";

        public float Magnitude
        {
            get
            {
                float product = Dot(this);
                double magnitude = Math.Sqrt(product);

                return (float)magnitude;
            }
        }

        public Vector2 Unit
        {
            get { return this / Magnitude; }
        }

        public Vector2(float x = 0, float y = 0)
        {
            X = x;
            Y = y;
        }

        internal Vector2(float[] coords)
        {
            X = coords.Length > 0 ? coords[0] : 0;
            Y = coords.Length > 1 ? coords[1] : 0;
        }

        internal Vector2(Attribute attr)
        {
            X = attr.readFloat();
            Y = attr.readFloat();
        }

        private delegate Vector2 Operator(Vector2 a, Vector2 b);

        private static Vector2 upcastFloatOp(Vector2 vec, float num, Operator upcast)
        {
            Vector2 numVec = new Vector2(num, num);
            return upcast(vec, numVec);
        }

        private static Vector2 upcastFloatOp(float num, Vector2 vec, Operator upcast)
        {
            Vector2 numVec = new Vector2(num, num);
            return upcast(numVec, vec);
        }

        private static Operator add = new Operator((a, b) => new Vector2(a.X + b.X, a.Y + b.Y));
        private static Operator sub = new Operator((a, b) => new Vector2(a.X - b.X, a.Y - b.Y));
        private static Operator mul = new Operator((a, b) => new Vector2(a.X * b.X, a.Y * b.Y));
        private static Operator div = new Operator((a, b) => new Vector2(a.X / b.X, a.Y / b.Y));

        public static Vector2 operator +(Vector2 a, Vector2 b) => add(a, b);
        public static Vector2 operator +(Vector2 v, float n) => upcastFloatOp(v, n, add);
        public static Vector2 operator +(float n, Vector2 v) => upcastFloatOp(n, v, add);

        public static Vector2 operator -(Vector2 a, Vector2 b) => sub(a, b);
        public static Vector2 operator -(Vector2 v, float n) => upcastFloatOp(v, n, sub);
        public static Vector2 operator -(float n, Vector2 v) => upcastFloatOp(n, v, sub);

        public static Vector2 operator *(Vector2 a, Vector2 b) => mul(a, b);
        public static Vector2 operator *(Vector2 v, float n) => upcastFloatOp(v, n, mul);
        public static Vector2 operator *(float n, Vector2 v) => upcastFloatOp(n, v, mul);

        public static Vector2 operator /(Vector2 a, Vector2 b) => div(a, b);
        public static Vector2 operator /(Vector2 v, float n) => upcastFloatOp(v, n, div);
        public static Vector2 operator /(float n, Vector2 v) => upcastFloatOp(n, v, div);

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.X, -v.Y);
        }

        public static Vector2 Zero => new Vector2(0, 0);

        public float Dot(Vector2 other)
        {
            float dotX = X * other.X;
            float dotY = Y * other.Y;

            return dotX + dotY;
        }

        public Vector2 Cross(Vector2 other)
        {
            float crossX = X * other.Y;
            float crossY = Y * other.X;

            return new Vector2(crossX, crossY);
        }

        public Vector2 Lerp(Vector2 other, float t)
        {
            return this + (other - this) * t;
        }
    }
}