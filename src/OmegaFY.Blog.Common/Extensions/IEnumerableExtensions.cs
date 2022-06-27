namespace OmegaFY.Blog.Common.Extensions;

public static class IEnumerableExtensions
{
    public static bool IsEmpty<T>(this IEnumerable<T> items) => !(items?.Any() ?? false);
}