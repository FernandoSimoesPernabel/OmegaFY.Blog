using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

public sealed record class GetMostRecentSharesQueryResult : GenericResult, IQueryResult
{
    public Guid ShareId { get; set; }

    public string ShareAuthorName { get; set; }

    public Guid PostId { get; set; }

    public string PostTitle { get; set; }

    public string PostAuthorName { get; set; }

    public DateTime DateAndTimeOfShare { get; set; }
}