using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Posts.MakePostPublic;

internal class MakePostPublicCommandHandler : CommandHandlerMediatRBase<MakePostPublicCommandHandler, MakePostPublicCommand, MakePostPublicCommandResult>
{
    public MakePostPublicCommandHandler(IUserInformation currentUser, ILogger<MakePostPublicCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<MakePostPublicCommandResult> HandleAsync(MakePostPublicCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
