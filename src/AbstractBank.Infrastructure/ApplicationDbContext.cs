using System.Reflection;
using AbstractBank.Domain.AccountAggregate;
using AbstractBank.Domain.CustomerAggregate;
using AbstractBank.Domain.TransactionAggregate;
using Microsoft.EntityFrameworkCore;

namespace AbstractBank.Infrastructure;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Account> Accounts => Set<Account>();

    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
