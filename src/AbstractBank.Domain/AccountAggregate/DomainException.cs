namespace AbstractBank.Domain.AccountAggregate;

public class DomainException : Exception
{
    public DomainException(string message)
         : base(message)
    {
    }
}
