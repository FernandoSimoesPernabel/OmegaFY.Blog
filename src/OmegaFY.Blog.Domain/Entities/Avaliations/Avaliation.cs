using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Avaliations;

public class Avaliation : Entity
{
    public Guid PostId { get; }

    public Author Author { get; }

    public ModificationDetails ModificationDetails { get; private set; }

    public Stars Rate { get; private set; }

    protected Avaliation() { }

    public Avaliation(Guid postId, Author author, Stars rate)
    {
        PostId = postId;
        Author = author;
        ModificationDetails = new ModificationDetails();
        Rate = rate;
    }

    internal void ChangeRating(Stars newRate)
    {
        Rate = newRate;
        ModificationDetails = new ModificationDetails(ModificationDetails.DateOfCreation);
    }
}