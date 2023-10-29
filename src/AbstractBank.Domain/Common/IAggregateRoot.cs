namespace AbstractBank.Domain.Common;

public interface IAggregateRoot<TId>
{
    TId Id { get; }
}
