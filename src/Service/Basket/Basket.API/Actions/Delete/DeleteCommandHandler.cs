namespace Basket.API.Actions.Delete;

public record DeleteCommand(string Document) : ICommand<DeleteCommandResult>;
public record DeleteCommandResult(bool isSucess);

public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
{
    public DeleteCommandValidator()
    {
        RuleFor(x => x.Document).NotEmpty().WithMessage("{PropertyName} is required");
    }
}

public class DeleteCommandHandler(IBasketRepository repository) : ICommandHandler<DeleteCommand, DeleteCommandResult>
{
    public async Task<DeleteCommandResult> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        return new DeleteCommandResult(await repository.Delete(request.Document, cancellationToken));
    }
}