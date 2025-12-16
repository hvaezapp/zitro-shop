using ZitroShop.Modules.Product.Common;
using ZitroShop.Modules.Product.Enums;

namespace ZitroShop.Modules.Product.Entities;

public class Product : BaseDomainEntity
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public ProductStatus Status { get; private set; }
}


