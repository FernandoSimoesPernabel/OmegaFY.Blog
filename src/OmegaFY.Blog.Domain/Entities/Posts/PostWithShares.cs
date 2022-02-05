using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class PostWithShares : Post
{
    private readonly List<Shared> _shareds;

    public IReadOnlyCollection<Shared> Shareds => _shareds.AsReadOnly();

    public PostWithShares(Author author, Header header, Body body) : base(author, header, body)
    {
        _shareds = new List<Shared>();
    }
}