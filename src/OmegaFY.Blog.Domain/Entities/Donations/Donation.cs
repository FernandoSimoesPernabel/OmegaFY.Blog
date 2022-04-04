namespace OmegaFY.Blog.Domain.Entities.Donations;

public class Donation : Entity, IAggregateRoot<Donation>
{
    public Guid FromUserId { get; }

    public Guid ToUserId { get; }

    public decimal Ammount { get; set; }

    public Donation(Guid fromUserId, Guid toUserId, decimal ammount)
    {
        FromUserId = fromUserId;
        ToUserId = toUserId;
        Ammount = ammount;
    }
}