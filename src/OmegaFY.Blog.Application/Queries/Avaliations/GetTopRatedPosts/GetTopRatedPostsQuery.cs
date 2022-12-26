using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;

public class GetTopRatedPostsQuery : QueryPagedRequestMediatRBase<PagedResult<GetTopRatedPostsQueryResult>>
{
    public GetTopRatedPostsQuery() { }

    public GetTopRatedPostsQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
