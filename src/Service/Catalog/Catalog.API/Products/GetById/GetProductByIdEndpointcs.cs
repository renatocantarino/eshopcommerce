using Catalog.API.Products.Get;

namespace Catalog.API.Products.GetById;

public class GetProductByIdEndpointcs : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{productId}",
            async (Guid productId, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(productId));
                return Results.Ok(result);
            })
            .WithName("GetProduct")
            .Produces<GetProductByIdQuery>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("get product by id")
            .WithDescription("get product by id");
    }
}