namespace AbstractBank.Domain.CustomerAggregate;

public sealed class Customer : IAggregateRoot<Guid>
{
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

    public void SetCurrentAccount(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new DomainException("Account id can't be empty!");
        }

        CurrentAccount = id;
    }
}