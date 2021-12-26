namespace OmegaFY.Blog.Domain.Queries;

public interface IQueryHandler<TQueryRequest, TQueryResult> where TQueryRequest : IQueryRequest where TQueryResult : IQueryResult
{
    public Task<TQueryResult> HandleAsync(TQueryRequest request, CancellationToken cancellationToken);
}