namespace ZitroShop.Modules.BasketModule.Models;

public class BasketItem
{
    public long ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
}
