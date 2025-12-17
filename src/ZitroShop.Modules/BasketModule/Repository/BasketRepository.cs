using StackExchange.Redis;
using System.Text.Json;
using ZitroShop.Modules.BasketModule.Models;
using ZitroShop.Shared.Infrastructure.Redis;

namespace ZitroShop.Modules.BasketModule.Repository;

public class BasketRepository
{
    private readonly IDatabase _redis;
    private static readonly TimeSpan BasketTtl = TimeSpan.FromMinutes(10);

    public BasketRepository(IRedisConnectionFactory redisFactory)
    {
        _redis = redisFactory.GetDatabase();
    }

    public async Task<Basket?> GetAsync(long userId)
    {
        var data = await _redis.StringGetAsync(BasketKey(userId));
        return data.HasValue
            ? JsonSerializer.Deserialize<Basket>(data!)
            : null;
    }

    public async Task SaveAsync(Basket basket)
    {
        await _redis.StringSetAsync(
            BasketKey(basket.UserId),
            JsonSerializer.Serialize(basket),
            BasketTtl);
    }

    private static string BasketKey(long userId)
                => $"Basket:{userId}";

}
