namespace Roblox.BinaryFormat.Chunks
{
    public class PRNT
    {
        public readonly byte Format;
        public readonly int NumRelations;

        public readonly int[] ChildrenIds;
        public readonly int[] ParentIds;

        public PRNT(RobloxBinaryChunk chunk)
        {
            using (RobloxBinaryReader reader = chunk.GetReader("PRNT"))
            {
                Format = reader.ReadByte();
                NumRelations = reader.ReadInt32();

                ChildrenIds = reader.ReadInstanceIds(NumRelations);
                ParentIds = reader.ReadInstanceIds(NumRelations);
            }
        }
    }
}
