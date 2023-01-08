using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.Domain.Repositories;
using OmegaFY.Blog.Domain.Repositories.Avaliations;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Avaliations.RatePost;

internal class RatePostCommandHandler : CommandHandlerMediatRBase<RatePostCommandHandler, RatePostCommand, RatePostCommandResult>
{
    private readonly IAvaliationRepository _repository;

    public RatePostCommandHandler(IUserInformation currentUser, ILogger<RatePostCommandHandler> logger, IAvaliationRepository repository)
        : base(currentUser, logger) => _repository = repository;

    public async override Task<RatePostCommandResult> HandleAsync(RatePostCommand command, CancellationToken cancellationToken)
    {
        PostAvaliations postToRate = await _repository.GetPostByIdAsync(command.PostId, cancellationToken);

        if (postToRate is null)
            throw new NotFoundException();

        postToRate.RatePost(_currentUser.CurrentRequestUserId.Value, command.Rate);

        await _repository.SaveChangesAsync(cancellationToken);

        Avaliation avaliationFromCurrentUser = postToRate.FindAvaliationAndThrowIfNotFound(_currentUser.CurrentRequestUserId.Value);

        return new RatePostCommandResult(
            avaliationFromCurrentUser.Id,
            avaliationFromCurrentUser.PostId,
            avaliationFromCurrentUser.AuthorId,
            avaliationFromCurrentUser.Rate,
            avaliationFromCurrentUser.ModificationDetails.DateOfCreation,
            avaliationFromCurrentUser.ModificationDetails.DateOfModification);
    }
}