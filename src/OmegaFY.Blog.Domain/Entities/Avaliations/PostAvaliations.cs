using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.Entities.Avaliations;

public class PostAvaliations : Entity, IAggregateRoot<PostAvaliations>
{
    private readonly List<Avaliation> _avaliations;

    public IReadOnlyCollection<Avaliation> Avaliations => _avaliations.AsReadOnly();

    public double AverageRate { get; private set; }

    protected PostAvaliations() => _avaliations = new List<Avaliation>();

    public void RatePost(Avaliation avaliation)
    {
        if (avaliation is null)
            throw new DomainArgumentException("");

        _avaliations.Add(avaliation);

        CalculateAverageRate();
    }

    public void ChangeUserRating(Guid avaliationId, ReferenceId authorId, Stars rate)
    {
        Avaliation currentAvaliation = FindAvaliationAndThrowIfNotFound(avaliationId, authorId);
        currentAvaliation.ChangeRating(rate);

        CalculateAverageRate();
    }

    public void RemoveRating(ReferenceId avaliationId, ReferenceId authorId)
    {
        Avaliation avaliation = FindAvaliationAndThrowIfNotFound(avaliationId, authorId);
        _avaliations.Remove(avaliation);

        CalculateAverageRate();
    }

    internal void CalculateAverageRate() => AverageRate = _avaliations.Average(avaliation => (double)avaliation.Rate);

    internal Avaliation FindAvaliationAndThrowIfNotFound(ReferenceId avaliationId, ReferenceId authorId)
    {
        Avaliation avaliation = _avaliations.FirstOrDefault(avaliation => avaliation.Id == avaliationId && avaliation.AuthorId == authorId);

        if (avaliation is null)
            throw new NotFoundException();

        return avaliation;
    }
}