namespace Roblox.BinaryFormat.Chunks
{
    public class INST
    {
        public readonly int TypeIndex;
        public readonly string TypeName;
        public readonly bool IsService;
        public readonly int NumInstances;
        public readonly int[] InstanceIds;

        public override string ToString()
        {
            return TypeName;
        }

        public INST(RobloxBinaryChunk chunk)
        {
            using (RobloxBinaryReader reader = chunk.GetReader("INST"))
            {
                TypeIndex = reader.ReadInt32();
                TypeName = reader.ReadString();
                IsService = reader.ReadBoolean();

                NumInstances = reader.ReadInt32();
                InstanceIds = reader.ReadInstanceIds(NumInstances);
            }
        }

        public void Allocate(RobloxBinaryFile file)
        {
            foreach (int instId in InstanceIds)
            {
                Instance inst = new Instance();
                inst.ClassName = TypeName;

                file.Instances[instId] = inst;
            }

            file.Types[TypeIndex] = this;
        }
    }
}
