using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public record class Shared
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