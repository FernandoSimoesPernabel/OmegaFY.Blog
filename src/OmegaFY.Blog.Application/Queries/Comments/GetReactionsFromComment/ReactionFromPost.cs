using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromPost;

public class ReactionFromPost
{
    public Guid ReactionId { get; set; }

    public Guid CommentId { get; set; }

    public Guid ReactionAuthorId { get; set; }

    public string ReactionAuthorName { get; set; }

    public Reactions CommentReaction { get; set; }
}