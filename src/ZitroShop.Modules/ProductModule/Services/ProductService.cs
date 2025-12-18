using Microsoft.EntityFrameworkCore;
using ZitroShop.Modules.BasketModule.Contracts;
using ZitroShop.Modules.ProductModule.Contracts;
using ZitroShop.Modules.ProductModule.DTOs;
using ZitroShop.Modules.ProductModule.Entities;
using ZitroShop.Modules.ProductModule.Persistence.Context;

namespace ZitroShop.Modules.ProductModule.Services;

public class ProductService(ProductModuleDbContext dbContext, ILockService lockService) : IProductService
{
    private readonly ProductModuleDbContext _dbContext = dbContext;
    public readonly ILockService _lockService = lockService;

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

    public async Task<List<GetProductDto>> GetProducts(CancellationToken ct)
    {
        List<GetProductDto> list = [];
        var products = await _dbContext.Products.AsNoTracking().ToListAsync(ct);
        foreach (var product in products)
        {
            var isLocked = await _lockService.IsLocked(product.Id);
            list.Add(new GetProductDto(product.Id, product.Name, product.Price, product.IsSold, isLocked));
        }
        return list;
    }
}
