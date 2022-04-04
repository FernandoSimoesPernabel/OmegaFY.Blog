using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class Post : Entity, IAggregateRoot<Post>
{
    public Author Author { get; }

    public Header Header { get; private set; }

    public Body Body { get; private set; }

    public ModificationDetails ModificationDetails { get; private set; }

    public bool Hidden { get; private set; }

    public Post(Author author, Header header, Body body)
    {
        Author = author;
        Header = header;
        Body = body;
        ModificationDetails = new ModificationDetails();
        Hidden = false;
    }
}