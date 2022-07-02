using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Donations.GetDonationsMade;

internal class GetDonationsMadeQueryHandler : QueryHandlerMediatRBase<GetDonationsMadeQueryHandler, GetDonationsMadeQuery, GetDonationsMadeQueryResult>
{
    public GetDonationsMadeQueryHandler(IUserInformation currentUser, ILogger<GetDonationsMadeQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override async Task<GetDonationsMadeQueryResult> HandleAsync(GetDonationsMadeQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
