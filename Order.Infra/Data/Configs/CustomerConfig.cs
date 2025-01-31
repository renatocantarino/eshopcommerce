using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Models;
using Order.Domain.VOs;

namespace Order.Infra.Data.Configs;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(
                customerId => customerId.Value,
                dbId => CustomerId.Of(dbId)
            );

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Document).IsRequired().HasMaxLength(15);
        builder.Property(c => c.Email).HasMaxLength(255);

        builder.HasIndex(c => c.Email).IsUnique();
        builder.HasIndex(c => c.Document).IsUnique();
    }
}