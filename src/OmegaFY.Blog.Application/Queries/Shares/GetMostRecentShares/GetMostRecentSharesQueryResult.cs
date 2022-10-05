using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

public class GetMostRecentSharesQueryResult : GenericResult, IQueryResult
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public string PostTitle { get; set; }

    public string PostSubTitle { get; set; }

    public Guid AuthorId { get; set; }

    public string AuthorName { get; set; }

    public DateTime DateAndTimeOfShare { get; set; }

    public GetMostRecentSharesQueryResult() { }

    public GetMostRecentSharesQueryResult(Guid id, Guid postId, string postTitle, string postSubTitle, Guid authorId, string authorName, DateTime dateAndTimeOfShare)
    {
        Id = id;
        PostId = postId;
        PostTitle = postTitle;
        PostSubTitle = postSubTitle;
        AuthorId = authorId;
        AuthorName = authorName;
        DateAndTimeOfShare = dateAndTimeOfShare;
    }
}