using MongoDB.Driver;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class IAsyncCursorSource
{
    public static async Task<TDocument[]> ToArrayAsync<TDocument>(this IAsyncCursorSource<TDocument> source, CancellationToken cancellationToken)
    {
        List<TDocument> result = await source.ToListAsync(cancellationToken);
        return result.ToArray();
    }
}