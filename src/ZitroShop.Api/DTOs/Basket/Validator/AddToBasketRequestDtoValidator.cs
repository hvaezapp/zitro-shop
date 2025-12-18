using FluentValidation;
namespace ZitroShop.Api.DTOs.Basket.Validator;

public class AddToBasketRequestDtoValidator : AbstractValidator<AddToBasketRequestDto>
{
    public AddToBasketRequestDtoValidator()
    {
        RuleFor(x => x.UserId)
             .GreaterThan(0)
             .WithMessage("UserId must be greater than zero");

        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId must be greater than zero");
    }
}
