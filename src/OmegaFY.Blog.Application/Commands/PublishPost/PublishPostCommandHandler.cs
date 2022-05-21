﻿using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Authentication;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Repositories.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Application.Commands.PublishPost;

internal class PublishPostCommandHandler : CommandHandlerMediatRBase<PublishPostCommandHandler, PublishPostCommand, PublishPostCommandResult>
{
    private readonly IPostRepository _repository;

    public PublishPostCommandHandler(IUserInformation currentUser, ILogger<PublishPostCommandHandler> logger, IPostRepository repository) : base(currentUser, logger)
    {
        _repository = repository;
    }

    public async override Task<PublishPostCommandResult> HandleAsync(PublishPostCommand command, CancellationToken cancellationToken)
    {
        Post newPost = new Post(_currentUser.CurrentRequestUserId, new Header(command.Title, command.SubTitle), command.Body);

        await _repository.CreatePostAsync(newPost, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return new PublishPostCommandResult(
            newPost.Id, 
            newPost.Author,
            newPost.Header.Title, 
            newPost.Header.SubTitle, 
            newPost.Body,
            newPost.ModificationDetails.DateOfCreation);
    }
}
