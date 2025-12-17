namespace ZitroShop.Api.Contracts.Basket;

public record AddToBasketRequest(
    long UserId,
    long ProductId);

