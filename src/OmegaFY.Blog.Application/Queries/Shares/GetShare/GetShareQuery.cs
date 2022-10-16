using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

public class GetShareQuery : QueryRequestMediatRBase<GetShareQueryResult>
{
    public Guid PostId { get; set; }

    public Guid ShareId { get; set; }

    public GetShareQuery() { }

    public GetShareQuery(Guid postId, Guid shareId)
    {
        PostId = postId;
        ShareId = shareId;
    }
}