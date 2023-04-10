using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromPost;

public sealed record class ReactionFromPost
{
    public Guid ReactionId { get; set; }

    public Guid CommentId { get; set; }

    public Guid ReactionAuthorId { get; set; }

    public string ReactionAuthorName { get; set; }

    public CommentReaction CommentReaction { get; set; }
}