using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Domain.Entities.Donations;

public class Donation : Entity, IAggregateRoot<Donation>
{
    public ReferenceId FromUserId { get; }

    public ReferenceId ToUserId { get; }

    public decimal Ammount { get; }

    public Donation(ReferenceId fromUserId, ReferenceId toUserId, decimal ammount)
    {
        if (ammount <= 0)
            throw new DomainArgumentException("");

        FromUserId = fromUserId;
        ToUserId = toUserId;
        Ammount = ammount;
    }
}