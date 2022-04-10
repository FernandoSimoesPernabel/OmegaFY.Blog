using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.Entities.Shares;

public class PostShares : Entity, IAggregateRoot<PostShares>
{
    private readonly List<Shared> _shareds;

    public IReadOnlyCollection<Shared> Shareds => _shareds.AsReadOnly();

    protected PostShares() => _shareds = new List<Shared>();

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