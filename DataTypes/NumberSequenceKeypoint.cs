namespace RobloxFiles.DataTypes
{
    public class NumberSequenceKeypoint
    {
        public readonly float Time;
        public readonly float Value;
        public readonly float Envelope;

        public override string ToString()
        {
            return $"{Time} {Value} {Envelope}";
        }

        public NumberSequenceKeypoint(float time, float value, float envelope = 0)
        {
            Time = time;
            Value = value;
            Envelope = envelope;
        }

        internal NumberSequenceKeypoint(Attribute attr)
        {
            Envelope = attr.readFloat();
            Time = attr.readFloat();
            Value = attr.readFloat();
        }
    }
}
