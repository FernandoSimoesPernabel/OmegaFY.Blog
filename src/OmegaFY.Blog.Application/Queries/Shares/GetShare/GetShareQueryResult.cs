using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

public class GetShareQueryResult : GenericResult, IQueryResult
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public DateTime DateAndTimeOfShare { get; set; }

    public GetShareQueryResult() { }

    public GetShareQueryResult(Guid id, Guid postId, Guid authorId, DateTime dateAndTimeOfShare)
    {
        Id = id;
        PostId = postId;
        AuthorId = authorId;
        DateAndTimeOfShare = dateAndTimeOfShare;
    }
}