using ZitroShop.Shared.Common;

namespace ZitroShop.Modules.PaymentModule.Entities;

public class Payment : BaseDomainEntity
{
    public long UserId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus Status { get; private set; }
}


#region enums
public enum PaymentStatus
{
    Processing = 0,
    Succeeded = 1,
    Failed = 2
}
#endregion
