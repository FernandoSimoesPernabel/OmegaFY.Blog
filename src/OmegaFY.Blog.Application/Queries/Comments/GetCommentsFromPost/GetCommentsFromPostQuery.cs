using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Comments.GetCommentsFromPost;

public sealed record class GetCommentsFromPostQuery : QueryRequestMediatRBase<GetCommentsFromPostQueryResult>
{
    public Guid PostId { get; set; }
}