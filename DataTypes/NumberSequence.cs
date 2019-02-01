using System;

namespace RobloxFiles.DataTypes
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
            int numKeys = keypoints.Length;

            if (numKeys < 2)
                throw new Exception("NumberSequence: requires at least 2 keypoints");
            else if (numKeys > 20)
                throw new Exception("NumberSequence: table is too long.");

            for (int key = 1; key < numKeys; key++)
                if (keypoints[key - 1].Time > keypoints[key].Time)
                    throw new Exception("NumberSequence: all keypoints must be ordered by time");

            if (Math.Abs(keypoints[0].Time) >= 10e-5f)
                throw new Exception("NumberSequence must start at time=0.0");

            if (Math.Abs(keypoints[numKeys - 1].Time - 1f) >= 10e-5f)
                throw new Exception("NumberSequence must end at time=1.0");

            Keypoints = keypoints;
        }

        public override string ToString()
        {
            return string.Join(" ", Keypoints);
        }
    }
}
