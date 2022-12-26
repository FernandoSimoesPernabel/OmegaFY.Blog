using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

namespace OmegaFY.Blog.WebAPI.Models.Queries;

public class GetShareInputModel
{
    public Guid PostId { get; set; }

    public Guid ShareId { get; set; }

    public GetShareQuery ToCommand() => new GetShareQuery(PostId, ShareId);
}