using Microsoft.Extensions.DependencyInjection;
using ZitroShop.Modules.BasketModule.Contracts;
using ZitroShop.Modules.BasketModule.Repository;
using ZitroShop.Modules.BasketModule.Services;

namespace ZitroShop.Modules.BasketModule.Registration;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterBasketModuleServices(this IServiceCollection services)
    {
        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<LockService>();
        services.AddScoped<BasketRepository>();

        return services;
    }
}
