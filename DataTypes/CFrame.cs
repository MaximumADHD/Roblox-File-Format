using RobloxFiles.Enums;
using System;
using System.Diagnostics.Contracts;

namespace RobloxFiles.DataTypes
{
    public class CFrame
    {
        private readonly float m14, m24, m34;

        private readonly float m11 = 1, m12, m13;
        private readonly float m21, m22 = 1, m23;
        private readonly float m31, m32, m33 = 1;

        private const float m41 = 0, m42 = 0, m43 = 0, m44 = 1;

        public float X => m14;
        public float Y => m24;
        public float Z => m34;

        public Vector3 Position => new Vector3(X, Y, Z);
        public CFrame Rotation => (this - Position);

        public Vector3 XVector => new Vector3(m11, m21, m31);
        public Vector3 YVector => new Vector3(m12, m22, m32);
        public Vector3 ZVector => new Vector3(m13, m23, m33);

        public Vector3 RightVector => XVector;
        public Vector3 UpVector => YVector;
        public Vector3 LookVector => -ZVector;

        public static readonly CFrame identity = new CFrame();

        public override int GetHashCode()
        {
            var components = GetComponents();
            int hashCode = 0;

            foreach (float component in components)
                hashCode ^= component.GetHashCode();

            return hashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CFrame other))
                return false;

            var compA = GetComponents();
            var compB = other.GetComponents();

            for (int i = 0; i < 12; i++)
            {
                float a = compA[i],
                      b = compB[i];

                if (a.Equals(b))
                    continue;

                return false;
            }

            return true;
        }

        public CFrame()
        {
            m14 = 0;
            m24 = 0;
            m34 = 0;
        }

        public CFrame(Vector3 pos)
        {
            m14 = pos.X;
            m24 = pos.Y;
            m34 = pos.Z;
        }

        public CFrame(float nx = 0, float ny = 0, float nz = 0)
        {
            m14 = nx;
            m24 = ny;
            m34 = nz;
        }

        public CFrame(Vector3 eye, Vector3 look)
        {
            Vector3 zAxis = (eye - look).Unit,
                    xAxis = Vector3.yAxis.Cross(zAxis),
                    yAxis = zAxis.Cross(xAxis);

            if (xAxis.Magnitude == 0)
            {
                xAxis = Vector3.zAxis;
                yAxis = Vector3.xAxis;
                zAxis = Vector3.yAxis;
            }

            m11 = xAxis.X; m12 = yAxis.X; m13 = zAxis.X; m14 = eye.X;
            m21 = xAxis.Y; m22 = yAxis.Y; m23 = zAxis.Y; m24 = eye.Y;
            m31 = xAxis.Z; m32 = yAxis.Z; m33 = zAxis.Z; m34 = eye.Z;
        }

        public CFrame(float nx, float ny, float nz, float i, float j, float k, float w)
        {
            float ii = i * i,
                  jj = j * j,
                  kk = k * k;

            m14 = nx;
            m24 = ny;
            m34 = nz;

            m11 = 1 - 2 * jj - 2 * kk;
            m12 = 2 * (i * j - k * w);
            m13 = 2 * (i * k + j * w);

            m21 = 2 * (i * j + k * w);
            m22 = 1 - 2 * ii - 2 * kk;
            m23 = 2 * (j * k - i * w);

            m31 = 2 * (i * k - j * w);
            m32 = 2 * (j * k + i * w);
            m33 = 1 - 2 * ii - 2 * jj;
        }

        public CFrame(float n14, float n24, float n34, float n11, float n12, float n13, float n21, float n22, float n23, float n31, float n32, float n33)
        {
            m14 = n14; m24 = n24; m34 = n34;
            m11 = n11; m12 = n12; m13 = n13;
            m21 = n21; m22 = n22; m23 = n23;
            m31 = n31; m32 = n32; m33 = n33;
        }

        public CFrame(params float[] comp)
        {
            Contract.Requires(comp.Length >= 12, "There should be 12 floats provided to construct a CFrame with an array of floats");

            m14 = comp[0]; m24 = comp[1]; m34 = comp[2];
            m11 = comp[3]; m12 = comp[4]; m13 = comp[5];
            m21 = comp[6]; m22 = comp[7]; m23 = comp[8];
            m31 = comp[9]; m32 = comp[10]; m33 = comp[11];
        }

        public CFrame(Vector3 pos, Vector3 vX, Vector3 vY, Vector3 vZ = null)
        {
            Contract.Requires(pos != null && vX != null && vY != null);

            if (vZ == null)
                vZ = vX.Cross(vY);

            m14 = pos.X; m24 = pos.Y; m34 = pos.Z;
            m11 = vX.X; m12 = vX.Y; m13 = vX.Z;
            m21 = vY.X; m22 = vY.Y; m23 = vY.Z;
            m31 = vZ.X; m32 = vZ.Y; m33 = vZ.Z;
        }

        public static CFrame operator +(CFrame a, Vector3 b)
        {
            float[] ac = a.GetComponents();

            float x = ac[0], y = ac[1], z = ac[2],
                  m11 = ac[3], m12 = ac[4], m13 = ac[5],
                  m21 = ac[6], m22 = ac[7], m23 = ac[8],
                  m31 = ac[9], m32 = ac[10], m33 = ac[11];

            return new CFrame(x + b.X, y + b.Y, z + b.Z, m11, m12, m13, m21, m22, m23, m31, m32, m33);
        }

        public static CFrame operator -(CFrame a, Vector3 b)
        {
            float[] ac = a.GetComponents();

            float x = ac[0], y = ac[1], z = ac[2],
                  m11 = ac[3], m12 = ac[4], m13 = ac[5],
                  m21 = ac[6], m22 = ac[7], m23 = ac[8],
                  m31 = ac[9], m32 = ac[10], m33 = ac[11];

            return new CFrame(x - b.X, y - b.Y, z - b.Z, m11, m12, m13, m21, m22, m23, m31, m32, m33);
        }

        public static Vector3 operator *(CFrame a, Vector3 b)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            else if (b == null)
                throw new ArgumentNullException(nameof(b));

            float[] ac = a.GetComponents();

            float m11 = ac[3], m12 = ac[4], m13 = ac[5],
                  m21 = ac[6], m22 = ac[7], m23 = ac[8],
                  m31 = ac[9], m32 = ac[10], m33 = ac[11];

            var up = new Vector3(m12, m22, m32);
            var back = new Vector3(m13, m23, m33);
            var right = new Vector3(m11, m21, m31);

            return a.Position + b.X * right + b.Y * up + b.Z * back;
        }

        public static CFrame operator *(CFrame a, CFrame b)
        {
            float[] ac = a.GetComponents();
            float[] bc = b.GetComponents();

            float a14 = ac[0], a24 = ac[1], a34 = ac[2],
                  a11 = ac[3], a12 = ac[4], a13 = ac[5],
                  a21 = ac[6], a22 = ac[7], a23 = ac[8],
                  a31 = ac[9], a32 = ac[10], a33 = ac[11];

            float b14 = bc[0], b24 = bc[1], b34 = bc[2],
                  b11 = bc[3], b12 = bc[4], b13 = bc[5],
                  b21 = bc[6], b22 = bc[7], b23 = bc[8],
                  b31 = bc[9], b32 = bc[10], b33 = bc[11];

            float n11 = a11 * b11 + a12 * b21 + a13 * b31 + a14 * m41;
            float n12 = a11 * b12 + a12 * b22 + a13 * b32 + a14 * m42;
            float n13 = a11 * b13 + a12 * b23 + a13 * b33 + a14 * m43;
            float n14 = a11 * b14 + a12 * b24 + a13 * b34 + a14 * m44;

            float n21 = a21 * b11 + a22 * b21 + a23 * b31 + a24 * m41;
            float n22 = a21 * b12 + a22 * b22 + a23 * b32 + a24 * m42;
            float n23 = a21 * b13 + a22 * b23 + a23 * b33 + a24 * m43;
            float n24 = a21 * b14 + a22 * b24 + a23 * b34 + a24 * m44;

            float n31 = a31 * b11 + a32 * b21 + a33 * b31 + a34 * m41;
            float n32 = a31 * b12 + a32 * b22 + a33 * b32 + a34 * m42;
            float n33 = a31 * b13 + a32 * b23 + a33 * b33 + a34 * m43;
            float n34 = a31 * b14 + a32 * b24 + a33 * b34 + a34 * m44;

            return new CFrame(n14, n24, n34, n11, n12, n13, n21, n22, n23, n31, n32, n33);
        }

        public override string ToString()
        {
            return string.Join(", ", GetComponents());
        }

        private static Vector3 VectorAxisAngle(Vector3 vec, Vector3 axis, float theta)
        {
            Vector3 unit = vec.Unit;

            float cosAng = (float)Math.Cos(theta);
            float sinAng = (float)Math.Sin(theta);

            return axis * cosAng + axis.Dot(unit) * unit * (1 - cosAng) + unit.Cross(axis) * sinAng;
        }

        public CFrame Inverse()
        {
            float[] ac = GetComponents();

            float a14 = ac[0], a24 = ac[1], a34 = ac[2],
                  a11 = ac[3], a12 = ac[4], a13 = ac[5],
                  a21 = ac[6], a22 = ac[7], a23 = ac[8],
                  a31 = ac[9], a32 = ac[10], a33 = ac[11];

            float det = (a11 * a22 * a33 * m44 + a11 * a23 * a34 * m42 + a11 * a24 * a32 * m43
                        + a12 * a21 * a34 * m43 + a12 * a23 * a31 * m44 + a12 * a24 * a33 * m41
                        + a13 * a21 * a32 * m44 + a13 * a22 * a34 * m41 + a13 * a24 * a31 * m42
                        + a14 * a21 * a33 * m42 + a14 * a22 * a31 * m43 + a14 * a23 * a32 * m41
                        - a11 * a22 * a34 * m43 - a11 * a23 * a32 * m44 - a11 * a24 * a33 * m42
                        - a12 * a21 * a33 * m44 - a12 * a23 * a34 * m41 - a12 * a24 * a31 * m43
                        - a13 * a21 * a34 * m42 - a13 * a22 * a31 * m44 - a13 * a24 * a32 * m41
                        - a14 * a21 * a32 * m43 - a14 * a22 * a33 * m41 - a14 * a23 * a31 * m42);

            if (det == 0)
                return this;

            float b11 = (a22 * a33 * m44 + a23 * a34 * m42 + a24 * a32 * m43 - a22 * a34 * m43 - a23 * a32 * m44 - a24 * a33 * m42) / det;
            float b12 = (a12 * a34 * m43 + a13 * a32 * m44 + a14 * a33 * m42 - a12 * a33 * m44 - a13 * a34 * m42 - a14 * a32 * m43) / det;
            float b13 = (a12 * a23 * m44 + a13 * a24 * m42 + a14 * a22 * m43 - a12 * a24 * m43 - a13 * a22 * m44 - a14 * a23 * m42) / det;
            float b14 = (a12 * a24 * a33 + a13 * a22 * a34 + a14 * a23 * a32 - a12 * a23 * a34 - a13 * a24 * a32 - a14 * a22 * a33) / det;

            float b21 = (a21 * a34 * m43 + a23 * a31 * m44 + a24 * a33 * m41 - a21 * a33 * m44 - a23 * a34 * m41 - a24 * a31 * m43) / det;
            float b22 = (a11 * a33 * m44 + a13 * a34 * m41 + a14 * a31 * m43 - a11 * a34 * m43 - a13 * a31 * m44 - a14 * a33 * m41) / det;
            float b23 = (a11 * a24 * m43 + a13 * a21 * m44 + a14 * a23 * m41 - a11 * a23 * m44 - a13 * a24 * m41 - a14 * a21 * m43) / det;
            float b24 = (a11 * a23 * a34 + a13 * a24 * a31 + a14 * a21 * a33 - a11 * a24 * a33 - a13 * a21 * a34 - a14 * a23 * a31) / det;

            float b31 = (a21 * a32 * m44 + a22 * a34 * m41 + a24 * a31 * m42 - a21 * a34 * m42 - a22 * a31 * m44 - a24 * a32 * m41) / det;
            float b32 = (a11 * a34 * m42 + a12 * a31 * m44 + a14 * a32 * m41 - a11 * a32 * m44 - a12 * a34 * m41 - a14 * a31 * m42) / det;
            float b33 = (a11 * a22 * m44 + a12 * a24 * m41 + a14 * a21 * m42 - a11 * a24 * m42 - a12 * a21 * m44 - a14 * a22 * m41) / det;
            float b34 = (a11 * a24 * a32 + a12 * a21 * a34 + a14 * a22 * a31 - a11 * a22 * a34 - a12 * a24 * a31 - a14 * a21 * a32) / det;

            return new CFrame(b14, b24, b34, b11, b12, b13, b21, b22, b23, b31, b32, b33);
        }

        public static CFrame FromAxisAngle(Vector3 axis, float theta)
        {
            Vector3 r = VectorAxisAngle(axis, Vector3.xAxis, theta),
                    u = VectorAxisAngle(axis, Vector3.yAxis, theta),
                    b = VectorAxisAngle(axis, Vector3.zAxis, theta);

            return new CFrame
            (
                0, 0, 0,
                r.X, u.X, b.X,
                r.Y, u.Y, b.Y,
                r.Z, u.Z, b.Z
            );
        }

        public static CFrame FromEulerAngles(RotationOrder order, EulerAngles angles)
        {
            CFrame cfx = FromAxisAngle(Vector3.xAxis, angles.Pitch),
                   cfy = FromAxisAngle(Vector3.yAxis, angles.Yaw),
                   cfz = FromAxisAngle(Vector3.zAxis, angles.Roll);

            CFrame result = null;

            switch (order)
            {
                case RotationOrder.XYZ:
                {
                    result = cfx * cfy * cfz;
                    break;
                }
                case RotationOrder.XZY:
                {
                    result = cfx * cfz * cfy;
                    break;
                }
                case RotationOrder.YXZ:
                {
                    result = cfy * cfx * cfz;
                    break;
                }
                case RotationOrder.YZX:
                {
                    result = cfy * cfz * cfx;
                    break;
                }
                case RotationOrder.ZXY:
                {
                    result = cfz * cfx * cfy;
                    break;
                }
                case RotationOrder.ZYX:
                {
                    result = cfz * cfy * cfx;
                    break;
                }
            }

            if (result == null)
                throw new ArgumentOutOfRangeException(nameof(order), order, null);

            return result;
        }

        public static CFrame FromEulerAnglesXYZ(float x, float y, float z)
        {
            CFrame cfx = FromAxisAngle(Vector3.xAxis, x),
                   cfy = FromAxisAngle(Vector3.yAxis, y),
                   cfz = FromAxisAngle(Vector3.zAxis, z);

            return cfx * cfy * cfz;
        }

        public static CFrame FromEulerAnglesXYZ(params float[] angles)
        {
            Contract.Requires(angles.Length == 3);

            float x = angles[0],
                  y = angles[1],
                  z = angles[2];

            return FromEulerAnglesXYZ(x, y, z);
        }

        public static CFrame Angles(float x, float y, float z) => FromEulerAnglesXYZ(x, y, z);
        public static CFrame Angles(params float[] angles) => FromEulerAnglesXYZ(angles);

        public CFrame Lerp(CFrame other, float t)
        {
            if (t == 0f)
                return this;
            else if (t == 1f)
                return other;

            var q1 = new Quaternion(this);
            var q2 = new Quaternion(other);

            CFrame rot = q1.Slerp(q2, t).ToCFrame();
            Vector3 pos = Position.Lerp(other.Position, t);

            return new CFrame(pos) * rot;
        }

        public CFrame ToWorldSpace(CFrame cf2)
        {
            return this * cf2;
        }

        public CFrame ToObjectSpace(CFrame other)
        {
            return Inverse() * other;
        }

        public Vector3 PointToWorldSpace(Vector3 v)
        {
            return this * v;
        }

        public Vector3 PointToObjectSpace(Vector3 v)
        {
            return Inverse() * v;
        }

        public Vector3 VectorToWorldSpace(Vector3 v)
        {
            return (this - Position) * v;
        }

        public Vector3 VectorToObjectSpace(Vector3 v)
        {
            return (this - Position).Inverse() * v;
        }

        public float[] GetComponents()
        {
            return new float[]
            {
                m14, m24, m34,
                m11, m12, m13,
                m21, m22, m23,
                m31, m32, m33
            };
        }

        public EulerAngles ToEulerAngles() => new EulerAngles
        {
            Yaw = (float)Math.Asin(m13),
            Pitch = (float)Math.Atan2(-m23, m33),
            Roll = (float)Math.Atan2(-m12, m11),
        };

        [Obsolete]
        public float[] ToEulerAnglesXYZ()
        {
            var result = ToEulerAngles();

            return new float[]
            {
                result.Pitch,
                result.Yaw,
                result.Roll
            };
        }

        public bool IsAxisAligned()
        {
            var tests = new float[3]
            {
                XVector.Dot(Vector3.xAxis),
                YVector.Dot(Vector3.yAxis),
                ZVector.Dot(Vector3.zAxis)
            };

            foreach (var test in tests)
            {
                float dot = Math.Abs(test);

                if (dot.FuzzyEquals(1))
                    continue;

                if (dot.FuzzyEquals(0))
                    continue;

                return false;
            }

            return true;
        }

        private static bool IsLegalOrientId(int orientId)
        {
            int xOrientId = (orientId / 6) % 3;
            int yOrientId = orientId % 3;
            return xOrientId != yOrientId;
        }

        public int GetOrientId()
        {
            if (!IsAxisAligned())
                return -1;

            int xNormal = XVector.ToNormalId();
            int yNormal = YVector.ToNormalId();
            int orientId = (6 * xNormal) + yNormal;

            if (!IsLegalOrientId(orientId))
                return -1;

            return orientId;
        }

        internal static CFrame FromOrientId(int orientId)
        {
            var xColumn = (NormalId)(orientId / 6);
            var yColumn = (NormalId)(orientId % 6);

            var R0 = Vector3.FromNormalId(xColumn);
            var R1 = Vector3.FromNormalId(yColumn);
            var R2 = R0.Cross(R1);

            var matrix = new float[12]
            {
                0,    0,    0,
                R0.X, R1.X, R2.X,
                R0.Y, R1.Y, R2.Y,
                R0.Z, R1.Z, R2.Z
            };

            return new CFrame(matrix);
        }
    }
}