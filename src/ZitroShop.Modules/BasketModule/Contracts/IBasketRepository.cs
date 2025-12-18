using ZitroShop.Modules.BasketModule.Models;

namespace ZitroShop.Modules.BasketModule.Contracts;

public interface IBasketRepository
{
    Task<Basket?> Get(long userId);
    Task<bool> Save(Basket basket);
    Task Delete(long userId);
}
