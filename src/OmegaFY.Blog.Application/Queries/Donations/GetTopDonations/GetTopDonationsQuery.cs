using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Donations.GetTopDonations;

public sealed record class GetTopDonationsQuery : QueryRequestMediatRBase<GetTopDonationsQueryResult>
{
}