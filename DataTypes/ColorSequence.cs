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
            int len = keypoints.Length;

            if (len < 2)
                throw new Exception("ColorSequence: requires at least 2 keypoints");
            else if (len > 20)
                throw new Exception("ColorSequence: table is too long.");

            for (int i = 1; i < len; i++)
                if (keypoints[i-1].Time > keypoints[i].Time)
                    throw new Exception("ColorSequence: all keypoints must be ordered by time");

            if (keypoints[0].Time < 0)
                throw new Exception("ColorSequence must start at time=0.0");

            if (keypoints[len-1].Time > 1)
                throw new Exception("ColorSequence must end at time=1.0");

            Keypoints = keypoints;
        }

        public override string ToString()
        {
            return string.Join(" ", Keypoints);
        }
    }
}
