using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

namespace OmegaFY.Blog.WebAPI.Models.Queries;

public class GetMostRecentSharesInputModel : PagedRequest
{
    public Guid? AuthorId { get; set; }

    public GetMostRecentSharesQuery ToCommand() => new GetMostRecentSharesQuery(PageNumber, PageSize, AuthorId);
}