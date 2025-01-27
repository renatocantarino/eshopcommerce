﻿namespace Catalog.API.Products.Create;

public class CreateEndPoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async (CreateCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/products/{result.id}", result);
            })
            .WithName("CreateProduct")
            .Produces<CreateCommand>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("create product")
            .WithDescription("create product");
    }
}