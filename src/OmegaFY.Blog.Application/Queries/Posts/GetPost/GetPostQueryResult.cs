using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Posts.GetPost;

public class GetPostQueryResult : GenericResult, IQueryResult
{
    public Guid Id { get; set; }

    public Guid AuthorId { get; set; }

    public string AuthorName { get; set; }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Content { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }

    public decimal AverageRate { get; set; }

    public int Avaliations { get; set; }

    public int Comments { get; set; }

    public int Shares { get; set; }
}