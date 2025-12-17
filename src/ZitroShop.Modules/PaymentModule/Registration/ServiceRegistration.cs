using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ZitroShop.Modules.PaymentModule.Contracts;
using ZitroShop.Modules.PaymentModule.Infrastructure.Consumers;
using ZitroShop.Modules.PaymentModule.Persistence.Context;
using ZitroShop.Modules.PaymentModule.Services;
using ZitroShop.Shared.Registration;

namespace ZitroShop.Modules.PaymentModule.Registration;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterPaymentModuleServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region db
        services.AddDbContext<PaymentModuleDbContext>(options =>
             options.UseSqlServer(
                 configuration.GetConnectionString("SvcDbContext"),
                 sqlOptions =>
                 {
                     sqlOptions.MigrationsAssembly("ZitroShop.Modules");
                     sqlOptions.MigrationsHistoryTable(
                         "__EFMigrationsHistory",
                         PaymentModuleDbContextSchema.DefaultSchema);
                 }));

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

            configure.AddConsumers(Assembly.GetExecutingAssembly());

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

        #region ioc
        services.AddScoped<IPaymentService , PaymentService>();
        #endregion

        return services;
    }
}
