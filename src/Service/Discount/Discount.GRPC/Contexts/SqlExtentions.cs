namespace Discount.GRPC.Contexts;

public static class SqlExtentions
{
    public static IApplicationBuilder UseMigrateData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();

        dbContext.Database.MigrateAsync();

        return app;
    }
}