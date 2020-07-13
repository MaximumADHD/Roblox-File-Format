using System;
using System.Collections.Generic;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public class PRNT : IBinaryFileChunk
    {
        private const byte FORMAT = 0;

        public void Load(BinaryRobloxFileReader reader)
        {
            BinaryRobloxFile file = reader.File;

            byte format = reader.ReadByte();
            int idCount = reader.ReadInt32();

            if (format != FORMAT)
                throw new Exception($"Unexpected PRNT format: {format} (expected {FORMAT}!)");

            var childIds = reader.ReadInstanceIds(idCount);
            var parentIds = reader.ReadInstanceIds(idCount);
            
            for (int i = 0; i < idCount; i++)
            {
                int childId = childIds[i];
                int parentId = parentIds[i];

                Instance child = file.Instances[childId];
                child.Parent = (parentId >= 0 ? file.Instances[parentId] : file);
                child.ParentLocked = child.IsService;
            }
        }

        public void Save(BinaryRobloxFileWriter writer)
        {
            var postInstances = writer.PostInstances;
            var idCount = postInstances.Count;

            var childIds = new List<int>();
            var parentIds = new List<int>();

            foreach (Instance inst in writer.PostInstances)
            {
                Instance parent = inst.Parent;

                int childId = int.Parse(inst.Referent);
                int parentId = -1;

                if (parent != null)
                    parentId = int.Parse(parent.Referent);

                childIds.Add(childId);
                parentIds.Add(parentId);
            }

            writer.Write(FORMAT);
            writer.Write(idCount);

            writer.WriteInstanceIds(childIds);
            writer.WriteInstanceIds(parentIds);
        }
    }
}
