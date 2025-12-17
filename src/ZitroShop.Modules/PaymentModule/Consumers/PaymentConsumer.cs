using MassTransit;
using ZitroShop.Modules.BasketModule.Contracts;
using ZitroShop.Modules.PaymentModule.EventModels;
using ZitroShop.Modules.PaymentModule.Persistence.Context;
using ZitroShop.Modules.ProductModule.Contracts;

namespace ZitroShop.Modules.PaymentModule.Consumers;

public class PaymentConsumer : IConsumer<PaymentRequestEvent>
{
    private readonly PaymentModuleDbContext _context;
    private readonly IBasketRepository _basketRepository;
    private readonly IProductService _productService;
    private readonly ILockService _lockService;

    public PaymentConsumer(PaymentModuleDbContext context,
                           IBasketRepository basketRepository,
                           IProductService productService,
                           ILockService lockService)
    {
        _context = context;
        _basketRepository = basketRepository;
        _productService = productService;
        _lockService = lockService;
    }

    public async Task Consume(ConsumeContext<PaymentRequestEvent> context)
    {
        var payment = await _context.Payments.FindAsync(context.Message.PaymentId);
        if (payment is null)
            return;
        try
        {
            var basket = await _basketRepository.GetAsync(payment.UserId);
            if (basket is null)
                throw new InvalidOperationException("Basket not found.");

            foreach (var item in basket.Items)
            {
                await _productService.SetAsSold(item.ProductId, ct: default);
                await _lockService.Release(item.ProductId);
            }

            await _basketRepository.Delete(basket.UserId);

            payment.Succeed();
        }
        catch
        {
            payment.Failed();
        }
        finally
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }
    }
}
