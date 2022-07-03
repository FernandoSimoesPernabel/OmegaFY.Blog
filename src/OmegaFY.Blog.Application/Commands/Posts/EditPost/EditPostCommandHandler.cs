using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Posts.EditPost;

internal class EditPostCommandHandler : CommandHandlerMediatRBase<EditPostCommandHandler, EditPostCommand, EditPostCommandResult>
{
    public EditPostCommandHandler(IUserInformation currentUser, ILogger<EditPostCommandHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<EditPostCommandResult> HandleAsync(EditPostCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
