using System.Linq;
using System.Collections.Generic;

using RobloxFiles.Enums;
using RobloxFiles.DataTypes;

namespace RobloxFiles.Utility
{
    public static class FontUtility
    {
        public static readonly IReadOnlyDictionary<int, FontSize> FontSizes = new Dictionary<int, FontSize>()
        {
            { 8,  FontSize.Size8  },
            { 9,  FontSize.Size9  },
            { 10, FontSize.Size10 },
            { 11, FontSize.Size11 },
            { 12, FontSize.Size12 },
            { 14, FontSize.Size14 },
            { 18, FontSize.Size18 },
            { 24, FontSize.Size24 },
            { 28, FontSize.Size28 },
            { 32, FontSize.Size32 },
            { 36, FontSize.Size36 },
            { 42, FontSize.Size42 },
            { 48, FontSize.Size48 },
            { 60, FontSize.Size60 },
            { 96, FontSize.Size96 },
        };


        /*
        for i, font in Enum.Font:GetEnumItems() do
            if font.Name == "Unknown" then
                continue
            end
    
            local fontFace = Font.fromEnum(font)
    
            print("{")
            print(`    Font.{font.Name},`)
    
            local args = {}
            table.insert(args, `"{fontFace.Family}"`)
    
            if fontFace.Weight ~= Enum.FontWeight.Regular then
                table.insert(args, `FontWeight.{fontFace.Weight.Name}`)
            end
    
            if fontFace.Style ~= Enum.FontStyle.Normal then
                if fontFace.Weight == Enum.FontWeight.Regular then
                    table.insert(args, "FontWeight.Regular")
                end
        
                table.insert(args, `FontStyle.{fontFace.Style.Name}`)
            end
    
            print(`    new FontFace({table.concat(args, ", ")})`)
            print("},\n")
        end
        */
        public static readonly IReadOnlyDictionary<Font, FontFace> FontFaces = new Dictionary<Font, FontFace>()
        {
            {
                Font.Legacy,
                new FontFace("rbxasset://fonts/families/LegacyArial.json")
            },

            {
                Font.Arial,
                new FontFace("rbxasset://fonts/families/Arial.json")
            },

            {
                Font.ArialBold,
                new FontFace("rbxasset://fonts/families/Arial.json", FontWeight.Bold)
            },

            {
                Font.SourceSans,
                new FontFace("rbxasset://fonts/families/SourceSansPro.json")
            },

            {
                Font.SourceSansBold,
                new FontFace("rbxasset://fonts/families/SourceSansPro.json", FontWeight.Bold)
            },

            {
                Font.SourceSansLight,
                new FontFace("rbxasset://fonts/families/SourceSansPro.json", FontWeight.Light)
            },

            {
                Font.SourceSansItalic,
                new FontFace("rbxasset://fonts/families/SourceSansPro.json", FontWeight.Regular, FontStyle.Italic)
            },

            {
                Font.Bodoni,
                new FontFace("rbxasset://fonts/families/AccanthisADFStd.json")
            },

            {
                Font.Garamond,
                new FontFace("rbxasset://fonts/families/Guru.json")
            },

            {
                Font.Cartoon,
                new FontFace("rbxasset://fonts/families/ComicNeueAngular.json")
            },

            {
                Font.Code,
                new FontFace("rbxasset://fonts/families/Inconsolata.json")
            },

            {
                Font.Highway,
                new FontFace("rbxasset://fonts/families/HighwayGothic.json")
            },

            {
                Font.SciFi,
                new FontFace("rbxasset://fonts/families/Zekton.json")
            },

            {
                Font.Arcade,
                new FontFace("rbxasset://fonts/families/PressStart2P.json")
            },

            {
                Font.Fantasy,
                new FontFace("rbxasset://fonts/families/Balthazar.json")
            },

            {
                Font.Antique,
                new FontFace("rbxasset://fonts/families/RomanAntique.json")
            },

            {
                Font.SourceSansSemibold,
                new FontFace("rbxasset://fonts/families/SourceSansPro.json", FontWeight.SemiBold)
            },

            {
                Font.Gotham,
                new FontFace("rbxasset://fonts/families/GothamSSm.json")
            },

            {
                Font.GothamMedium,
                new FontFace("rbxasset://fonts/families/GothamSSm.json", FontWeight.Medium)
            },

            {
                Font.GothamBold,
                new FontFace("rbxasset://fonts/families/GothamSSm.json", FontWeight.Bold)
            },

            {
                Font.GothamBlack,
                new FontFace("rbxasset://fonts/families/GothamSSm.json", FontWeight.Heavy)
            },

            {
                Font.AmaticSC,
                new FontFace("rbxasset://fonts/families/AmaticSC.json")
            },

            {
                Font.Bangers,
                new FontFace("rbxasset://fonts/families/Bangers.json")
            },

            {
                Font.Creepster,
                new FontFace("rbxasset://fonts/families/Creepster.json")
            },

            {
                Font.DenkOne,
                new FontFace("rbxasset://fonts/families/DenkOne.json")
            },

            {
                Font.Fondamento,
                new FontFace("rbxasset://fonts/families/Fondamento.json")
            },

            {
                Font.FredokaOne,
                new FontFace("rbxasset://fonts/families/FredokaOne.json")
            },

            {
                Font.GrenzeGotisch,
                new FontFace("rbxasset://fonts/families/GrenzeGotisch.json")
            },

            {
                Font.IndieFlower,
                new FontFace("rbxasset://fonts/families/IndieFlower.json")
            },

            {
                Font.JosefinSans,
                new FontFace("rbxasset://fonts/families/JosefinSans.json")
            },

            {
                Font.Jura,
                new FontFace("rbxasset://fonts/families/Jura.json")
            },

            {
                Font.Kalam,
                new FontFace("rbxasset://fonts/families/Kalam.json")
            },

            {
                Font.LuckiestGuy,
                new FontFace("rbxasset://fonts/families/LuckiestGuy.json")
            },

            {
                Font.Merriweather,
                new FontFace("rbxasset://fonts/families/Merriweather.json")
            },

            {
                Font.Michroma,
                new FontFace("rbxasset://fonts/families/Michroma.json")
            },

            {
                Font.Nunito,
                new FontFace("rbxasset://fonts/families/Nunito.json")
            },

            {
                Font.Oswald,
                new FontFace("rbxasset://fonts/families/Oswald.json")
            },

            {
                Font.PatrickHand,
                new FontFace("rbxasset://fonts/families/PatrickHand.json")
            },

            {
                Font.PermanentMarker,
                new FontFace("rbxasset://fonts/families/PermanentMarker.json")
            },

            {
                Font.Roboto,
                new FontFace("rbxasset://fonts/families/Roboto.json")
            },

            {
                Font.RobotoCondensed,
                new FontFace("rbxasset://fonts/families/RobotoCondensed.json")
            },

            {
                Font.RobotoMono,
                new FontFace("rbxasset://fonts/families/RobotoMono.json")
            },

            {
                Font.Sarpanch,
                new FontFace("rbxasset://fonts/families/Sarpanch.json")
            },

            {
                Font.SpecialElite,
                new FontFace("rbxasset://fonts/families/SpecialElite.json")
            },

            {
                Font.TitilliumWeb,
                new FontFace("rbxasset://fonts/families/TitilliumWeb.json")
            },

            {
                Font.Ubuntu,
                new FontFace("rbxasset://fonts/families/Ubuntu.json")
            },

            {
                Font.BuilderSans,
                new FontFace("rbxasset://fonts/families/BuilderSans.json")
            },

            {
                Font.BuilderSansMedium,
                new FontFace("rbxasset://fonts/families/BuilderSans.json", FontWeight.Medium)
            },

            {
                Font.BuilderSansBold,
                new FontFace("rbxasset://fonts/families/BuilderSans.json", FontWeight.Bold)
            },

            {
                Font.BuilderSansExtraBold,
                new FontFace("rbxasset://fonts/families/BuilderSans.json", FontWeight.ExtraBold)
            },

            {
                Font.Arimo,
                new FontFace("rbxasset://fonts/families/Arimo.json")
            },

            {
                Font.ArimoBold,
                new FontFace("rbxasset://fonts/families/Arimo.json", FontWeight.Bold)
            },
        };

        public static FontSize GetFontSize(int fontSize)
        {
            if (fontSize > 60)
                return FontSize.Size96;

            if (FontSizes.ContainsKey(fontSize))
                return FontSizes[fontSize];

            FontSize closest = FontSizes
                .Where(pair => pair.Key <= fontSize)
                .Select(pair => pair.Value)
                .Last();

            return closest;
        }

        public static FontSize GetFontSize(float size)
        {
            int fontSize = (int)size;
            return GetFontSize(fontSize);
        }

        public static int GetFontSize(FontSize fontSize)
        {
            int value = FontSizes
                .Where(pair => pair.Value == fontSize)
                .Select(pair => pair.Key)
                .First();

            return value;
        }

        public static Font GetLegacyFont(FontFace face)
        {
            var result = Font.Unknown;

            var faceQuery = FontFaces
                .Where(pair => face.Equals(pair.Value))
                .Select(pair => pair.Key);

            if (faceQuery.Any())
                result = faceQuery.First();

            return result;
        }

        public static bool TryGetFontFace(Font font, out FontFace face)
        {
            return FontFaces.TryGetValue(font, out face);
        }
    }
}
