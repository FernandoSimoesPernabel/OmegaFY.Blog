using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Shares;

public class PostShares : Entity, IAggregateRoot<PostShares>
{
    private readonly List<Shared> _shareds;

    public IReadOnlyCollection<Shared> Shareds => _shareds.AsReadOnly();

    protected PostShares() => _shareds = new List<Shared>();

    public bool HasAuthorAlreadySharedPost(ReferenceId authorId) => _shareds.Any(share => share.AuthorId == authorId);

    public void Share(Shared shared)
    {
        if (shared is null)
            throw new DomainArgumentException("");

        if (HasAuthorAlreadySharedPost(shared.AuthorId))
            throw new ConflictedException();

        _shareds.Add(shared);
    }

    public void Unshare(ReferenceId shareId, ReferenceId authorId)
    {
        Shared shared = _shareds.FirstOrDefault(share => share.Id == shareId && share.AuthorId == authorId);

        if (shared is null)
            throw new NotFoundException();

        _shareds.Remove(shared);
    }
}