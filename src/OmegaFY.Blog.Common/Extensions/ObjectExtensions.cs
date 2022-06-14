namespace OmegaFY.Blog.Common.Extensions;

public static class ObjectExtensions
{
    public static bool In(this object value, params object[] valuesToCompare) => valuesToCompare?.Any(v => v == value) ?? false;

    public static string ToJson(this object value) => System.Text.Json.JsonSerializer.Serialize(value);
}