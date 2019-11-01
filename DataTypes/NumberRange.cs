using System;

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

        private static void checkRange(float min, float max)
        {
            if (max - min >= 0)
                return;

            throw new Exception("NumberRange: invalid range");
        }

        public NumberRange(float min = 0, float max = 0)
        {
            checkRange(min, max);

            Min = min;
            Max = max;
        }

        internal NumberRange(Attribute attr)
        {
            float min = attr.readFloat();
            float max = attr.readFloat();

            checkRange(min, max);

            Min = min;
            Max = max;
        }
    }
}
