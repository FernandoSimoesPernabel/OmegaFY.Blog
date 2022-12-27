using OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliation;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

namespace OmegaFY.Blog.WebAPI.Models.Queries;

public class GetAvaliationInputModel
{
    public Guid PostId { get; set; }

    public Guid AvaliationId { get; set; }

    public GetAvaliationQuery ToQuery() => new GetAvaliationQuery(PostId, AvaliationId);
}