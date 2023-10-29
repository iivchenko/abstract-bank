namespace AbstractBank.Domain.TransactionAggregate;

public interface ITransactionRepository
{
    Task<Transaction> Create(Transaction transaction);
}