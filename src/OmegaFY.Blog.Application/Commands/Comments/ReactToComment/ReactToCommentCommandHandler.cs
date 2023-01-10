using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Repositories.Comments;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Comments.ReactToComment;

internal class ReactToCommentCommandHandler : CommandHandlerMediatRBase<ReactToCommentCommandHandler, ReactToCommentCommand, ReactToCommentCommandResult>
{
    private readonly ICommentRepository _repository;

    public ReactToCommentCommandHandler(IUserInformation currentUser, ILogger<ReactToCommentCommandHandler> logger, ICommentRepository repository)
        : base(currentUser, logger) => _repository = repository;

    public override async Task<ReactToCommentCommandResult> HandleAsync(ReactToCommentCommand command, CancellationToken cancellationToken)
    {
        PostComments postToReactToComment = await _repository.GetPostByIdAsync(command.PostId, cancellationToken);

        if (postToReactToComment is null)
            throw new NotFoundException();

        postToReactToComment.ReactToComment(command.CommentId, _currentUser.CurrentRequestUserId.Value, command.Reaction);

        await _repository.SaveChangesAsync(cancellationToken);

        Reaction reactionFromCurrentUser = postToReactToComment.FindReactionAndThrowIfNotFound(command.CommentId, _currentUser.CurrentRequestUserId.Value);

        return new ReactToCommentCommandResult(
            reactionFromCurrentUser.Id,
            reactionFromCurrentUser.CommentId,
            command.PostId,
            reactionFromCurrentUser.CommentReaction);
    }
}