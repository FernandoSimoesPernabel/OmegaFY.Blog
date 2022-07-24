using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Comments;

public class Reaction : Entity
{
    public Guid CommentId { get; }

    public Author Author { get; }

    public Reactions CommentReaction { get; private set; }

    protected Reaction() { }

    public Reaction(Guid commentId, Author author, Reactions commentReaction)
    {
        if (commentId == Guid.Empty)
            throw new DomainArgumentException("");

        if (author is null)
            throw new DomainArgumentException("");

        ChangeCommentReaction(commentReaction);
        CommentId = commentId;
        Author = author;
    }

    public void ChangeCommentReaction(Reactions commentReaction)
    {
        if (!commentReaction.IsDefined())
            throw new DomainArgumentException("");

        CommentReaction = commentReaction;
    }
}
