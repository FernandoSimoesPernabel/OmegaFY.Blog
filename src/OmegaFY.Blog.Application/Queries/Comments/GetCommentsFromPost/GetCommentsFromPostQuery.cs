using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Comments.GetCommentsFromPostsFromPost;

public sealed record class GetCommentsFromPostQuery : QueryRequestMediatRBase<GetCommentsFromPostQueryResult>
{
    public Guid PostId { get; set; }
}