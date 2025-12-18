using Microsoft.AspNetCore.Mvc;
using ZitroShop.Modules.ProductModule.Contracts;
using ZitroShop.Modules.ProductModule.DTOs;

namespace ZitroShop.Api.Controllers;

[Route("products")]
public class ProductController : BaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }


    [HttpGet]
    public async Task<ActionResult<List<GetProductDto>>> Get(CancellationToken ct)
    {
        var products = await _productService.GetProducts(ct);
        return Ok(products);
    }
}
