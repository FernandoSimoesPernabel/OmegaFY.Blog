using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.Entities.Avaliations;

public class PostAvaliations : Entity, IAggregateRoot<PostAvaliations>
{
    private readonly List<Avaliation> _avaliations;

    public IReadOnlyCollection<Avaliation> Avaliations => _avaliations.AsReadOnly();

    public decimal AverageRate { get; private set; }

    protected PostAvaliations() => _avaliations = new List<Avaliation>();

    public void RatePost(Avaliation avaliation)
    {
        if (avaliation is null)
            throw new DomainArgumentException("");

        _avaliations.Add(avaliation);

        CalculateAverageRate();
    }

    public void ChangeUserRating(Guid avaliationId, Stars rate)
    {
        Avaliation currentAvaliation = FindAvaliationAndThrowIfNotFound(avaliationId);
        currentAvaliation.ChangeRating(rate);

        CalculateAverageRate();
    }

    public void RemoveRating(Guid avaliationId)
    {
        Avaliation avaliation = FindAvaliationAndThrowIfNotFound(avaliationId);
        _avaliations.Remove(avaliation);

        CalculateAverageRate();
    }

    internal void CalculateAverageRate() => AverageRate = _avaliations.Average(avaliation => (decimal)avaliation.Rate);

    internal Avaliation FindAvaliationAndThrowIfNotFound(Guid avaliationId)
    {
        Avaliation avaliation = _avaliations.FirstOrDefault(x => x.Id == avaliationId);

        if (avaliation is null)
            throw new NotFoundException();

        return avaliation;
    }
}