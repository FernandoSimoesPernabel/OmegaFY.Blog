namespace OmegaFY.Blog.Domain.Entities.Posts;

public class PostWithAvaliations : Post
{
    private readonly List<Avaliation> _avaliations;

    public IReadOnlyCollection<Avaliation> Avaliations => _avaliations.AsReadOnly();

    public PostWithAvaliations()
    {
        _avaliations = new List<Avaliation>();
    }
}