namespace Basket.API.Actions.Store;

public class StoreEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket",
          async (StoreCommand cmd, ISender sender) =>
          {
              var result = await sender.Send(cmd);
              return Results.Created($"/basket/{result.Document}", result);
          })
          .WithName("CreateBasket")
          .Produces<StoreCommand>(StatusCodes.Status201Created)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithSummary("Create Basket")
          .WithDescription("Create Basket");
    }
}