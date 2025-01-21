namespace Order.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        return services;
    }

    public static WebApplicationBuilder UseApiServices(this WebApplicationBuilder builder)
    {
        return builder;
    }
}