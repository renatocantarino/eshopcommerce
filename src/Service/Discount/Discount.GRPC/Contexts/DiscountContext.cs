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
                    .HasData(new Coupon { Id = 1, ProductName = "IPhone X", Description = "aplle phone", Amount = 150 },
                                  new Coupon { Id = 2, ProductName = "IPhone XX", Description = "aplle phone X", Amount = 100 });
    }
}