using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Shares;

public class Shared : Entity
{
    public Guid PostId { get; }

    public Guid AuthorId { get; }

    public DateTime DateAndTimeOfShare { get; }

    protected Shared() { }

    public Shared(Guid postId, Author author)
    {
        if (postId == Guid.Empty)
            throw new DomainArgumentException("");

        if (author is null)
            throw new DomainArgumentException("");

        PostId = postId;
        AuthorId = author;
        DateAndTimeOfShare = DateTime.UtcNow;
    }
}