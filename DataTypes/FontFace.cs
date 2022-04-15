using RobloxFiles.Enums;

namespace RobloxFiles.DataTypes
{
    // Implementation of Roblox's Font datatype.
    // Renamed to FontFace to avoid disambiguation with System.Font and the Font enum.

    public class FontFace
    {
        public readonly Content Family = "rbxasset://fonts/families/LegacyArial.json";
        public readonly FontWeight Weight = FontWeight.Regular;
        public readonly FontStyle Style = FontStyle.Normal;

        public FontFace(Content family, FontWeight weight = FontWeight.Regular, FontStyle style = FontStyle.Normal)
        {
            Family = family;
            Weight = weight;
            Style = style;
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
