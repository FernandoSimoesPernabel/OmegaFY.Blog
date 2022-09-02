using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;

public class GetMostRecentPublishedPostsQuery : QueryPagedRequestMediatRBase<PagedResult<GetMostRecentPublishedPostsQueryResult>>
{
    public GetMostRecentPublishedPostsQuery() { }

    public GetMostRecentPublishedPostsQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}