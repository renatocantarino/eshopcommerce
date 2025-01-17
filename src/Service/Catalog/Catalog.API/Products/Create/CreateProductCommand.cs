using Catalog.API.Entities;
using Kernel.CQRS;
using Mapster;
using Marten;

namespace Catalog.API.Products.Create;

public record CreateProductCommand(
    string Name,
    string Description,
    List<string> Categories,
    decimal Price,
    string ImageUrl) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid id, DateTime createdAt);

public class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = command.Adapt<Product>();
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id, product.CreatedAt);
    }
}