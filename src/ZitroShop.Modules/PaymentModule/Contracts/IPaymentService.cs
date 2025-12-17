using ZitroShop.Modules.PaymentModule.DTOs;

namespace ZitroShop.Modules.PaymentModule.Contracts;

public interface IPaymentService
{
    Task<StartPaymentResultDto> Start(long userId ,CancellationToken ct);
    Task<PaymentStatusDto> GetStatus(long paymentId ,CancellationToken ct);
}
