using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.Entities.Avaliations;

public class PostAvaliations : Entity, IAggregateRoot<PostAvaliations>
{
    private readonly List<Avaliation> _avaliations;

    public IReadOnlyCollection<Avaliation> Avaliations => _avaliations.AsReadOnly();

    public decimal AverageRate { get; private set; }

    protected PostAvaliations() => _avaliations = new List<Avaliation>();

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

        AverageRate = _avaliations.Average(x => (decimal)x.Rate);
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