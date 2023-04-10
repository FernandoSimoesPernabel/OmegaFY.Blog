using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Comments.GetCommentsFromPostsFromPost;

public sealed record class GetCommentsFromPostQueryResult : GenericResult, IQueryResult
{
    public CommentFromPost[] CommentsFromPost { get; set; }

    public GetCommentsFromPostQueryResult() { }

    public GetCommentsFromPostQueryResult(CommentFromPost[] commentsFromPost)
    {
        CommentsFromPost = commentsFromPost;
    }
}