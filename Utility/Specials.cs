using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using RobloxFiles.Enums;
using RobloxFiles.DataTypes;

using Newtonsoft.Json;

namespace RobloxFiles
{
    internal struct AccessoryBlob
    {
        public long AssetId;
        public int Order;
        public float Puffiness;
        public AccessoryType AccessoryType;

        public override bool Equals(object obj)
        {
            if (obj is AccessoryBlob blob)
            {
                if (AssetId != blob.AssetId)
                    return false;

                if (Order != blob.Order)
                    return false;

                if (!Puffiness.FuzzyEquals(blob.Puffiness))
                    return false;

                if (!AccessoryType.Equals(blob.AccessoryType))
                    return false;

                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Order.GetHashCode() ^
                   AssetId.GetHashCode() ^
                   Puffiness.GetHashCode() ^ 
                   AccessoryType.GetHashCode();
        }
    }

    static class Specials
    {
        public static BodyPartDescription GetBodyPart(HumanoidDescription hDesc, BodyPart bodyPart)
        {
            BodyPartDescription target = null;
            var existed = false;

            foreach (var bodyPartDesc in hDesc.GetChildrenOfType<BodyPartDescription>())
            {
                if (bodyPartDesc.BodyPart == bodyPart)
                {
                    target = bodyPartDesc;
                    existed = true;
                    break;
                }
            }

            if (target == null)
            {
                target = new BodyPartDescription()
                {
                    BodyPart = bodyPart,
                    Parent = hDesc,
                };
            }

            if (!existed)
            {
                var bodyPartName = Enum.GetName(typeof(BodyPart), bodyPart);
                var propAssetId = hDesc.GetProperty(bodyPartName);

                var bodyColorName = bodyPartName + "Color";
                var propColor = hDesc.GetProperty(bodyColorName);

                if (propAssetId != null)
                {
                    var newAssetId = new Property("AssetId", PropertyType.Int64, target);
                    newAssetId.Value = propAssetId.CastValue<long>();
                    target.AddProperty(newAssetId);
                }

                if (propColor != null)
                {
                    var newColor = new Property("Color", PropertyType.Color3, target);
                    newColor.Value = propColor.CastValue<Color3>();
                    target.AddProperty(newColor);
                }
            }
            
            return target;
        }

        public static string GetAccessoryBlob(HumanoidDescription hDesc)
        {
            Property legacyProp = hDesc.GetProperty("AccessoryBlob");

            var layered = hDesc.GetChildrenOfType<AccessoryDescription>()
                .Where(child => child.IsLayered)
                .ToList();

            if (legacyProp != null)
            {
                if (!layered.Any())
                {
                    string value = legacyProp.CastValue<string>();
                    var data = JsonConvert.DeserializeObject<AccessoryBlob[]>(value);

                    if (data != null)
                    {
                        foreach (var blob in data)
                        {
                            layered.Add(new AccessoryDescription()
                            {
                                AccessoryType = blob.AccessoryType,
                                Puffiness = blob.Puffiness,
                                AssetId = blob.AssetId,
                                Order = blob.Order,
                                IsLayered = true,
                                Parent = hDesc,
                            });
                        }
                    }
                }
                
                hDesc.RemoveProperty("AccessoryBlob");
            }

            var accessoryBlobs = layered.Select(accDesc => new AccessoryBlob()
            {
                AccessoryType = accDesc.AccessoryType,
                Puffiness = accDesc.Puffiness,
                AssetId = accDesc.AssetId,
                Order = accDesc.Order,
            });

            return JsonConvert.SerializeObject(accessoryBlobs.ToArray());
        }

        public static string SetAccessoryBlob(HumanoidDescription hDesc, string value)
        {
            return "";
        }

        public static string GetAccessories(HumanoidDescription hDesc, AccessoryType accessoryType)
        {
            return "";
        }
    }
}
