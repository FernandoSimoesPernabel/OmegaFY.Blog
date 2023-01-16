using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Repositories.Avaliations;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Avaliations.RemoveRating;

internal class RemoveRatingCommandHandler : CommandHandlerMediatRBase<RemoveRatingCommandHandler, RemoveRatingCommand, RemoveRatingCommandResult>
{
    private readonly IAvaliationRepository _repository;

    public RemoveRatingCommandHandler(IUserInformation currentUser, ILogger<RemoveRatingCommandHandler> logger, IAvaliationRepository repository)
        : base(currentUser, logger) => _repository = repository;

    public async override Task<RemoveRatingCommandResult> HandleAsync(RemoveRatingCommand command, CancellationToken cancellationToken)
    {
        PostAvaliations postToUnrate = await _repository.GetPostByIdAsync(command.PostId, cancellationToken);

        if (postToUnrate is null) throw new NotFoundException();

        postToUnrate.RemoveRating(_currentUser.CurrentRequestUserId.Value);

        await _repository.SaveChangesAsync(cancellationToken);

        return new RemoveRatingCommandResult();
    }
}