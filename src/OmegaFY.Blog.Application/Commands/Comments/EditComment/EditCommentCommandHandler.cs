using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Comments.EditComment;

internal class EditCommentCommandHandler : CommandHandlerMediatRBase<EditCommentCommandHandler, EditCommentCommand, EditCommentCommandResult>
{
    public EditCommentCommandHandler(IUserInformation currentUser, ILogger<EditCommentCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<EditCommentCommandResult> HandleAsync(EditCommentCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
