namespace OmegaFY.Blog.Domain.Commands;

public interface ICommandHandler<TCommand, TCommandResult> where TCommand : ICommand where TCommandResult : ICommandResult
{
    public Task<TCommandResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
}
