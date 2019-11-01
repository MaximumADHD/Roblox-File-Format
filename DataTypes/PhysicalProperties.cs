using RobloxFiles.Enums;
using RobloxFiles.Utility;

namespace RobloxFiles.DataTypes
{
    public class PhysicalProperties
    {
        public readonly float Density = 1.0f;
        public readonly float Friction = 1.0f;
        public readonly float Elasticity = 0.5f;

        public readonly float FrictionWeight = 1.0f;
        public readonly float ElasticityWeight = 1.0f;

        public override string ToString()
        {
            return $"{Density}, {Friction}, {Elasticity}, {FrictionWeight}, {ElasticityWeight}";
        }

        public PhysicalProperties(Material material)
        {
            if (MaterialInfo.FrictionWeightMap.ContainsKey(material))
                FrictionWeight = MaterialInfo.FrictionWeightMap[material];

            Density = MaterialInfo.DensityMap[material];
            Friction = MaterialInfo.FrictionMap[material];
            Elasticity = MaterialInfo.ElasticityMap[material];
        }

        public PhysicalProperties(float density, float friction, float elasticity, float frictionWeight = 1f, float elasticityWeight = 1f)
        {
            Density = density;
            Friction = friction;
            Elasticity = elasticity;

            FrictionWeight = frictionWeight;
            ElasticityWeight = elasticityWeight;
        }

        internal PhysicalProperties(Attribute attr)
        {
            Density = attr.readFloat();
            Friction = attr.readFloat();
            Elasticity = attr.readFloat();

            FrictionWeight = attr.readFloat();
            ElasticityWeight = attr.readFloat();
        }
    }
}
