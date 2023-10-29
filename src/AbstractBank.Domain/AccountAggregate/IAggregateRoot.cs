namespace AbstractBank.Domain.AccountAggregate;

public interface IAggregateRoot<TId>
{
    TId Id { get; }
}

