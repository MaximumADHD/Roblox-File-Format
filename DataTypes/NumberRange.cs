using System;
using System.Diagnostics.Contracts;

namespace RobloxFiles.DataTypes
{
    public class NumberRange
    {
        public readonly float Min;
        public readonly float Max;

        public override string ToString() => $"{Min} {Max}";

        public NumberRange(float num)
        {
            Min = num;
            Max = num;
        }

        public NumberRange(float min = 0, float max = 0)
        {
            Contract.Requires(max - min >= 0, "Max must be greater than min.");
            Contract.EndContractBlock();
            
            Min = min;
            Max = max;
        }

        public override int GetHashCode()
        {
            return Min.GetHashCode() ^ Max.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is NumberRange other))
                return false;

            if (!Min.Equals(other.Min))
                return false;

            if (!Max.Equals(other.Max))
                return false;

            return true;
        }
    }
}
