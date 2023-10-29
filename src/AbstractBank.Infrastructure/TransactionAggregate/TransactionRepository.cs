using AbstractBank.Domain.TransactionAggregate;

namespace AbstractBank.Infrastructure.TransactionAggregate;

public sealed class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _context;

    public TransactionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Transaction>> FindByAccountId(Guid accountId)
    {
        var entities = _context.Transactions.Where(x => x.AccountId == accountId);

        return Task.FromResult(entities.AsEnumerable());
    }

    public Task<Transaction> Create(Transaction transaction)
    {
        var entity = _context.Transactions.Add(transaction).Entity;

        return Task.FromResult(entity);
    }
}
