using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Repositories.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Posts.ChangePostContent;

internal class ChangePostContentCommandHandler : CommandHandlerMediatRBase<ChangePostContentCommandHandler, ChangePostContentCommand, ChangePostContentCommandResult>
{
    private readonly IPostRepository _repository;

    public ChangePostContentCommandHandler(IUserInformation currentUser, ILogger<ChangePostContentCommandHandler> logger, IPostRepository repository) : base(currentUser, logger)
    {
        _repository = repository;
    }

    public override async Task<ChangePostContentCommandResult> HandleAsync(ChangePostContentCommand command, CancellationToken cancellationToken)
    {
        Post existingPost = await _repository.GetByIdAsync(command.PostId, _currentUser.CurrentRequestUserId.Value, cancellationToken);

        if (existingPost is null) throw new NotFoundException();

        existingPost.ChangeContent(new Header(command.Title, command.SubTitle), command.Body);

        await _repository.UpdatePostAsync(existingPost, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return new ChangePostContentCommandResult(
            existingPost.Id,
            existingPost.AuthorId,
            existingPost.Header.Title,
            existingPost.Header.SubTitle,
            existingPost.Body,
            existingPost.ModificationDetails.DateOfCreation,
            existingPost.ModificationDetails.DateOfModification.Value);
    }
}