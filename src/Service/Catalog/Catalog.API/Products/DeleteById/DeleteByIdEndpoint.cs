namespace Catalog.API.Products.DeleteById;

public class DeleteByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{productId}",
            async (Guid productId, ISender sender) =>
            {
                var result = await sender.Send(new DeleteByIdCommand(productId));
                return Results.Ok(result);
            })
            .WithName("DeleteProductById")
            .Produces<DeleteByIdCommand>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("delete product by Id")
            .WithDescription("delete product Id");
    }
}