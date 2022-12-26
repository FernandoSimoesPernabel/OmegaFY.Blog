using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Commands.Avaliations.RatePost;

public class RatePostCommand : CommandMediatRBase<RatePostCommandResult>
{
    public Guid PostId { get; set; }

    public Stars Rate { get; set; }

    public RatePostCommand() { }

    public RatePostCommand(Guid postId, Stars rate)
    {
        PostId = postId;
        Rate = rate;
    }
}