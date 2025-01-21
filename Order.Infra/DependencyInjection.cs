using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Order.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("OrderDb");

        //services.AddDbContext<OrderContext>(options =>
        //    options.UseSqlServer(configuration.GetConnectionString("OrderConnection")));

        //services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}