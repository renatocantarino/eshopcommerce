namespace Basket.API.Actions.Store;

public record StoreCommand(ShoppingCart Cart) : ICommand<StoreCommandResult>;

public record StoreCommandResult(string Name, bool isSucess);

public class StoreCommandValidator : AbstractValidator<StoreCommand>
{
    public StoreCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("{PropertyName} is required");
        RuleFor(x => x.Cart.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} is required");
    }
}

public class StoreCommandHandler(IBasketRepository repository) : ICommandHandler<StoreCommand, StoreCommandResult>
{
    public async Task<StoreCommandResult> Handle(StoreCommand cmd, CancellationToken cancellationToken)
    {
        //id baskt need id

        await repository.Store(cmd.Cart, cancellationToken);

        return new StoreCommandResult(cmd.Cart.UserName, true);
    }
}