namespace AbstractBank.Domain.AccountAggregate;

public interface IAccountRepository
{
    Task<Account> Create(Account account);
}