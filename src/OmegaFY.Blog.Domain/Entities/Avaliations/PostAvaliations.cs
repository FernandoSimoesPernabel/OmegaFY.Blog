using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.Entities.Avaliations;

public class PostAvaliations : Entity, IAggregateRoot<PostAvaliations>
{
    private readonly List<Avaliation> _avaliations;

    public IReadOnlyCollection<Avaliation> Avaliations => _avaliations.AsReadOnly();

    public double AverageRate { get; private set; }

    protected PostAvaliations() => _avaliations = new List<Avaliation>();

    public bool HasAuthorAlreadyRatedPost(ReferenceId authorId) => _avaliations.Any(share => share.AuthorId == authorId);

    public Avaliation FindAvaliationAndThrowIfNotFound(ReferenceId authorId)
    {
        Avaliation avaliation = _avaliations.FirstOrDefault(avaliation => avaliation.AuthorId == authorId);

        if (avaliation is null)
            throw new NotFoundException();

        return avaliation;
    }

    public void RatePost(ReferenceId authorId, Stars rate)
    {
        if (HasAuthorAlreadyRatedPost(authorId))
        {
            ChangeUserRating(authorId, rate);
            return;
        }

        _avaliations.Add(new Avaliation(Id, authorId, rate));

        CalculateAverageRate();
    }

    public void ChangeUserRating(ReferenceId authorId, Stars newRate)
    {
        Avaliation currentAvaliation = FindAvaliationAndThrowIfNotFound(authorId);
        currentAvaliation.ChangeRating(newRate);

        CalculateAverageRate();
    }

    public void RemoveRating(ReferenceId authorId)
    {
        Avaliation avaliation = FindAvaliationAndThrowIfNotFound(authorId);
        _avaliations.Remove(avaliation);

        CalculateAverageRate();
    }

    internal void CalculateAverageRate() => AverageRate = _avaliations.Any() ? _avaliations.Average(avaliation => (double)avaliation.Rate) : 0;
}