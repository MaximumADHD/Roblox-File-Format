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
            Envelope = attr.ReadFloat();
            Time = attr.ReadFloat();
            Value = attr.ReadFloat();
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
            if (!(obj is NumberSequenceKeypoint))
                return false;

            var otherKey = obj as NumberSequenceKeypoint;

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
