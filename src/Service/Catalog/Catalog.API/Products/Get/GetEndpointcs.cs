using Catalog.API.Products.Create;

namespace Catalog.API.Products.Get;

public class GetEndpointcs : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products",
            async (ISender sender) =>
            {
                var result = await sender.Send(new GetQuery());

                return Results.Ok(result);
            })
            .WithName("GetProducts")
            .Produces<GetQuery>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("get products")
            .WithDescription("get products");
    }
}