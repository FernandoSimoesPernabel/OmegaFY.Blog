using OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliationsFromPost;
using OmegaFY.Blog.Application.Queries.Avaliations.GetMostRecentAvaliations;
using OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;

public interface IAvaliationQueryProvider : IQueryProvider
{
    public Task<PagedResult<GetTopRatedPostsQueryResult>> GetTopRatedPostsQueryResultAsync(GetTopRatedPostsQuery request, CancellationToken cancellationToken);

    public Task<PagedResult<GetMostRecentAvaliationsQueryResult>> GetMostRecentAvaliationsQueryResultAsync(GetMostRecentAvaliationsQuery request, CancellationToken cancellationToken);

    public Task<GetAvaliationsFromPostQueryResult> GetAvaliationsFromPostQueryResultAsync(GetAvaliationsFromPostQuery request, CancellationToken cancellationToken);
}