using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Posts.GetPost;

public sealed record class GetPostQuery : QueryRequestMediatRBase<GetPostQueryResult>
{
    public Guid PostId { get; set; }
}