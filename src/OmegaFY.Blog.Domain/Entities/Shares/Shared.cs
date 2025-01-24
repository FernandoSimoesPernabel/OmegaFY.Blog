using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Shares;

public class Shared : Entity
{
    public ReferenceId PostId { get; }

    public ReferenceId AuthorId { get; }

    public DateTime DateAndTimeOfShare { get; }

    protected Shared() { }

    private Shared(ReferenceId shareId, ReferenceId postId, ReferenceId authorId, DateTime dateAndTimeOfShare) : base(shareId)
    {
        PostId = postId;
        AuthorId = authorId;
        DateAndTimeOfShare = dateAndTimeOfShare;
    }

    public Shared(ReferenceId postId, ReferenceId authorId)
    {
        PostId = postId;
        AuthorId = authorId;
        DateAndTimeOfShare = DateTime.UtcNow;
    }

    public static Shared Create(ReferenceId shareId, ReferenceId postId, ReferenceId authorId, DateTime dateAndTimeOfShare) 
        => new Shared(shareId, postId, authorId, dateAndTimeOfShare);
}