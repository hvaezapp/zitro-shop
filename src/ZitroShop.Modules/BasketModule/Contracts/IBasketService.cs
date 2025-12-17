namespace ZitroShop.Modules.BasketModule.Contracts;

public interface IBasketService
{
    Task<bool> AddProduct(long userId, long productId, CancellationToken ct);
}
