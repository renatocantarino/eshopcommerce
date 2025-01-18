namespace Basket.API.Actions.Get;

public record GetByUserName(string userName) : IQuery<GetByUserNameResult>;
public record GetByUserNameResult(ShoppingCart ShoppingCart);

public class GetQueryHandler : IQueryHandler<GetByUserName, GetByUserNameResult>
{
    public Task<GetByUserNameResult> Handle(GetByUserName request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}