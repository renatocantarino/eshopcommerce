using Catalog.API.Entities;
using Kernel.CQRS;

namespace Catalog.API.Products;

public record CreateProductCommand(
    string name,
    string description,
    List<string> categories,
    decimal price,
    string imageUrl) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid id, DateTime createdAt);

public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product(command.name,
            command.description,
            command.categories,
            command.imageUrl,
            command.price);

        return new CreateProductResult(product.Id, product.CreatedAt);
    }
}