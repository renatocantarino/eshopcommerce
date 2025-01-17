namespace Catalog.API.Products.Update;

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products",
            async (UpdateProductCommand request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateProduct")
            .Produces<UpdateProductCommand>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("update product")
            .WithDescription("update product");
    }
}