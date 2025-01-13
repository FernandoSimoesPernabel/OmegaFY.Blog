using OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliationsFromPost;
using OmegaFY.Blog.Application.Queries.Avaliations.GetMostRecentAvaliations;
using OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;

namespace OmegaFY.Blog.Data.MongoDB.QueryProviders;

internal class AvaliationQueryProvider : IAvaliationQueryProvider
{
    public Task<GetAvaliationsFromPostQueryResult> GetAvaliationsFromPostQueryResultAsync(GetAvaliationsFromPostQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<GetMostRecentAvaliationsQueryResult>> GetMostRecentAvaliationsQueryResultAsync(GetMostRecentAvaliationsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<GetTopRatedPostsQueryResult>> GetTopRatedPostsQueryResultAsync(GetTopRatedPostsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}