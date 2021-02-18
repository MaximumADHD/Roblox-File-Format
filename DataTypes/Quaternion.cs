using System;

namespace RobloxFiles.DataTypes
{
    /// <summary>
    /// Quaternion is a utility used by the CFrame DataType to handle rotation interpolation.
    /// It can be used as an independent Quaternion implementation if you so please!
    /// </summary>
    public class Quaternion
    {
        public readonly float X, Y, Z, W;
        public override string ToString() => $"{X}, {Y}, {Z}, {W}";

        public float Magnitude
        {
            get
            {
                float squared = Dot(this);
                double magnitude = Math.Sqrt(squared);

                return (float)magnitude;
            }
        }
        
        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Quaternion(Vector3 qv, float qw)
        {
            X = qv.X;
            Y = qv.Y;
            Z = qv.Z;
            W = qw;
        }

        public Quaternion(CFrame cf)
        {
            float[] ac = cf.GetComponents();

            float m11 = ac[3], m12 = ac[4],  m13 = ac[5],
                  m21 = ac[6], m22 = ac[7],  m23 = ac[8],
                  m31 = ac[9], m32 = ac[10], m33 = ac[11];

            float trace = m11 + m22 + m33;

            if (trace > 0)
            {
                float s = (float)Math.Sqrt(1 + trace);
                float r = 0.5f / s;

                W = s * 0.5f;
                X = (m32 - m23) * r;
                Y = (m13 - m31) * r;
                Z = (m21 - m12) * r;
            }
            else
            {
                float big = Math.Max(Math.Max(m11, m22), m33);

                if (big == m11)
                {
                    float s = (float)Math.Sqrt(1 + m11 - m22 - m33);
                    float r = 0.5f / s;

                    W = (m32 - m23) * r;
                    X = 0.5f * s;
                    Y = (m21 + m12) * r;
                    Z = (m13 + m31) * r;
                }
                else if (big == m22)
                {
                    float s = (float)Math.Sqrt(1 - m11 + m22 - m33);
                    float r = 0.5f / s;

                    W = (m13 - m31) * r;
                    X = (m21 + m12) * r;
                    Y = 0.5f * s;
                    Z = (m32 + m23) * r;
                }
                else if (big == m33)
                {
                    float s = (float)Math.Sqrt(1 - m11 - m22 + m33);
                    float r = 0.5f / s;

                    W = (m21 - m12) * r;
                    X = (m13 + m31) * r;
                    Y = (m32 + m23) * r;
                    Z = 0.5f * s;
                }
            }
        }

        public float Dot(Quaternion other)
        {
            return (X * other.X) + (Y * other.Y) + (Z * other.Z) + (W * other.W);
        }

        public Quaternion Lerp(Quaternion other, float alpha)
        {
            Quaternion result = this * (1.0f - alpha) + other * alpha;
            return result / result.Magnitude;
        }

        public Quaternion Slerp(Quaternion other, float alpha)
        {
            float cosAng = Dot(other);

            if (cosAng < 0)
            {
                other = -other;
                cosAng = -cosAng;
            }

            double ang = Math.Acos(cosAng);

            if (ang >= 0.05f)
            {
                float scale0 = (float)Math.Sin((1.0f - alpha) * ang);
                float scale1 = (float)Math.Sin(alpha * ang);
                float denom  = (float)Math.Sin(ang);

                return ((this * scale0) + (other * scale1)) / denom;
            }
            else
            {
                return Lerp(other, alpha);
            }
        }

        public CFrame ToCFrame()
        {
            float xc = X * 2f,
                  yc = Y * 2f,
                  zc = Z * 2f;

            float xx = X * xc,
                  xy = X * yc,
                  xz = X * zc;

            float wx = W * xc,
                  wy = W * yc,
                  wz = W * zc;

            float yy = Y * yc,
                  yz = Y * zc,
                  zz = Z * zc;

            return new CFrame
            (
                0, 0, 0,

                1f - (yy + zz),
                xy - wz,
                xz + wy,

                xy + wz,
                1f - (xx + zz),
                yz - wx,

                xz - wy,
                yz + wx,
                1f - (xx + yy)
            );
        }

        public static Quaternion operator +(Quaternion a, Quaternion b)
        {
            return new Quaternion(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }

        public static Quaternion operator -(Quaternion a, Quaternion b)
        {
            return new Quaternion(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        public static Quaternion operator *(Quaternion a, float f)
        {
            return new Quaternion(a.X * f, a.Y * f, a.Z * f, a.W * f);
        }

        public static Quaternion operator /(Quaternion a, float f)
        {
            return new Quaternion(a.X / f, a.Y / f, a.Z / f, a.W / f);
        }

        public static Quaternion operator -(Quaternion a)
        {
            return new Quaternion(-a.X, -a.Y, -a.Z, -a.W);
        }

        public static Quaternion operator *(Quaternion a, Quaternion b)
        {
            Vector3 v1 = new Vector3(a.X, a.Y, a.Z),
                    v2 = new Vector3(b.X, b.Y, b.Z);

            float s1 = a.W,
                  s2 = b.W;

            return new Quaternion(s1 * v2 + s2 * v1 + v1.Cross(v2), s1 * s2 - v1.Dot(v2));
        }

        public EulerAngles ToEulerAngles()
        {
            var angles = new EulerAngles();

            double sinr_cosp = 2 * (W * X + Y * Z);
            double cosr_cosp = 1 - 2 * (X * X + Y * Y);
            angles.Roll = (float)Math.Atan2(sinr_cosp, cosr_cosp);

            double sinp = 2 * (W * Y - Z * X);
            angles.Pitch = (float)Math.Asin(sinp);

            double siny_cosp = 2 * (W * Z + X * Y);
            double cosy_cosp = 1 - 2 * (Y * Y + Z * Z);
            angles.Yaw = (float)Math.Atan2(siny_cosp, cosy_cosp);

            return angles;
        }

        public override int GetHashCode()
        {
            int hash = X.GetHashCode()
                     ^ Y.GetHashCode()
                     ^ Z.GetHashCode()
                     ^ W.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Quaternion other))
                return false;

            if (!X.Equals(other.X))
                return false;

            if (!Y.Equals(other.Y))
                return false;

            if (!Z.Equals(other.Z))
                return false;

            if (!W.Equals(other.W))
                return false;

            return true;
        }
    }
}
