using ZitroShop.Modules.BasketModule.Models;

namespace ZitroShop.Modules.BasketModule.Contracts;

public interface IBasketRepository
{
    Task<Basket?> GetAsync(long userId);
    Task<bool> SaveAsync(Basket basket);
    Task Delete(long userId);
}
