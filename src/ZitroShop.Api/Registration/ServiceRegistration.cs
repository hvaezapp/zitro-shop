using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace ZitroShop.Api.Registration;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
