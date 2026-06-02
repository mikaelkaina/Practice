namespace Practice.Domain;

public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.CreateVersion7();
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; protected set; } = DateTime.UtcNow;

    protected void SetUpdateAt()
        => UpdatedAt = DateTime.UtcNow;
}
