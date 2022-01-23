namespace OmegaFY.Blog.Domain.Entities.Posts;

public class PostWithComments : Post
{
    private readonly List<Comment> _comments;

    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    public PostWithComments()
    {
        _comments = new List<Comment>();
    }
}