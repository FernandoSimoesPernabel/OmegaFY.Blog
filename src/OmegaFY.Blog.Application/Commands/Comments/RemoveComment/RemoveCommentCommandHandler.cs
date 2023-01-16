using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Repositories.Comments;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Comments.RemoveComment;

internal class RemoveCommentCommandHandler : CommandHandlerMediatRBase<RemoveCommentCommandHandler, RemoveCommentCommand, RemoveCommentCommandResult>
{
    private readonly ICommentRepository _repository;

    public RemoveCommentCommandHandler(IUserInformation currentUser, ILogger<RemoveCommentCommandHandler> logger, ICommentRepository repository)
        : base(currentUser, logger) => _repository = repository;

    public override async Task<RemoveCommentCommandResult> HandleAsync(RemoveCommentCommand command, CancellationToken cancellationToken)
    {
        PostComments postToRemoveComment = await _repository.GetPostByIdAsync(command.PostId, cancellationToken);

        if (postToRemoveComment is null)
            throw new NotFoundException();

        postToRemoveComment.RemoveComment(command.CommentId, _currentUser.CurrentRequestUserId.Value);

        await _repository.SaveChangesAsync(cancellationToken);

        return new RemoveCommentCommandResult();
    }
}