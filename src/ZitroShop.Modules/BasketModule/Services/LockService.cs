using StackExchange.Redis;
using ZitroShop.Modules.BasketModule.Contracts;
using ZitroShop.Shared.Infrastructure.Redis;

namespace ZitroShop.Modules.BasketModule.Services;
public class LockService(IRedisConnectionFactory redisFactory) : ILockService
{
    private readonly IDatabase _redis = redisFactory.GetDatabase();
    private static readonly TimeSpan LockTtl = TimeSpan.FromMinutes(10);

    private static string LockKey(long productId)
        => $"Lock:Product:{productId}";

    public async Task Lock(long productId)
    {
        var success = await _redis.StringSetAsync(
                            LockKey(productId),
                            "locked",
                            LockTtl,
                            When.NotExists);

        if (!success)
            throw new InvalidOperationException("Product is already locked.");
    }

    public async Task Release(long productId)
    {
        await _redis.KeyDeleteAsync(LockKey(productId));
    }

    public Task<bool> IsLocked(long productId)
        => _redis.KeyExistsAsync(LockKey(productId));
}
