namespace RobloxFiles.DataTypes
{
    /// <summary>
    /// ProtectedString is a type used by some of the XML properties.
    /// Here, it only exists as a wrapper class for strings.
    /// </summary>
    public class ProtectedString
    {
        public readonly string ProtectedValue;
        public override string ToString() => ProtectedValue;

        public ProtectedString(string value)
        {
            ProtectedValue = value;
        }

        public static implicit operator string(ProtectedString protectedString)
        {
            return protectedString.ProtectedValue;
        }

        public static implicit operator ProtectedString(string value)
        {
            return new ProtectedString(value);
        }
    }
}
