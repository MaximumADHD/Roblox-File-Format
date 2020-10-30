using System;
using System.Collections.Generic;
using System.Text;

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

            Type instType = Type.GetType($"RobloxFiles.{ClassName}");
            file.Classes[ClassIndex] = this;

            if (instType == null)
            {
                if (RobloxFile.LogErrors)
                    Console.Error.WriteLine($"INST - Unknown class: {ClassName} while reading INST chunk.");

                return;
            }

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

        public void WriteInfo(StringBuilder builder)
        {
            builder.AppendLine($"- ClassIndex:   {ClassIndex}");
            builder.AppendLine($"- ClassName:    {ClassName}");
            builder.AppendLine($"- IsService:    {IsService}");

            if (IsService && RootedServices != null)
                builder.AppendLine($"- RootedServices: `{string.Join(", ", RootedServices)}`");

            builder.AppendLine($"- NumInstances: {NumInstances}");
            builder.AppendLine($"- InstanceIds: `{string.Join(", ", InstanceIds)}`");
        }
    }
}
