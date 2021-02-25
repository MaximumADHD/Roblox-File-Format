namespace RobloxFiles.DataTypes
{
    public class UDim2
    {
        public readonly UDim X, Y;
        public override string ToString() => $"{{{X}}},{{{Y}}}";

        public UDim Width => X;
        public UDim Height => Y;

        public UDim2(float scaleX = 0, int offsetX = 0, float scaleY = 0, int offsetY = 0)
        {
            X = new UDim(scaleX, offsetX);
            Y = new UDim(scaleY, offsetY);
        }

        public UDim2(UDim x, UDim y)
        {
            X = x;
            Y = y;
        }

        public UDim2 Lerp(UDim2 other, float alpha)
        {
            float scaleX = X.Scale + ((other.X.Scale - X.Scale) * alpha);
            int offsetX = X.Offset + (int)((other.X.Offset - X.Offset) * alpha);

            float scaleY = Y.Scale + ((other.Y.Scale - Y.Scale) * alpha);
            int offsetY = Y.Offset + (int)((other.Y.Offset - Y.Offset) * alpha);

            return new UDim2(scaleX, offsetX, scaleY, offsetY);
        }

        public override int GetHashCode()
        {
            int hash = X.GetHashCode()
                     ^ Y.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is UDim2 other))
                return false;

            if (!X.Equals(other.X))
                return false;

            if (!Y.Equals(other.Y))
                return false;

            return true;
        }
    }
}
