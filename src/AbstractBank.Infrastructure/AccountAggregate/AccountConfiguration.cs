using AbstractBank.Domain.AccountAggregate;
using AbstractBank.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbstractBank.Infrastructure.AccountAggregate;

public sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId);

        builder
            .Property(x => x.Credits);
    }
}