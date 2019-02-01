namespace RobloxFiles.DataTypes
{
    public class UDim
    {
        public readonly float Scale;
        public readonly int Offset;

        public UDim(float scale = 0, int offset = 0)
        {
            Scale = scale;
            Offset = offset;
        }

        public static UDim operator+(UDim a, UDim b)
        {
            return new UDim(a.Scale + b.Scale, a.Offset + b.Offset);
        }

        public static UDim operator-(UDim a, UDim b)
        {
            return new UDim(a.Scale - b.Scale, a.Offset - b.Offset);
        }

        public override string ToString()
        {
            return string.Join(", ", Scale, Offset);
        }
    }
}