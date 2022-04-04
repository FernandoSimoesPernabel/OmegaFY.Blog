using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class Avaliation : Entity
{
    public Guid PostId { get; }

    public Author Author { get; }

    public ModificationDetails ModificationDetails { get; private set; }

    public Stars Rate { get; private set; }

    public Avaliation(Guid postId, Author author, Stars rate)
    {
        PostId = postId;
        Author = author;
        ModificationDetails = new ModificationDetails();
        Rate = rate;
    }
}