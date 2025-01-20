using Discount.GRPC;

namespace Basket.API.Actions.Store;

public record StoreCommand(ShoppingCart Cart) : ICommand<StoreCommandResult>;

public record StoreCommandResult(string Document, bool isSucess);

public class StoreCommandValidator : AbstractValidator<StoreCommand>
{
    public StoreCommandValidator()
    {
        RuleFor(x => x.Cart)
            .NotNull()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.Cart.Document)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} is required");
    }
}

public class StoreCommandHandler(IBasketRepository repository, DiscountService.DiscountServiceClient grpcClient) : ICommandHandler<StoreCommand, StoreCommandResult>
{
    public async Task<StoreCommandResult> Handle(StoreCommand cmd, CancellationToken cancellationToken)
    {
        foreach (var item in cmd.Cart.Items)
        {
            var coupon = await grpcClient.GetDiscountAsync(new GetDiscountRequest { ProductName = item.Product.ToString() }, cancellationToken: cancellationToken);
            item.ApllyDiscount(coupon.Amount);
        }

        await repository.Store(cmd.Cart, cancellationToken);

        return new StoreCommandResult(cmd.Cart.Document, true);
    }
}