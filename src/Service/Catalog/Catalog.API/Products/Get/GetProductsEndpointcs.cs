using Catalog.API.Products.Create;

namespace Catalog.API.Products.Get;

public class GetProductsEndpointcs : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products",
            async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                return Results.Ok(result);
            })
            .WithName("GetProducts")
            .Produces<GetProductsQuery>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("get products")
            .WithDescription("get products");
    }
}