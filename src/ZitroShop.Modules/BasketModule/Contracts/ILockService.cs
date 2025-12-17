namespace ZitroShop.Modules.BasketModule.Contracts;

public interface ILockService
{
    Task Lock(long productId);
    Task Release(long productId);
    Task<bool> IsLocked(long productId);
}
