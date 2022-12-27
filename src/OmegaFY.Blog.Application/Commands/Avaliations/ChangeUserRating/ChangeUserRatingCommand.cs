using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Commands.Avaliations.ChangeUserRating;

public class ChangeUserRatingCommand : CommandMediatRBase<ChangeUserRatingCommandResult>
{
    public Guid PostId { get; set; }

    public Guid AvaliationId { get; set; }

    public Stars NewRate { get; set; }

    public ChangeUserRatingCommand() { }

    public ChangeUserRatingCommand(Guid postId, Guid avaliationId, Stars newRate)
    {
        PostId = postId;
        AvaliationId = avaliationId;
        NewRate = newRate;
    }
}