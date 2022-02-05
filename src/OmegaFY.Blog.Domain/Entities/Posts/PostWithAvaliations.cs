using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class PostWithAvaliations : Post
{
    private readonly List<Avaliation> _avaliations;

    public IReadOnlyCollection<Avaliation> Avaliations => _avaliations.AsReadOnly();

    public PostWithAvaliations(Author author, Header header, Body body) : base(author, header, body)
    {
        _avaliations = new List<Avaliation>();
    }
}