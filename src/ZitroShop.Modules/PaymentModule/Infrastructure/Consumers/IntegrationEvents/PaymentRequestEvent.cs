namespace ZitroShop.Modules.PaymentModule.Infrastructure.Consumers.IntegrationEvents;

public record PaymentRequestEvent(long PaymentId, long UserId);
