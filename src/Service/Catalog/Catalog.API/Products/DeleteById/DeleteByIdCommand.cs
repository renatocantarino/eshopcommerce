namespace Catalog.API.Products.DeleteById;

public record DeleteByIdCommand(Guid Id) : ICommand<DeleteByIdCommandResult>;
public record DeleteByIdCommandResult(bool IsSucess);

public class DeleteByIdCommandHandler(IDocumentSession session) : ICommandHandler<DeleteByIdCommand, DeleteByIdCommandResult>
{
    public async Task<DeleteByIdCommandResult> Handle(DeleteByIdCommand command, CancellationToken cancellationToken)
    {
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteByIdCommandResult(true);
    }
}