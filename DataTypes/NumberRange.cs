using System;

namespace RobloxFiles.DataTypes
{
    public class NumberRange
    {
        public readonly float Min;
        public readonly float Max;

        public NumberRange(float min = 0, float max = 0)
        {
            if (max - min < 0)
                throw new Exception("NumberRange: invalid range");

            Min = min;
            Max = max;
        }

        public override string ToString()
        {
            return string.Join(" ", Min, Max);
        }
    }
}
