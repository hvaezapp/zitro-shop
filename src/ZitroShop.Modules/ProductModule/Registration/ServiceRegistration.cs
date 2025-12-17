using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZitroShop.Modules.ProductModule.Contracts;
using ZitroShop.Modules.ProductModule.Persistence.Context;
using ZitroShop.Modules.ProductModule.Services;

namespace ZitroShop.Modules.ProductModule.Registration;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterProductModuleServices(this IServiceCollection services , IConfiguration configuration)
    {

       services.AddDbContext<ProductModuleDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("SvcDbContext"),
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("ZitroShop.Modules");
                    sqlOptions.MigrationsHistoryTable(
                        "__EFMigrationsHistory",
                        ProductModuleDbContextSchema.DefaultSchema);
                }));

        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
