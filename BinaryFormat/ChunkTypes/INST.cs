using System.Collections.Generic;
using System.IO;

namespace Roblox.BinaryFormat.Chunks
{
    public class INST
    {
        public readonly int TypeIndex;
        public readonly string TypeName;
        public readonly bool IsService;
        public readonly int NumInstances;
        public readonly int[] InstanceIds;

        public Dictionary<string, PROP> Properties;

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

            Properties = new Dictionary<string, PROP>();
        }
    }
}
