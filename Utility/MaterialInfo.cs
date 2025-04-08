using System.Collections.Generic;
using RobloxFiles.Enums;

namespace RobloxFiles.Utility
{
    /*
    for i, material in Enum.Material:GetEnumItems() do 
        local physics = PhysicalProperties.new(material)
    
        local entry = string.format(
            "{ Material.%-14s new PhysicalPropertyInfo(%.2ff, %.2ff, %.2ff, %.2ff, %.2ff) },",
            `{material.Name},`,
            physics.Density,
            physics.Friction,
            physics.Elasticity,
            physics.FrictionWeight,
            physics.ElasticityWeight
        )
    
        print(entry)
    end
    */

    public struct PhysicalPropertyInfo
    {
        public float Density;
        public float Friction;
        public float Elasticity;
        public float FrictionWeight;
        public float ElasticityWeight;

        public PhysicalPropertyInfo(float density, float friction, float elasticity, float frictionWeight, float elasticityWeight)
        {
            Density = density;
            Friction = friction;
            Elasticity = elasticity;
            FrictionWeight = frictionWeight;
            ElasticityWeight = elasticityWeight;
        }
    }

    public static class PhysicalPropertyData
    {
        /// <summary>
        /// A dictionary mapping materials to their default physical properties.
        /// </summary>
        public static readonly IReadOnlyDictionary<Material, PhysicalPropertyInfo> Materials = new Dictionary<Material, PhysicalPropertyInfo>()
        {
            { Material.Plastic,       new PhysicalPropertyInfo(0.70f, 0.30f, 0.50f, 1.00f, 1.00f) },
            { Material.SmoothPlastic, new PhysicalPropertyInfo(0.70f, 0.20f, 0.50f, 1.00f, 1.00f) },
            { Material.Neon,          new PhysicalPropertyInfo(0.70f, 0.30f, 0.20f, 1.00f, 1.00f) },
            { Material.Wood,          new PhysicalPropertyInfo(0.35f, 0.48f, 0.20f, 1.00f, 1.00f) },
            { Material.WoodPlanks,    new PhysicalPropertyInfo(0.35f, 0.48f, 0.20f, 1.00f, 1.00f) },
            { Material.Marble,        new PhysicalPropertyInfo(2.56f, 0.20f, 0.17f, 1.00f, 1.00f) },
            { Material.Slate,         new PhysicalPropertyInfo(2.69f, 0.40f, 0.20f, 1.00f, 1.00f) },
            { Material.Concrete,      new PhysicalPropertyInfo(2.40f, 0.70f, 0.20f, 0.30f, 1.00f) },
            { Material.Granite,       new PhysicalPropertyInfo(2.69f, 0.40f, 0.20f, 1.00f, 1.00f) },
            { Material.Brick,         new PhysicalPropertyInfo(1.92f, 0.80f, 0.15f, 0.30f, 1.00f) },
            { Material.Pebble,        new PhysicalPropertyInfo(2.40f, 0.40f, 0.17f, 1.00f, 1.50f) },
            { Material.Cobblestone,   new PhysicalPropertyInfo(2.69f, 0.50f, 0.17f, 1.00f, 1.00f) },
            { Material.Rock,          new PhysicalPropertyInfo(2.69f, 0.50f, 0.17f, 1.00f, 1.00f) },
            { Material.Sandstone,     new PhysicalPropertyInfo(2.69f, 0.50f, 0.15f, 5.00f, 1.00f) },
            { Material.Basalt,        new PhysicalPropertyInfo(2.69f, 0.70f, 0.15f, 0.30f, 1.00f) },
            { Material.CrackedLava,   new PhysicalPropertyInfo(2.69f, 0.65f, 0.15f, 1.00f, 1.00f) },
            { Material.Limestone,     new PhysicalPropertyInfo(2.69f, 0.50f, 0.15f, 1.00f, 1.00f) },
            { Material.Pavement,      new PhysicalPropertyInfo(2.69f, 0.50f, 0.17f, 0.30f, 1.00f) },
            { Material.CorrodedMetal, new PhysicalPropertyInfo(7.85f, 0.70f, 0.20f, 1.00f, 1.00f) },
            { Material.DiamondPlate,  new PhysicalPropertyInfo(7.85f, 0.35f, 0.25f, 1.00f, 1.00f) },
            { Material.Foil,          new PhysicalPropertyInfo(2.70f, 0.40f, 0.25f, 1.00f, 1.00f) },
            { Material.Metal,         new PhysicalPropertyInfo(7.85f, 0.40f, 0.25f, 1.00f, 1.00f) },
            { Material.Grass,         new PhysicalPropertyInfo(0.90f, 0.40f, 0.10f, 1.00f, 1.50f) },
            { Material.LeafyGrass,    new PhysicalPropertyInfo(0.90f, 0.40f, 0.10f, 2.00f, 2.00f) },
            { Material.Sand,          new PhysicalPropertyInfo(1.60f, 0.50f, 0.05f, 5.00f, 2.50f) },
            { Material.Fabric,        new PhysicalPropertyInfo(0.70f, 0.35f, 0.05f, 1.00f, 1.00f) },
            { Material.Snow,          new PhysicalPropertyInfo(0.90f, 0.30f, 0.03f, 3.00f, 4.00f) },
            { Material.Mud,           new PhysicalPropertyInfo(0.90f, 0.30f, 0.07f, 3.00f, 4.00f) },
            { Material.Ground,        new PhysicalPropertyInfo(0.90f, 0.45f, 0.10f, 1.00f, 1.00f) },
            { Material.Asphalt,       new PhysicalPropertyInfo(2.36f, 0.80f, 0.20f, 0.30f, 1.00f) },
            { Material.Salt,          new PhysicalPropertyInfo(2.16f, 0.50f, 0.05f, 1.00f, 1.00f) },
            { Material.Ice,           new PhysicalPropertyInfo(0.92f, 0.02f, 0.15f, 3.00f, 1.00f) },
            { Material.Glacier,       new PhysicalPropertyInfo(0.92f, 0.05f, 0.15f, 2.00f, 1.00f) },
            { Material.Glass,         new PhysicalPropertyInfo(2.40f, 0.25f, 0.20f, 1.00f, 1.00f) },
            { Material.ForceField,    new PhysicalPropertyInfo(2.40f, 0.25f, 0.20f, 1.00f, 1.00f) },
            { Material.Air,           new PhysicalPropertyInfo(0.01f, 0.01f, 0.01f, 1.00f, 1.00f) },
            { Material.Water,         new PhysicalPropertyInfo(1.00f, 0.00f, 0.01f, 1.00f, 1.00f) },
            { Material.Cardboard,     new PhysicalPropertyInfo(0.70f, 0.50f, 0.05f, 1.00f, 2.00f) },
            { Material.Carpet,        new PhysicalPropertyInfo(1.10f, 0.40f, 0.25f, 1.00f, 2.00f) },
            { Material.CeramicTiles,  new PhysicalPropertyInfo(2.40f, 0.51f, 0.20f, 1.00f, 1.00f) },
            { Material.ClayRoofTiles, new PhysicalPropertyInfo(2.00f, 0.51f, 0.20f, 1.00f, 1.00f) },
            { Material.RoofShingles,  new PhysicalPropertyInfo(2.36f, 0.80f, 0.20f, 0.30f, 1.00f) },
            { Material.Leather,       new PhysicalPropertyInfo(0.86f, 0.35f, 0.25f, 1.00f, 1.00f) },
            { Material.Plaster,       new PhysicalPropertyInfo(0.75f, 0.60f, 0.20f, 0.30f, 1.00f) },
            { Material.Rubber,        new PhysicalPropertyInfo(1.30f, 1.50f, 0.95f, 3.00f, 2.00f) },
        };
    }
}