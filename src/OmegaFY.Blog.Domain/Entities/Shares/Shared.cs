using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Shares;

public class Shared : Entity
{
    public ReferenceId PostId { get; }

    public ReferenceId AuthorId { get; }

    public DateTime DateAndTimeOfShare { get; }

    protected Shared() { }

    public Shared(ReferenceId postId, ReferenceId authorId)
    {
        PostId = postId;
        AuthorId = authorId;
        DateAndTimeOfShare = DateTime.UtcNow;
    }
}