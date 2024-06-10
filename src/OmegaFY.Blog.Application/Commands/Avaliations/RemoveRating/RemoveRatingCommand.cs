using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Avaliations.RemoveRating;

public sealed record class RemoveRatingCommand : CommandMediatRBase<RemoveRatingCommandResult>
{
    public Guid PostId { get; set; }
}