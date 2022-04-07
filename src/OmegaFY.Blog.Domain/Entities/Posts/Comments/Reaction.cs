using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Posts.Comments;

public class Reaction : Entity
{
    public Guid CommentId { get; }

    public Author Author { get; }

    public Reactions CommentReaction { get; private set; }

    protected Reaction() { }

    public Reaction(Guid commentId, Author author, Reactions commentReaction)
    {
        CommentId = commentId;
        Author = author;
        CommentReaction = commentReaction;
    }

    public void ChangeCommentReaction(Reactions newCommentReaction) => CommentReaction = newCommentReaction;
}
