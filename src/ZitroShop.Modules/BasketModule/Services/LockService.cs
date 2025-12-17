using StackExchange.Redis;
using ZitroShop.Shared.Infrastructure.Redis;

namespace ZitroShop.Modules.BasketModule.Services;
public class LockService(IRedisConnectionFactory redisFactory)
{
    private readonly IDatabase _redis = redisFactory.GetDatabase();
    private static readonly TimeSpan LockTtl = TimeSpan.FromMinutes(10);

    private static string LockKey(long productId)
        => $"Lock:Product:{productId}";

    public async Task Lock(long productId)
    {
        var result = await _redis.StringSetAsync(
                            LockKey(productId),
                            "locked",
                            LockTtl,
                            When.NotExists);

        if (!result)
            throw new InvalidOperationException("Product is already locked.");
    }

    public async Task<bool> IsLocked(long productId)
        => await _redis.KeyExistsAsync(LockKey(productId));
}
