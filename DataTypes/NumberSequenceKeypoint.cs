namespace Roblox.DataTypes
{
    public struct NumberSequenceKeypoint
    {
        public readonly float Time;
        public readonly float Value;
        public readonly float Envelope;

        public NumberSequenceKeypoint(float time, float value, float envelope = 0)
        {
            Time = time;
            Value = value;
            Envelope = envelope;
        }

        public override string ToString()
        {
            return string.Join(" ", Time, Value, Envelope);
        }
    }
}
