using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

public class GetMostRecentSharesQuery : QueryPagedRequestMediatRBase<PagedResult<GetMostRecentSharesQueryResult>>
{
    public Guid? AuthorId { get; set; }

    public GetMostRecentSharesQuery() { }

    public GetMostRecentSharesQuery(int pageNumber, int pageSize, Guid? authorId)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        AuthorId = authorId;
    }
}