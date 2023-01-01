﻿using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.Domain.Repositories.Avaliations;
using OmegaFY.Blog.Domain.Repositories.Shares;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Shares.SharePost;

internal class SharePostCommandHandler : CommandHandlerMediatRBase<SharePostCommandHandler, SharePostCommand, SharePostCommandResult>
{
    private readonly IShareRepository _repository;

    public SharePostCommandHandler(
        IUserInformation currentUser,
        ILogger<SharePostCommandHandler> logger,
        IShareRepository repository) : base(currentUser, logger) => _repository = repository;

    public override async Task<SharePostCommandResult> HandleAsync(SharePostCommand command, CancellationToken cancellationToken)
    {
        PostShares postToShare = await _repository.GetPostByIdAsync(command.Id, cancellationToken);

        if (postToShare is null)
            throw new NotFoundException();

        Shared postShareFromCurrentUser = new Shared(postToShare.Id, _currentUser.CurrentRequestUserId.Value);

        postToShare.Share(postShareFromCurrentUser);

        await _repository.SaveChangesAsync(cancellationToken);

        return new SharePostCommandResult(
            postShareFromCurrentUser.Id,
            postShareFromCurrentUser.PostId,
            postShareFromCurrentUser.AuthorId,
            postShareFromCurrentUser.DateAndTimeOfShare);
    }
}