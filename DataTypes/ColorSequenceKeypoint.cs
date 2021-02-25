namespace RobloxFiles.DataTypes
{
    public class ColorSequenceKeypoint
    {
        public readonly float Time;
        public readonly Color3uint8 Value;
        public readonly int Envelope;

        public override string ToString()
        {
            Color3 Color = Value;
            return $"{Time} {Color.R} {Color.G} {Color.B} {Envelope}";
        }

        public ColorSequenceKeypoint(float time, Color3 value, int envelope = 0)
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
            if (!(obj is ColorSequenceKeypoint otherKey))
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
