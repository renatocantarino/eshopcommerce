namespace Catalog.API.Products.Get;

public record GetProductsResult(IReadOnlyCollection<Product> Products);
public record GetQuery() : IQuery<GetProductsResult>;

public class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        return new GetProductsResult(products);
    }
}