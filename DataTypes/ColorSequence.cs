using System;

namespace RobloxFiles.DataTypes
{
    public class ColorSequence
    {
        public readonly ColorSequenceKeypoint[] Keypoints;

        public override string ToString()
        {
            return string.Join<ColorSequenceKeypoint>(" ", Keypoints);
        }

        public ColorSequence(float r, float g, float b) : this(new Color3(r, g, b))
        {
        }

        public ColorSequence(Color3 c) : this(c, c)
        {
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

            var first = keypoints[0];
            var last = keypoints[numKeys - 1];

            if (!first.Time.FuzzyEquals(0))
                throw new Exception("ColorSequence must start at time=0.0");

            if (!last.Time.FuzzyEquals(1))
                throw new Exception("ColorSequence must end at time=1.0");

            Keypoints = keypoints;
        }
        
        public ColorSequence(Attribute attr)
        {
            int numKeys = attr.readInt();
            var keypoints = new ColorSequenceKeypoint[numKeys];

            for (int i = 0; i < numKeys; i++)
                keypoints[i] = new ColorSequenceKeypoint(attr);

            Keypoints = keypoints;
        }
    }
}
