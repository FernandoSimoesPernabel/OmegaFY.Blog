using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

internal class GetMostRecentSharesQueryHandler : QueryHandlerMediatRBase<GetMostRecentSharesQueryHandler, GetMostRecentSharesQuery, GetMostRecentSharesQueryResult>
{
    public GetMostRecentSharesQueryHandler(IUserInformation currentUser, ILogger<GetMostRecentSharesQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override async Task<GetMostRecentSharesQueryResult> HandleAsync(GetMostRecentSharesQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
