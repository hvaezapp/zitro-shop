using FluentValidation;
using ZitroShop.Api.DTOs.Basket;

namespace ZitroShop.Api.DTOs.Payment.Validator;


public class StartPaymentRequestDtoValidator : AbstractValidator<StartPaymentRequestDto>
{
    public StartPaymentRequestDtoValidator()
    {
        RuleFor(x => x.UserId)
             .GreaterThan(0)
             .WithMessage("UserId must be greater than zero");

    }
}

