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

public class StoreCommandHandler : ICommandHandler<StoreCommand, StoreCommandResult>
{
    public async Task<StoreCommandResult> Handle(StoreCommand cmd, CancellationToken cancellationToken)
    {
        var cart = cmd.Cart;
        return new StoreCommandResult("bsk-name", true);
    }
}