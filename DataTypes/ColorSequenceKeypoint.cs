namespace RobloxFiles.DataTypes
{
    public class ColorSequenceKeypoint
    {
        public readonly float Time;
        public readonly Color3 Value;
        public readonly byte[] Reserved;

        public ColorSequenceKeypoint(float time, Color3 value, byte[] reserved = null)
        {
            Time = time;
            Value = value;
            Reserved = reserved;
        }

        public override string ToString()
        {
            return string.Join(" ", Time, Value.R, Value.G, Value.B, 0);
        }
    }
}
