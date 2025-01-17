namespace Catalog.API.Products.GetByCategory;

public record GetByCategoryQueryResult(IReadOnlyCollection<Product> products);
public record GetByCategoryQuery(string Category) : IQuery<GetByCategoryQueryResult>;

public class GetByCategoryQueryHandler(IDocumentSession session, ILogger<GetByCategoryQueryHandler> logger) : IQueryHandler<GetByCategoryQuery, GetByCategoryQueryResult>
{
    public async Task<GetByCategoryQueryResult> Handle(GetByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(p => p.Categories.Contains(query.Category))
            .ToListAsync();

        return new GetByCategoryQueryResult(products);
    }
}