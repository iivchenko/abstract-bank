using AbstractBank.Domain.AccountAggregate;

namespace AbstractBank.Domain.CustomerAggregate;

public sealed class Customer : IAggregateRoot<Guid>
{
    private readonly List<Guid> _accounts = new List<Guid>();

    private Customer()
    {
    }

    public Customer(
        Guid id,
        CustomerName name, 
        CustomerSurname surname)
    {
        if (id == Guid.Empty)
        {
            throw new DomainException("Customer id can't be empty!");
        }

        Id = id;
        Name = name;
        Surname = surname;
    }

    public Guid Id { get; private set; }

    public CustomerName Name { get; private set; }

    public CustomerSurname Surname { get; private set; }

    public Guid? CurrentAccount { get; private set; }

    public IReadOnlyCollection<Guid> Accounts { get => _accounts; }

    public void AddAccount(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new DomainException("Account id can't be empty!");
        }

        if (_accounts.Contains(id))
        {
            throw new DomainException($"Account with id '{id}' already part of the customer.");
        }

        _accounts.Add(id);
    }

    public void SetCurrentAccount(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new DomainException("Account id can't be empty!");
        }

        if (!_accounts.Contains(id))
        {
            throw new DomainException($"Account with id '{id}' is not part of the customer.");
        }

        CurrentAccount = id;
    }
}