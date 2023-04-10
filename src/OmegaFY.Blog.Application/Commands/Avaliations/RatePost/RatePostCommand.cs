using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Commands.Avaliations.RatePost;

public sealed record class RatePostCommand : CommandMediatRBase<RatePostCommandResult>
{
    public Guid PostId { get; set; }

    public Stars Rate { get; set; }
}