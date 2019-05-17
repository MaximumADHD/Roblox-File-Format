using System.Globalization;
using System.Linq;

// This global class defines extension methods to numeric types
// where I don't want system globalization to come into play.

internal static class Formatting
{
    private static CultureInfo invariant => CultureInfo.InvariantCulture;

    public static string ToInvariantString(this float value)
    {
        string result;

        if (float.IsPositiveInfinity(value))
            result = "INF";
        else if (float.IsNegativeInfinity(value))
            result = "-INF";
        else if (float.IsNaN(value))
            result = "NAN";
        else
            result = value.ToString(invariant);

        return result;
    }

    public static string ToInvariantString(this double value)
    {
        string result;

        if (double.IsPositiveInfinity(value))
            result = "INF";
        else if (double.IsNegativeInfinity(value))
            result = "-INF";
        else if (double.IsNaN(value))
            result = "NAN";
        else
            result = value.ToString(invariant);

        return result;
    }

    public static string ToInvariantString(this int value)
    {
        return value.ToString(invariant);
    }

    public static string ToInvariantString(this object value)
    {
        if (value is float)
        {
            float f = (float)value;
            return f.ToInvariantString();
        }
        else if (value is double)
        {
            double d = (double)value;
            return d.ToInvariantString();
        }
        else if (value is int)
        {
            int i = (int)value;
            return i.ToInvariantString();
        }
        else
        {
            // Unhandled
            return value.ToString();
        }
    }

    public static float ParseFloat(string value)
    {
        float result;

        if (value == "INF")
            result = float.PositiveInfinity;
        else if (value == "-INF")
            result = float.NegativeInfinity;
        else if (value == "NAN")
            result = float.NaN;
        else
            result = float.Parse(value, invariant);

        return result;
    }

    public static double ParseDouble(string value)
    {
        double result;

        if (value == "INF")
            result = double.PositiveInfinity;
        else if (value == "-INF")
            result = double.NegativeInfinity;
        else if (value == "NAN")
            result = double.NaN;
        else
            result = double.Parse(value, invariant);

        return result;
    }

    public static int ParseInt(string s)
    {
        return int.Parse(s, invariant);
    }
}