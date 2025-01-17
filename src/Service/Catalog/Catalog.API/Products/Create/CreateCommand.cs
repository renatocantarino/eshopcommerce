﻿using FluentValidation;

namespace Catalog.API.Products.Create;

public record CreateCommand(
    string Name,
    string Description,
    List<string> Categories,
    decimal Price,
    string ImageUrl) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid id, DateTime createdAt);

public class CreateProductHandler(IDocumentSession session, ILogger<CreateProductHandler> logger) : ICommandHandler<CreateCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("CreateProductHandler : call {@Command}", command);
        var product = command.Adapt<Product>();
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id, product.CreatedAt);
    }
}