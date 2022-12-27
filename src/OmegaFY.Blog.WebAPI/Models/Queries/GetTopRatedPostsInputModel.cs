using OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.WebAPI.Models.Queries;

public class GetTopRatedPostsInputModel : PagedRequest
{
    public GetTopRatedPostsQuery ToQuery() => new GetTopRatedPostsQuery(PageNumber, PageSize);
}