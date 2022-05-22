using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;

public class GetAllPostsQueryResult : GenericResult, IQueryResult
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public Guid AuthorId { get; set; }

    public DateTime DateOfCreation { get; set; }

    public GetAllPostsQueryResult() { }

    public GetAllPostsQueryResult(Guid id, string title, Guid authorId, DateTime dateOfCreation)
    {
        Id = id;
        Title = title;
        AuthorId = authorId;
        DateOfCreation = dateOfCreation;
    }
}