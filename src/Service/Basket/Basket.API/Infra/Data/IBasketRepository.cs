namespace Basket.API.Infra.Data;

public interface IBasketRepository
{
    Task<ShoppingCart> Get(string document, CancellationToken cancellationToken = default);

    Task<ShoppingCart> Store(ShoppingCart basket, CancellationToken cancellationToken = default);

    Task<bool> Delete(string document, CancellationToken cancellationToken = default);
}