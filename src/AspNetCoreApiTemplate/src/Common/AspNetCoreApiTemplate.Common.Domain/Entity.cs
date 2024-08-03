namespace AspNetCoreApiTemplate.Common.Domain;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; } = default!;
}

public abstract class Entity : Entity<Guid>
{
    public IEnumerable<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();
    private readonly List<IDomainEvent> _domainEvents = [];

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
    
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}