using System.Collections.Generic;
using RobloxFiles.Enums;

namespace RobloxFiles.Utility
{
    /// <summary>
    /// This class defines several dictionaries of metadata for Roblox materials.
    /// It is primarily used for the PhysicalProperties DataType.
    /// </summary>
    public static class MaterialInfo
    {
        /// <summary>
        /// A dictionary mapping materials to their default Density.
        /// </summary>
        public static readonly IReadOnlyDictionary<Material, float> DensityMap = new Dictionary<Material, float>()
        {
            {Material.Air,           0.01f},
            {Material.Asphalt,       2.36f},
            {Material.Basalt,        2.69f},
            {Material.Brick,         1.92f},
            {Material.Cobblestone,   2.69f},
            {Material.Concrete,      2.40f},
            {Material.CorrodedMetal, 7.85f},
            {Material.CrackedLava,   2.69f},
            {Material.DiamondPlate,  7.85f},
            {Material.Fabric,        0.70f},
            {Material.Foil,          2.70f},
            {Material.ForceField,    2.40f},
            {Material.Glacier,       0.92f},
            {Material.Glass,         2.40f},
            {Material.Granite,       2.69f},
            {Material.Grass,         0.90f},
            {Material.Ground,        0.90f},
            {Material.Ice,           0.92f},
            {Material.LeafyGrass,    0.90f},
            {Material.Limestone,     2.69f},
            {Material.Marble,        2.56f},
            {Material.Metal,         7.85f},
            {Material.Mud,           0.90f},
            {Material.Neon,          0.70f},
            {Material.Pavement,      2.69f},
            {Material.Pebble,        2.40f},
            {Material.Plastic,       0.70f},
            {Material.Rock,          2.69f},
            {Material.Salt,          2.16f},
            {Material.Sand,          1.60f},
            {Material.Sandstone,     2.69f},
            {Material.Slate,         2.69f},
            {Material.SmoothPlastic, 0.70f},
            {Material.Snow,          0.90f},
            {Material.Water,         1.00f},
            {Material.Wood,          0.35f},
            {Material.WoodPlanks,    0.35f},
        };

        /// <summary>
        /// A dictionary mapping materials to their default Elasticity.
        /// </summary>
        public static readonly IReadOnlyDictionary<Material, float> ElasticityMap = new Dictionary<Material, float>()
        {
            {Material.Air,           0.01f},
            {Material.Asphalt,       0.20f},
            {Material.Basalt,        0.15f},
            {Material.Brick,         0.15f},
            {Material.Cobblestone,   0.17f},
            {Material.Concrete,      0.20f},
            {Material.CorrodedMetal, 0.20f},
            {Material.CrackedLava,   0.15f},
            {Material.DiamondPlate,  0.25f},
            {Material.Fabric,        0.05f},
            {Material.Foil,          0.25f},
            {Material.ForceField,    0.20f},
            {Material.Glacier,       0.15f},
            {Material.Glass,         0.20f},
            {Material.Granite,       0.20f},
            {Material.Grass,         0.10f},
            {Material.Ground,        0.10f},
            {Material.Ice,           0.15f},
            {Material.LeafyGrass,    0.10f},
            {Material.Limestone,     0.15f},
            {Material.Marble,        0.17f},
            {Material.Metal,         0.25f},
            {Material.Mud,           0.07f},
            {Material.Neon,          0.20f},
            {Material.Pavement,      0.17f},
            {Material.Pebble,        0.17f},
            {Material.Plastic,       0.50f},
            {Material.Rock,          0.17f},
            {Material.Salt,          0.05f},
            {Material.Sand,          0.05f},
            {Material.Sandstone,     0.15f},
            {Material.Slate,         0.20f},
            {Material.SmoothPlastic, 0.50f},
            {Material.Snow,          0.03f},
            {Material.Water,         0.01f},
            {Material.Wood,          0.20f},
            {Material.WoodPlanks,    0.20f},
        };

        /// <summary>
        /// A dictionary mapping materials to their default Friction.
        /// </summary>
        public static readonly IReadOnlyDictionary<Material, float> FrictionMap = new Dictionary<Material, float>()
        {
            {Material.Air,           0.01f},
            {Material.Asphalt,       0.80f},
            {Material.Basalt,        0.70f},
            {Material.Brick,         0.80f},
            {Material.Cobblestone,   0.50f},
            {Material.Concrete,      0.70f},
            {Material.CorrodedMetal, 0.70f},
            {Material.CrackedLava,   0.65f},
            {Material.DiamondPlate,  0.35f},
            {Material.Fabric,        0.35f},
            {Material.Foil,          0.40f},
            {Material.ForceField,    0.25f},
            {Material.Glacier,       0.05f},
            {Material.Glass,         0.25f},
            {Material.Granite,       0.40f},
            {Material.Grass,         0.40f},
            {Material.Ground,        0.45f},
            {Material.Ice,           0.02f},
            {Material.LeafyGrass,    0.40f},
            {Material.Limestone,     0.50f},
            {Material.Marble,        0.20f},
            {Material.Metal,         0.40f},
            {Material.Mud,           0.30f},
            {Material.Neon,          0.30f},
            {Material.Pavement,      0.50f},
            {Material.Pebble,        0.40f},
            {Material.Plastic,       0.30f},
            {Material.Rock,          0.50f},
            {Material.Salt,          0.50f},
            {Material.Sand,          0.50f},
            {Material.Sandstone,     0.50f},
            {Material.Slate,         0.40f},
            {Material.SmoothPlastic, 0.20f},
            {Material.Snow,          0.30f},
            {Material.Water,         0.00f},
            {Material.Wood,          0.48f},
            {Material.WoodPlanks,    0.48f},
        };

        /// <summary>
        /// A dictionary mapping materials to their default Friction.<para/>
        /// NOTE: This only maps materials that have different FrictionWeights.<para/>
        ///       If it isn't in here, assume their FrictionWeight is 1.
        /// </summary>
        public static readonly IReadOnlyDictionary<Material, float> FrictionWeightMap = new Dictionary<Material, float>()
        {
            {Material.Asphalt,       0.30f},
            {Material.Basalt,        0.30f},
            {Material.Brick,         0.30f},
            {Material.Concrete,      0.30f},
            {Material.Ice,           3.00f},
            {Material.Sand,          5.00f},
            {Material.Sandstone,     5.00f},
        };
    }
}