using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Shares.GetSharesFromPost;

internal class GetSharesFromPostQueryHandler : QueryHandlerMediatRBase<GetSharesFromPostQueryHandler, GetSharesFromPostQuery, GetSharesFromPostQueryResult>
{
    private readonly IShareQueryProvider _shareQueryProvider;

    public GetSharesFromPostQueryHandler(IUserInformation currentUser, ILogger<GetSharesFromPostQueryHandler> logger, IShareQueryProvider shareQueryProvider)
        : base(currentUser, logger) => _shareQueryProvider = shareQueryProvider;

    public override Task<GetSharesFromPostQueryResult> HandleAsync(GetSharesFromPostQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
