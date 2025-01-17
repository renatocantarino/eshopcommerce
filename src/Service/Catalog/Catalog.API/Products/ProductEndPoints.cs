using Carter;
using MediatR;

namespace Catalog.API.Products;

public class ProductEndPoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async (CreateProductCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/products/{result.id}", result);
            })
            .WithName("CreateProduct")
            .Produces<CreateProductCommand>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("create product")
            .WithDescription("create product");
    }
}