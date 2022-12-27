using OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliation;
using OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;

namespace OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;

public interface IAvaliationQueryProvider : IQueryProvider
{
    public Task<GetAvaliationQueryResult> GetAvaliationQueryResultAsync(GetAvaliationQuery request, CancellationToken cancellationToken);

    public Task<PagedResult<GetTopRatedPostsQueryResult>> GetTopRatedPostsQueryResultAsync(GetTopRatedPostsQuery request, CancellationToken cancellationToken);
}