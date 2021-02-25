using System;

namespace RobloxFiles.DataTypes
{
    public class Color3
    {
        public readonly float R, G, B;
        public override string ToString() => $"{R}, {G}, {B}";

        public Color3(float r = 0, float g = 0, float b = 0)
        {
            R = r;
            G = g;
            B = b;
        }

        public override int GetHashCode()
        {
            int r = R.GetHashCode(),
                g = G.GetHashCode(),
                b = B.GetHashCode();

            return r ^ g ^ b;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Color3 other))
                return false;

            if (!R.Equals(other.R))
                return false;

            if (!G.Equals(other.G))
                return false;

            if (!B.Equals(other.B))
                return false;

            return true;
        }

        public static Color3 FromRGB(uint r = 0, uint g = 0, uint b = 0)
        {
            return new Color3(r / 255f, g / 255f, b / 255f);
        }

        public static Color3 FromHSV(float h = 0, float s = 0, float v = 0)
        {
            int i = (int)Math.Min(5, Math.Floor(6.0 * h));
            float f = 6.0f * h - i;

            float m = v * (1.0f - (s));
            float n = v * (1.0f - (s * f));
            float k = v * (1.0f - (s * (1 - f)));

            switch (i)
            {
                case  0 : return new Color3(v, k, m);
                case  1 : return new Color3(n, v, m);
                case  2 : return new Color3(m, v, k);
                case  3 : return new Color3(m, n, v);
                case  4 : return new Color3(k, m, v);
                case  5 : return new Color3(v, m, n);
                default : return new Color3(0, 0, 0);
            }
        }

        public static float[] ToHSV(Color3 color)
        {
            float val = Math.Max(Math.Max(color.R, color.G), color.B);

            if (Math.Abs(val) < 0.001f)
                return new float[3] { 0, 0, 0 };

            float hue = Math.Min(Math.Min(color.R, color.G), color.B);
            float sat = (val - hue) / val;

            if (Math.Abs(sat) >= 0.001f)
            {
                Vector3 rgbN = val - new Vector3(color.R, color.G, color.B);
                rgbN /= (val - hue);

                if (color.R == val)
                    hue = (color.G == hue) ? 5.0f + rgbN.Z : 1.0f - rgbN.Y;
                else if (color.G == val)
                    hue = (color.B == hue) ? 1.0f + rgbN.X : 3.0f - rgbN.Z;
                else
                    hue = (color.R == hue) ? 3.0f + rgbN.Y : 5.0f - rgbN.Z;

                hue /= 6.0f;
            }

            return new float[3] { hue, sat, val };
        }

        public Color3 Lerp(Color3 other, float alpha)
        {
            float r = (R + (other.R - R) * alpha);
            float g = (G + (other.G - G) * alpha);
            float b = (B + (other.B - B) * alpha);

            return new Color3(r, g, b);
        }
    }
}
