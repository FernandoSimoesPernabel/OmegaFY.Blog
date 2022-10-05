using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

namespace OmegaFY.Blog.Application.Queries.QueryProviders.Shares;

public interface IShareQueryProvider : IQueryProvider
{
    public Task<GetShareQueryResult> GetShareQueryResultAsync(Guid shareId, Guid authorId, CancellationToken cancellationToken);
}