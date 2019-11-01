namespace RobloxFiles.DataTypes
{
    public class ColorSequenceKeypoint
    {
        public readonly float Time;
        public readonly Color3 Value;
        public readonly int Envelope;

        public override string ToString()
        {
            return $"{Time} {Value.R} {Value.G} {Value.B} {Envelope}";
        }

        public ColorSequenceKeypoint(float time, Color3 value, int envelope = 0)
        {
            Time = time;
            Value = value;
            Envelope = envelope;
        }

        internal ColorSequenceKeypoint(Attribute attr)
        {
            Envelope = attr.readInt();
            Time = attr.readFloat();
            Value = new Color3(attr);
        }
    }
}
