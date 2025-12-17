using Microsoft.EntityFrameworkCore;
using ZitroShop.Modules.ProductModule.Contracts;
using ZitroShop.Modules.ProductModule.Entities;
using ZitroShop.Modules.ProductModule.Persistence.Context;

namespace ZitroShop.Modules.ProductModule.Services;

public class ProductService(ProductModuleDbContext dbContext) : IProductService
{
    private readonly ProductModuleDbContext _dbContext = dbContext;

    public Task<Product?> GetById(long productId, CancellationToken ct)
    {
        return _dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId, ct);
    }

    public Task<bool> IsSold(long productId, CancellationToken ct)
    {
        return _dbContext.Products.AnyAsync(x => x.Id == productId && x.IsSold, ct);
    }

    public async Task SetAsSold(long productId, CancellationToken ct)
    {
        var product = await GetById(productId, ct);
        if (product is null)
            throw new InvalidOperationException($"Product not found.");

        product.Sold();

        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync(ct);
    }
}
