using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roblox
{
    public enum PropertyType
    {
        Unknown,
        String,
        Bool,
        Int,
        Float,
        Double,
        UDim,
        UDim2,
        Ray,
        Faces,
        Axes,
        BrickColor,
        Color3,
        Vector2,
        Vector3,
        Vector2int16,
        CFrame,
        Quaternion,
        Enum,
        Ref,
        Vector3int16,
        NumberSequence,
        ColorSequence,
        NumberRange,
        Rect,
        PhysicalProperties,
        Color3uint8,
        Int64
    }

    public class RobloxProperty
    {
        public string Name;
        public PropertyType Type;
        public object Value;

        public override string ToString()
        {
            Type PropertyType = typeof(PropertyType);

            string typeName = Enum.GetName(PropertyType, Type);
            string valueLabel;

            if (Value != null)
                valueLabel = Value.ToString();
            else
                valueLabel = "?";

            return string.Join(" ", typeName, Name, '=', valueLabel);
        }
    }
}
