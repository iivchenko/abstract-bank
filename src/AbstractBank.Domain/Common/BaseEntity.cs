namespace AbstractBank.Domain.Common;

public abstract class BaseEntity
{
    private readonly List<IDomainEvent> _events = new();

    public IReadOnlyCollection<IDomainEvent> Events => _events.AsReadOnly();

    public void Publish(IDomainEvent domainEvent)
    {
        _events.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _events.Clear();
    }
}