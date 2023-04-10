using MediatR;

namespace OmegaFY.Blog.Application.Commands.Base;

public abstract record class CommandMediatRBase<TResult> : ICommand, IRequest<TResult>
{
}