using AbstractBank.Domain.AccountAggregate;
using AbstractBank.Domain.TransactionAggregate;

namespace AbstractBank.Infrastructure.TransactionAggregate;

public sealed class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _context;

    public TransactionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Transaction> Create(Transaction transaction)
    {
        var entity = _context.Transactions.Add(transaction).Entity;

        return Task.FromResult(entity);
    }
}
