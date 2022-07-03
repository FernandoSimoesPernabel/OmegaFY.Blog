using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Pagination;

public class PagedResult<TResult> : GenericResult, IQueryResult
{
    public TResult[] Results { get; }

    public PagedResultInfo ResultInfo { get; }

    public PagedResult() { }

    public PagedResult(PagedResultInfo resultInfo, TResult[] results)
    {
        ResultInfo = resultInfo;
        Results = results;
    }
}