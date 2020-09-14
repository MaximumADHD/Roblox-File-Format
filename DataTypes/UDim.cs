namespace RobloxFiles.DataTypes
{
    public class UDim
    {
        public readonly float Scale;
        public readonly int Offset;

        public override string ToString() => $"{Scale}, {Offset}";

        public UDim(float scale = 0, int offset = 0)
        {
            Scale = scale;
            Offset = offset;
        }

        internal UDim(Attribute attr)
        {
            Scale = attr.ReadFloat();
            Offset = attr.ReadInt();
        }

        public static UDim operator+(UDim a, UDim b)
        {
            return new UDim(a.Scale + b.Scale, a.Offset + b.Offset);
        }

        public static UDim operator-(UDim a, UDim b)
        {
            return new UDim(a.Scale - b.Scale, a.Offset - b.Offset);
        }

        public override int GetHashCode()
        {
            int hash = Scale.GetHashCode()
                     ^ Offset.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is UDim))
                return false;

            var other = obj as UDim;

            if (!Scale.Equals(other.Scale))
                return false;

            if (!Offset.Equals(other.Offset))
                return false;

            return true;
        }
    }
}