using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Commands.Avaliations.ChangeUserRating;

public class ChangeUserRatingCommandResult : GenericResult, ICommandResult
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public Stars Rate { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime DateOfModification { get; set; }

    public ChangeUserRatingCommandResult() { }

    public ChangeUserRatingCommandResult(Guid id, Guid postId, Guid authorId, Stars rate, DateTime dateOfCreation, DateTime dateOfModification)
    {
        Id = id;
        PostId = postId;
        AuthorId = authorId;
        Rate = rate;
        DateOfCreation = dateOfCreation;
        DateOfModification = dateOfModification;
    }
}