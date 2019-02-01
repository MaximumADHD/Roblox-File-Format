using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxFiles.DataTypes
{
    public struct Region3int16
    {
        public readonly Vector3int16 Min, Max;

        public Region3int16(Vector3int16 min = null, Vector3int16 max = null)
        {
            Min = min ?? new Vector3int16();
            Max = max ?? new Vector3int16();
        }

        public override string ToString()
        {
            return string.Join("; ", Min, Max);
        }
    }
}
