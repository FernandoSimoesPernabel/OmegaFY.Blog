using OmegaFY.Blog.Domain.QueryProviders.Posts.QueryResults;

namespace OmegaFY.Blog.Domain.QueryProviders.Posts;

public interface IPostQueryProvider : IQueryProvider
{
    public Task<GetPostQueryResult> GetPostQueryResultAsync(Guid id, CancellationToken cancellationToken);
}