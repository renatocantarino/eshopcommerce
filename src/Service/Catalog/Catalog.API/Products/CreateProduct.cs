using Catalog.API.Entities;
using Kernel.CQRS;
using Mapster;

namespace Catalog.API.Products;

public record CreateProductCommand(
    string Name,
    string Description,
    List<string> Categories,
    decimal Price,
    string ImageUrl) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid id, DateTime createdAt);

public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = command.Adapt<Product>();

        //var product = new Product(command.name,
        //    command.description,
        //    command.categories,
        //    command.imageUrl,
        //    command.price);

        return new CreateProductResult(product.Id, product.CreatedAt);
    }
}