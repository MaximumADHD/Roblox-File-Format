namespace RobloxFiles.DataTypes
{
    public class Region3int16
    {
        public readonly Vector3int16 Min, Max;
        public override string ToString() => $"{Min}; {Max}";

        public Region3int16(Vector3int16 min = null, Vector3int16 max = null)
        {
            Min = min ?? new Vector3int16();
            Max = max ?? new Vector3int16();
        }

        public override int GetHashCode()
        {
            int hash = Min.GetHashCode()
                     ^ Max.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Region3int16 other))
                return false;

            if (!Min.Equals(other.Min))
                return false;

            if (!Max.Equals(other.Max))
                return false;

            return true;
        }
    }
}
