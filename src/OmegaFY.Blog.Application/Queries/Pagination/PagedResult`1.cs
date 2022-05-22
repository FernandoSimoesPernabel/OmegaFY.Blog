using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Pagination;

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