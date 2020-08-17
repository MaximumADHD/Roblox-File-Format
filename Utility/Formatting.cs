using System;
using System.IO;
using System.Globalization;
using System.Text;

internal static class Formatting
{
    private static CultureInfo Invariant => CultureInfo.InvariantCulture;

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
            result = value.ToString(Invariant);

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
            result = value.ToString(Invariant);

        return result;
    }

    public static string ToInvariantString(this int value)
    {
        return value.ToString(Invariant);
    }

    public static string ToInvariantString(this object value)
    {
        switch (value)
        {
            case double d : return d.ToInvariantString();
            case float  f : return f.ToInvariantString();
            case int    i : return i.ToInvariantString();
            default       : return value.ToString();
        }
    }

    public static string ToLowerInvariant(this string str)
    {
        return str.ToLower(Invariant);
    }

    public static string ToUpperInvariant(this string str)
    {
        return str.ToUpper(Invariant);
    }

    public static bool StartsWithInvariant(this string str, string other)
    {
        return str.StartsWith(other, StringComparison.InvariantCulture);
    }

    public static bool EndsWithInvariant(this string str, string other)
    {
        return str.EndsWith(other, StringComparison.InvariantCulture);
    }

    public static float ParseFloat(string value)
    {
        switch (value)
        {
            case  "NAN" : return float.NaN;
            case  "INF" : return float.PositiveInfinity;
            case "-INF" : return float.NegativeInfinity;
            default     : return float.Parse(value, Invariant);
        }
    }

    public static double ParseDouble(string value)
    {
        switch (value)
        {
            case  "NAN" : return double.NaN;
            case  "INF" : return double.PositiveInfinity;
            case "-INF" : return double.NegativeInfinity;
            default     : return double.Parse(value, Invariant);
        }
    }

    public static int ParseInt(string s)
    {
        return int.Parse(s, Invariant);
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