namespace AbstractBank.Application.Common;

public interface IUnitOfWork
{
    Task SaveChanges();
}
