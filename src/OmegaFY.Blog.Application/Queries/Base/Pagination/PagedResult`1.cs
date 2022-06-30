using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Base.Pagination;

public class PagedResult<TResult> : GenericResult, IQueryResult
{
    public TResult[] Results { get; }

    public PagedResultInfo ResultInfo { get; }

    protected PagedResult() { }

    public PagedResult(PagedResultInfo resultInfo, TResult[] results)
    {
        ResultInfo = resultInfo;
        Results = results;
    }
}