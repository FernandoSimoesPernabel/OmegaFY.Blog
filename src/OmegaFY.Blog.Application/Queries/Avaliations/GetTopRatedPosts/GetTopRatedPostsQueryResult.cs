using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;

public sealed record class GetTopRatedPostsQueryResult : GenericResult, IQueryResult
{
    public Guid PostId { get; set; }

    public string PostTitle { get; set; }

    public Guid AuthorId { get; set; }

    public string PostAuthorName { get; set; }

    public DateTime DateOfCreation { get; set; }

    public double AverageRate { get; set; }
}