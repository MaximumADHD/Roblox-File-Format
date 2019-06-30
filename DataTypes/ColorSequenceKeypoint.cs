namespace RobloxFiles.DataTypes
{
    public class ColorSequenceKeypoint
    {
        public readonly float Time;
        public readonly Color3 Value;
        public readonly int Envelope;

        public ColorSequenceKeypoint(float time, Color3 value, int envelope = 0)
        {
            Time = time;
            Value = value;
            Envelope = envelope;
        }

        public override string ToString()
        {
            return string.Join(" ", Time, Value.R, Value.G, Value.B, Envelope);
        }
    }
}
