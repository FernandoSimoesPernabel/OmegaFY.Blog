using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;

public class CurrentUserHasSharedPostQueryResult : GenericResult, IQueryResult
{
    public Guid PostId { get; set; }

    public Guid? ShareId { get; set; }

    public bool HaveSharePost => ShareId.HasValue;

    public CurrentUserHasSharedPostQueryResult() { }

    public CurrentUserHasSharedPostQueryResult(Guid postId, Guid? shareId)
    {
        PostId = postId;
        ShareId = shareId;
    }
}