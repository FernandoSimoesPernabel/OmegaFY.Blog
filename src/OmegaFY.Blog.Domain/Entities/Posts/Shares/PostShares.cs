using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Posts.Shares;

public class PostShares : Post
{
    private readonly List<Shared> _shareds;

    public IReadOnlyCollection<Shared> Shareds => _shareds.AsReadOnly();

    protected PostShares() { }

    public PostShares(Author author, Header header, Body body) : base(author, header, body)
    {
        _shareds = new List<Shared>();
    }

    public void Share(Shared shared)
    {
        if (shared is null)
            throw new DomainArgumentException("");

        _shareds.Add(shared);
    }

    public void Unshare(Guid sharedId)
    {
        Shared shared = _shareds.FirstOrDefault(x => x.Id == sharedId);

        if (shared is not null)
            _shareds.Remove(shared);
    }
}