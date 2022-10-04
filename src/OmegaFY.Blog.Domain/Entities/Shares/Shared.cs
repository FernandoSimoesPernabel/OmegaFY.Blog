using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.Entities.Shares;

public class Shared : Entity
{
    public Guid PostId { get; }

    public Guid AuthorId { get; }

    public DateTime DateAndTimeOfShare { get; }

    protected Shared() { }

    public Shared(Guid postId, Guid authorId)
    {
        if (postId == Guid.Empty)
            throw new DomainArgumentException("");

        if (authorId == Guid.Empty)
            throw new DomainArgumentException("");

        PostId = postId;
        AuthorId = authorId;
        DateAndTimeOfShare = DateTime.UtcNow;
    }
}