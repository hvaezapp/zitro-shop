using StackExchange.Redis;

namespace ZitroShop.Shared.Infrastructure.Redis;

public interface IRedisConnectionFactory
{
    IDatabase GetDatabase();
}
