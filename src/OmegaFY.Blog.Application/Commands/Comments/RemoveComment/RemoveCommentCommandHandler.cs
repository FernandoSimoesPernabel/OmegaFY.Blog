using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Comments.RemoveComment;

internal class RemoveCommentCommandHandler : CommandHandlerMediatRBase<RemoveCommentCommandHandler, RemoveCommentCommand, RemoveCommentCommandResult>
{
    public RemoveCommentCommandHandler(IUserInformation currentUser, ILogger<RemoveCommentCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<RemoveCommentCommandResult> HandleAsync(RemoveCommentCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
