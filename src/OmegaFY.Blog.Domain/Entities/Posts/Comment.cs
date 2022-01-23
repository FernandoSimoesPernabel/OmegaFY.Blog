namespace OmegaFY.Blog.Domain.Entities.Posts;

public class Comment : Entity
{
    private readonly List<Reaction> _reactions;

    public IReadOnlyCollection<Reaction> Reactions => _reactions.AsReadOnly();

    public Comment()
    {
        _reactions = new List<Reaction>();
    }
}