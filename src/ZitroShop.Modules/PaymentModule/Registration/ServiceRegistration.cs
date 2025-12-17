using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZitroShop.Modules.PaymentModule.Persistence.Context;

namespace ZitroShop.Modules.PaymentModule.Registration;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterPaymentModuleServices(this IServiceCollection services, IConfiguration configuration)
    {
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

        return services;
    }
}
