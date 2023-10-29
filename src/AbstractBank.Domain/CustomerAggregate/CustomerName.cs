using AbstractBank.Domain.AccountAggregate;

namespace AbstractBank.Domain.CustomerAggregate;

public sealed record CustomerName
{
    public static readonly int MaxLength = 25;

    public CustomerName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException("Customer name can't be null or empty!");
        }

        if (value.Length > MaxLength)
        {
            throw new DomainException($"Customer name '{value}' with length '{value.Length}' exceeds maximum allowed length of '{MaxLength}' characters.!");
        }

        Value = value;
    }

    public string Value { get; private set; }

    public static implicit operator string(CustomerName name)
    {
        return name.Value;
    }

    public static implicit operator CustomerName(string name)
    {
        return new CustomerName(name);
    }
}
