using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;

public class GetMostRecentPublishedPostsQueryResult : GenericResult, IQueryResult
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string AuthorName { get; set; }

    public DateTime DateOfCreation { get; set; }
}