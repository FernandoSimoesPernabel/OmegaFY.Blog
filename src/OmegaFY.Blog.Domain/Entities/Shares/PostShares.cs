using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Shares;

public class PostShares : Entity, IAggregateRoot<PostShares>
{
    private readonly List<Shared> _shareds;

    public IReadOnlyCollection<Shared> Shareds => _shareds.AsReadOnly();

    protected PostShares() => _shareds = new List<Shared>();

    public bool AuthorHasAlredySharedPost(Author author) => _shareds.Any(share => share.AuthorId == author.Id);

    public void Share(Shared shared)
    {
        if (shared is null)
            throw new DomainArgumentException("");

        _shareds.Add(shared);
    }

    public void Unshare(Author author)
    {
        Shared shared = _shareds.FirstOrDefault(x => x.AuthorId == author.Id);

        if (shared is not null)
            _shareds.Remove(shared);
    }
}