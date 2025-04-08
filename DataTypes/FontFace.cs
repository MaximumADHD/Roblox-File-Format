using RobloxFiles.Enums;
using RobloxFiles.Utility;

namespace RobloxFiles.DataTypes
{
    // Implementation of Roblox's FontFace datatype.
    // In Luau this type is named Font, but we avoid that name
    // to avoid ambiguity with System.Font and Roblox's Font enum.

    public class FontFace
    {
        public readonly ContentId Family = "rbxasset://fonts/families/LegacyArial.json";
        public readonly FontWeight Weight = FontWeight.Regular;
        public readonly FontStyle Style = FontStyle.Normal;

        // Roblox caches the asset of the font's face to make it
        // load faster. At runtime both the Family and the CachedFaceId
        // are loaded in parallel. If the CachedFaceId doesn't match with
        // the family file's face asset, then the correct one will be loaded late.
        // Setting this is not required, it's just a throughput optimization.
        public ContentId CachedFaceId { get; set; } = "";

        public FontFace(ContentId family, FontWeight weight = FontWeight.Regular, FontStyle style = FontStyle.Normal, string cachedFaceId = "")
        {
            CachedFaceId = cachedFaceId;
            Family = family;
            Weight = weight;
            Style = style;
        }

        public static FontFace FromEnum(Font font)
        {
            return FontUtility.FontFaces[font];
        }

        public static FontFace FromName(string name, FontWeight weight = FontWeight.Regular, FontStyle style = FontStyle.Normal)
        {
            ContentId url = $"rbxasset://fonts/families/{name}.json";
            return new FontFace(url, weight, style);
        }

        public static FontFace FromId(ulong id, FontWeight weight = FontWeight.Regular, FontStyle style = FontStyle.Normal)
        {
            ContentId url = $"rbxassetid://{id}";
            return new FontFace(url, weight, style);
        }

        public override string ToString()
        {
            return $"Font {{ Family = {Family}, Weight = {Weight}, Style = {Style}}}";
        }

        public override int GetHashCode()
        {
            int hash = Family.GetHashCode() 
                     ^ Weight.GetHashCode() 
                     ^ Style.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FontFace font))
                return false;

            if (Family != font.Family)
                return false;

            if (Weight != font.Weight)
                return false;

            if (Style != font.Style)
                return false;

            return true;
        }
    }
}
