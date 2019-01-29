using System;

namespace Roblox.DataTypes
{
    public struct ColorSequence
    {
        public readonly ColorSequenceKeypoint[] Keypoints;

        public ColorSequence(Color3 c)
        {
            ColorSequenceKeypoint a = new ColorSequenceKeypoint(0, c);
            ColorSequenceKeypoint b = new ColorSequenceKeypoint(1, c);

            Keypoints = new ColorSequenceKeypoint[2] { a, b };
        }

        public ColorSequence(Color3 c0, Color3 c1)
        {
            ColorSequenceKeypoint a = new ColorSequenceKeypoint(0, c0);
            ColorSequenceKeypoint b = new ColorSequenceKeypoint(1, c1);

            Keypoints = new ColorSequenceKeypoint[2] { a, b };
        }

        public ColorSequence(ColorSequenceKeypoint[] keypoints)
        {
            int numKeys = keypoints.Length;

            if (numKeys < 2)
                throw new Exception("ColorSequence: requires at least 2 keypoints");
            else if (numKeys > 20)
                throw new Exception("ColorSequence: table is too long.");

            for (int key = 1; key < numKeys; key++)
                if (keypoints[key - 1].Time > keypoints[key].Time)
                    throw new Exception("ColorSequence: all keypoints must be ordered by time");

            if (Math.Abs(keypoints[0].Time) >= 10e-5f)
                throw new Exception("ColorSequence must start at time=0.0");

            if (Math.Abs(keypoints[numKeys - 1].Time - 1f) >= 10e-5f)
                throw new Exception("ColorSequence must end at time=1.0");

            Keypoints = keypoints;
        }

        public override string ToString()
        {
            return string.Join(" ", Keypoints);
        }
    }
}
