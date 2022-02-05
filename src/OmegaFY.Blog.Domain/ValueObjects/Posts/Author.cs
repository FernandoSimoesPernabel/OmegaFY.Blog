namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public readonly struct Author
{
    public Guid Id { get; }

    public Author(Guid id)
    {
        Id = id;
    }
}
