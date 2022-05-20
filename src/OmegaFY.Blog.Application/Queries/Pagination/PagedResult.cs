using OmegaFY.Blog.Domain.Queries;
using OmegaFY.Blog.Domain.Result.Base;

namespace OmegaFY.Blog.Application.Queries.Pagination;

public abstract class PagedResult : GenericResult, IQueryResult
{
    private readonly PagedResultInfo _resultInfo;

    protected PagedResult() { }

    public PagedResult(PagedResultInfo resultInfo) => _resultInfo = resultInfo;

    public PagedResultInfo PaginationInformation() => _resultInfo;
}