using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Shares.SharePost;

internal class SharePostCommandHandler : CommandHandlerMediatRBase<SharePostCommandHandler, SharePostCommand, SharePostCommandResult>
{
    public SharePostCommandHandler(IUserInformation currentUser, ILogger<SharePostCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<SharePostCommandResult> HandleAsync(SharePostCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
