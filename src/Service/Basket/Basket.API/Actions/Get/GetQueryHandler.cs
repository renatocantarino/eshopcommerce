namespace Basket.API.Actions.Get;

public record GetByUserName(string UserName) : IQuery<GetByUserNameResult>;
public record GetByUserNameResult(ShoppingCart ShoppingCart);

public class GetQueryHandler(IBasketRepository repository) : IQueryHandler<GetByUserName, GetByUserNameResult>
{
    public async Task<GetByUserNameResult> Handle(GetByUserName request, CancellationToken cancellationToken)
    {
        return new GetByUserNameResult(await repository.Get(request.UserName, cancellationToken));
    }
}