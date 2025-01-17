using Marten.Pagination;

namespace Catalog.API.Products.Get;

public record GetProductsResult(IEnumerable<Product> Products);
public record GetQuery(int? pageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

public class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .ToPagedListAsync(query.pageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

        return new GetProductsResult(products);
    }
}