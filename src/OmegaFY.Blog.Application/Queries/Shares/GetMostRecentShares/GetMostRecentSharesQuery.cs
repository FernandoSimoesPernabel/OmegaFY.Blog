using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

public class GetMostRecentSharesQuery : QueryPagedRequestMediatRBase<PagedResult<GetMostRecentSharesQueryResult>>
{
    public Guid? AuthorId { get; set; }
}