using FluentValidation;
using ZitroShop.Api.Common;
namespace ZitroShop.Api.DTOs.Basket.Validator;

public class AddToBasketRequestDtoValidator : AbstractValidator<AddToBasketRequestDto>
{
    public AddToBasketRequestDtoValidator()
    {
        RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage(ValidationMessages.UserIdRequired)
                .GreaterThan(0)
                .WithMessage(ValidationMessages.UserIdMustGreaterThanZero);

        RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage(ValidationMessages.ProductIdRequired)
                .GreaterThan(0)
                .WithMessage(ValidationMessages.ProductIdMustGreaterThanZero);
    }
}
