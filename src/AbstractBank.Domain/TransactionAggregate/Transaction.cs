namespace AbstractBank.Domain.TransactionAggregate;

// Note:
// I personaly think Transaction should not be aggregate root
// but entity and part of an account. 
// The assignment asks to have separate services for 
// Accounts and Transactions. If I have more time I will 
// implement different services and current split for aggregates
// will help me in the future.
public sealed class Transaction : IAggregateRoot<Guid>
{
    public Transaction(Guid id, Guid accountId, decimal previousCredits, decimal newCredits)
    {
        if (id == Guid.Empty)
        {
            throw new DomainException("Transaction id can't be empty!");
        }

        if (accountId == Guid.Empty)
        {
            throw new DomainException("Transaction id can't be empty!");
        }

        if (previousCredits == newCredits)
        {
            throw new DomainException("Invalid transaction, previous and new credits can't be equal!");
        }

        Id = id;
        AccountId = accountId;
        PreviousCredits = previousCredits;
        NewCredits = newCredits;
    }

    public Guid Id { get; private set; }

    public Guid AccountId { get; private set; }
    public decimal PreviousCredits { get; private set; }
    public decimal NewCredits { get; private set; }
}
