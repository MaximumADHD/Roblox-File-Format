using RobloxFiles.Enums;
using RobloxFiles.DataTypes.Utility;

namespace RobloxFiles.DataTypes
{
    public struct PhysicalProperties
    {
        public readonly float Density;
        public readonly float Friction;
        public readonly float Elasticity;

        public readonly float FrictionWeight;
        public readonly float ElasticityWeight;

        public PhysicalProperties(Material material)
        {
            Density = MaterialInfo.DensityMap[material];
            Friction = MaterialInfo.FrictionMap[material];
            Elasticity = MaterialInfo.ElasticityMap[material];

            FrictionWeight = 1;
            ElasticityWeight = 1;
        }

        public PhysicalProperties(float density, float friction, float elasticity)
        {
            Density = density;
            Friction = friction;
            Elasticity = elasticity;

            FrictionWeight = 1;
            ElasticityWeight = 1;
        }

        public PhysicalProperties(float density, float friction, float elasticity, float frictionWeight, float elasticityWeight)
        {
            Density = density;
            Friction = friction;
            Elasticity = elasticity;

            FrictionWeight = frictionWeight;
            ElasticityWeight = elasticityWeight;
        }

        public override string ToString()
        {
            return string.Join(", ", Density, Friction, Elasticity, FrictionWeight, ElasticityWeight);
        }
    }
}
