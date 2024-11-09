using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.ValueObjects.Posts;

public readonly record struct Body
{
    public string Content { get; }

    public Body(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new DomainArgumentException("Não foi informado nenhum conteudo para o corpo.");

        Content = content;
    }

    public override int GetHashCode() => Content.GetHashCode();

    public override string ToString() => Content.ToString();

    public static implicit operator string(Body body) => body.Content;

    public static implicit operator Body(string body) => new Body(body);
}