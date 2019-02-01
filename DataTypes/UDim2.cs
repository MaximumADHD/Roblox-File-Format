namespace RobloxFiles.DataTypes
{
    public struct UDim2
    {
        public readonly UDim X, Y;

        public UDim Width => X;
        public UDim Height => Y;

        public UDim2(float scaleX, int offsetX, float scaleY, int offsetY)
        {
            X = new UDim(scaleX, offsetX);
            Y = new UDim(scaleY, offsetY);
        }

        public UDim2(UDim x, UDim y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return '{' + X.ToString() + "},{" + Y.ToString() + '}';
        }

        public UDim2 Lerp(UDim2 other, float alpha)
        {
            float scaleX = X.Scale + ((other.X.Scale - X.Scale) * alpha);
            int offsetX = X.Offset + (int)((other.X.Offset - X.Offset) * alpha);

            float scaleY = Y.Scale + ((other.Y.Scale - Y.Scale) * alpha);
            int offsetY = Y.Offset + (int)((other.Y.Offset - Y.Offset) * alpha);

            return new UDim2(scaleX, offsetX, scaleY, offsetY);
        }
    }
}
