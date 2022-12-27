using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;

namespace OmegaFY.Blog.WebAPI.Models.Queries;

public class GetAllPostsInputModel : PagedRequest
{
    public DateTime? StartDateOfCreation { get; set; }

    public DateTime? EndDateOfCreation { get; set; }

    public Guid? AuthorId { get; set; }

    public GetAllPostsQuery ToQuery() => new GetAllPostsQuery(StartDateOfCreation, EndDateOfCreation, AuthorId, PageNumber, PageSize);
}