﻿namespace Basket.API.Actions.Get;

public class GetEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}",
           async (string userName, ISender sender) =>
           {
               var result = await sender.Send(new GetByUserName(userName));
               return Results.Ok(result);
           })
           .WithName("GetBasket")
           .Produces<GetByUserName>(StatusCodes.Status201Created)
           .ProducesProblem(StatusCodes.Status400BadRequest)
           .WithSummary("Get Basket")
           .WithDescription("Get Basket");
    }
}