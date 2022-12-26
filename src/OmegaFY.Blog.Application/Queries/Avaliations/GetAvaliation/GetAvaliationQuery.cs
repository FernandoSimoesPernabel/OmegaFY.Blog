using OmegaFY.Blog.Application.Queries.Base;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliation;

public class GetAvaliationQuery : QueryRequestMediatRBase<GetAvaliationQueryResult>
{
    public Guid PostId { get; set; }

    public Guid AvaliationId { get; set; }

    public GetAvaliationQuery() { }

    public GetAvaliationQuery(Guid postId, Guid avaliationId)
    {
        PostId = postId;
        AvaliationId = avaliationId;
    }
}