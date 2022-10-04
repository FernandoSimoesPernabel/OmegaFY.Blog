using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

internal class GetShareQueryHandler : QueryHandlerMediatRBase<GetShareQueryHandler, GetShareQuery, GetShareQueryResult>
{
    public GetShareQueryHandler(IUserInformation currentUser, ILogger<GetShareQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override async Task<GetShareQueryResult> HandleAsync(GetShareQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}