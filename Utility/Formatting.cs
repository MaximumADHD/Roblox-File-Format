using System;
using System.IO;
using System.Globalization;
using System.Text;

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

    public static bool FuzzyEquals(this float a, float b, float epsilon = 10e-5f)
    {
        return Math.Abs(a - b) < epsilon;
    }

    public static bool FuzzyEquals(this double a, double b, double epsilon = 10e-5)
    {
        return Math.Abs(a - b) < epsilon;
    }

    public static byte[] ReadBuffer(this BinaryReader reader)
    {
        int len = reader.ReadInt32();
        return reader.ReadBytes(len);
    }

    public static string ReadString(this BinaryReader reader, bool useIntLength)
    {
        if (!useIntLength)
            return reader.ReadString();

        byte[] buffer = reader.ReadBuffer();
        return Encoding.UTF8.GetString(buffer);
    }
}