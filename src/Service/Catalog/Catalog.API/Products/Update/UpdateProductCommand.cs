namespace Catalog.API.Products.Update;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    List<string> Categories,
    decimal Price,
    string ImageUrl) : ICommand<UpdateProductCommandResult>;
public record UpdateProductCommandResult(bool isSucess);

public class UpdateProductCommandHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductCommandResult>
{
    public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
            throw new NotFoundException($"product {command.Id} not found");

        product.Name = command.Name;
        product.Description = command.Description;
        product.Price = command.Price;
        product.ImageUrl = command.ImageUrl;
        product.Categories = command.Categories;
        product.SetUpdatedAt();

        session.Update(product);

        return new UpdateProductCommandResult(true);
    }
}