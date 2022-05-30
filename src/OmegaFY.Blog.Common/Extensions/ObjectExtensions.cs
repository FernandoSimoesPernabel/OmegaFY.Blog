namespace OmegaFY.Blog.Common.Extensions;

public static class ObjectExtensions
{
    public static bool In(this object value, params object[] valuesToCompare) => valuesToCompare?.Any(v => v == value) ?? false;

    public static Task<T> ToTaskResult<T>(this T obj) => Task.FromResult(obj);
}