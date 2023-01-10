using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Repositories.Comments;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Comments.EditComment;

internal class EditCommentCommandHandler : CommandHandlerMediatRBase<EditCommentCommandHandler, EditCommentCommand, EditCommentCommandResult>
{
    private readonly ICommentRepository _repository;

    public EditCommentCommandHandler(IUserInformation currentUser, ILogger<EditCommentCommandHandler> logger, ICommentRepository repository)
        : base(currentUser, logger) => _repository = repository;

    public override async Task<EditCommentCommandResult> HandleAsync(EditCommentCommand command, CancellationToken cancellationToken)
    {
        PostComments postToComment = await _repository.GetPostByIdAsync(command.PostId, cancellationToken);

        if (postToComment is null)
            throw new NotFoundException();

        postToComment.EditComment(command.CommentId, _currentUser.CurrentRequestUserId.Value, command.NewContent);

        await _repository.SaveChangesAsync(cancellationToken);

        Comment commentFromCurrentUser = postToComment.FindCommentAndThrowIfNotFound(command.CommentId, _currentUser.CurrentRequestUserId.Value);

        return new EditCommentCommandResult(
            commentFromCurrentUser.Id,
            commentFromCurrentUser.PostId,
            commentFromCurrentUser.AuthorId,
            commentFromCurrentUser.Body,
            commentFromCurrentUser.ModificationDetails.DateOfCreation,
            commentFromCurrentUser.ModificationDetails.DateOfModification.Value);
    }
}