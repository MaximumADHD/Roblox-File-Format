namespace RobloxFiles.DataTypes
{
    public class ColorSequenceKeypoint
    {
        public readonly float Time;
        public readonly Color3 Value;

        public ColorSequenceKeypoint(float time, Color3 value)
        {
            Time = time;
            Value = value;
        }

        public override string ToString()
        {
            return string.Join(" ", Time, Value.R, Value.G, Value.B, 0);
        }
    }
}
