using FluentValidation;
using FluentValidation.AspNetCore;
using ZitroShop.Api.DTOs.Basket.Validator;
using ZitroShop.Api.DTOs.Payment.Validator;

namespace ZitroShop.Api.Registration;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<AddToBasketRequestDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<StartPaymentRequestDtoValidator>();
        return services;
    }
}
