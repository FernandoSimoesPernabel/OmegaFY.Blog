using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Comments.ReactToComment;

internal class ReactToCommentCommandHandler : CommandHandlerMediatRBase<ReactToCommentCommandHandler, ReactToCommentCommand, ReactToCommentCommandResult>
{
    public ReactToCommentCommandHandler(IUserInformation currentUser, ILogger<ReactToCommentCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<ReactToCommentCommandResult> HandleAsync(ReactToCommentCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
