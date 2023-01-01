using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;

internal class CurrentUserHasSharedPostQueryHandler : QueryHandlerMediatRBase<CurrentUserHasSharedPostQueryHandler, CurrentUserHasSharedPostQuery, CurrentUserHasSharedPostQueryResult>
{
    private readonly IShareQueryProvider _shareQueryProvider;

    public CurrentUserHasSharedPostQueryHandler(IUserInformation currentUser, ILogger<CurrentUserHasSharedPostQueryHandler> logger, IShareQueryProvider shareQueryProvider)
        : base(currentUser, logger) => _shareQueryProvider = shareQueryProvider;

    public override async Task<CurrentUserHasSharedPostQueryResult> HandleAsync(CurrentUserHasSharedPostQuery request, CancellationToken cancellationToken)
        => await _shareQueryProvider.CurrentUserHasSharedPostQueryResultAsync(request.Id, _currentUser.CurrentRequestUserId.Value, cancellationToken);
}
