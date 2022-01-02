using MediatR;
using OmegaFY.Blog.Domain.Commands;

namespace OmegaFY.Blog.Application.Commands.Base;

public abstract class CommandMediatRBase<TResult> : ICommand, IRequest<TResult>
{
}
