using MediatR;
using OmegaFY.Blog.Domain.Queries;

namespace OmegaFY.Blog.Application.Queries.Base;

public abstract class QueryRequestMediatRBase<TResult> : IQueryRequest, IRequest<TResult>
{
}
