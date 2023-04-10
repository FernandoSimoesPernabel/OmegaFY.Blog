using MediatR;

namespace OmegaFY.Blog.Application.Queries.Base;

public abstract record class QueryRequestMediatRBase<TResult> : IQueryRequest, IRequest<TResult>
{
}