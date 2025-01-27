﻿namespace Catalog.API.Products.GetById;

public record GetProductByIdResult(Product product);
public record GetByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public class GetProductByIdQueryHandler(IDocumentSession session) : IQueryHandler<GetByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product is null)
            throw new NotFoundException($"Product {query.Id} not found");

        return new GetProductByIdResult(product);
    }
}