namespace ZitroShop.Modules.BasketModule.Contracts;

public interface IBasketService
{
    Task AddProduct(long userId, long productId, CancellationToken ct);
}
