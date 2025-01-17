using Catalog.API.Products.Get;

namespace Catalog.API.Products.GetById;

public record GetProductByIdResult(Product product);
public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler : call {@Query}", query);
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product is null)
            throw new Exception($"Product {query.Id} not found");

        return new GetProductByIdResult(product);
    }
}