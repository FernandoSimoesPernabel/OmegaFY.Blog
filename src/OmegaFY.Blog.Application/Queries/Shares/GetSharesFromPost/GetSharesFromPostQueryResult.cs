using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Shares.GetSharesFromPost;

public sealed record class GetSharesFromPostQueryResult : GenericResult, IQueryResult
{
    public ShareFromPost[] SharesFromPost { get; set; }

    public GetSharesFromPostQueryResult()
    {
        SharesFromPost = Array.Empty<ShareFromPost>();
    }

    public GetSharesFromPostQueryResult(ShareFromPost[] sharesFromPost)
    {
        SharesFromPost = sharesFromPost;
    }
}