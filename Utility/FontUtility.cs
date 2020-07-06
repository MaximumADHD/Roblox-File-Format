using System.Collections.Generic;
using System.Linq;

using RobloxFiles.Enums;

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
    }
}
