using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class Shared : Entity
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