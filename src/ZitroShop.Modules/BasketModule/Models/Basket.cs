namespace ZitroShop.Modules.BasketModule.Models;

public class Basket
{
    public long UserId { get; set; }
    public List<BasketItem> Items { get; set; } = [];
}
