namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public class Author
{
    public Guid Id { get; }

    public Author(Guid id)
    {
        Id = id;
    }
}
