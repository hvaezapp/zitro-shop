using ZitroShop.Modules.ProductModule.DTOs;
using ZitroShop.Modules.ProductModule.Entities;

namespace ZitroShop.Modules.ProductModule.Contracts;

public interface IProductService
{
    Task<Product?> GetById(long productId , CancellationToken ct);
    Task<bool> IsSold(long productId, CancellationToken ct);
    Task SetAsSold(long productId , CancellationToken ct);
    Task<List<GetProductDto>> GetProducts(CancellationToken ct);
}
