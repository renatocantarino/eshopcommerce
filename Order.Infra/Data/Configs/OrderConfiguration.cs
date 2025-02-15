namespace Order.Infra.Data.Configs;

public class OrderConfiguration : IEntityTypeConfiguration<Domain.Models.Order>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Order> builder)
    {
        builder.HasKey(oi => oi.Id);

        builder.Property(oi => oi.Id).HasConversion(
                                   orderId => orderId.Value,
                                   dbId => OrderId.Of(dbId));

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(oi => oi.CustomerId)
            .IsRequired();

        builder.HasMany<OrderItem>()
            .WithOne()
            .HasForeignKey(oi => oi.OrderId);

        builder.ComplexProperty(oi => oi.OrderName, nameBuilder =>
        {
            nameBuilder.Property(name => name.Value)
            .HasColumnName(nameof(Domain.Models.Order.OrderName))
            .HasMaxLength(100)
            .IsRequired();
        });

        builder.ComplexProperty(
        o => o.ShippingAddress, addressBuilder =>
        {
            addressBuilder.Property(a => a.Country)
                .HasMaxLength(50);

            addressBuilder.Property(a => a.ZipCode)
                .HasMaxLength(5)
                .IsRequired();
        });

        builder.ComplexProperty(
          o => o.BillingAddress, addressBuilder =>
          {
              addressBuilder.Property(a => a.Country)
                  .HasMaxLength(50);

              addressBuilder.Property(a => a.ZipCode)
                  .HasMaxLength(5)
                  .IsRequired();
          });

        builder.ComplexProperty(
               o => o.Payment, paymentBuilder =>
               {
                   paymentBuilder.Property(p => p.CardName)
                       .HasMaxLength(50);

                   paymentBuilder.Property(p => p.CardNumber)
                       .HasMaxLength(24)
                       .IsRequired();

                   paymentBuilder.Property(p => p.Expiration)
                       .HasMaxLength(10);

                   paymentBuilder.Property(p => p.CVV)
                       .HasMaxLength(3);

                   paymentBuilder.Property(p => p.PaymentMethod);
               });

        builder.Property(o => o.Status)
            .HasDefaultValue(OrderStatus.Pending)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

        builder.Property(o => o.TotalPrice);
    }
}