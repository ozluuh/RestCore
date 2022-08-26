namespace RestCore.Extensions;

public static class GeneralExtension
{
    public static string Union(this string @this, string separator, params string[] values)
    => @this += separator += string.Join(separator, values);

    public static string Union(this IEnumerable<string> @this, string separator)
    => string.Join(separator, @this);

    public static string Union(this IEnumerable<string> @this, char separator)
    => string.Join(separator, @this);
}
