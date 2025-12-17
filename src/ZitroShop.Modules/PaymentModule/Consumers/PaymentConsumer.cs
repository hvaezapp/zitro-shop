using MassTransit;
using ZitroShop.Modules.BasketModule.Repository;
using ZitroShop.Modules.BasketModule.Services;
using ZitroShop.Modules.PaymentModule.EventModels;
using ZitroShop.Modules.PaymentModule.Persistence.Context;
using ZitroShop.Modules.ProductModule.Contracts;

namespace ZitroShop.Modules.PaymentModule.Consumers;

public class PaymentConsumer : IConsumer<PaymentRequestEvent>
{
    private readonly PaymentModuleDbContext _context;
    private readonly BasketRepository _basketRepo;
    private readonly IProductService _productService;
    private readonly LockService _lockService;

    public PaymentConsumer(PaymentModuleDbContext context,
                           BasketRepository basketRepo, 
                           IProductService productService, 
                           LockService lockService)
    {
        _context = context;
        _basketRepo = basketRepo;
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
            var basket = await _basketRepo.GetAsync(payment.UserId);
            if (basket is null)
                throw new InvalidOperationException("Basket not found.");

            foreach (var item in basket.Items)
            {
                await _productService.SetAsSold(item.ProductId , ct:default);
            }  

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
