using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromComment;

public sealed record class GetReactionsFromCommentQuery : QueryRequestMediatRBase<GetReactionsFromCommentQueryResult>
{
    public Guid CommentId { get; set; }
}