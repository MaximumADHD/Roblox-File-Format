namespace RobloxFiles.DataTypes
{
    public struct UniqueId
    {
        public readonly uint Time;
        public readonly uint Index;
        public readonly ulong Random;

        public UniqueId(uint time, uint index, ulong random)
        {
            Time = time;
            Index = index;
            Random = random;
        }
    }
}
