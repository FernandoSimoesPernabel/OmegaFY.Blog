using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public readonly record struct Body
{
    public string Content { get; }

    public Body(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new DomainArgumentException("");

        Content = content;
    }

    public static implicit operator string(Body body) => body.Content;

    public static implicit operator Body(string body) => new Body(body);
}