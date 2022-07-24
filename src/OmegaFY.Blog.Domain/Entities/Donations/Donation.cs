using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.Entities.Donations;

public class Donation : Entity, IAggregateRoot<Donation>
{
    public Guid FromUserId { get; }

    public Guid ToUserId { get; }

    public decimal Ammount { get; }

    public Donation(Guid fromUserId, Guid toUserId, decimal ammount)
    {
        if (fromUserId == Guid.Empty)
            throw new DomainArgumentException("");

        if (toUserId == Guid.Empty)
            throw new DomainArgumentException("");

        if (ammount <= 0)
            throw new DomainArgumentException("");

        FromUserId = fromUserId;
        ToUserId = toUserId;
        Ammount = ammount;
    }
}