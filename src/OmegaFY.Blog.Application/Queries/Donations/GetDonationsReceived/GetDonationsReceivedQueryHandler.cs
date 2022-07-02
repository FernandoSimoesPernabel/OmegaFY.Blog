using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Donations.GetDonationsReceived;

internal class GetDonationsReceivedQueryHandler : QueryHandlerMediatRBase<GetDonationsReceivedQueryHandler, GetDonationsReceivedQuery, GetDonationsReceivedQueryResult>
{
    public GetDonationsReceivedQueryHandler(IUserInformation currentUser, ILogger<GetDonationsReceivedQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override async Task<GetDonationsReceivedQueryResult> HandleAsync(GetDonationsReceivedQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
