using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Repositories.Shares;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Shares.UnsharePost;

internal class UnsharePostCommandHandler : CommandHandlerMediatRBase<UnsharePostCommandHandler, UnsharePostCommand, UnsharePostCommandResult>
{
    private readonly IShareRepository _repository;

    public UnsharePostCommandHandler(
        IUserInformation currentUser, 
        ILogger<UnsharePostCommandHandler> logger, 
        IShareRepository repository) : base(currentUser, logger)
    {
        _repository = repository;
    }

    public override Task<UnsharePostCommandResult> HandleAsync(UnsharePostCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}