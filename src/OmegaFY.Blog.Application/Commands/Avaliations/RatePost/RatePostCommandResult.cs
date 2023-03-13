using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Commands.Avaliations.RatePost;

public class RatePostCommandResult : GenericResult, ICommandResult
{
    public Guid AvaliationId { get; }

    public Guid PostId { get; }

    public Guid AuthorId { get; }

    public Stars Rate { get; }

    public DateTime DateOfCreation { get; }

    public DateTime? DateOfModification { get; }

    public RatePostCommandResult(Guid avaliationId, Guid postId, Guid authorId, Stars rate, DateTime dateOfCreation, DateTime? dateOfModification)
    {
        AvaliationId = avaliationId;
        PostId = postId;
        AuthorId = authorId;
        Rate = rate;
        DateOfCreation = dateOfCreation;
        DateOfModification = dateOfModification;
    }
}