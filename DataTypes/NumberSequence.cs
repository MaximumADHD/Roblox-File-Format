using System;

namespace RobloxFiles.DataTypes
{
    public class NumberSequence
    {
        public readonly NumberSequenceKeypoint[] Keypoints;

        public override string ToString()
        {
            return string.Join<NumberSequenceKeypoint>(" ", Keypoints);
        }

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

            var first = keypoints[0];
            var last = keypoints[numKeys - 1];

            if (!first.Time.FuzzyEquals(0))
                throw new Exception("NumberSequence must start at time=0.0");

            if (!last.Time.FuzzyEquals(1))
                throw new Exception("NumberSequence must end at time=1.0");

            Keypoints = keypoints;
        }

        public override int GetHashCode()
        {
            int hash = 0;

            foreach (var keypoint in Keypoints)
                hash ^= keypoint.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is NumberSequence numberSeq))
                return false;

            var otherKeys = numberSeq.Keypoints;

            if (Keypoints.Length != otherKeys.Length)
                return false;

            for (int i = 0; i < Keypoints.Length; i++)
            {
                var keyA = Keypoints[i];
                var keyB = otherKeys[i];

                if (keyA.Equals(keyB))
                    continue;

                return false;
            }

            return true;
        }
    }
}
