namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public record class Shared
{
    public Guid PostId { get; }

    public Author Author { get; }

    public DateTime DateAndTimeOfShare { get; }

    protected Shared() { }

    public Shared(Guid postId, Author author, DateTime dateAndTimeOfShare)
    {
        PostId = postId;
        Author = author;
        DateAndTimeOfShare = dateAndTimeOfShare;
    }
}