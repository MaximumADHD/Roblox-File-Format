namespace RobloxFiles.DataTypes
{
    /// <summary>
    /// ProtectedString is a type used by some of the XML properties.
    /// Here, it only exists as a wrapper class for strings.
    /// </summary>
    public class ProtectedString
    {
        public readonly string Value;

        public override string ToString()
        {
            return Value;
        }

        public ProtectedString(string value)
        {
            Value = value;
        }

        public static implicit operator string(ProtectedString protectedString)
        {
            return protectedString.Value;
        }

        public static implicit operator ProtectedString(string value)
        {
            return new ProtectedString(value);
        }
    }
}
