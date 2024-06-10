using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

public sealed record class GetMostRecentSharesQuery : QueryPagedRequestMediatRBase<PagedResult<GetMostRecentSharesQueryResult>>
{
    public Guid? AuthorId { get; set; }
}