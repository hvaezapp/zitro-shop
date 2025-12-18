using FluentValidation;
using ZitroShop.Api.Common;

namespace ZitroShop.Api.DTOs.Payment.Validator;


public class StartPaymentRequestDtoValidator : AbstractValidator<StartPaymentRequestDto>
{
    public StartPaymentRequestDtoValidator()
    {
        RuleFor(x => x.UserId)
               .NotEmpty()
               .WithMessage(ValidationMessages.UserIdRequired)
               .GreaterThan(0)
               .WithMessage(ValidationMessages.UserIdMustGreaterThanZero);

    }
}

