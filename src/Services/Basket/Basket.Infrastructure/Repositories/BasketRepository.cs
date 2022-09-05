using System.Text.Json;
using Basket.Domain.Abstractions.Repositories;
using Common.Primitives;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.Infrastructure.Repositories;

internal class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _redisCache;

    public BasketRepository(IDistributedCache cache)
    {
        Ensure.NotNull(cache, nameof(cache));
        _redisCache = cache;
    }

    public async Task DeteleAsync(Guid id)
    {
        await _redisCache.RemoveAsync(id.ToString());
    }

    public async Task<Domain.Entities.Basket?> GetBasketAsync(Guid id)
    {
        var basket = await _redisCache.GetStringAsync(id.ToString());

        if (string.IsNullOrEmpty(basket))
        {
            return null;
        }

        return JsonSerializer.Deserialize<Domain.Entities.Basket>(basket);

    }

    public async Task<Domain.Entities.Basket> UpdateBasketAsync(Domain.Entities.Basket basket)
    {
        Ensure.NotNull(basket, nameof(basket));

        await _redisCache.SetStringAsync(basket.Id.ToString(), JsonSerializer.Serialize(basket));
        return await GetBasketAsync(basket.Id);
    }
}
