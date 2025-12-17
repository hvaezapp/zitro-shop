using Microsoft.EntityFrameworkCore;
using ZitroShop.Modules.ProductModule.Contracts;
using ZitroShop.Modules.ProductModule.Entities;
using ZitroShop.Modules.ProductModule.Persistence.Context;

namespace ZitroShop.Modules.ProductModule.Services;

public class ProductService(ProductModuleDbContext dbContext) : IProductService
{
    private readonly ProductModuleDbContext _dbContext = dbContext;

    public async Task<Product?> GetById(long productId, CancellationToken ct)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId, ct);
    }

    public async Task<bool> IsSold(long productId, CancellationToken ct)
    {
        return await _dbContext.Products.AnyAsync(x => x.Id == productId && x.IsSold, ct);
    }
}
