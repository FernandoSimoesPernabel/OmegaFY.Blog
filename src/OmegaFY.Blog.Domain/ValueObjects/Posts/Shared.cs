namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public record class Shared
{
    public Guid PostId { get; }

    public Guid AuthorId { get; }

    public DateTime DateAndTimeOfShare { get; }

    protected Shared() { }

    public Shared(Guid postId, Guid authorId, DateTime dateAndTimeOfShare)
    {
        PostId = postId;
        AuthorId = authorId;
        DateAndTimeOfShare = dateAndTimeOfShare;
    }
}