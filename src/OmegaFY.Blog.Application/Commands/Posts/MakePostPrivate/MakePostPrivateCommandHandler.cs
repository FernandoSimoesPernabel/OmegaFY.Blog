using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Repositories.Posts;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Commands.Posts.MakePostPrivate;

internal class MakePostPrivateCommandHandler : CommandHandlerMediatRBase<MakePostPrivateCommandHandler, MakePostPrivateCommand, MakePostPrivateCommandResult>
{
    private readonly IPostRepository _repository;

    public MakePostPrivateCommandHandler(IUserInformation currentUser, ILogger<MakePostPrivateCommandHandler> logger, IPostRepository repository) : base(currentUser, logger)
    {
        _repository = repository;
    }

    public override async Task<MakePostPrivateCommandResult> HandleAsync(MakePostPrivateCommand command, CancellationToken cancellationToken)
    {
        Post existingPost = await _repository.GetByIdAsync(command.Id, _currentUser.CurrentRequestUserId.Value, cancellationToken);

        if (existingPost is null) throw new NotFoundException();

        existingPost.MakePrivate();

        await _repository.SaveChangesAsync(cancellationToken);

        return new();
    }
}