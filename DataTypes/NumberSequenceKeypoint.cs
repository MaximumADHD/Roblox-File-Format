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

        public override int GetHashCode()
        {
            int hash = Time.GetHashCode()
                     ^ Value.GetHashCode()
                     ^ Envelope.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is NumberSequenceKeypoint otherKey))
                return false;

            if (!Time.Equals(otherKey.Time))
                return false;

            if (!Value.Equals(otherKey.Value))
                return false;

            if (!Envelope.Equals(otherKey.Envelope))
                return false;

            return true;
        }
    }
}
