namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public record class Body
{
    public string Content { get; }

    public Body(string content)
    {
        Content = content;
    }

    public static implicit operator string(Body body) => body?.Content;

    public static implicit operator Body(string body) => new Body(body);
}