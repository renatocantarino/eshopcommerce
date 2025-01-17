﻿namespace Catalog.API.Products.DeleteById;

public record DeleteByIdCommand(Guid Id) : IQuery<DeleteByIdCommandResult>;
public record DeleteByIdCommandResult(bool IsSucess);

public class DeleteByIdCommandHandler(IDocumentSession session, ILogger<DeleteByIdCommandHandler> logger) : IQueryHandler<DeleteByIdCommand, DeleteByIdCommandResult>
{
    public async Task<DeleteByIdCommandResult> Handle(DeleteByIdCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteByIdCommandHandler : call {@Command}", command);

        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteByIdCommandResult(true);
    }
}