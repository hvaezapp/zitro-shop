namespace ZitroShop.Modules.ProductModule.Persistence.Context;

public class ProductDbContextSchema
{
    public const string DefaultSchema = "ProductModule";
    public const string DefaultDecimalColumnType = "decimal(18,6)";

    public static class Product
    {
        public const string TableName = "Products";
    }
}
