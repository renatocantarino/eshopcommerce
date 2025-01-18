namespace Basket.API.Actions.Delete;

public class DeleteEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}",

          async (string userName, ISender sender) =>
         {
             return Results.Ok(await sender.Send(new DeleteCommand(userName)));
         })
         .WithName("DeleteUserBasket")
         .Produces<DeleteCommand>(StatusCodes.Status201Created)
         .ProducesProblem(StatusCodes.Status400BadRequest)
         .ProducesProblem(StatusCodes.Status404NotFound)
         .WithSummary("Delete Basket")
         .WithDescription("Delete Basket");
    }
}