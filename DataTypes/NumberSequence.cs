using System;

namespace Roblox.DataTypes
{
    public struct NumberSequence
    {
        public readonly NumberSequenceKeypoint[] Keypoints;

        public NumberSequence(float n)
        {
            NumberSequenceKeypoint a = new NumberSequenceKeypoint(0, n);
            NumberSequenceKeypoint b = new NumberSequenceKeypoint(1, n);

            Keypoints = new NumberSequenceKeypoint[2] { a, b };
        }

        public NumberSequence(float n0, float n1)
        {
            NumberSequenceKeypoint a = new NumberSequenceKeypoint(0, n0);
            NumberSequenceKeypoint b = new NumberSequenceKeypoint(1, n1);

            Keypoints = new NumberSequenceKeypoint[2] { a, b };
        }

        public NumberSequence(NumberSequenceKeypoint[] keypoints)
        {
            int len = keypoints.Length;

            if (len < 2)
                throw new Exception("NumberSequence: requires at least 2 keypoints");
            else if (len > 20)
                throw new Exception("NumberSequence: table is too long.");

            for (int i = 1; i < len; i++)
                if (keypoints[i - 1].Time > keypoints[i].Time)
                    throw new Exception("NumberSequence: all keypoints must be ordered by time");

            if (keypoints[0].Time < 0)
                throw new Exception("NumberSequence must start at time=0.0");

            if (keypoints[len - 1].Time > 1)
                throw new Exception("NumberSequence must end at time=1.0");

            Keypoints = keypoints;
        }

        public override string ToString()
        {
            return string.Join(" ", Keypoints);
        }
    }
}
