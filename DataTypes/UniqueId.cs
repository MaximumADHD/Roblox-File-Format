using System;

namespace RobloxFiles.DataTypes
{
    public struct UniqueId
    {
        public readonly uint Time;
        public readonly uint Index;
        public readonly long Random;

        public UniqueId(long random, uint time, uint index)
        {
            Time = time;
            Index = index;
            Random = random;
        }

        public override string ToString()
        {
            string random = Random.ToString("x2").PadLeft(16, '0');
            string index = Index.ToString("x2").PadLeft(8, '0');
            string time = Time.ToString("x2").PadLeft(8, '0');

            return $"{random}{time}{index}";
        }
    }
}
