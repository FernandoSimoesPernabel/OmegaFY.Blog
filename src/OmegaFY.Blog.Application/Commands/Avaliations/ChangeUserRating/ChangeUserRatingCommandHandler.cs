using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Repositories.Avaliations;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Avaliations.ChangeUserRating;

internal class ChangeUserRatingCommandHandler : CommandHandlerMediatRBase<ChangeUserRatingCommandHandler, ChangeUserRatingCommand, ChangeUserRatingCommandResult>
{
    private readonly IAvaliationRepository _repository;

    public ChangeUserRatingCommandHandler(IUserInformation currentUser, ILogger<ChangeUserRatingCommandHandler> logger, IAvaliationRepository repository)
        : base(currentUser, logger) => _repository = repository;

    public override async Task<ChangeUserRatingCommandResult> HandleAsync(ChangeUserRatingCommand command, CancellationToken cancellationToken)
    {
        PostAvaliations postToRate = await _repository.GetPostByIdAsync(command.PostId, cancellationToken);

        if (postToRate is null) throw new NotFoundException();

        postToRate.ChangeUserRating(command.AvaliationId, _currentUser.CurrentRequestUserId.Value, command.NewRate);

        await _repository.SaveChangesAsync(cancellationToken);

        Avaliation changedAvaliation = postToRate.FindAvaliationAndThrowIfNotFound(command.AvaliationId, _currentUser.CurrentRequestUserId.Value);

        return new ChangeUserRatingCommandResult(
            changedAvaliation.Id,
            changedAvaliation.PostId,
            changedAvaliation.AuthorId,
            changedAvaliation.Rate,
            changedAvaliation.ModificationDetails.DateOfCreation,
            changedAvaliation.ModificationDetails.DateOfModification.Value);
    }
}
