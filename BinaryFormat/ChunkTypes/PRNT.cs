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

        public void Assemble(RobloxBinaryFile file)
        {
            for (int i = 0; i < NumRelations; i++)
            {
                int childId = ChildrenIds[i];
                int parentId = ParentIds[i];

                Instance child = file.Instances[childId];

                if (parentId >= 0)
                {
                    Instance parent = file.Instances[parentId];
                    child.Parent = parent;
                }
                else
                {
                    file.BinaryTrunk.Add(child);
                }
            }
        }
    }
}
