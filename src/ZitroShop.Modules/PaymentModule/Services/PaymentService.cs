using MassTransit;
using Microsoft.EntityFrameworkCore;
using ZitroShop.Modules.BasketModule.Repository;
using ZitroShop.Modules.PaymentModule.Contracts;
using ZitroShop.Modules.PaymentModule.DTOs;
using ZitroShop.Modules.PaymentModule.Entities;
using ZitroShop.Modules.PaymentModule.EventModels;
using ZitroShop.Modules.PaymentModule.Persistence.Context;

namespace ZitroShop.Modules.PaymentModule.Services;

public class PaymentService : IPaymentService
{
    private readonly PaymentModuleDbContext _context;
    private readonly IPublishEndpoint _publisher;
    private readonly BasketRepository _basketRepo;

    public PaymentService(PaymentModuleDbContext context,
                          IPublishEndpoint publisher,
                          BasketRepository basketRepo)
    {
        _context = context;
        _publisher = publisher;
        _basketRepo = basketRepo;
    }

    public async Task<StartPaymentResultDto> Start(long userId, CancellationToken ct)
    {
        try
        {
            var basket = await _basketRepo.GetAsync(userId);
            if (basket is null || !basket.Items.Any())
                throw new InvalidOperationException("Basket is empty.");

            var payment = Payment.Create(userId, basket.Items.Sum(s => s.Price));
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync(ct);

            // publish message to rabbit
            await _publisher.Publish(new PaymentRequestEvent(payment.Id, userId), ct);

            return new StartPaymentResultDto(payment.Id, payment.Status.ToString());
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Payment start failed.", ex);
        }
    }

    public async Task<PaymentStatusDto> GetStatus(long paymentId, CancellationToken ct)
    {
        var payment = await _context.Payments.FirstOrDefaultAsync(a => a.Id == paymentId, ct);

        if (payment is null)
            throw new InvalidOperationException("Payment not found.");

        return new PaymentStatusDto(payment.Id, payment.Status.ToString());
    }
}

