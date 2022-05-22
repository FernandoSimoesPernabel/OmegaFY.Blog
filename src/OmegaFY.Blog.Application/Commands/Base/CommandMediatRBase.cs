using MediatR;

namespace OmegaFY.Blog.Application.Commands.Base;

public abstract class CommandMediatRBase<TResult> : ICommand, IRequest<TResult>
{
}