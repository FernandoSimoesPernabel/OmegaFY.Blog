using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;
using Microsoft.Extensions.Logging;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetMostRecentAvaliations;

internal class GetMostRecentAvaliationsQueryHandler : QueryHandlerMediatRBase<GetMostRecentAvaliationsQueryHandler, GetMostRecentAvaliationsQuery, PagedResult<GetMostRecentAvaliationsQueryResult>>
{
    public GetMostRecentAvaliationsQueryHandler(IUserInformation currentUser, ILogger<GetMostRecentAvaliationsQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<PagedResult<GetMostRecentAvaliationsQueryResult>> HandleAsync(GetMostRecentAvaliationsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}