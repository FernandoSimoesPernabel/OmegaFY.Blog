namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public record class Author
{
    public Guid Id { get; }

    public Author(Guid id)
    {
        Id = id;
    }

    public static implicit operator Guid(Author author) => author.Id;
}
