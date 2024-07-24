using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetMostRecentAvaliations;

internal sealed class GetMostRecentAvaliationsQueryHandler : QueryHandlerMediatRBase<GetMostRecentAvaliationsQueryHandler, GetMostRecentAvaliationsQuery, PagedResult<GetMostRecentAvaliationsQueryResult>>
{
    private readonly IAvaliationQueryProvider _avaliationQueryProvider;

    public GetMostRecentAvaliationsQueryHandler(IUserInformation currentUser, ILogger<GetMostRecentAvaliationsQueryHandler> logger, IAvaliationQueryProvider avaliationQueryProvider)
        : base(currentUser, logger) => _avaliationQueryProvider = avaliationQueryProvider;

    public override Task<PagedResult<GetMostRecentAvaliationsQueryResult>> HandleAsync(GetMostRecentAvaliationsQuery request, CancellationToken cancellationToken)
        => _avaliationQueryProvider.GetMostRecentAvaliationsQueryResultAsync(request, cancellationToken);
}