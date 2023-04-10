using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;

public sealed record class GetTopRatedPostsQuery : QueryPagedRequestMediatRBase<PagedResult<GetTopRatedPostsQueryResult>>
{
}