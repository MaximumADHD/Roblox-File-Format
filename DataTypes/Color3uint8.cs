namespace RobloxFiles.DataTypes
{
    /// <summary>
    /// Color3uint8 functions as an interconvertible storage medium for Color3 types.
    /// It is used by property types that want their Color3 value encoded with bytes instead of floats.
    /// </summary>
    public class Color3uint8
    {
        public readonly byte R, G, B;
        public override string ToString() => $"{R}, {G}, {B}";

        public Color3uint8(byte r = 0, byte g = 0, byte b = 0)
        {
            R = r;
            G = g;
            B = b;
        }

        public override int GetHashCode()
        {
            return (R << 16) | (G << 8) | B;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Color3uint8))
                return false;

            int rgb0 = GetHashCode(),
                rgb1 = obj.GetHashCode();

            return rgb0.Equals(rgb1);
        }

        public static implicit operator Color3(Color3uint8 color)
        {
            float r = color.R / 255f;
            float g = color.G / 255f;
            float b = color.B / 255f;

            return new Color3(r, g, b);
        }

        public static implicit operator Color3uint8(Color3 color)
        {
            byte r = (byte)(color.R * 255);
            byte g = (byte)(color.G * 255);
            byte b = (byte)(color.B * 255);

            return new Color3uint8(r, g, b);
        }
    }
}
