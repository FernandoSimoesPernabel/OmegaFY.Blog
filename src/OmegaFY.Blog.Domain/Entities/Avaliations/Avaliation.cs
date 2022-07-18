using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
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
        if (postId == Guid.Empty)
            throw new DomainArgumentException("");

        if (author is null)
            throw new DomainArgumentException("");

        ChangeRating(rate);
        PostId = postId;
        Author = author;
        ModificationDetails = new ModificationDetails();

    }

    internal void ChangeRating(Stars rate)
    {
        if (!rate.IsDefined())
            throw new DomainArgumentException("");

        Rate = rate;

        if (ModificationDetails is not null)
            ModificationDetails = new ModificationDetails(ModificationDetails.DateOfCreation);
    }
}