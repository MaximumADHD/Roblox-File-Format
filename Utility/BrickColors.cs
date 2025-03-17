using System.Collections.Generic;

using RobloxFiles.DataTypes;

namespace RobloxFiles.Utility
{
    internal struct BrickColorInfo
    {
        public string Name;
        public uint Color;

        public BrickColorInfo(string name, uint color)
        {
            Name = name;
            Color = color;
        }
    }

    /// <summary>
    /// This static class defines all of Roblox's built-in BrickColor data.
    /// It is used primarily by the BrickColor DataType.
    /// </summary>
    internal static class BrickColors
    {
        public static readonly BrickColorId[] Palette = new BrickColorId[128]
        {
            BrickColorId.Earth_green,
            BrickColorId.Slime_green,
            BrickColorId.Bright_bluish_green,
            BrickColorId.Black,
            BrickColorId.Deep_blue,
            BrickColorId.Dark_blue,
            BrickColorId.Navy_blue,
            BrickColorId.Parsley_green,
            BrickColorId.Dark_green,
            BrickColorId.Teal,
            BrickColorId.Smoky_grey,
            BrickColorId.Steel_blue,
            BrickColorId.Storm_blue,
            BrickColorId.Lapis,
            BrickColorId.Dark_indigo,
            BrickColorId.Camo,
            BrickColorId.Sea_green,
            BrickColorId.Shamrock,
            BrickColorId.Toothpaste,
            BrickColorId.Sand_blue,
            BrickColorId.Medium_blue,
            BrickColorId.Bright_blue,
            BrickColorId.Really_blue,
            BrickColorId.Mulberry,
            BrickColorId.Forest_green,
            BrickColorId.Bright_green,
            BrickColorId.Grime,
            BrickColorId.Lime_green,
            BrickColorId.Pastel_bluegreen,
            BrickColorId.Fossil,
            BrickColorId.Electric_blue,
            BrickColorId.Lavender,
            BrickColorId.Royal_purple,
            BrickColorId.Eggplant,
            BrickColorId.Sand_green,
            BrickColorId.Moss,
            BrickColorId.Artichoke,
            BrickColorId.Sage_green,
            BrickColorId.Pastel_light_blue,
            BrickColorId.Cadet_blue,
            BrickColorId.Cyan,
            BrickColorId.Alder,
            BrickColorId.Lilac,
            BrickColorId.Plum,
            BrickColorId.Bright_violet,
            BrickColorId.Olive,
            BrickColorId.Br_yellowish_green,
            BrickColorId.Olivine,
            BrickColorId.Laurel_green,
            BrickColorId.Quill_grey,
            BrickColorId.Ghost_grey,
            BrickColorId.Pastel_Blue,
            BrickColorId.Pastel_violet,
            BrickColorId.Pink,
            BrickColorId.Hot_pink,
            BrickColorId.Magenta,
            BrickColorId.Crimson,
            BrickColorId.Deep_orange,
            BrickColorId.New_Yeller,
            BrickColorId.Medium_green,
            BrickColorId.Mint,
            BrickColorId.Pastel_green,
            BrickColorId.Light_stone_grey,
            BrickColorId.Light_blue,
            BrickColorId.Baby_blue,
            BrickColorId.Carnation_pink,
            BrickColorId.Persimmon,
            BrickColorId.Really_red,
            BrickColorId.Bright_red,
            BrickColorId.Maroon,
            BrickColorId.Gold,
            BrickColorId.Bright_yellow,
            BrickColorId.Daisy_orange,
            BrickColorId.Cool_yellow,
            BrickColorId.Pastel_yellow,
            BrickColorId.Pearl,
            BrickColorId.Fog,
            BrickColorId.Mauve,
            BrickColorId.Sunrise,
            BrickColorId.Terra_Cotta,
            BrickColorId.Dusty_Rose,
            BrickColorId.Cocoa,
            BrickColorId.Neon_orange,
            BrickColorId.Bright_orange,
            BrickColorId.Wheat,
            BrickColorId.Buttermilk,
            BrickColorId.Institutional_white,
            BrickColorId.White,
            BrickColorId.Light_reddish_violet,
            BrickColorId.Pastel_orange,
            BrickColorId.Salmon,
            BrickColorId.Tawny,
            BrickColorId.Rust,
            BrickColorId.CGA_brown,
            BrickColorId.Br_yellowish_orange,
            BrickColorId.Cashmere,
            BrickColorId.Khaki,
            BrickColorId.Lily_white,
            BrickColorId.Seashell,
            BrickColorId.Pastel_brown,
            BrickColorId.Light_orange,
            BrickColorId.Medium_red,
            BrickColorId.Burgundy,
            BrickColorId.Reddish_brown,
            BrickColorId.Cork,
            BrickColorId.Burlap,
            BrickColorId.Beige,
            BrickColorId.Oyster,
            BrickColorId.Mid_gray,
            BrickColorId.Brick_yellow,
            BrickColorId.Nougat,
            BrickColorId.Brown,
            BrickColorId.Pine_Cone,
            BrickColorId.Fawn_brown,
            BrickColorId.Sand_red,
            BrickColorId.Hurricane_grey,
            BrickColorId.Cloudy_grey,
            BrickColorId.Linen,
            BrickColorId.Copper,
            BrickColorId.Dark_orange,
            BrickColorId.Medium_brown,
            BrickColorId.Bronze,
            BrickColorId.Dark_stone_grey,
            BrickColorId.Medium_stone_grey,
            BrickColorId.Flint,
            BrickColorId.Dark_taupe,
            BrickColorId.Burnt_Sienna,
            BrickColorId.Really_black,
        };

        public static readonly IReadOnlyDictionary<BrickColorId, BrickColorInfo> InfoMap = new Dictionary<BrickColorId, BrickColorInfo>()
        {
            {
                BrickColorId.White,
                new BrickColorInfo("White", 0xF2F3F3)
            },
            {
                BrickColorId.Grey,
                new BrickColorInfo("Grey", 0xA1A5A2)
            },
            {
                BrickColorId.Light_yellow,
                new BrickColorInfo("Light yellow", 0xF9E999)
            },
            {
                BrickColorId.Brick_yellow,
                new BrickColorInfo("Brick yellow", 0xD7C59A)
            },
            {
                BrickColorId.Light_green_Mint,
                new BrickColorInfo("Light green (Mint)", 0xC2DAB8)
            },
            {
                BrickColorId.Light_reddish_violet,
                new BrickColorInfo("Light reddish violet", 0xE8BAC8)
            },
            {
                BrickColorId.Pastel_Blue,
                new BrickColorInfo("Pastel Blue", 0x80BBDB)
            },
            {
                BrickColorId.Light_orange_brown,
                new BrickColorInfo("Light orange brown", 0xCB8442)
            },
            {
                BrickColorId.Nougat,
                new BrickColorInfo("Nougat", 0xCC8E69)
            },
            {
                BrickColorId.Bright_red,
                new BrickColorInfo("Bright red", 0xC4281C)
            },
            {
                BrickColorId.Med_reddish_violet,
                new BrickColorInfo("Med. reddish violet", 0xC470A0)
            },
            {
                BrickColorId.Bright_blue,
                new BrickColorInfo("Bright blue", 0x0D69AC)
            },
            {
                BrickColorId.Bright_yellow,
                new BrickColorInfo("Bright yellow", 0xF5CD30)
            },
            {
                BrickColorId.Earth_orange,
                new BrickColorInfo("Earth orange", 0x624732)
            },
            {
                BrickColorId.Black,
                new BrickColorInfo("Black", 0x1B2A35)
            },
            {
                BrickColorId.Dark_grey,
                new BrickColorInfo("Dark grey", 0x6D6E6C)
            },
            {
                BrickColorId.Dark_green,
                new BrickColorInfo("Dark green", 0x287F47)
            },
            {
                BrickColorId.Medium_green,
                new BrickColorInfo("Medium green", 0xA1C48C)
            },
            {
                BrickColorId.Lig_Yellowich_orange,
                new BrickColorInfo("Lig. Yellowich orange", 0xF3CF9B)
            },
            {
                BrickColorId.Bright_green,
                new BrickColorInfo("Bright green", 0x4B974B)
            },
            {
                BrickColorId.Dark_orange,
                new BrickColorInfo("Dark orange", 0xA05F35)
            },
            {
                BrickColorId.Light_bluish_violet,
                new BrickColorInfo("Light bluish violet", 0xC1CADE)
            },
            {
                BrickColorId.Transparent,
                new BrickColorInfo("Transparent", 0xECECEC)
            },
            {
                BrickColorId.Tr_Red,
                new BrickColorInfo("Tr. Red", 0xCD544B)
            },
            {
                BrickColorId.Tr_Lg_blue,
                new BrickColorInfo("Tr. Lg blue", 0xC1DFF0)
            },
            {
                BrickColorId.Tr_Blue,
                new BrickColorInfo("Tr. Blue", 0x7BB6E8)
            },
            {
                BrickColorId.Tr_Yellow,
                new BrickColorInfo("Tr. Yellow", 0xF7F18D)
            },
            {
                BrickColorId.Light_blue,
                new BrickColorInfo("Light blue", 0xB4D2E4)
            },
            {
                BrickColorId.Tr_Flu_Reddish_orange,
                new BrickColorInfo("Tr. Flu. Reddish orange", 0xD9856C)
            },
            {
                BrickColorId.Tr_Green,
                new BrickColorInfo("Tr. Green", 0x84B68D)
            },
            {
                BrickColorId.Tr_Flu_Green,
                new BrickColorInfo("Tr. Flu. Green", 0xF8F184)
            },
            {
                BrickColorId.Phosph_White,
                new BrickColorInfo("Phosph. White", 0xECE8DE)
            },
            {
                BrickColorId.Light_red,
                new BrickColorInfo("Light red", 0xEEC4B6)
            },
            {
                BrickColorId.Medium_red,
                new BrickColorInfo("Medium red", 0xDA867A)
            },
            {
                BrickColorId.Medium_blue,
                new BrickColorInfo("Medium blue", 0x6E99CA)
            },
            {
                BrickColorId.Light_grey,
                new BrickColorInfo("Light grey", 0xC7C1B7)
            },
            {
                BrickColorId.Bright_violet,
                new BrickColorInfo("Bright violet", 0x6B327C)
            },
            {
                BrickColorId.Br_yellowish_orange,
                new BrickColorInfo("Br. yellowish orange", 0xE29B40)
            },
            {
                BrickColorId.Bright_orange,
                new BrickColorInfo("Bright orange", 0xDA8541)
            },
            {
                BrickColorId.Bright_bluish_green,
                new BrickColorInfo("Bright bluish green", 0x008F9C)
            },
            {
                BrickColorId.Earth_yellow,
                new BrickColorInfo("Earth yellow", 0x685C43)
            },
            {
                BrickColorId.Bright_bluish_violet,
                new BrickColorInfo("Bright bluish violet", 0x435493)
            },
            {
                BrickColorId.Tr_Brown,
                new BrickColorInfo("Tr. Brown", 0xBFB7B1)
            },
            {
                BrickColorId.Medium_bluish_violet,
                new BrickColorInfo("Medium bluish violet", 0x6874AC)
            },
            {
                BrickColorId.Tr_Medi_reddish_violet,
                new BrickColorInfo("Tr. Medi. reddish violet", 0xE5ADC8)
            },
            {
                BrickColorId.Med_yellowish_green,
                new BrickColorInfo("Med. yellowish green", 0xC7D23C)
            },
            {
                BrickColorId.Med_bluish_green,
                new BrickColorInfo("Med. bluish green", 0x55A5AF)
            },
            {
                BrickColorId.Light_bluish_green,
                new BrickColorInfo("Light bluish green", 0xB7D7D5)
            },
            {
                BrickColorId.Br_yellowish_green,
                new BrickColorInfo("Br. yellowish green", 0xA4BD47)
            },
            {
                BrickColorId.Lig_yellowish_green,
                new BrickColorInfo("Lig. yellowish green", 0xD9E4A7)
            },
            {
                BrickColorId.Med_yellowish_orange,
                new BrickColorInfo("Med. yellowish orange", 0xE7AC58)
            },
            {
                BrickColorId.Br_reddish_orange,
                new BrickColorInfo("Br. reddish orange", 0xD36F4C)
            },
            {
                BrickColorId.Bright_reddish_violet,
                new BrickColorInfo("Bright reddish violet", 0x923978)
            },
            {
                BrickColorId.Light_orange,
                new BrickColorInfo("Light orange", 0xEAB892)
            },
            {
                BrickColorId.Tr_Bright_bluish_violet,
                new BrickColorInfo("Tr. Bright bluish violet", 0xA5A5CB)
            },
            {
                BrickColorId.Gold,
                new BrickColorInfo("Gold", 0xDCBC81)
            },
            {
                BrickColorId.Dark_nougat,
                new BrickColorInfo("Dark nougat", 0xAE7A59)
            },
            {
                BrickColorId.Silver,
                new BrickColorInfo("Silver", 0x9CA3A8)
            },
            {
                BrickColorId.Neon_orange,
                new BrickColorInfo("Neon orange", 0xD5733D)
            },
            {
                BrickColorId.Neon_green,
                new BrickColorInfo("Neon green", 0xD8DD56)
            },
            {
                BrickColorId.Sand_blue,
                new BrickColorInfo("Sand blue", 0x74869D)
            },
            {
                BrickColorId.Sand_violet,
                new BrickColorInfo("Sand violet", 0x877C90)
            },
            {
                BrickColorId.Medium_orange,
                new BrickColorInfo("Medium orange", 0xE09864)
            },
            {
                BrickColorId.Sand_yellow,
                new BrickColorInfo("Sand yellow", 0x958A73)
            },
            {
                BrickColorId.Earth_blue,
                new BrickColorInfo("Earth blue", 0x203A56)
            },
            {
                BrickColorId.Earth_green,
                new BrickColorInfo("Earth green", 0x27462D)
            },
            {
                BrickColorId.Tr_Flu_Blue,
                new BrickColorInfo("Tr. Flu. Blue", 0xCFE2F7)
            },
            {
                BrickColorId.Sand_blue_metallic,
                new BrickColorInfo("Sand blue metallic", 0x7988A1)
            },
            {
                BrickColorId.Sand_violet_metallic,
                new BrickColorInfo("Sand violet metallic", 0x958EA3)
            },
            {
                BrickColorId.Sand_yellow_metallic,
                new BrickColorInfo("Sand yellow metallic", 0x938767)
            },
            {
                BrickColorId.Dark_grey_metallic,
                new BrickColorInfo("Dark grey metallic", 0x575857)
            },
            {
                BrickColorId.Black_metallic,
                new BrickColorInfo("Black metallic", 0x161D32)
            },
            {
                BrickColorId.Light_grey_metallic,
                new BrickColorInfo("Light grey metallic", 0xABADAC)
            },
            {
                BrickColorId.Sand_green,
                new BrickColorInfo("Sand green", 0x789082)
            },
            {
                BrickColorId.Sand_red,
                new BrickColorInfo("Sand red", 0x957977)
            },
            {
                BrickColorId.Dark_red,
                new BrickColorInfo("Dark red", 0x7B2E2F)
            },
            {
                BrickColorId.Tr_Flu_Yellow,
                new BrickColorInfo("Tr. Flu. Yellow", 0xFFF67B)
            },
            {
                BrickColorId.Tr_Flu_Red,
                new BrickColorInfo("Tr. Flu. Red", 0xE1A4C2)
            },
            {
                BrickColorId.Gun_metallic,
                new BrickColorInfo("Gun metallic", 0x756C62)
            },
            {
                BrickColorId.Red_flipflop,
                new BrickColorInfo("Red flip/flop", 0x97695B)
            },
            {
                BrickColorId.Yellow_flipflop,
                new BrickColorInfo("Yellow flip/flop", 0xB48455)
            },
            {
                BrickColorId.Silver_flipflop,
                new BrickColorInfo("Silver flip/flop", 0x898788)
            },
            {
                BrickColorId.Curry,
                new BrickColorInfo("Curry", 0xD7A94B)
            },
            {
                BrickColorId.Fire_Yellow,
                new BrickColorInfo("Fire Yellow", 0xF9D62E)
            },
            {
                BrickColorId.Flame_yellowish_orange,
                new BrickColorInfo("Flame yellowish orange", 0xE8AB2D)
            },
            {
                BrickColorId.Reddish_brown,
                new BrickColorInfo("Reddish brown", 0x694028)
            },
            {
                BrickColorId.Flame_reddish_orange,
                new BrickColorInfo("Flame reddish orange", 0xCF6024)
            },
            {
                BrickColorId.Medium_stone_grey,
                new BrickColorInfo("Medium stone grey", 0xA3A2A5)
            },
            {
                BrickColorId.Royal_blue,
                new BrickColorInfo("Royal blue", 0x4667A4)
            },
            {
                BrickColorId.Dark_Royal_blue,
                new BrickColorInfo("Dark Royal blue", 0x23478B)
            },
            {
                BrickColorId.Bright_reddish_lilac,
                new BrickColorInfo("Bright reddish lilac", 0x8E4285)
            },
            {
                BrickColorId.Dark_stone_grey,
                new BrickColorInfo("Dark stone grey", 0x635F62)
            },
            {
                BrickColorId.Lemon_metalic,
                new BrickColorInfo("Lemon metalic", 0x828A5D)
            },
            {
                BrickColorId.Light_stone_grey,
                new BrickColorInfo("Light stone grey", 0xE5E4DF)
            },
            {
                BrickColorId.Dark_Curry,
                new BrickColorInfo("Dark Curry", 0xB08E44)
            },
            {
                BrickColorId.Faded_green,
                new BrickColorInfo("Faded green", 0x709578)
            },
            {
                BrickColorId.Turquoise,
                new BrickColorInfo("Turquoise", 0x79B5B5)
            },
            {
                BrickColorId.Light_Royal_blue,
                new BrickColorInfo("Light Royal blue", 0x9FC3E9)
            },
            {
                BrickColorId.Medium_Royal_blue,
                new BrickColorInfo("Medium Royal blue", 0x6C81B7)
            },
            {
                BrickColorId.Rust,
                new BrickColorInfo("Rust", 0x904C2A)
            },
            {
                BrickColorId.Brown,
                new BrickColorInfo("Brown", 0x7C5C46)
            },
            {
                BrickColorId.Reddish_lilac,
                new BrickColorInfo("Reddish lilac", 0x96709F)
            },
            {
                BrickColorId.Lilac,
                new BrickColorInfo("Lilac", 0x6B629B)
            },
            {
                BrickColorId.Light_lilac,
                new BrickColorInfo("Light lilac", 0xA7A9CE)
            },
            {
                BrickColorId.Bright_purple,
                new BrickColorInfo("Bright purple", 0xCD6298)
            },
            {
                BrickColorId.Light_purple,
                new BrickColorInfo("Light purple", 0xE4ADC8)
            },
            {
                BrickColorId.Light_pink,
                new BrickColorInfo("Light pink", 0xDC9095)
            },
            {
                BrickColorId.Light_brick_yellow,
                new BrickColorInfo("Light brick yellow", 0xF0D5A0)
            },
            {
                BrickColorId.Warm_yellowish_orange,
                new BrickColorInfo("Warm yellowish orange", 0xEBB87F)
            },
            {
                BrickColorId.Cool_yellow,
                new BrickColorInfo("Cool yellow", 0xFDEA8D)
            },
            {
                BrickColorId.Dove_blue,
                new BrickColorInfo("Dove blue", 0x7DBBDD)
            },
            {
                BrickColorId.Medium_lilac,
                new BrickColorInfo("Medium lilac", 0x342B75)
            },
            {
                BrickColorId.Slime_green,
                new BrickColorInfo("Slime green", 0x506D54)
            },
            {
                BrickColorId.Smoky_grey,
                new BrickColorInfo("Smoky grey", 0x5B5D69)
            },
            {
                BrickColorId.Dark_blue,
                new BrickColorInfo("Dark blue", 0x0010B0)
            },
            {
                BrickColorId.Parsley_green,
                new BrickColorInfo("Parsley green", 0x2C651D)
            },
            {
                BrickColorId.Steel_blue,
                new BrickColorInfo("Steel blue", 0x527CAE)
            },
            {
                BrickColorId.Storm_blue,
                new BrickColorInfo("Storm blue", 0x335882)
            },
            {
                BrickColorId.Lapis,
                new BrickColorInfo("Lapis", 0x102ADC)
            },
            {
                BrickColorId.Dark_indigo,
                new BrickColorInfo("Dark indigo", 0x3D1585)
            },
            {
                BrickColorId.Sea_green,
                new BrickColorInfo("Sea green", 0x348E40)
            },
            {
                BrickColorId.Shamrock,
                new BrickColorInfo("Shamrock", 0x5B9A4C)
            },
            {
                BrickColorId.Fossil,
                new BrickColorInfo("Fossil", 0x9FA1AC)
            },
            {
                BrickColorId.Mulberry,
                new BrickColorInfo("Mulberry", 0x592259)
            },
            {
                BrickColorId.Forest_green,
                new BrickColorInfo("Forest green", 0x1F801D)
            },
            {
                BrickColorId.Cadet_blue,
                new BrickColorInfo("Cadet blue", 0x9FADC0)
            },
            {
                BrickColorId.Electric_blue,
                new BrickColorInfo("Electric blue", 0x0989CF)
            },
            {
                BrickColorId.Eggplant,
                new BrickColorInfo("Eggplant", 0x7B007B)
            },
            {
                BrickColorId.Moss,
                new BrickColorInfo("Moss", 0x7C9C6B)
            },
            {
                BrickColorId.Artichoke,
                new BrickColorInfo("Artichoke", 0x8AAB85)
            },
            {
                BrickColorId.Sage_green,
                new BrickColorInfo("Sage green", 0xB9C4B1)
            },
            {
                BrickColorId.Ghost_grey,
                new BrickColorInfo("Ghost grey", 0xCACBD1)
            },
            {
                BrickColorId.Lilac_2,
                new BrickColorInfo("Lilac", 0xA75E9B)
            },
            {
                BrickColorId.Plum,
                new BrickColorInfo("Plum", 0x7B2F7B)
            },
            {
                BrickColorId.Olivine,
                new BrickColorInfo("Olivine", 0x94BE81)
            },
            {
                BrickColorId.Laurel_green,
                new BrickColorInfo("Laurel green", 0xA8BD99)
            },
            {
                BrickColorId.Quill_grey,
                new BrickColorInfo("Quill grey", 0xDFDFDE)
            },
            {
                BrickColorId.Crimson,
                new BrickColorInfo("Crimson", 0x970000)
            },
            {
                BrickColorId.Mint,
                new BrickColorInfo("Mint", 0xB1E5A6)
            },
            {
                BrickColorId.Baby_blue,
                new BrickColorInfo("Baby blue", 0x98C2DB)
            },
            {
                BrickColorId.Carnation_pink,
                new BrickColorInfo("Carnation pink", 0xFF98DC)
            },
            {
                BrickColorId.Persimmon,
                new BrickColorInfo("Persimmon", 0xFF5959)
            },
            {
                BrickColorId.Maroon,
                new BrickColorInfo("Maroon", 0x750000)
            },
            {
                BrickColorId.Gold_2,
                new BrickColorInfo("Gold", 0xEFB838)
            },
            {
                BrickColorId.Daisy_orange,
                new BrickColorInfo("Daisy orange", 0xF8D96D)
            },
            {
                BrickColorId.Pearl,
                new BrickColorInfo("Pearl", 0xE7E7EC)
            },
            {
                BrickColorId.Fog,
                new BrickColorInfo("Fog", 0xC7D4E4)
            },
            {
                BrickColorId.Salmon,
                new BrickColorInfo("Salmon", 0xFF9494)
            },
            {
                BrickColorId.Terra_Cotta,
                new BrickColorInfo("Terra Cotta", 0xBE6862)
            },
            {
                BrickColorId.Cocoa,
                new BrickColorInfo("Cocoa", 0x562424)
            },
            {
                BrickColorId.Wheat,
                new BrickColorInfo("Wheat", 0xF1E7C7)
            },
            {
                BrickColorId.Buttermilk,
                new BrickColorInfo("Buttermilk", 0xFEF3BB)
            },
            {
                BrickColorId.Mauve,
                new BrickColorInfo("Mauve", 0xE0B2D0)
            },
            {
                BrickColorId.Sunrise,
                new BrickColorInfo("Sunrise", 0xD490BD)
            },
            {
                BrickColorId.Tawny,
                new BrickColorInfo("Tawny", 0x965555)
            },
            {
                BrickColorId.Rust_2,
                new BrickColorInfo("Rust", 0x8F4C2A)
            },
            {
                BrickColorId.Cashmere,
                new BrickColorInfo("Cashmere", 0xD3BE96)
            },
            {
                BrickColorId.Khaki,
                new BrickColorInfo("Khaki", 0xE2DCBC)
            },
            {
                BrickColorId.Lily_white,
                new BrickColorInfo("Lily white", 0xEDEAEA)
            },
            {
                BrickColorId.Seashell,
                new BrickColorInfo("Seashell", 0xE9DADA)
            },
            {
                BrickColorId.Burgundy,
                new BrickColorInfo("Burgundy", 0x883E3E)
            },
            {
                BrickColorId.Cork,
                new BrickColorInfo("Cork", 0xBC9B5D)
            },
            {
                BrickColorId.Burlap,
                new BrickColorInfo("Burlap", 0xC7AC78)
            },
            {
                BrickColorId.Beige,
                new BrickColorInfo("Beige", 0xCABFA3)
            },
            {
                BrickColorId.Oyster,
                new BrickColorInfo("Oyster", 0xBBB3B2)
            },
            {
                BrickColorId.Pine_Cone,
                new BrickColorInfo("Pine Cone", 0x6C584B)
            },
            {
                BrickColorId.Fawn_brown,
                new BrickColorInfo("Fawn brown", 0xA0844F)
            },
            {
                BrickColorId.Hurricane_grey,
                new BrickColorInfo("Hurricane grey", 0x958988)
            },
            {
                BrickColorId.Cloudy_grey,
                new BrickColorInfo("Cloudy grey", 0xABA89E)
            },
            {
                BrickColorId.Linen,
                new BrickColorInfo("Linen", 0xAF9483)
            },
            {
                BrickColorId.Copper,
                new BrickColorInfo("Copper", 0x966766)
            },
            {
                BrickColorId.Medium_brown,
                new BrickColorInfo("Medium brown", 0x564236)
            },
            {
                BrickColorId.Bronze,
                new BrickColorInfo("Bronze", 0x7E683F)
            },
            {
                BrickColorId.Flint,
                new BrickColorInfo("Flint", 0x69665C)
            },
            {
                BrickColorId.Dark_taupe,
                new BrickColorInfo("Dark taupe", 0x5A4C42)
            },
            {
                BrickColorId.Burnt_Sienna,
                new BrickColorInfo("Burnt Sienna", 0x6A3909)
            },
            {
                BrickColorId.Institutional_white,
                new BrickColorInfo("Institutional white", 0xF8F8F8)
            },
            {
                BrickColorId.Mid_gray,
                new BrickColorInfo("Mid gray", 0xCDCDCD)
            },
            {
                BrickColorId.Really_black,
                new BrickColorInfo("Really black", 0x111111)
            },
            {
                BrickColorId.Really_red,
                new BrickColorInfo("Really red", 0xFF0000)
            },
            {
                BrickColorId.Deep_orange,
                new BrickColorInfo("Deep orange", 0xFFB000)
            },
            {
                BrickColorId.Alder,
                new BrickColorInfo("Alder", 0xB480FF)
            },
            {
                BrickColorId.Dusty_Rose,
                new BrickColorInfo("Dusty Rose", 0xA34B4B)
            },
            {
                BrickColorId.Olive,
                new BrickColorInfo("Olive", 0xC1BE42)
            },
            {
                BrickColorId.New_Yeller,
                new BrickColorInfo("New Yeller", 0xFFFF00)
            },
            {
                BrickColorId.Really_blue,
                new BrickColorInfo("Really blue", 0x0000FF)
            },
            {
                BrickColorId.Navy_blue,
                new BrickColorInfo("Navy blue", 0x002060)
            },
            {
                BrickColorId.Deep_blue,
                new BrickColorInfo("Deep blue", 0x2154B9)
            },
            {
                BrickColorId.Cyan,
                new BrickColorInfo("Cyan", 0x04AFEC)
            },
            {
                BrickColorId.CGA_brown,
                new BrickColorInfo("CGA brown", 0xAA5500)
            },
            {
                BrickColorId.Magenta,
                new BrickColorInfo("Magenta", 0xAA00AA)
            },
            {
                BrickColorId.Pink,
                new BrickColorInfo("Pink", 0xFF66CC)
            },
            {
                BrickColorId.Deep_orange_2,
                new BrickColorInfo("Deep orange", 0xFFAF00)
            },
            {
                BrickColorId.Teal,
                new BrickColorInfo("Teal", 0x12EED4)
            },
            {
                BrickColorId.Toothpaste,
                new BrickColorInfo("Toothpaste", 0x00FFFF)
            },
            {
                BrickColorId.Lime_green,
                new BrickColorInfo("Lime green", 0x00FF00)
            },
            {
                BrickColorId.Camo,
                new BrickColorInfo("Camo", 0x3A7D15)
            },
            {
                BrickColorId.Grime,
                new BrickColorInfo("Grime", 0x7F8E64)
            },
            {
                BrickColorId.Lavender,
                new BrickColorInfo("Lavender", 0x8C5B9F)
            },
            {
                BrickColorId.Pastel_light_blue,
                new BrickColorInfo("Pastel light blue", 0xAFDDFF)
            },
            {
                BrickColorId.Pastel_orange,
                new BrickColorInfo("Pastel orange", 0xFFC9C9)
            },
            {
                BrickColorId.Pastel_violet,
                new BrickColorInfo("Pastel violet", 0xB1A7FF)
            },
            {
                BrickColorId.Pastel_bluegreen,
                new BrickColorInfo("Pastel blue-green", 0x9FF3E9)
            },
            {
                BrickColorId.Pastel_green,
                new BrickColorInfo("Pastel green", 0xCCFFCC)
            },
            {
                BrickColorId.Pastel_yellow,
                new BrickColorInfo("Pastel yellow", 0xFFFFCC)
            },
            {
                BrickColorId.Pastel_brown,
                new BrickColorInfo("Pastel brown", 0xFFCC99)
            },
            {
                BrickColorId.Royal_purple,
                new BrickColorInfo("Royal purple", 0x6225D1)
            },
            {
                BrickColorId.Hot_pink,
                new BrickColorInfo("Hot pink", 0xFF00BF)
            },
        };
    }
}