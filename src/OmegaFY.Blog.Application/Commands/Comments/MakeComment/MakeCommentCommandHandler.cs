using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Repositories.Comments;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Comments.MakeComment;

internal class MakeCommentCommandHandler : CommandHandlerMediatRBase<MakeCommentCommandHandler, MakeCommentCommand, MakeCommentCommandResult>
{
    private readonly ICommentRepository _repository;

    public MakeCommentCommandHandler(IUserInformation currentUser, ILogger<MakeCommentCommandHandler> logger, ICommentRepository repository)
        : base(currentUser, logger) => _repository = repository;

    public override async Task<MakeCommentCommandResult> HandleAsync(MakeCommentCommand command, CancellationToken cancellationToken)
    {
        PostComments postToComment = await _repository.GetPostByIdAsync(command.PostId, cancellationToken);

        if (postToComment is null)
            throw new NotFoundException();

        Comment commentFromCurrentUser = new Comment(command.PostId, _currentUser.CurrentRequestUserId.Value, command.Content);

        postToComment.Comment(commentFromCurrentUser);

        await _repository.UpdatePostCommentsAsync(postToComment, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return new MakeCommentCommandResult(
            commentFromCurrentUser.Id,
            commentFromCurrentUser.PostId,
            commentFromCurrentUser.AuthorId,
            commentFromCurrentUser.Body,
            commentFromCurrentUser.ModificationDetails.DateOfCreation);
    }
}