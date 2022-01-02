using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Authentication;
using OmegaFY.Blog.Domain.Commands;

namespace OmegaFY.Blog.Application.Commands.Base;

internal abstract class CommandHandlerMediatRBase<TCommandHandler, TCommand, TCommandResult> : ICommandHandler<TCommand, TCommandResult> 
    where TCommand : ICommand 
    where TCommandResult : ICommandResult
{
    protected readonly IUserInformation _currentUser;

    protected readonly ILogger<TCommandHandler> _logger;

    public CommandHandlerMediatRBase(IUserInformation user, ILogger<TCommandHandler> logger)
    {
        _currentUser = user;
        _logger = logger;
    }

    public abstract Task<TCommandResult> HandleAsync(TCommand request, CancellationToken cancellationToken);
}
