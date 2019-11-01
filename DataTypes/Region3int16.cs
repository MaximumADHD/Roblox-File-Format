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

        internal Region3int16(Attribute attr)
        {
            Min = new Vector3int16(attr);
            Max = new Vector3int16(attr);
        }
    }
}
