using MediatR;
using OmegaFY.Blog.Domain.Pagination;
using OmegaFY.Blog.Domain.Queries;

namespace OmegaFY.Blog.Application.Queries.Base;

public abstract class QueryPagedRequestMediatRBase<TResult> : PagedRequest, IQueryRequest, IRequest<TResult>
{
}