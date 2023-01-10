using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Repositories.Comments;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Comments.RemoveReaction;

internal class RemoveReactionCommandHandler : CommandHandlerMediatRBase<RemoveReactionCommandHandler, RemoveReactionCommand, RemoveReactionCommandResult>
{
    private readonly ICommentRepository _repository;

    public RemoveReactionCommandHandler(IUserInformation currentUser, ILogger<RemoveReactionCommandHandler> logger, ICommentRepository repository)
        : base(currentUser, logger) => _repository = repository;

    public override async Task<RemoveReactionCommandResult> HandleAsync(RemoveReactionCommand command, CancellationToken cancellationToken)
    {
        PostComments postToRemoveReaction = await _repository.GetPostByIdAsync(command.PostId, cancellationToken);

        if (postToRemoveReaction is null)
            throw new NotFoundException();

        postToRemoveReaction.RemoveReactionFromComment(command.CommentId, _currentUser.CurrentRequestUserId.Value);

        await _repository.SaveChangesAsync(cancellationToken);

        return new RemoveReactionCommandResult();
    }
}