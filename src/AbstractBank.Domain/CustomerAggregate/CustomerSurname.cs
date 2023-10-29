using AbstractBank.Domain.AccountAggregate;

namespace AbstractBank.Domain.CustomerAggregate;

public sealed record CustomerSurname
{
    public static readonly int MaxLength = 25;

    public CustomerSurname(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException("Customer surname can't be null or empty!");
        }

        if (value.Length > MaxLength)
        {
            throw new DomainException($"Customer surname '{value}' with length '{value.Length}' exceeds maximum allowed length of '{MaxLength}' characters.!");
        }

        Value = value;
    }

    public string Value { get; private set; }

    public static implicit operator string(CustomerSurname name)
    {
        return name.Value;
    }

    public static implicit operator CustomerSurname(string name)
    {
        return new CustomerSurname(name);
    }
}