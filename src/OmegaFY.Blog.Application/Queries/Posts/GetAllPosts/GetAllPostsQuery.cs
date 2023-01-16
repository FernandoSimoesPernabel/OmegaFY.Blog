using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;

public class GetAllPostsQuery : QueryPagedRequestMediatRBase<PagedResult<GetAllPostsQueryResult>>
{
    public DateTime? StartDateOfCreation { get; set; }

    public DateTime? EndDateOfCreation { get; set; }

    public Guid? AuthorId { get; set; }
}