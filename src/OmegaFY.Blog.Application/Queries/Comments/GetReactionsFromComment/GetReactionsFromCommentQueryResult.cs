using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromComment;

public sealed record class GetReactionsFromCommentQueryResult : GenericResult, IQueryResult
{
    public ReactionFromComment[] ReactionsFromPost { get; set; }

    public GetReactionsFromCommentQueryResult() { }

    public GetReactionsFromCommentQueryResult(ReactionFromComment[] reactionsFromPost)
    {
        ReactionsFromPost = reactionsFromPost;
    }
}