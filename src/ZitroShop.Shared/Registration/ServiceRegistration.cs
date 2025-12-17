using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZitroShop.Shared.Infrastructure.Redis;

namespace ZitroShop.Shared.Registration;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region redis
        services.AddSingleton<IRedisConnectionFactory>(sp =>
        {
            var connectionString = configuration.GetConnectionString("Redis")
                                   ?? throw new InvalidOperationException("Redis Config Not Found");
            return new RedisConnectionFactory(connectionString);
        });
        #endregion

        #region rabbitMq
        services.AddMassTransit(configure =>
        {
            var host = configuration["RabbitMqSetting:Host"]
                            ?? throw new InvalidOperationException("RabbitMq Host Not Found");

            var username = configuration["RabbitMqSetting:UserName"]
                            ?? throw new InvalidOperationException("RabbitMq UserName Not Found");

            var password = configuration["RabbitMqSetting:Password"]
                            ?? throw new InvalidOperationException("RabbitMq Password Not Found");

            configure.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(host, hostConfigure =>
                {
                    hostConfigure.Username(username);
                    hostConfigure.Password(password);
                });

                cfg.ConfigureEndpoints(context);
            });
        });
        #endregion

        return services;
    }


}


