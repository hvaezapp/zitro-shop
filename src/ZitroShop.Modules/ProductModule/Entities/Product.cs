using ZitroShop.Modules.ProductModule.Common;

namespace ZitroShop.Modules.ProductModule.Entities;

public class Product : BaseDomainEntity
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public bool IsSold { get; private set; }
}


