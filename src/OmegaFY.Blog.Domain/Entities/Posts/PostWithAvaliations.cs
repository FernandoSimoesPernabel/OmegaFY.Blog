using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class PostWithAvaliations : Post
{
    private readonly List<Avaliation> _avaliations;

    public IReadOnlyCollection<Avaliation> Avaliations => _avaliations.AsReadOnly();

    public int AverageRate { get; private set; }

    protected PostWithAvaliations() { }

    public PostWithAvaliations(Author author, Header header, Body body) : base(author, header, body)
    {
        _avaliations = new List<Avaliation>();
    }

    public Avaliation FindAvaliationAndThrowIfNotFound(Guid avaliationId)
    {
        Avaliation avaliation = _avaliations.FirstOrDefault(x => x.Id == avaliationId);

        if (avaliation is null)
            throw new NotFoundException("");

        return avaliation;
    }

    public void RatePost(Avaliation avaliation)
    {
        if (avaliation is null)
            throw new DomainArgumentException("");

        _avaliations.Add(avaliation);

        AverageRate = (int)_avaliations.Average(x => (int)x.Rate);
    }

    public void ChangeUserRating(Guid avaliationId, Stars newRate)
    {
        Avaliation currentAvaliation = FindAvaliationAndThrowIfNotFound(avaliationId);
        currentAvaliation.ChangeRating(newRate);
    }

    public void RemoveRating(Guid avaliationId)
    {
        Avaliation avaliation = FindAvaliationAndThrowIfNotFound(avaliationId);
        _avaliations.Remove(avaliation);
    }
}