using MediatR;

namespace OmegaFY.Blog.Application.Queries.Base
{

    public abstract class QueryRequestMediatRBase<TResult> : QueryRequestBase, IRequest<TResult>
    {

    }

}
