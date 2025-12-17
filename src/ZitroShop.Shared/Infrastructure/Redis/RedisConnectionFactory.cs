using StackExchange.Redis;

namespace ZitroShop.Shared.Infrastructure.Redis;

public class RedisConnectionFactory : IRedisConnectionFactory
{
    private readonly Lazy<ConnectionMultiplexer> _lazyConnection;

    public RedisConnectionFactory(string connectionString)
    {
        _lazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(connectionString));
    }

    public IDatabase GetDatabase()
    {
        return _lazyConnection.Value.GetDatabase(); 
    }
}
