namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public readonly struct Body
{
    public string Content { get; }

    public Body(string content)
    {
        Content = content;
    }
}