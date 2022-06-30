using MediatR;
using OmegaFY.Blog.Application.Queries.Base.Pagination;

namespace OmegaFY.Blog.Application.Queries.Base;

public abstract class QueryPagedRequestMediatRBase<TResult> : PagedRequest, IQueryRequest, IRequest<TResult>
{
}