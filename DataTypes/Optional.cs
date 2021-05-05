namespace RobloxFiles.DataTypes
{
    // Optional represents a value that can be explicitly
    // marked as an optional variant to a specified type.
    // In practice this is used for OptionalCFrame.

    public struct Optional<T>
    {
        public T Value;
        public bool HasValue => (Value != null);

        public Optional(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value?.ToString() ?? "null";
        }

        public static implicit operator T(Optional<T> optional)
        {
            if (optional.HasValue)
                return optional.Value;

            return default(T);
        }

        public static implicit operator Optional<T>(T value)
        {
            return new Optional<T>(value);
        }
    }
}
