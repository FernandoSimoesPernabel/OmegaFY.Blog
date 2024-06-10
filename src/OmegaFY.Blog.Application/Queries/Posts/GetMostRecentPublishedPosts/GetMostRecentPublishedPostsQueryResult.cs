using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;

public sealed record class GetMostRecentPublishedPostsQueryResult : GenericResult, IQueryResult
{
    public Guid PostId { get; set; }

    public string Title { get; set; }

    public string AuthorName { get; set; }

    public DateTime DateOfCreation { get; set; }
}