namespace RobloxFiles.DataTypes
{
    public class Rect
    {
        public readonly Vector2 Min;
        public readonly Vector2 Max;

        public float Width => (Max - Min).X;
        public float Height => (Max - Min).Y;

        public Rect(Vector2 min = null, Vector2 max = null)
        {
            Min = min ?? Vector2.Zero;
            Max = max ?? Vector2.Zero;
        }

        public Rect(float minX, float minY, float maxX, float maxY)
        {
            Min = new Vector2(minX, minY);
            Max = new Vector2(maxX, maxY);
        }

        public override string ToString()
        {
            return string.Join(", ", Min, Max);
        }
    }
}
