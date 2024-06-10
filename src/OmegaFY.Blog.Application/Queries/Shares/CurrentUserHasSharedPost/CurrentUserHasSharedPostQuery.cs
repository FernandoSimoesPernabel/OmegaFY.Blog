using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;

public sealed record class CurrentUserHasSharedPostQuery : QueryRequestMediatRBase<CurrentUserHasSharedPostQueryResult>
{
    public Guid PostId { get; set; }
}