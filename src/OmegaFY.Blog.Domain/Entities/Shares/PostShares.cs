using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Shares;

public class PostShares : Entity, IAggregateRoot<PostShares>
{
    private readonly List<Shared> _shareds;

    public IReadOnlyCollection<Shared> Shareds => _shareds.AsReadOnly();

    protected PostShares() => _shareds = new List<Shared>();

    public bool HasAuthorAlreadySharedPost(Author author) => _shareds.Any(share => share.AuthorId == author.Id);

    public void Share(Shared shared)
    {
        if (shared is null)
            throw new DomainArgumentException("");

        if (HasAuthorAlreadySharedPost(shared.AuthorId))
            throw new ConflictedException();

        _shareds.Add(shared);
    }

    public void Unshare(Guid shareId, Author author)
    {
        Shared shared = _shareds.FirstOrDefault(share => share.Id == shareId && share.AuthorId == author.Id);

        if (shared is null)
            throw new NotFoundException();

        _shareds.Remove(shared);
    }
}