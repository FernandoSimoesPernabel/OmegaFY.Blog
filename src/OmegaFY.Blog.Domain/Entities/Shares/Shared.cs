using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Shares;

public class Shared : Entity
{
    public ReferenceId PostId { get; }

    public ReferenceId AuthorId { get; }

    public DateTime DateAndTimeOfShare { get; }

    protected Shared() { }

    public Shared(Guid postId, ReferenceId authorId)
    {
        PostId = postId;
        AuthorId = authorId;
        DateAndTimeOfShare = DateTime.UtcNow;
    }
}