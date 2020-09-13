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
            Min = min ?? Vector2.Zero;
            Max = max ?? Vector2.Zero;
        }

        public Rect(float minX, float minY, float maxX, float maxY)
        {
            Min = new Vector2(minX, minY);
            Max = new Vector2(maxX, maxY);
        }

        internal Rect(Attribute attr)
        {
            Min = new Vector2(attr);
            Max = new Vector2(attr);
        }

        public override int GetHashCode()
        {
            int hash = Min.GetHashCode()
                     ^ Max.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Rect))
                return false;

            var other = obj as Rect;

            if (!Min.Equals(other.Min))
                return false;

            if (!Max.Equals(other.Max))
                return false;

            return true;
        }
    }
}
