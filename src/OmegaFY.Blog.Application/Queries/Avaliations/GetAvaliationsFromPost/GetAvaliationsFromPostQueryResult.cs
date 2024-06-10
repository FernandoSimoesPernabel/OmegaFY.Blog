using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliationsFromPost;

public sealed record class GetAvaliationsFromPostQueryResult : GenericResult, IQueryResult
{
    public AvaliationFromPost[] AvaliationsFromPost { get; set; }

    public GetAvaliationsFromPostQueryResult() => AvaliationsFromPost = Array.Empty<AvaliationFromPost>();

    public GetAvaliationsFromPostQueryResult(AvaliationFromPost[] avaliationsFromPost) => AvaliationsFromPost = avaliationsFromPost;
}