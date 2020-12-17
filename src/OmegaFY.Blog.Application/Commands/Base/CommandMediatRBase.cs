using MediatR;

namespace OmegaFY.Blog.Application.Commands.Base
{

    public abstract class CommandMediatRBase<TResult> : CommandBase, IRequest<TResult>
    {

    }

}
