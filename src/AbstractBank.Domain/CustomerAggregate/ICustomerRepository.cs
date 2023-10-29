namespace AbstractBank.Domain.CustomerAggregate;

public interface ICustomerRepository
{
    Task<Customer?> FindById(Guid id);
}
