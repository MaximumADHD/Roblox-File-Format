using System;

namespace RobloxFiles.DataTypes
{
    public struct Region3
    {
        public readonly CFrame CFrame;
        public readonly Vector3 Size;

        public Region3(Vector3 a, Vector3 b)
        {
            CFrame = new CFrame((a + b) / 2);
            Size = b - a;
        }

        public override string ToString()
        {
            return CFrame + "; " + Size;
        }

        public Region3 ExpandToGrid(float resolution)
        {
            Vector3 min = (CFrame - (Size / 2)).Position / resolution;
            Vector3 max = (CFrame + (Size / 2)).Position / resolution;

            Vector3 emin = new Vector3
            (
                (float)Math.Floor(min.X) * resolution,
                (float)Math.Floor(min.Y) * resolution,
                (float)Math.Floor(min.Z) * resolution
            );

            Vector3 emax = new Vector3
            (
                (float)Math.Floor(max.X) * resolution,
                (float)Math.Floor(max.Y) * resolution,
                (float)Math.Floor(max.Z) * resolution
            );

            return new Region3(emin, emax);
        }
    }
}
