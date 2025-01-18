namespace Basket.API.Infra.Data;

public class BasketRepository(IDocumentSession session) : IBasketRepository
{
    public async Task<bool> Delete(string name, CancellationToken cancellationToken = default)
    {
        session.Delete<ShoppingCart>(name);
        await session.SaveChangesAsync();
        return true;
    }

    public async Task<ShoppingCart> Get(string name, CancellationToken cancellationToken = default)
    {
        var basket = await session.LoadAsync<ShoppingCart>(name, cancellationToken);
        return basket is null ? throw new BasketNotFoundException(name) : basket;
    }

    public async Task<ShoppingCart> Store(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        session.Store(basket);
        await session.SaveChangesAsync();
        return basket;
    }
}