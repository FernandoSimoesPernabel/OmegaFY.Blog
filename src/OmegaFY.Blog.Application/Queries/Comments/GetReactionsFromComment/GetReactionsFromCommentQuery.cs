using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromPost;

public sealed record class GetReactionsFromCommentQuery : QueryRequestMediatRBase<GetReactionsFromCommentQueryResult>
{
    public Guid CommentId { get; set; }
}