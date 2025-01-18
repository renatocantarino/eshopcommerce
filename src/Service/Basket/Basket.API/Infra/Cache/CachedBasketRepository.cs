namespace Basket.API.Infra.Cache
{
    public class CachedBasketRepository(IBasketRepository repository,
                                        IDistributedCache redis) : IBasketRepository
    {
        public async Task<bool> Delete(string document, CancellationToken cancellationToken = default)
        {
            var action = await repository.Delete(document, cancellationToken);
            await redis.RemoveAsync(document, cancellationToken);

            return action;
        }

        public async Task<ShoppingCart> Get(string document, CancellationToken cancellationToken = default)
        {
            var cached = await redis.GetStringAsync(document, cancellationToken);
            if (!string.IsNullOrEmpty(cached))
                return JsonSerializer.Deserialize<ShoppingCart>(cached);

            var basket = await repository.Get(document, cancellationToken);
            await redis.SetStringAsync(document, JsonSerializer.Serialize(basket), cancellationToken);
            return basket;
        }

        public async Task<ShoppingCart> Store(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            var stored = await repository.Store(basket, cancellationToken);
            await redis.SetStringAsync(basket.Document, JsonSerializer.Serialize(basket), cancellationToken);

            return stored;
        }
    }
}