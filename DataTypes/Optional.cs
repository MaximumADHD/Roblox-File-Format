using System;

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

        public override int GetHashCode()
        {
            if (HasValue)
                return Value.GetHashCode();

            var T = typeof(T);
            return T.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Optional<T> optional))
                return false;

            if (HasValue != optional.HasValue)
                return false;

            if (HasValue)
                return Value.Equals(optional.Value);

            return true; // Both have no value.
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
