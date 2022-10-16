using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;

public class GetAllPostsQueryResult : GenericResult, IQueryResult
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string AuthorName { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }

    public decimal AverageRate { get; set; }
}