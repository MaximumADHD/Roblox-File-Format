using System;
using System.Collections.Generic;
using System.Linq;

using RobloxFiles.Utility;

namespace RobloxFiles.DataTypes
{
    public class BrickColor
    {
        public readonly int Number;
        public readonly string Name;
        public readonly Color3 Color;

        public float R => Color.R;
        public float G => Color.G;
        public float B => Color.B;

        public override string ToString() => Name;

        private static readonly List<BrickColor> ByPalette;
        private static readonly Dictionary<int, BrickColor> ByNumber;

        private static readonly Random RNG = new Random();

        private const string DefaultName = "Medium stone grey";
        private const int DefaultNumber = 194;

        public static implicit operator int(BrickColor color) => color.Number;
        public static implicit operator BrickColor(int number) => FromNumber(number);

        internal BrickColor(int number, uint rgb, string name)
        {
            uint r = (rgb / 65536) % 256;
            uint g = (rgb / 256) % 256;
            uint b = (rgb % 256);

            Name = name;
            Number = number;

            Color = Color3.FromRGB(r, g, b);
        }

        static BrickColor()
        {
            ByNumber = BrickColors.ColorMap.ToDictionary(brickColor => brickColor.Number);
            ByPalette = BrickColors.PaletteMap.Select(number => ByNumber[number]).ToList();
        }

        public override int GetHashCode()
        {
            return Number;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BrickColor))
                return false;

            var bc = obj as BrickColor;
            return Number == bc.Number;
        }

        public static BrickColor FromName(string name)
        {
            BrickColor result = null;
            var query = BrickColors.ColorMap.Where((bc) => bc.Name == name);

            if (query.Any())
                result = query.First();
            else
                result = FromName(DefaultName);

            return result;
        }

        public static BrickColor FromNumber(int number)
        {
            if (!ByNumber.ContainsKey(number))
                number = DefaultNumber;

            return ByNumber[number];
        }

        public static BrickColor FromColor3(Color3 color)
        {
            return FromRGB(color.R, color.G, color.B);
        }

        public static BrickColor FromRGB(float r = 0, float g = 0, float b = 0)
        {
            BrickColor bestMatch = FromNumber(-1);
            float closest = float.MaxValue;

            foreach (BrickColor brickColor in BrickColors.ColorMap)
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
            int index = RNG.Next(ByPalette.Count);
            return ByPalette[index];
        }

        public static BrickColor Palette(int index)
        {
            if (index < 0 || index >= ByPalette.Count)
                throw new Exception("Palette index was out of range.");

            return ByPalette[index];
        }

        public static BrickColor White()    => FromName("White");
        public static BrickColor Gray()     => FromName("Medium stone grey");
        public static BrickColor DarkGray() => FromName("Dark stone grey");
        public static BrickColor Black()    => FromName("Black");
        public static BrickColor Red()      => FromName("Bright red");
        public static BrickColor Yellow()   => FromName("Bright yellow");
        public static BrickColor Green()    => FromName("Dark green");
        public static BrickColor Blue()     => FromName("Bright blue");
    }
}
