namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public class Body
{
    public string Content { get; }

    public Body(string content)
    {
        Content = content;
    }
}