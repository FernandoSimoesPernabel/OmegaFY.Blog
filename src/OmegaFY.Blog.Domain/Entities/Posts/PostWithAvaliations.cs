using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class PostWithAvaliations : Post
{
    private readonly List<Avaliation> _avaliations;

    public IReadOnlyCollection<Avaliation> Avaliations => _avaliations.AsReadOnly();

    public Stars AverageRate { get; private set; }

    public PostWithAvaliations(Author author, Header header, Body body) : base(author, header, body)
    {
        _avaliations = new List<Avaliation>();
    }

    public void RatePost(Avaliation avaliation)
    {
        _avaliations.Add(avaliation);
        AverageRate = (Stars)_avaliations.Average(x => (int)x.Rate);
    }
}