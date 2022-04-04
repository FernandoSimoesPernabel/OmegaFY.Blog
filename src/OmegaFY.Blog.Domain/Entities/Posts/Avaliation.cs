using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class Avaliation : Entity
{
    public Guid PostId { get; }

    public Author Author { get; }

    public DateTime DateAndTimeOfAvaliation { get; }

    public Stars Rate { get; private set; }

    public Avaliation(Guid postId, Author author, Stars rate)
    {
        PostId = postId;
        Author = author;
        DateAndTimeOfAvaliation = DateTime.UtcNow;
        Rate = rate;
    }
}