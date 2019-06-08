using System.Collections.Generic;
using System.Linq;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public class INST : IBinaryFileChunk
    {
        public int TypeIndex { get; internal set; }
        public string TypeName { get; internal set; }

        public bool IsService { get; internal set; }
        public List<bool> RootedServices { get; internal set; }

        public int NumInstances { get; internal set; }
        public List<int> InstanceIds { get; internal set; }

        public override string ToString()
        {
            return TypeName;
        }

        public void LoadFromReader(BinaryRobloxFileReader reader)
        {
            BinaryRobloxFile file = reader.File;

            TypeIndex = reader.ReadInt32();
            TypeName = reader.ReadString();
            IsService = reader.ReadBoolean();

            NumInstances = reader.ReadInt32();
            InstanceIds = reader.ReadInstanceIds(NumInstances);

            if (IsService)
            {
                RootedServices = new List<bool>();

                for (int i = 0; i < NumInstances; i++)
                {
                    bool isRooted = reader.ReadBoolean();
                    RootedServices.Add(isRooted);
                }
            }

            for (int i = 0; i < NumInstances; i++)
            {
                int instId = InstanceIds[i];

                var inst = new Instance()
                {
                    ClassName = TypeName,
                    IsService = IsService,
                    Referent = instId.ToString()
                };

                if (IsService)
                {
                    bool rooted = RootedServices[i];
                    inst.IsRootedService = rooted;
                }

                file.Instances[instId] = inst;
            }

            file.Types[TypeIndex] = this;
        }

        public BinaryRobloxFileChunk SaveAsChunk(BinaryRobloxFileWriter writer)
        {
            writer.StartWritingChunk(this);

            writer.Write(TypeIndex);
            writer.WriteString(TypeName);

            writer.Write(IsService);
            writer.Write(NumInstances);
            writer.WriteInstanceIds(InstanceIds);

            if (IsService)
            {
                BinaryRobloxFile file = writer.File;

                foreach (int instId in InstanceIds)
                {
                    Instance service = file.Instances[instId];
                    writer.Write(service.IsRootedService);
                }
            }

            return writer.FinishWritingChunk();
        }

        internal static void ApplyTypeMap(BinaryRobloxFileWriter writer)
        {
            BinaryRobloxFile file = writer.File;
            file.Instances = writer.Instances.ToArray();

            var types = writer.TypeMap
                .OrderBy(type => type.Key)
                .Select(type => type.Value)
                .ToArray();

            for (int i = 0; i < types.Length; i++, file.NumTypes++)
            {
                INST type = types[i];
                type.TypeIndex = i;
            }

            file.Types = types;
        }
    }
}
