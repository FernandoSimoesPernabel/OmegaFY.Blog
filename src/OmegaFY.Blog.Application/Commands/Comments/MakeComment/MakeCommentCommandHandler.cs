using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Comments.MakeComment;

internal class MakeCommentCommandHandler : CommandHandlerMediatRBase<MakeCommentCommandHandler, MakeCommentCommand, MakeCommentCommandResult>
{
    public MakeCommentCommandHandler(IUserInformation currentUser, ILogger<MakeCommentCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<MakeCommentCommandResult> HandleAsync(MakeCommentCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
