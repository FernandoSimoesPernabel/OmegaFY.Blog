using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Application.Commands.Shares.SharePost;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.Domain.Repositories.Shares;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Shares.UnsharePost;

internal class UnsharePostCommandHandler : CommandHandlerMediatRBase<UnsharePostCommandHandler, UnsharePostCommand, UnsharePostCommandResult>
{
    private readonly IShareRepository _repository;

    public UnsharePostCommandHandler(
        IUserInformation currentUser,
        ILogger<UnsharePostCommandHandler> logger,
        IShareRepository repository) : base(currentUser, logger) => _repository = repository;

    public override async Task<UnsharePostCommandResult> HandleAsync(UnsharePostCommand command, CancellationToken cancellationToken)
    {
        PostShares postToShare = await _repository.GetPostByIdAsync(command.PostId, cancellationToken);

        if (postToShare is null)
            throw new NotFoundException();

        postToShare.Unshare(_currentUser.CurrentRequestUserId.Value);

        await _repository.SaveChangesAsync(cancellationToken);

        return new UnsharePostCommandResult();
    }
}