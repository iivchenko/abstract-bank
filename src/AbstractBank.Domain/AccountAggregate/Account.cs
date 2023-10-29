namespace AbstractBank.Domain.AccountAggregate;

public sealed class Account : BaseEntity, IAggregateRoot<Guid>
{
    public Account(Guid id, Guid customerId)
    {
        if (id == Guid.Empty)
        {
            throw new DomainException("Account id can't be empty!");
        }

        if (customerId == Guid.Empty)
        {
            throw new DomainException("Customer id can't be empty!");
        }

        Id = id;
        CustomerId = customerId;
        Credits = 0;
    }

    public Guid Id { get; private set; }

    public Guid CustomerId { get; private set; }

    public decimal Credits { get; private set; }

    public void AddTransaction(decimal change)
    {
        if (change == 0)
        {
            throw new DomainException($"Account change should be different from zero!");
        }

        if (change < 0 && change > Credits)
        {
            throw new DomainException($"Not enough credicts to deduct from the account with id '{Id}'!");
        }

        var oldCredit = Credits;
        Credits += change;

        Publish(new AccountCreditsChangedDomainEvent(Id, oldCredit, Credits));
    }
}
