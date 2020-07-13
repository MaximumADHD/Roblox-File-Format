using System;
using System.Collections.Generic;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public class INST : IBinaryFileChunk
    {
        public int ClassIndex { get; internal set; }
        public string ClassName { get; internal set; }

        public bool IsService { get; internal set; }
        public List<bool> RootedServices { get; internal set; }

        public int NumInstances { get; internal set; }
        public List<int> InstanceIds { get; internal set; }

        public override string ToString() => ClassName;
        
        public void Load(BinaryRobloxFileReader reader)
        {
            BinaryRobloxFile file = reader.File;

            ClassIndex = reader.ReadInt32();
            ClassName = reader.ReadString();
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
                Type instType = Type.GetType($"RobloxFiles.{ClassName}") ?? typeof(Instance);

                var inst = Activator.CreateInstance(instType) as Instance;
                inst.Referent = instId.ToString();
                inst.IsService = IsService;
                
                if (IsService)
                {
                    bool isRooted = RootedServices[i];
                    inst.Parent = (isRooted ? file : null);
                }

                file.Instances[instId] = inst;
            }

            file.Classes[ClassIndex] = this;
        }

        public void Save(BinaryRobloxFileWriter writer)
        {
            writer.Write(ClassIndex);
            writer.WriteString(ClassName);

            writer.Write(IsService);
            writer.Write(NumInstances);
            writer.WriteInstanceIds(InstanceIds);

            if (IsService)
            {
                var file = writer.File;

                foreach (int instId in InstanceIds)
                {
                    Instance service = file.Instances[instId];
                    writer.Write(service.Parent == file);
                }
            }
        }
    }
}
