using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Donations.GetTopDonations;

internal class GetTopDonationsQueryHandler : QueryHandlerMediatRBase<GetTopDonationsQueryHandler, GetTopDonationsQuery, GetTopDonationsQueryResult>
{
    public GetTopDonationsQueryHandler(IUserInformation currentUser, ILogger<GetTopDonationsQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override async Task<GetTopDonationsQueryResult> HandleAsync(GetTopDonationsQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
