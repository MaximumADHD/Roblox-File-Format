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

        public int NumObjects { get; internal set; }
        public List<int> ObjectIds { get; internal set; }

        public override string ToString() => ClassName;
        
        public void Load(BinaryRobloxFileReader reader)
        {
            BinaryRobloxFile file = reader.File;

            ClassIndex = reader.ReadInt32();
            ClassName = reader.ReadString();
            IsService = reader.ReadBoolean();

            NumObjects = reader.ReadInt32();
            ObjectIds = reader.ReadObjectIds(NumObjects);

            Type instType = Type.GetType($"RobloxFiles.{ClassName}");
            file.Classes[ClassIndex] = this;

            if (instType == null)
            {
                RobloxFile.LogError($"INST - Unknown class: {ClassName} while reading INST chunk.");
                return;
            }

            if (IsService)
            {
                RootedServices = new List<bool>();

                for (int i = 0; i < NumObjects; i++)
                {
                    bool isRooted = reader.ReadBoolean();
                    RootedServices.Add(isRooted);
                }
            }

            for (int i = 0; i < NumObjects; i++)
            {
                int objId = ObjectIds[i];
                
                var obj = Activator.CreateInstance(instType) as RbxObject;
                obj.Referent = objId.ToString();

                if (obj is Instance inst)
                {
                    if (IsService && inst.IsService)
                    {
                        var serviceInfo = Attribute.GetCustomAttribute(instType, typeof(RbxService)) as RbxService;
                        bool isRooted = RootedServices[i];

                        if (!isRooted && serviceInfo.IsRooted)
                            // Service MUST be a child of the DataModel.
                            isRooted = true;

                        inst.Parent = (isRooted ? file : null);
                    }
                }
                
                file.Objects[objId] = obj;
            }
        }

        public void Save(BinaryRobloxFileWriter writer)
        {
            writer.Write(ClassIndex);
            writer.WriteString(ClassName);

            writer.Write(IsService);
            writer.Write(NumObjects);
            writer.WriteObjectIds(ObjectIds);

            if (IsService)
            {
                var file = writer.File;

                foreach (int objId in ObjectIds)
                {
                    RbxObject obj = file.Objects[objId];

                    if (obj is Instance service)
                    {
                        writer.Write(service.Parent == file);
                        continue;
                    }

                    writer.Write(false);
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

            builder.AppendLine($"- NumObjects: {NumObjects}");
            builder.AppendLine($"- ObjectIds: `{string.Join(", ", ObjectIds)}`");
        }
    }
}
