namespace RobloxFiles.DataTypes
{
    public class Rect
    {
        public readonly Vector2 Min;
        public readonly Vector2 Max;

        public float Width => (Max - Min).X;
        public float Height => (Max - Min).Y;

        public override string ToString() => $"{Min}, {Max}";

        public Rect(Vector2 min = null, Vector2 max = null)
        {
            Min = min ?? Vector2.zero;
            Max = max ?? Vector2.zero;
        }

        public Rect(float minX, float minY, float maxX, float maxY)
        {
            Min = new Vector2(minX, minY);
            Max = new Vector2(maxX, maxY);
        }

        public override int GetHashCode()
        {
            int hash = Min.GetHashCode()
                     ^ Max.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Rect other))
                return false;

            if (!Min.Equals(other.Min))
                return false;

            if (!Max.Equals(other.Max))
                return false;

            return true;
        }
    }
}
