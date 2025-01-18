namespace Basket.API.Infra.Data;

public class BasketRepository(IDocumentSession session) : IBasketRepository
{
    public async Task<bool> Delete(string document, CancellationToken cancellationToken = default)
    {
        session.Delete<ShoppingCart>(document);
        await session.SaveChangesAsync();
        return true;
    }

    public async Task<ShoppingCart> Get(string document, CancellationToken cancellationToken = default)
    {
        var basket = await session.LoadAsync<ShoppingCart>(document, cancellationToken);
        return basket is null ? throw new BasketNotFoundException(document) : basket;
    }

    public async Task<ShoppingCart> Store(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        session.Store(basket);
        await session.SaveChangesAsync();
        return basket;
    }
}