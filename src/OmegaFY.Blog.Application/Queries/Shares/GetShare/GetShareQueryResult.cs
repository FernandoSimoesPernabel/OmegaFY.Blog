using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

public class GetShareQueryResult : GenericResult, IQueryResult
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public string AuthorName { get; set; }

    public DateTime DateAndTimeOfShare { get; set; }
}