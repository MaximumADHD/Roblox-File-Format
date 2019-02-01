using System;

namespace RobloxFiles.DataTypes
{
    public struct NumberRange
    {
        public readonly float Min;
        public readonly float Max;

        public NumberRange(float min, float max)
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
