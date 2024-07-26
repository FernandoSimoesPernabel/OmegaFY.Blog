namespace OmegaFY.Blog.Domain.Entities;

public abstract class Entity : IEquatable<Entity>
{
    public ReferenceId Id { get; }

    protected Entity() => Id = Ulid.NewUlid().ToGuid();

    public override bool Equals(object obj)
    {
        if (obj is not Entity entity) return false;
        return CompareEquality(this, entity);
    }

    public bool Equals(Entity other) => CompareEquality(this, other);

    public override int GetHashCode() => HashCode.Combine(Id);

    public override string ToString() => $"{GetType().Name}_{Id}";

    public static bool operator ==(Entity entity1, Entity entity2) => CompareEquality(entity1, entity2);

    public static bool operator !=(Entity entity1, Entity entity2) => !(entity1 == entity2);

    public static implicit operator Guid(Entity entity) => entity?.Id ?? Guid.Empty;

    private static bool CompareEquality(Entity entity1, Entity entity2)
    {
        if (entity1 is null && entity2 is null) return true;

        if (entity1 is null || entity2 is null) return false;

        return entity1.Id == entity2.Id;
    }
}
