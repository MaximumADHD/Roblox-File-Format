using System;
using System.Collections.Generic;
using System.Linq;

using RobloxFiles.Utility;

namespace RobloxFiles.DataTypes
{
    public enum BrickColorId
    {
        White = 1,
        Grey,
        Light_yellow,
        Brick_yellow = 5,
        Light_green_Mint,
        Light_reddish_violet = 9,
        Pastel_Blue = 11,
        Light_orange_brown,
        Nougat = 18,
        Bright_red = 21,
        Med_reddish_violet,
        Bright_blue,
        Bright_yellow,
        Earth_orange,
        Black,
        Dark_grey,
        Dark_green,
        Medium_green,
        Lig_Yellowich_orange = 36,
        Bright_green,
        Dark_orange,
        Light_bluish_violet,
        Transparent,
        Tr_Red,
        Tr_Lg_blue,
        Tr_Blue,
        Tr_Yellow,
        Light_blue,
        Tr_Flu_Reddish_orange = 47,
        Tr_Green,
        Tr_Flu_Green,
        Phosph_White,
        Light_red = 100,
        Medium_red,
        Medium_blue,
        Light_grey,
        Bright_violet,
        Br_yellowish_orange,
        Bright_orange,
        Bright_bluish_green,
        Earth_yellow,
        Bright_bluish_violet = 110,
        Tr_Brown,
        Medium_bluish_violet,
        Tr_Medi_reddish_violet,
        Med_yellowish_green = 115,
        Med_bluish_green,
        Light_bluish_green = 118,
        Br_yellowish_green,
        Lig_yellowish_green,
        Med_yellowish_orange,
        Br_reddish_orange = 123,
        Bright_reddish_violet,
        Light_orange,
        Tr_Bright_bluish_violet,
        Gold,
        Dark_nougat,
        Silver = 131,
        Neon_orange = 133,
        Neon_green,
        Sand_blue,
        Sand_violet,
        Medium_orange,
        Sand_yellow,
        Earth_blue = 140,
        Earth_green,
        Tr_Flu_Blue = 143,
        Sand_blue_metallic = 145,
        Sand_violet_metallic,
        Sand_yellow_metallic,
        Dark_grey_metallic,
        Black_metallic,
        Light_grey_metallic,
        Sand_green,
        Sand_red = 153,
        Dark_red,
        Tr_Flu_Yellow = 157,
        Tr_Flu_Red,
        Gun_metallic = 168,
        Red_flipflop = 176,
        Yellow_flipflop = 178,
        Silver_flipflop,
        Curry,
        Fire_Yellow = 190,
        Flame_yellowish_orange,
        Reddish_brown,
        Flame_reddish_orange,
        Medium_stone_grey,
        Royal_blue,
        Dark_Royal_blue,
        Bright_reddish_lilac = 198,
        Dark_stone_grey,
        Lemon_metalic,
        Light_stone_grey = 208,
        Dark_Curry,
        Faded_green,
        Turquoise,
        Light_Royal_blue,
        Medium_Royal_blue,
        Rust = 216,
        Brown,
        Reddish_lilac,
        Lilac,
        Light_lilac,
        Bright_purple,
        Light_purple,
        Light_pink,
        Light_brick_yellow,
        Warm_yellowish_orange,
        Cool_yellow,
        Dove_blue = 232,
        Medium_lilac = 268,
        Slime_green = 301,
        Smoky_grey,
        Dark_blue,
        Parsley_green,
        Steel_blue,
        Storm_blue,
        Lapis,
        Dark_indigo,
        Sea_green,
        Shamrock,
        Fossil,
        Mulberry,
        Forest_green,
        Cadet_blue,
        Electric_blue,
        Eggplant,
        Moss,
        Artichoke,
        Sage_green,
        Ghost_grey,
        Lilac_2,
        Plum,
        Olivine,
        Laurel_green,
        Quill_grey,
        Crimson = 327,
        Mint,
        Baby_blue,
        Carnation_pink,
        Persimmon,
        Maroon,
        Gold_2,
        Daisy_orange,
        Pearl,
        Fog,
        Salmon,
        Terra_Cotta,
        Cocoa,
        Wheat,
        Buttermilk,
        Mauve,
        Sunrise,
        Tawny,
        Rust_2,
        Cashmere,
        Khaki,
        Lily_white,
        Seashell,
        Burgundy,
        Cork,
        Burlap,
        Beige,
        Oyster,
        Pine_Cone,
        Fawn_brown,
        Hurricane_grey,
        Cloudy_grey,
        Linen,
        Copper,
        Medium_brown,
        Bronze,
        Flint,
        Dark_taupe,
        Burnt_Sienna,
        Institutional_white = 1001,
        Mid_gray,
        Really_black,
        Really_red,
        Deep_orange,
        Alder,
        Dusty_Rose,
        Olive,
        New_Yeller,
        Really_blue,
        Navy_blue,
        Deep_blue,
        Cyan,
        CGA_brown,
        Magenta,
        Pink,
        Deep_orange_2,
        Teal,
        Toothpaste,
        Lime_green,
        Camo,
        Grime,
        Lavender,
        Pastel_light_blue,
        Pastel_orange,
        Pastel_violet,
        Pastel_bluegreen,
        Pastel_green,
        Pastel_yellow,
        Pastel_brown,
        Royal_purple,
        Hot_pink,
    }

    public class BrickColor
    {
        public BrickColorId Id;
        public readonly string Name;
        public readonly Color3 Color;
        public int Number => (int)Id;

        public float R => Color.R;
        public float G => Color.G;
        public float B => Color.B;

        public override string ToString() => Name;

        private static readonly Random RNG = new Random();
        private static readonly Dictionary<string, BrickColor> ByName;
        private static readonly Dictionary<BrickColorId, BrickColor> ById;
        private const BrickColorId DefaultId = BrickColorId.Medium_stone_grey;

        public static implicit operator BrickColorId(BrickColor color) => color.Id;
        public static implicit operator BrickColor(BrickColorId id) => ById[id];

        [Obsolete]
        public static implicit operator int(BrickColor color) => color.Number;

        [Obsolete]
        public static implicit operator BrickColor(int number) => FromNumber(number);

        internal BrickColor(BrickColorId id, BrickColorInfo info)
        {
            var rgb = info.Color;
            var name = info.Name;

            uint r = (rgb / 65536) % 256;
            uint g = (rgb / 256) % 256;
            uint b = (rgb % 256);

            Id = id;
            Name = name;
            Color = Color3.FromRGB(r, g, b);
        }

        static BrickColor()
        {
            ById = BrickColors.InfoMap.ToDictionary(pair => pair.Key, pair => new BrickColor(pair.Key, pair.Value));
            ByName = new Dictionary<string, BrickColor>();

            foreach (var pair in ById)
            {
                var brickColor = pair.Value;

                if (ByName.ContainsKey(brickColor.Name))
                    continue;

                ByName.Add(brickColor.Name, brickColor);
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BrickColor bc))
                return false;

            return Id == bc.Id;
        }

        public static BrickColor FromName(string name)
        {
            return ByName[name];
        }

        [Obsolete]
        public static BrickColor FromNumber(int number)
        {
            BrickColorId id = DefaultId;

            if (Enum.IsDefined(typeof(BrickColorId), number))
                id = (BrickColorId)number;

            return ById[id];
        }

        public static BrickColor FromColor3(Color3 color)
        {
            return FromRGB(color.R, color.G, color.B);
        }

        public static BrickColor FromRGB(float r = 0, float g = 0, float b = 0)
        {
            BrickColor bestMatch = BrickColorId.Medium_stone_grey;
            float closest = float.MaxValue;

            foreach (BrickColor brickColor in ById.Values)
            {
                float dist = Math.Abs(brickColor.R - r)
                           + Math.Abs(brickColor.G - g)
                           + Math.Abs(brickColor.B - b);

                if (dist < closest)
                {
                    // Return this BrickColor if its an exact match.
                    if (dist == 0.0f)
                        return brickColor;

                    bestMatch = brickColor;
                    closest = dist;
                }
            }

            return bestMatch;
        }
        
        public static BrickColor Random()
        {
            int index = RNG.Next(BrickColors.Palette.Length);
            return BrickColors.Palette[index];
        }

        public static BrickColor Palette(int index)
        {
            if (index < 0 || index >= BrickColors.Palette.Length)
                throw new Exception("Palette index was out of range.");

            return BrickColors.Palette[index];
        }

        public static BrickColor Red() => BrickColorId.Bright_red;
        public static BrickColor Gray() => BrickColorId.Medium_stone_grey;
        public static BrickColor Blue() => BrickColorId.Bright_blue;
        public static BrickColor Black() => BrickColorId.Black;
        public static BrickColor Green() => BrickColorId.Bright_green;
        public static BrickColor White() => BrickColorId.White;
        public static BrickColor Yellow() => BrickColorId.Bright_yellow;
        public static BrickColor DarkGray() => BrickColorId.Dark_stone_grey;
    }
}
