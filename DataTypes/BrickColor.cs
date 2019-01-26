using System;
using System.Collections.Generic;
using System.Linq;

using Roblox.DataTypes.Utility;

namespace Roblox.DataTypes
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

        private static List<BrickColor> ByPalette;
        private static Dictionary<int, BrickColor> ByNumber;
        private static Dictionary<string, BrickColor> ByName;

        private static Random RNG = new Random();

        private const string DefaultName = "Medium stone grey";
        private const int DefaultNumber = 194;

        internal BrickColor(int number, int rgb, string name)
        {
            int r = (rgb / 65536) % 256;
            int g = (rgb / 256) % 256;
            int b = rgb % 256;

            Name = name;
            Number = number;

            Color = Color3.fromRGB(r, g, b);
        }

        static BrickColor()
        {
            ByName = BrickColors.ColorMap.ToDictionary(brickColor => brickColor.Name);
            ByNumber = BrickColors.ColorMap.ToDictionary(brickColor => brickColor.Number);
            ByPalette = BrickColors.PaletteMap.Select(number => ByNumber[number]).ToList();
        }

        public static BrickColor New(string name)
        {
            if (!ByName.ContainsKey(name))
                name = DefaultName;

            return ByName[name];
        }

        public static BrickColor New(int number)
        {
            if (!ByNumber.ContainsKey(number))
                number = DefaultNumber;

            return ByNumber[number];
        }

        public static BrickColor New(Color3 color)
        {
            return New(color.R, color.G, color.B);
        }

        public static BrickColor New(float r = 0, float g = 0, float b = 0)
        {
            BrickColor bestMatch = New(-1);
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

        public static BrickColor White()    => New("White");
        public static BrickColor Gray()     => New("Medium stone grey");
        public static BrickColor DarkGray() => New("Dark stone grey");
        public static BrickColor Black()    => New("Black");
        public static BrickColor Red()      => New("Bright red");
        public static BrickColor Yellow()   => New("Bright yellow");
        public static BrickColor Green()    => New("Dark green");
        public static BrickColor Blue()     => New("Bright blue");
    }
}