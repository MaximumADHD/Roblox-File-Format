namespace Roblox.DataTypes
{
    public struct ColorSequenceKeypoint
    {
        public readonly float Time;
        public readonly Color3 Color;

        public ColorSequenceKeypoint(float time, Color3 color)
        {
            Time = time;
            Color = color;
        }

        public override string ToString()
        {
            return string.Join(" ", Time, Color.R, Color.G, Color.B, 0);
        }
    }
}
