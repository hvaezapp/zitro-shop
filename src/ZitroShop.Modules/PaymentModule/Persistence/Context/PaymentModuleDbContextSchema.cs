namespace ZitroShop.Modules.PaymentModule.Persistence.Context;

public class PaymentModuleDbContextSchema
{
    public const string DefaultSchema = "PaymentModule";
    public const string DefaultDecimalColumnType = "decimal(18,6)";

    public static class Payment
    {
        public const string TableName = "Payments";
    }
}
