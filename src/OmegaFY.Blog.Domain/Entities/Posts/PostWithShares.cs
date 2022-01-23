namespace OmegaFY.Blog.Domain.Entities.Posts;

public class PostWithShares : Post
{
    private readonly List<Shared> _shareds;

    public IReadOnlyCollection<Shared> Shareds => _shareds.AsReadOnly();

    public PostWithShares()
    {
        _shareds = new List<Shared>();
    }
}