using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZitroShop.Shared.Infrastructure.Redis;

namespace ZitroShop.Shared.Registration;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IRedisConnectionFactory>(sp =>
        {
            var connectionString = configuration.GetConnectionString("Redis") 
                                   ?? throw new InvalidOperationException("Redis Config Not Found");
            return new RedisConnectionFactory(connectionString);
        });

        return services;
    }
}
