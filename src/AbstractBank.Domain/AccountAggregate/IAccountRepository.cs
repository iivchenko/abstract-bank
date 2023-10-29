namespace AbstractBank.Domain.AccountAggregate;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> FindByCustomerId(Guid customerId);

    Task<Account> Create(Account account);
}