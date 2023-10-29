using AbstractBank.Domain.TransactionAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AbstractBank.Domain.AccountAggregate;

namespace AbstractBank.Infrastructure.TransactionAggregate;

public sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasOne<Account>();

        builder
            .Property(x => x.PreviousCredits);

        builder
           .Property(x => x.NewCredits);
    }
}