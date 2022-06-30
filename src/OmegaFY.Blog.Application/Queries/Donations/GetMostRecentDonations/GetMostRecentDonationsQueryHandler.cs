using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Donations.GetMostRecentDonations;

internal class GetMostRecentDonationsQueryHandler : QueryHandlerMediatRBase<GetMostRecentDonationsQueryHandler, GetMostRecentDonationsQuery, GetMostRecentDonationsQueryResult>
{
    public GetMostRecentDonationsQueryHandler(IUserInformation currentUser, ILogger<GetMostRecentDonationsQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override async Task<GetMostRecentDonationsQueryResult> HandleAsync(GetMostRecentDonationsQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
