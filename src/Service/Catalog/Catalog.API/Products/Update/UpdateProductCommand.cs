namespace Catalog.API.Products.Update;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    List<string> Categories,
    decimal Price,
    string ImageUrl) : ICommand<UpdateProductCommandResult>;
public record UpdateProductCommandResult(bool isSucess);

public class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductCommandResult>
{
    public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteByIdCommandHandler : call {@Command}", command);

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
            throw new NotFoundException($"product {command.Id} not found");

        product.Name = command.Name;
        product.Description = command.Description;
        product.Price = command.Price;
        product.ImageUrl = command.ImageUrl;
        product.Categories = command.Categories;

        session.Update(product);

        return new UpdateProductCommandResult(true);
    }
}