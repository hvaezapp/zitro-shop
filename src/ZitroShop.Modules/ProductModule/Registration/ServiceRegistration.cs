using Microsoft.Extensions.DependencyInjection;
using ZitroShop.Modules.ProductModule.Contracts;
using ZitroShop.Modules.ProductModule.Services;

namespace ZitroShop.Modules.ProductModule.Registration;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterProductModuleServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
