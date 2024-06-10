using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliationsFromPost;

public sealed record class GetAvaliationsFromPostQuery : QueryRequestMediatRBase<GetAvaliationsFromPostQueryResult>
{
    public Guid PostId { get; set; }
}