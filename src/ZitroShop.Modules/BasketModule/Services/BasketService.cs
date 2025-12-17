using ZitroShop.Modules.BasketModule.Contracts;
using ZitroShop.Modules.BasketModule.Models;
using ZitroShop.Modules.BasketModule.Repository;
using ZitroShop.Modules.ProductModule.Contracts;

namespace ZitroShop.Modules.BasketModule.Services;

public class BasketService : IBasketService
{
    private readonly BasketRepository _basketRepository;
    private readonly LockService _lockService;
    private readonly IProductService _productService;

    public BasketService(BasketRepository basketRepository,
                         LockService lockService,
                         IProductService productService)
    {
        _basketRepository = basketRepository;
        _lockService = lockService;
        _productService = productService;
    }

    public async Task<bool> AddProduct(long userId, long productId, CancellationToken ct)
    {
        if (await _productService.IsSold(productId, ct))
            throw new InvalidOperationException("Product is solded.");

        await _lockService.Lock(productId);

        var product = await _productService.GetById(productId, ct)
                     ?? throw new InvalidOperationException("Product not found.");

        var basket = await _basketRepository.GetAsync(userId)
                     ?? new Basket { UserId = userId };

        basket.Items.Add(new BasketItem
        {
            ProductId = product.Id,
            ProductName = product.Name,
            Price = product.Price
        });

        return await _basketRepository.SaveAsync(basket);
    }
}
