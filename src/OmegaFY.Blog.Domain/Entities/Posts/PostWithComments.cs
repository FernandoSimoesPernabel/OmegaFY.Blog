using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class PostWithComments : Post
{
    private readonly List<Comment> _comments;

    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    public PostWithComments(Author author, Header header, Body body) : base(author, header, body)
    {
        _comments = new List<Comment>();
    }
}