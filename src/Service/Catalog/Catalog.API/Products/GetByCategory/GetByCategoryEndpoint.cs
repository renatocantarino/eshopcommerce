namespace Catalog.API.Products.GetByCategory;

public class GetByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}",
           async (string category, ISender sender) =>
           {
               var result = await sender.Send(new GetByCategoryQuery(category));
               return Results.Ok(result);
           })
           .WithName("GetProductByCategory")
           .Produces<GetByCategoryQuery>(StatusCodes.Status200OK)
           .ProducesProblem(StatusCodes.Status400BadRequest)
           .WithSummary("get product by category")
           .WithDescription("get product category");
    }
}