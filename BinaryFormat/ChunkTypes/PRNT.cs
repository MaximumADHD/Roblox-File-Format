namespace RobloxFiles.BinaryFormat.Chunks
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

        public void Assemble(BinaryRobloxFile file)
        {
            for (int i = 0; i < NumRelations; i++)
            {
                int childId = ChildrenIds[i];
                int parentId = ParentIds[i];

                Instance child = file.Instances[childId];
                Instance parent = null;

                if (parentId >= 0)
                    parent = file.Instances[parentId];
                else
                    parent = file.BinContents;

                child.Parent = parent;
            }
        }
    }
}
