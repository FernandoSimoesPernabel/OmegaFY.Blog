using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.WebAPI.Models.Queries;
public class GetMostRecentPublishedPostsInputModel : PagedRequest
{
    public GetMostRecentPublishedPostsQuery ToCommand() => new GetMostRecentPublishedPostsQuery(PageNumber, PageSize);
}