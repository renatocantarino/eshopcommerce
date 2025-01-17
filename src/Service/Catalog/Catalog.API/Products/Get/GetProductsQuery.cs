namespace Catalog.API.Products.Get;

public record GetProductsResult(IReadOnlyCollection<Product> Products);
public record GetProductsQuery() : IQuery<GetProductsResult>;

public class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler : call {@Query}", query);
        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        return new GetProductsResult(products);
    }
}