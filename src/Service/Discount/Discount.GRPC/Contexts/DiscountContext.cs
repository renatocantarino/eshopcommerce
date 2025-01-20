namespace Discount.GRPC.Contexts;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupons { get; set; }

    public DiscountContext(DbContextOptions<DiscountContext> opts) : base(opts)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>()
                    .HasData(new Coupon { Id = 1, ProductId = "c72b9046-9f0a-4e62-8091-324885f914fb", ProductName = "IPhone X", Description = "aplle phone", Amount = 150 },
                                  new Coupon { Id = 2, ProductId = "fab15cac-d53b-4085-9ed3-da014e03a856", ProductName = "IPhone XX", Description = "aplle phone X", Amount = 100 });
    }
}