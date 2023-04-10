using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;

public sealed record class GetMostRecentPublishedPostsQuery : QueryPagedRequestMediatRBase<PagedResult<GetMostRecentPublishedPostsQueryResult>>
{
}