using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Comments.GetComment;

public sealed record class GetCommentQuery : QueryRequestMediatRBase<GetCommentQueryResult>
{
    public Guid CommentId { get; set; }
}