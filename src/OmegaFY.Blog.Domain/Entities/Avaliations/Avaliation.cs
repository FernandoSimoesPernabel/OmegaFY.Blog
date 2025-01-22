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

    private Avaliation(ReferenceId avaliationId, ReferenceId postId, ReferenceId authorId, Stars rate) : base(avaliationId)
    {
        PostId = postId;
        AuthorId = authorId;
        Rate = rate;
    }

    public Avaliation(ReferenceId postId, ReferenceId authorId, Stars rate)
    {
        PostId = postId;
        AuthorId = authorId;
        ChangeRating(rate);
        ModificationDetails = new ModificationDetails();
    }

    internal void ChangeRating(Stars rate)
    {
        if (!rate.IsDefined())
            throw new DomainArgumentException("A avaliação informada está fora do range aceitado.");

        Rate = rate;

        ModificationDetails = new ModificationDetails(ModificationDetails.DateOfCreation);
    }

    public static Avaliation Create(ReferenceId avaliationId, ReferenceId postId, ReferenceId authorId, Stars rate) 
        => new Avaliation(avaliationId, postId, authorId, rate);
}