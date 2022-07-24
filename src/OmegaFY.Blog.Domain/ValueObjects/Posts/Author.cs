using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public record class Author
{
    public Guid Id { get; }

    public Author(Guid id)
    {
        if (id == Guid.Empty)
            throw new DomainArgumentException("");

        Id = id;
    }

    public static implicit operator Guid(Author author) => author.Id;

    public static implicit operator Author(Guid authorId) => new Author(authorId);
}