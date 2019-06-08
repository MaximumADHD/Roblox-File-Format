using System.Collections.Generic;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public class PRNT : IBinaryFileChunk
    {
        public byte Format { get; private set; }
        public int NumRelations { get; private set; }

        public List<int> ChildrenIds { get; private set; }
        public List<int> ParentIds { get; private set; }

        public void LoadFromReader(BinaryRobloxFileReader reader)
        {
            BinaryRobloxFile file = reader.File;

            Format = reader.ReadByte();
            NumRelations = reader.ReadInt32();

            ChildrenIds = reader.ReadInstanceIds(NumRelations);
            ParentIds = reader.ReadInstanceIds(NumRelations);
            
            for (int i = 0; i < NumRelations; i++)
            {
                int childId = ChildrenIds[i];
                int parentId = ParentIds[i];

                Instance child = file.Instances[childId];
                child.Parent = (parentId >= 0 ? file.Instances[parentId] : file);
            }
        }

        public BinaryRobloxFileChunk SaveAsChunk(BinaryRobloxFileWriter writer)
        {
            BinaryRobloxFile file = writer.File;
            writer.StartWritingChunk(this);

            Format = 0;
            NumRelations = file.Instances.Length;

            ChildrenIds = new List<int>();
            ParentIds = new List<int>();

            foreach (Instance inst in file.Instances)
            {
                Instance parent = inst.Parent;

                int childId = int.Parse(inst.Referent);
                int parentId = -1;

                if (parent != null)
                    parentId = int.Parse(parent.Referent);

                ChildrenIds.Add(childId);
                ParentIds.Add(parentId);
            }

            writer.Write(Format);
            writer.Write(NumRelations);

            writer.WriteInstanceIds(ChildrenIds);
            writer.WriteInstanceIds(ParentIds);

            return writer.FinishWritingChunk();
        }
    }
}
