using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;

public class GetAllPostsQuery : QueryPagedRequestMediatRBase<PagedResult<GetAllPostsQueryResult>>
{
    public DateTime? StartDateOfCreation { get; set; }

    public DateTime? EndDateOfCreation { get; set; }

    public Guid? AuthorId { get; set; }

    public GetAllPostsQuery() { }

    public GetAllPostsQuery(DateTime? startDateOfCreation, DateTime? endDateOfCreation, Guid? authorId, int pageNumber, int pageSize)
    {
        StartDateOfCreation = startDateOfCreation;
        EndDateOfCreation = endDateOfCreation;
        AuthorId = authorId;
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
}
