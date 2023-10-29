using AbstractBank.Domain.AccountAggregate;

namespace AbstractBank.Infrastructure.AccountAggregate;

public sealed class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Account> Create(Account account)
    {
        var entity = _context.Accounts.Add(account).Entity;

        return Task.FromResult(entity);
    }
}
