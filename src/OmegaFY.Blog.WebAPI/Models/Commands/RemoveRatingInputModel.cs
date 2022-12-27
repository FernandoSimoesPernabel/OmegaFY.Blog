using OmegaFY.Blog.Application.Commands.Avaliations.RemoveRating;

namespace OmegaFY.Blog.WebAPI.Models.Commands;

public class RemoveRatingInputModel
{
    public Guid PostId { get; set; }

    public Guid AvaliationId { get; set; }

    public RemoveRatingCommand ToCommand() => new RemoveRatingCommand(PostId, AvaliationId);
}