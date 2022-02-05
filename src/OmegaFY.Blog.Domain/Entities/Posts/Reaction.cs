using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class Reaction : Entity
{
    public Guid CommentId { get; }

    public Author Author { get; }

    public Reactions AuthorReaction { get; private set; }

    public Reaction(Guid commentId, Author author, Reactions authorReaction)
    {
        CommentId = commentId;
        Author = author;
        AuthorReaction = authorReaction;
    }

    public void ChangeAuthorReaction(Reactions newAuthorReaction) => AuthorReaction = newAuthorReaction;
}
