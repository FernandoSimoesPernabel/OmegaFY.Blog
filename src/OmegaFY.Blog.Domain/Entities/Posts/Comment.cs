using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class Comment : Entity
{
    private readonly List<Reaction> _reactions;

    public Guid PostId { get; }

    public Author Author { get; }

    public Body Body { get; private set; }

    public ModificationDetails ModificationDetails { get; private set; }

    public IReadOnlyCollection<Reaction> Reactions => _reactions.AsReadOnly();

    public Comment(Guid postId, Author author, Body body)
    {
        _reactions = new List<Reaction>();

        PostId = postId;
        Author = author;
        Body = body;
        ModificationDetails = new ModificationDetails();
    }
}