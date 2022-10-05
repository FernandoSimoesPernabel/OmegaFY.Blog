using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

internal class GetMostRecentSharesQueryHandler : QueryHandlerMediatRBase<GetMostRecentSharesQueryHandler, GetMostRecentSharesQuery, PagedResult<GetMostRecentSharesQueryResult>>
{
    private readonly IShareQueryProvider _shareQueryProvider;

    public GetMostRecentSharesQueryHandler(IUserInformation currentUser, ILogger<GetMostRecentSharesQueryHandler> logger, IShareQueryProvider shareQueryProvider)
        : base(currentUser, logger) => _shareQueryProvider = shareQueryProvider;

    public override async Task<PagedResult<GetMostRecentSharesQueryResult>> HandleAsync(GetMostRecentSharesQuery request, CancellationToken cancellationToken)
        => await _shareQueryProvider.GetMostRecentSharesQueryResultAsync(request, cancellationToken);
}