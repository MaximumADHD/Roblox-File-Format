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
            var info = PhysicalPropertyData.Materials[material];
            ElasticityWeight = info.ElasticityWeight;
            FrictionWeight = info.FrictionWeight;
            Elasticity = info.Elasticity;
            Friction = info.Friction;
            Density = info.Density;
        }

        public PhysicalProperties(float density, float friction, float elasticity, float frictionWeight = 1f, float elasticityWeight = 1f)
        {
            Density = density;
            Friction = friction;
            Elasticity = elasticity;
            FrictionWeight = frictionWeight;
            ElasticityWeight = elasticityWeight;
        }

        public override int GetHashCode()
        {
            int hash = Density.GetHashCode()
                     ^ Friction.GetHashCode()
                     ^ Elasticity.GetHashCode()
                     ^ FrictionWeight.GetHashCode()
                     ^ ElasticityWeight.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PhysicalProperties other))
                return false;

            if (!Density.Equals(other.Density))
                return false;

            if (!Friction.Equals(other.Friction))
                return false;

            if (!Elasticity.Equals(other.Elasticity))
                return false;

            if (!FrictionWeight.Equals(other.FrictionWeight))
                return false;

            if (!ElasticityWeight.Equals(other.ElasticityWeight))
                return false;

            return true;
        }
    }
}
