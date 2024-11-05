using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Avaliations;

public class Avaliation : Entity
{
    public ReferenceId PostId { get; }

    public ReferenceId AuthorId { get; }

    public ModificationDetails ModificationDetails { get; private set; }

    public Stars Rate { get; private set; }

    protected Avaliation() { }

    public Avaliation(ReferenceId postId, ReferenceId authorId, Stars rate)
    {
        PostId = postId;
        AuthorId = authorId;
        ModificationDetails = new ModificationDetails();
        ChangeRating(rate);
    }

    internal void ChangeRating(Stars rate)
    {
        if (!rate.IsDefined())
            throw new DomainArgumentException("A avaliação informada está fora do range aceitado.");

        Rate = rate;

        if (ModificationDetails is not null)
            ModificationDetails = new ModificationDetails(ModificationDetails.DateOfCreation);
    }
}