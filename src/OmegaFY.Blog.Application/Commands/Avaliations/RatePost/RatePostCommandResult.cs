using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Commands.Avaliations.RatePost;

public class RatePostCommandResult : GenericResult, ICommandResult
{
    public Guid AvaliationId { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public Stars Rate { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }

    public RatePostCommandResult() { }

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