using System.Collections.Generic;
using System.Globalization;

public static class Extensions
{

    public static string S(this float f) => f.ToString(CultureInfo.InvariantCulture);
    public static float F(this string s) => float.Parse(s, CultureInfo.InvariantCulture);

    public static List<float> V(this string s)
    {
        var array = new List<float>();
        var data = s.Replace(" ", "").Split(",", System.StringSplitOptions.RemoveEmptyEntries);
        foreach(var item in data)
        {
            try
            {
                array.Add(item.F());
            }
            catch
            {
                return null;
            }
        }

        return array;
    }
}