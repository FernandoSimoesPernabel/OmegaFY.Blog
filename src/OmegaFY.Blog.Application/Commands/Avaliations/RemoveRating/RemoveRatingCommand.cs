using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Avaliations.RemoveRating;

public class RemoveRatingCommand : CommandMediatRBase<RemoveRatingCommandResult>
{
    public Guid PostId { get; set; }

    public Guid AvaliationId { get; set; }

    public RemoveRatingCommand() { }

    public RemoveRatingCommand(Guid postId, Guid avaliationId)
    {
        PostId = postId;
        AvaliationId = avaliationId;
    }
}