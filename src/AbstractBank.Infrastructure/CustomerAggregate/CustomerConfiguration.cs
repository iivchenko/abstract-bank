using AbstractBank.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using static Azure.Core.HttpHeader;

namespace AbstractBank.Infrastructure.CustomerAggregate;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .OwnsOne(x => x.Name)
            .Property(x => x.Value)
                .HasColumnName(nameof(Customer.Name))
                .IsRequired()
                .HasMaxLength(CustomerName.MaxLength);

        builder
            .OwnsOne(x => x.Surname)
            .Property(x => x.Value)
                .HasColumnName(nameof(Customer.Surname))
                .IsRequired()
                .HasMaxLength(CustomerSurname.MaxLength);
    }
}
