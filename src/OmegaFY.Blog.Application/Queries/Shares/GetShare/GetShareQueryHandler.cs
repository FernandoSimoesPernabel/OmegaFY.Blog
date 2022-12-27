using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

internal class GetShareQueryHandler : QueryHandlerMediatRBase<GetShareQueryHandler, GetShareQuery, GetShareQueryResult>
{
    private readonly IShareQueryProvider _shareQueryProvider;

    public GetShareQueryHandler(IUserInformation currentUser, ILogger<GetShareQueryHandler> logger, IShareQueryProvider shareQueryProvider)
        : base(currentUser, logger) => _shareQueryProvider = shareQueryProvider;

    public override async Task<GetShareQueryResult> HandleAsync(GetShareQuery request, CancellationToken cancellationToken)
    {
        GetShareQueryResult result = await _shareQueryProvider.GetShareQueryResultAsync(request.ShareId, _currentUser.CurrentRequestUserId.Value, cancellationToken);
        return result ?? throw new NotFoundException();
    }
}