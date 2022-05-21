using OmegaFY.Blog.Domain.Queries;
using OmegaFY.Blog.Domain.Result.Base;

namespace OmegaFY.Blog.Domain.Pagination;

public class PagedResult<TResult> : GenericResult, IQueryResult, IPagedResult
{
    private readonly PagedResultInfo _resultInfo;

    public TResult[] Results { get; }

    protected PagedResult() { }

    public PagedResult(PagedResultInfo resultInfo, TResult[] results)
    {
        _resultInfo = resultInfo;
        Results = results;
    }

    public PagedResultInfo PaginationInformation() => _resultInfo;
}