namespace Basket.API.Infra.Data;

public interface IBasketRepository
{
    Task<ShoppingCart> Get(string name, CancellationToken cancellationToken = default);

    Task<ShoppingCart> Store(ShoppingCart basket, CancellationToken cancellationToken = default);

    Task<bool> Delete(string name, CancellationToken cancellationToken = default);
}