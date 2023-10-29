namespace AbstractBank.Domain.TransactionAggregate;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> FindByAccountId(Guid accountId);
    Task<Transaction> Create(Transaction transaction);
}