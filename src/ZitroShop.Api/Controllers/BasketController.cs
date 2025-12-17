using Microsoft.AspNetCore.Mvc;
using ZitroShop.Api.Contracts.Basket;
using ZitroShop.Modules.BasketModule.Contracts;

namespace ZitroShop.Api.Controllers;

[ApiController]
[Route("basket")]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }


    [HttpPost("add")]
    public async Task<ActionResult<bool>> Add(AddToBasketRequest request , CancellationToken ct)
    {
        var result = await _basketService.AddProduct(request.UserId , request.ProductId , ct);
        return Ok(result);
    }
}
