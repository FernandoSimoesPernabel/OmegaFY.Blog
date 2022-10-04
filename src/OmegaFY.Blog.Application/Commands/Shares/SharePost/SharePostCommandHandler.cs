using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Repositories.Shares;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Shares.SharePost;

internal class SharePostCommandHandler : CommandHandlerMediatRBase<SharePostCommandHandler, SharePostCommand, SharePostCommandResult>
{
    private readonly IShareRepository _repository;

    public SharePostCommandHandler(
        IUserInformation currentUser,
        ILogger<SharePostCommandHandler> logger,
        IShareRepository repository) : base(currentUser, logger)
    {
        _repository = repository;
    }

    public override Task<SharePostCommandResult> HandleAsync(SharePostCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}